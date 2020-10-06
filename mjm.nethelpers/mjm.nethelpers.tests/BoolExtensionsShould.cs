using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class BoolExtensionsShould
    {
        [Fact]
        public void BeTrueIfTrue()
        {
            var sut = true.IsTrue();
            sut.ShouldBeTrue();
        }
        
        [Fact]
        public void BeFalseIfFalse()
        {
            var sut = true.IsFalse();
            sut.ShouldBeFalse();
        }
        
        [Fact]
        public void BeFalseIfTrue()
        {
            var sut = true.IsFalse();
            sut.ShouldBeFalse();
        }
        
        [Fact]
        public void BeTrueIfFalse()
        {
            var sut = false.IsFalse();
            sut.ShouldBeTrue();
        }
    }
}