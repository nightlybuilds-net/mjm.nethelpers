using System;
using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class StringExtensionShould
    {
        [Fact]
        public void ParseToInt()
        {
            var sut = "123";
            var parsed = sut.Parse<int>();

            parsed.ShouldBe(123);
        }

        [Fact]
        public void ThrowExceptionIfCannotParse()
        {
            var sut = "test";
            Should.Throw<Exception>(() =>
            {
                var parsed = sut.Parse<int>();
            });
        }


        [Fact]
        public void TryParseToInt()
        {
            var sut = "test";
            var parsed = sut.TryParse<int>();

            parsed.ShouldBe(0);
        }
    }
}