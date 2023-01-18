using System;
using System.Threading.Tasks;
using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class ObjectExtensionShould
    {
        [Fact]
        public void ConcatenatePublicPropertiesToString()
        {
            var test = new TestDto();
            var tostring = test.PropertiesToString();
            tostring.ShouldBe("A: AVal -- B: 1");
        }

        [Fact]
        public void CheckForNull()
        {
            string obj = null;
            obj.IsNull().ShouldBeTrue();
            obj.IsNotNull().ShouldBeFalse();
        }
        
        [Fact]
        public void SerializeToJson()
        {
            var obj = new
            {
                Name = "Mark Jack",
                Surname = "Milian"
            };
            var serialized = obj.ToJson();
            serialized.ShouldBe(@"{""Name"":""Mark Jack"",""Surname"":""Milian""}");
        }

        [Fact]
        public void CastToT()
        {
            object obj = new TestDto();
            obj.To<TestDto>().GetType().ShouldBe(typeof(TestDto));
        }
        
        [Fact]
        public void ThrowForWrongCast()
        {
            object obj = new TestDto();

            Action action = () => { obj.To<string>(); };

            action.ShouldThrow<InvalidCastException>();
            
        }
        
        [Fact]
        public void RunIfConditionIsTrue()
        {
            var runned = false;
            string obj = "test";
            obj.If(s => s == "test",() => runned = true);
            runned.ShouldBeTrue();
        }
        
        [Fact]
        public async Task RunTaskIfConditionIsTrue()
        {
            var runned = false;
            string obj = "test";
            await obj.If(s => s == "test", async () =>
            {
                await Task.Delay(1);
                runned = true;
            });
            runned.ShouldBeTrue();
        }
    }

    class TestDto
    {
        public string A { get; set; }
        public int B { get; set; }

        private string no;

        public TestDto()
        {
            this.A = "AVal";
            this.B = 1;
            this.no = "no";
        }
    }
}