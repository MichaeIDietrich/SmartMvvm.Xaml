using SmartMvvm.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class ShortTest
    {
        private static readonly Random _generator = new Random();

        [Theory]
        [MemberData(nameof(GenerateRandomLongs), 20)]
        public void Ctor_Value_Is_Returned(short value)
        {
            // given
            var sut = new Short(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(GenerateRandomLongs), 20)]
        public void Property_Value_Is_Returned(short value)
        {
            // given
            var sut = new Short(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> GenerateRandomLongs(int count)
        {
            return Enumerable.Range(0, count).Select(_ => new object[] { (short)_generator.Next() });
        }
    }
}
