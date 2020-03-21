using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Byte = SmartMvvm.Xaml.Markup.Byte;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class ByteTest
    {
        private static readonly Random _generator = new Random();

        [Theory]
        [MemberData(nameof(GenerateRandomBytes), 20)]
        public void Ctor_Value_Is_Returned(byte value)
        {
            // given
            var sut = new Byte(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [MemberData(nameof(GenerateRandomBytes), 20)]
        public void Property_Value_Is_Returned(byte value)
        {
            // given
            var sut = new Byte(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        public static IEnumerable<object[]> GenerateRandomBytes(int count)
        {
            return Enumerable.Range(0, count).Select(_ =>
            {
                unchecked
                {
                    return new object[] {(byte)_generator.Next()};
                }
            });
        }
    }
}
