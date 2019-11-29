using SmartMvvm.Xaml.Markup;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class BoolTest
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Ctor_Value_Is_Returned(bool value)
        {
            // given
            var sut = new Bool(value);

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Property_Value_Is_Returned(bool value)
        {
            // given
            var sut = new Bool(default) { Value = value };

            // when
            var result = sut.ProvideValue(default);

            // then
            Assert.Equal(value, result);
        }
    }
}
