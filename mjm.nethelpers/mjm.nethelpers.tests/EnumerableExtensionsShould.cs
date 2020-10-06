using System;
using System.Collections.Generic;
using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class EnumerableExtensionsShould
    {
        [Fact]
        public void WorkOnList()
        {
            var sut = new List<int>();
            sut.IsEmpty().ShouldBeTrue();

            sut.Add(1);
            sut.IsEmpty().ShouldBeFalse();

            sut.AddRange(new[] {1, 2, 4});
            sut.IsEmpty().ShouldBeFalse();
        }

        [Fact]
        public void WorkOnNullList()
        {
            List<int> sut = null;
            Should.Throw<Exception>(() =>
            {
                var isEmpty = sut.IsEmpty();
            });

            sut.IsNullOrEmpty().ShouldBeTrue();

            sut = new List<int>();

            sut.IsNullOrEmpty().ShouldBeTrue();

            sut.Add(1);
            sut.IsNullOrEmpty().ShouldBeFalse();
        }

        [Fact]
        public void WorkOnArray()
        {
            var sut = new int[0];
            sut.IsEmpty().ShouldBeTrue();

            sut = new int[1];
            sut[0] = 1;
            sut.IsEmpty().ShouldBeFalse();
            sut = new int[3];
            sut[0] = 1;
            sut[1] = 2;
            sut[2] = 4;
            sut.IsEmpty().ShouldBeFalse();
        }

        [Fact]
        public void WorkOnNullArray()
        {
            int[] sut = null;
            Should.Throw<Exception>(() =>
            {
                var isEmpty = sut.IsEmpty();
            });

            sut.IsNullOrEmpty().ShouldBeTrue();

            sut = new int[0];
            sut.IsNullOrEmpty().ShouldBeTrue();
            sut = new int[1];
            sut[0] = 1;
            sut.IsNullOrEmpty().ShouldBeFalse();
        }
    }
}