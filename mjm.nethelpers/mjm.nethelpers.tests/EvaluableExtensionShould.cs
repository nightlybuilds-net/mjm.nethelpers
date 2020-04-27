using System;
using System.Globalization;
using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class EvaluableExtensionShould
    {
        [Fact]
        public void ReturnNewValueIfTrue()
        {
            var sut = "123";
            var evaluable = sut.AsEvaluable();
            var sut2  = evaluable.If(s => s == "123")
                .Then("124");
            
            sut2.ShouldBe("124");
            sut.ShouldBe("123");
        }
        
        [Fact]
        public void ReturnSameValueIfFalse()
        {
            var sut = "123";
            var evaluable = sut.AsEvaluable();
            var sut2  = evaluable.If(s => s == "antani")
                .Then("124");
            
            sut2.ShouldBe("123");
            sut.ShouldBe("123");
        }
        
        [Fact]
        public void ThenSetReturnSameValueIfFalse()
        {
            var sut = "123";
            var evaluable = sut.AsEvaluable();
            var sut2  = evaluable.If(s => s == "antani")
                .Then(() => 1);
            
            sut2.ShouldBe(1);
            sut.ShouldBe("123");
        }

        
    }
}