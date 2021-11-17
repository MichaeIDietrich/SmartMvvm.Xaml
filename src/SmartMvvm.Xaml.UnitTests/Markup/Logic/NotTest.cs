using SmartMvvm.Xaml.Markup.Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public sealed class NotTest
    {
        [Theory]
        [MemberData(nameof(ParametersData))]
        public void Ctor_Parameter_Is_Negated(object param, bool expected)
        {
            // given
            var sut = new Not(param);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> ParametersData()
        {
            yield return new object[] { true, false };
            yield return new object[] { false, true };
            yield return new object[] { MarkupConstants.StaticTrue, false };
            yield return new object[] { MarkupConstants.StaticFalse, true };
            yield return new object[] { new Binding { Source = true }, false };
            yield return new object[] { new Binding { Source = false }, true };
            yield return new object[] { DependencyProperty.UnsetValue, true };
        }
    }
}
