using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace mjm.nethelpers.tests
{
    public class TransactionManagerShould
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TransactionManagerShould(ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task run_steps_in_order()
        {
            var list = new List<int>();
            var manager = new TransactionalManager();
            manager.AddTransaction(() =>
            {
                list.Add(1);
                return Task.CompletedTask;
            }, () =>
            {
                list.Remove(1);
                return Task.CompletedTask;
            });
            
            manager.AddTransaction(() =>
            {
                list.Add(2);
                return Task.CompletedTask;
            }, () =>
            {
                list.Remove(2);
                return Task.CompletedTask;
            });

            await manager.Execute();
            list[0].ShouldBe(1);
            list[1].ShouldBe(2);
        }
        
        [Fact]
        public async Task run_steps_in_order_rollback_order_if_fail()
        {
            var list = new List<int>();
            var listFallBack = new List<int>();
            var manager = new TransactionalManager();
            manager.AddTransaction(() =>
            {
                list.Add(1);
                return Task.CompletedTask;
            }, () =>
            {
                list.Remove(1);
                listFallBack.Add(1);
                return Task.CompletedTask;
            });
            
            manager.AddTransaction(() =>
            {
                list.Add(2);
                return Task.CompletedTask;
            }, () =>
            {
                list.Remove(2);
                listFallBack.Add(2);
                return Task.CompletedTask;
            });
            
            manager.AddTransaction(() =>
            {
                throw new Exception();
            }, () =>
            {
                list.Remove(2);
                return Task.CompletedTask;
            });

            await manager.Execute();
            list.Count.ShouldBe(0);
            listFallBack[0].ShouldBe(2);
            listFallBack[1].ShouldBe(1);
        }
    }
}