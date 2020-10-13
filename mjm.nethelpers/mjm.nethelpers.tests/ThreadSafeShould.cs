using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace mjm.nethelpers.tests
{
    public class ThreadSafeShould
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ThreadSafeShould(ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }

        //[Fact]
        public void throw_when_not_used_for_multiaccess()
        {
            Should.Throw<AggregateException>(() =>
            {
                var rand = new Random(Guid.NewGuid().GetHashCode());
                var list = new List<string>();
                Parallel.For(0, 10000, i =>
                {
                    var r = rand.Next();
                    var isOdd = r % 2 == 0;
                    if (isOdd)
                        this.ReadList(list);
                    else
                        this.AddList(list);
                });
                _testOutputHelper.WriteLine(list.Count().ToString());
            });
            
        }
        
        [Fact]
        public void not_throw_when_used_for_multiaccess()
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var tsList = ThreadSafe.On(new List<string>());
            Parallel.For(0, 10000, i =>
            {
                var r = rand.Next();
                var isOdd = r % 2 == 0;
                if (isOdd)
                    tsList.Use(this.ReadList);
                else
                    tsList.Use(this.AddList);
            });
            _testOutputHelper.WriteLine(tsList.Use(list => list.Count).ToString());
            // or
            tsList.Use(list => _testOutputHelper.WriteLine(list.Count.ToString()));

        }


        private void ReadList(List<string> list)
        {
            _testOutputHelper.WriteLine(list.Any() ? list.Last() : "no data");
        }
        
        private void AddList(List<string> list)
        {
            var newElement = Guid.NewGuid().ToString();
            _testOutputHelper.WriteLine($"Addding {newElement}");
            list.Add(newElement);
        }
    }
    
    
}