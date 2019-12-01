using SmartMvvm.Xaml.Markup.Logic;
using System.Collections.Generic;
using System.Windows.Data;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public sealed class AndTest
    {
        [Theory]
        [MemberData(nameof(TwoParametersData))]
        public void Two_Parameter_Ctor_Are_And_Combined(object param1, object param2, bool expected)
        {
            // given
            var sut = new And(param1, param2);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ThreeParametersData))]
        public void Three_Parameter_Ctor_Are_And_Combined(object param1, object param2, object param3, bool expected)
        {
            // given
            var sut = new And(param1, param2, param3);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(FourParametersData))]
        public void Four_Parameter_Ctor_Are_And_Combined(object param1, object param2, object param3, object param4, bool expected)
        {
            // given
            var sut = new And(param1, param2, param3, param4);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TwoParametersData()
        {
            yield return new object[] { false, false, false };
            yield return new object[] { true, false, false };
            yield return new object[] { false, true, false };
            yield return new object[] { true, true, true };
            yield return new object[] { MarkupConstants.StaticTrue, true, true };
            yield return new object[] { MarkupConstants.StaticTrue, MarkupConstants.StaticFalse, false };
            yield return new object[] { new Binding { Source = true }, true, true };
            yield return new object[] { new Binding { Source = false }, false, false };
        }

        public static IEnumerable<object[]> ThreeParametersData()
        {
            yield return new object[] { false, false, false, false };
            yield return new object[] { true, false, true, false };
            yield return new object[] { false, true, false, false };
            yield return new object[] { true, true, true, true };
            yield return new object[] { MarkupConstants.StaticTrue, true, MarkupConstants.True, true };
            yield return new object[] { MarkupConstants.StaticTrue, MarkupConstants.StaticFalse, false, false };
            yield return new object[] { new Binding { Source = true }, true, MarkupConstants.StaticTrue, true };
            yield return new object[] { new Binding { Source = false }, false, true, false };
        }

        public static IEnumerable<object[]> FourParametersData()
        {
            yield return new object[] { false, false, false, false, false };
            yield return new object[] { true, false, true, false, false };
            yield return new object[] { false, true, false, false, false };
            yield return new object[] { true, true, true, true, true };
            yield return new object[] { MarkupConstants.StaticTrue, true, MarkupConstants.True, true, true };
            yield return new object[] { MarkupConstants.StaticTrue, MarkupConstants.StaticFalse, false, true, false };
            yield return new object[] { new Binding { Source = true }, true, MarkupConstants.StaticTrue, true, true };
            yield return new object[] { new Binding { Source = false }, false, true, true, false };
        }
    }
}
