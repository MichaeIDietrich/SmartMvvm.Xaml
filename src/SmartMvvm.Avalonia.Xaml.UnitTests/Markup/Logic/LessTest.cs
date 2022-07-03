using Avalonia.Data;
using SmartMvvm.Avalonia.Xaml.Markup;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System.Collections.Generic;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public sealed class LessTest
    {
        [Theory]
        [MemberData(nameof(ParametersData))]
        public void Check_Whether_First_Is_Less_Than_Second(object param1, object param2, bool expected)
        {
            // given
            var sut = new Less(param1, param2);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> ParametersData()
        {
            yield return new object[] { 0, 1, true };
            yield return new object[] { 1, 1, false };
            yield return new object[] { 1, 0, false };
            yield return new object[] { 1.23, 123, true };
            yield return new object[] { new Int(20), "10", false };
            yield return new object[] { -19, "-20", false };
            yield return new object[] { new Binding { Source = -100 }, new Int(10), true };
            yield return new object[] { "155", new Binding { Source = "144" }, false };
            yield return new object[] { 10, BindingNotification.UnsetValue, false };
            yield return new object[] { BindingNotification.UnsetValue, 10, true };
        }
    }
}
