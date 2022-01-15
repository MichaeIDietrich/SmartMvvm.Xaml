using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using SmartMvvm.Xaml.Markup.Logic;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public sealed class IsTypeOfTest
    {
        [Theory]
        [MemberData(nameof(ParametersData))]
        public void Check_Whether_First_Is_Type_Of_Second(object param1, object param2, bool expected)
        {
            // given
            var sut = new IsTypeOf(param1, param2);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> ParametersData()
        {
            // left param, right param, expected result
            yield return new object[] { "123", typeof(string), true };
            yield return new object[] { 5, typeof(int), true };
            yield return new object[] { 5.6d, typeof(double), true };
            yield return new object[] { 4, typeof(string), false };
            yield return new object[] { 3.45d, typeof(int), false };
            yield return new object[] { "123", typeof(double), false };
            yield return new object[] { new Binding { Source = "123" }, typeof(string), true };
            yield return new object[] { new Binding { Source = 5 }, typeof(int), true };
            yield return new object[] { new Binding { Source = 5.6d }, typeof(double), true };
            yield return new object[] { new Binding { Source = 4 }, typeof(string), false };
            yield return new object[] { new Binding { Source = 3.45d }, typeof(int), false };
            yield return new object[] { new Binding { Source = "123" }, typeof(double), false };
            yield return new[] { DependencyProperty.UnsetValue, "155", false };
        }
    }
}