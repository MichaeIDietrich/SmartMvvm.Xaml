using System.Windows.Data;
using SmartMvvm.Xaml.Markup;
using SmartMvvm.Xaml.UnitTests.Markup.Logic;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public class SwitchTest
    {
        [Theory]
        [InlineData(20, 4)] // first case
        [InlineData(30, 5)] // second case
        [InlineData(null, 7)] // null case
        [InlineData(-1, 10)] // default
        public void Resolve_Value(object input, object expected)
        {
            var firstCase = new Case(20, 4);
            var secondCase = new Case(30, 5);
            var nullCase = new Case(null, 7);
            const int defaultValue = 10;

            // given
            var sut = new Switch(new Binding { Source = input }, firstCase, secondCase, nullCase) { Default = defaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }
    }
}