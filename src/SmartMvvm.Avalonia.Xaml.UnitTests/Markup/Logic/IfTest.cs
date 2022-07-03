using Avalonia.Data;
using SmartMvvm.Avalonia.Xaml.Markup;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System.Collections.Generic;
using Xunit;
using static SmartMvvm.Avalonia.Xaml.Markup.Logic.If;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public sealed class IfTest
    {
        [Fact]
        public void True_Condition_Returns_True()
        {
            // given
            var sut = new If(true);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(true, result);
        }

        [Fact]
        public void False_Condition_Returns_False()
        {
            // given
            var sut = new If(false);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(false, result);
        }

        [Fact]
        public void True_Condition_Returns_Then()
        {
            // given
            var sut = new If(true) { Then = "RESULT" };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("RESULT", result);
        }

        [Fact]
        public void False_Condition_Retuns_Else()
        {
            // given
            var sut = new If(false) { Else = "RESULT" };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("RESULT", result);
        }

        [Fact]
        public void True_Condition_Returns_ThenBinding()
        {
            // given
            var sut = new If(true) { ThenBind = new Binding { Source = "RESULT" } };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("RESULT", result);
        }

        [Fact]
        public void False_Condition_Retuns_ElseBinding()
        {
            // given
            var sut = new If(false) { ElseBind = new Binding { Source = "RESULT" } };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("RESULT", result);
        }

        [Theory]
        [MemberData(nameof(ParametersData))]
        public void Check_BuiltIn_Evaluation(object left, ComparisonMode comparisonMode, object right, bool expected)
        {
            // given
            var sut = new If(left, comparisonMode, right);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> ParametersData()
        {
            // left param, comparison mode, right param, expected result
            yield return new object[] { 0, ComparisonMode.GreaterThan, 1, false };
            yield return new object[] { 1, ComparisonMode.Equals, 1, true };
            yield return new object[] { "1", ComparisonMode.NotEquals, 1, true };
            yield return new object[] { 1, ComparisonMode.GreaterThan, 0, true };
            yield return new object[] { 1.23, ComparisonMode.GreaterOrEquals, 123, false };
            yield return new object[] { new Int(20), ComparisonMode.LessOrEquals, "10", false };
            yield return new object[] { -19, ComparisonMode.LessThan, "-20", false };
            yield return new object[] { new Binding { Source = -100 }, ComparisonMode.Equals, new Int(-100), true };
            yield return new object[] { "155", ComparisonMode.LessOrEquals, new Binding { Source = "144" }, false };
            yield return new object[] { "abc", ComparisonMode.Equals, new Binding { Source = "abc" }, true };
            yield return new object[] { 155, ComparisonMode.Equals, new Binding { Source = "155" }, false };
            yield return new object[] { 155, ComparisonMode.Equals, "155", false };
            yield return new object[] { true, ComparisonMode.And, false, false };
            yield return new object[] { true, ComparisonMode.Or, false, true };
        }
    }
}
