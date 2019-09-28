using System;
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