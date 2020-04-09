using System;
using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class GenericExtensionShould
    {
        [Fact]
        public void ReturnValueIfBetweenRange()
        {
            var clampedInt = 5.Clamp(1, 6);
            clampedInt.ShouldBe(5);
            
            var clampedDouble = 3.5.Clamp(1, 6);
            clampedDouble.ShouldBe(3.5);
        }
        
        [Fact]
        public void ReturnMaxIfExceedRange()
        {
            var clampedInt = 5.Clamp(1, 4);
            clampedInt.ShouldBe(4);
            
            var clampedDouble = 3.5.Clamp(1, 3);
            clampedDouble.ShouldBe(3);
        }
        
        [Fact]
        public void ReturnMinIfLowerThenRange()
        {
            var clampedInt = 5.Clamp(7, 18);
            clampedInt.ShouldBe(7);
            
            var clampedDouble = 3.5.Clamp(5, 8);
            clampedDouble.ShouldBe(5);
        }
        
        [Fact]
        public void ThrowIfMinGreaterThenMax()
        {
            Action action = () => { 5.Clamp(18, 10); };
            action.ShouldThrow<Exception>();
        }
    }
}