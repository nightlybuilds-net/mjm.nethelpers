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

        [Fact]
        public void ParseToDateTimeWithDefaultBehaviour()
        {
            var sut = "2020-05-10 09:30:15";
            var sut2 = "2020-05-10T09:30:15";
            var sut3 = "2020/05/10 09:30:15";
            var sutError = "2020-05-1009:30:15";
            
            var parsed = sut.ParseDateTime();
            AssertCommonForDatetime(parsed, 2020, 5, 10, 9, 30, 15);
            
            var parsed2 = sut2.ParseDateTime();
            AssertCommonForDatetime(parsed2, 2020, 5, 10, 9, 30, 15);
            
            var parsed3 = sut3.ParseDateTime();
            AssertCommonForDatetime(parsed3, 2020, 5, 10, 9, 30, 15);
            
            Should.Throw<Exception>(() =>
            {
                var parsedError = sutError.ParseDateTime();
            });
        }
        
        [Fact]
        public void TryParseToDateTimeWithDefaultBehaviour()
        {
            var sut = "2020-05-10 09:30:15";
            var sut2 = "2020-05-10T09:30:15";
            var sut3 = "2020/05/10 09:30:15";
            var sutError = "2020-05-1009:30:15";
            
            var parsed = sut.TryParseDateTime();
            AssertCommonForDatetime(parsed, 2020, 5, 10, 9, 30, 15);
            
            var parsed2 = sut2.TryParseDateTime();
            AssertCommonForDatetime(parsed2, 2020, 5, 10, 9, 30, 15);
            
            var parsed3 = sut3.TryParseDateTime();
            AssertCommonForDatetime(parsed3, 2020, 5, 10, 9, 30, 15);
            
            var parsedError = sutError.TryParseDateTime();

            var defaultDateTime = default(DateTime);
            AssertCommonForDatetime(parsedError, defaultDateTime.Year, defaultDateTime.Month, defaultDateTime.Day, defaultDateTime.Hour, defaultDateTime.Minute, defaultDateTime.Second);
            
        }

        private static void AssertCommonForDatetime(DateTime parsed, int year, int month, int day, int hour, int minutes, int seconds)
        {
            parsed.Year.ShouldBe(year);
            parsed.Month.ShouldBe(month);
            parsed.Day.ShouldBe(day);
            parsed.Hour.ShouldBe(hour);
            parsed.Minute.ShouldBe(minutes);
            parsed.Second.ShouldBe(seconds);
        }
    }
}