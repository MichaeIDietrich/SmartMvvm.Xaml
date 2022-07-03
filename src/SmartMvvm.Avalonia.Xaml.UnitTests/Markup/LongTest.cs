using SmartMvvm.Avalonia.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup
{
    public sealed class LongTest
    {
        private static readonly Random _generator = new Random();

        [Theory]
        [MemberData(nameof(GenerateRandomLongs), 20)]
        public void Ctor_Value_Is_Returned(long value)
        {
            // given
            var sut = new Long(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(GenerateRandomLongs), 20)]
        public void Property_Value_Is_Returned(long value)
        {
            // given
            var sut = new Long(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> GenerateRandomLongs(int count)
        {
            return Enumerable.Range(0, count).Select(_ => new object[] { LongRandom() });
        }

        private static long LongRandom()
        {
            var buffer = new byte[8];
            _generator.NextBytes(buffer);

            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
