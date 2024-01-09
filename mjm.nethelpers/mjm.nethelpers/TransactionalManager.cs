using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mjm.nethelpers.Extensions;

namespace mjm.nethelpers
{
    /// <summary>
    /// Helper to manage transactions
    /// </summary>
    public class TransactionalManager
    {
        private readonly List<(Func<Task> transaction, Func<Task> rollback)> _transactions =
            new List<(Func<Task> transaction, Func<Task> rollback)>();

        /// <summary>
        /// Add a transaction step with fallback action
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="rollback"></param>
        public void AddTransaction(Func<Task> transaction, Func<Task> rollback)
        {
            this._transactions.Add((transaction, rollback));
        }

        /// <summary>
        /// Run the transactions steps
        /// </summary>
        /// <returns></returns>
        public async Task<TransactionResult> Execute()
        {
            var result = new TransactionResult();
            
            for (var i = 0; i < this._transactions.Count; i++)
            {
                try
                {
                    await this._transactions[i].transaction();
                }
                catch (Exception e)
                {
                    result.TransactionException = new TransactionException(i,e);
                    
                    // throw for fallback fail
                    for (var j = i-1; j >= 0; j--)
                    {
                        try
                        {
                            await this._transactions[j].rollback();
                        }
                        catch (Exception exception)
                        {
                            result.RollBackException = new TransactionException(j,e);
                            return result;
                        }
                    }

                    return result;
                }
            }

            return result;
        }
    }

    public class TransactionResult
    {
        public bool Result => this.TransactionException.IsNull() && this.RollBackException.IsNull();
        public TransactionException TransactionException { get; set; }
        public TransactionException RollBackException { get; set; }
        
    }

    public class TransactionException : Exception
    {
        public int Step { get; }

        public TransactionException(int step, Exception exception) : base($"Step {step} has failed. See InnerException [{typeof(Exception)}] for details.",exception)
        {
            this.Step = step;
        }

        /// <summary>
        /// Recover a detailed error message
        /// </summary>
        /// <returns></returns>
        public string GetLogMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Step {this.Step} has failed. Inner Exception message:");
            stringBuilder.AppendLine($"{this.InnerException?.Message}");
            stringBuilder.AppendLine(this.InnerException?.StackTrace);
            return stringBuilder.ToString();
        }
    }

}