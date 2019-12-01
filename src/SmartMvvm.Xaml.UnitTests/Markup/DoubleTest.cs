using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Double = SmartMvvm.Xaml.Markup.Double;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class DoubleTest
    {
        private static readonly Random _generator = new Random();

        [Theory]
        [MemberData(nameof(GenerateRandomDoubles), 20)]
        public void Ctor_Value_Is_Returned(double value)
        {
            // given
            var sut = new Double(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(GenerateRandomDoubles), 20)]
        public void Property_Value_Is_Returned(double value)
        {
            // given
            var sut = new Double(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> GenerateRandomDoubles(int count)
        {
            return Enumerable.Range(0, count).Select(_ => new object[] { _generator.NextDouble() });
        }
    }
}
