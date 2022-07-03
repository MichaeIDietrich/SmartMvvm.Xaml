using SmartMvvm.Avalonia.Xaml.Markup;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup
{
    public sealed class VarTest
    {
        [Fact]
        public void Property_Value_Is_Returned()
        {
            // given
            var value = new object();

            var sut = new Var { Value = value };

            // when
            var result = sut.Value;

            // then
            Assert.Same(value, result);
        }
    }
}
