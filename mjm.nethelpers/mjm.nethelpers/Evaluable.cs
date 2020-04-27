using System;
using System.Threading.Tasks;

namespace mjm.nethelpers
{
    /// <summary>
    /// Concatenate 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Evaluable<T> 
    {
        public T Value { get; }

        public Evaluable(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Evaluate 
        /// </summary>
        /// <param name="evaluate"></param>
        /// <returns></returns>
        public Concatenable<T> If(Func<T, bool> evaluate)
        {
            var res = evaluate.Invoke(this.Value);
            return new Concatenable<T>(this.Value,res);
        }
    }

    public class Concatenable<T>
    {
        public T Value { get; private set; }
        public bool Res { get; }

        public Concatenable(T value, bool res)
        {
            this.Value = value;
            this.Res = res;
        }
        
        public void Then(Action action)
        {
            if (!this.Res) return;
            action.Invoke();
        }
        
        public TRes Then<TRes>(Func<TRes> func)
        {
            return !this.Res ? default : func.Invoke();
        }

        public T Then(T newValue)
        {
            if (this.Res)
                this.Value = newValue;

            return this.Value;
        }
    }
}