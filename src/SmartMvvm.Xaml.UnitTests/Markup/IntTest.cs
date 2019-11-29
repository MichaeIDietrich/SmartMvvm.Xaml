using SmartMvvm.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class IntTest
    {
        private static readonly Random _generator = new Random();

        [Theory]
        [MemberData(nameof(GenerateRandomIntegers), 20)]
        public void Ctor_Value_Is_Returned(int value)
        {
            // given
            var sut = new Int(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(GenerateRandomIntegers), 20)]
        public void Property_Value_Is_Returned(int value)
        {
            // given
            var sut = new Int(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> GenerateRandomIntegers(int count)
        {
            return Enumerable.Range(0, count).Select(_ => new object[] { _generator.Next() });
        }
    }
}
