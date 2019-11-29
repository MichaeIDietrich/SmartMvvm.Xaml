using SmartMvvm.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class FloatTest
    {
        private static readonly Random _generator = new Random();

        [Theory]
        [MemberData(nameof(GenerateRandomFloats), 20)]
        public void Ctor_Value_Is_Returned(float value)
        {
            // given
            var sut = new Float(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(GenerateRandomFloats), 20)]
        public void Property_Value_Is_Returned(float value)
        {
            // given
            var sut = new Float(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> GenerateRandomFloats(int count)
        {
            return Enumerable.Range(0, count).Select(_ => new object[] { (float)_generator.NextDouble() });
        }
    }
}
