using Avalonia.Data;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System.Collections.Generic;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public sealed class CalcTest
    {
        [Theory]
        [MemberData(nameof(OneVariableParameterData))]
        public void Calculate_With_One_Variable(string expression, object first, object expected)
        {
            // given
            var sut = new Calc(expression, first);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TwoVariablesParameterData))]
        public void Calculate_With_Two_Variable(string expression, object first, object second, object expected)
        {
            // given
            var sut = new Calc(expression, first, second);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ThreeVariablesParameterData))]
        public void Calculate_With_Three_Variable(string expression, object first, object second, object third, object expected)
        {
            // given
            var sut = new Calc(expression, first, second, third);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(FourVariablesParameterData))]
        public void Calculate_With_Four_Variable(string expression, object first, object second, object third, object fourth, object expected)
        {
            // given
            var sut = new Calc(expression, first, second, third, fourth);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ParameterDataWithMinMax))]
        public void Result_Is_Truncated_To_Min_And_Max(string expression, object min, object max, object expected)
        {
            // given
            var sut = new Calc(expression) { Min = min, Max = max };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ParameterDataWithMinMax))]
        public void Result_Is_Truncated_To_Min_And_Max_Using_Bindings(string expression, object min, object max, object expected)
        {
            // given
            var sut = new Calc(string.Empty)
            {
                Expression = new Binding { Source = expression },
                Min = new Binding { Source = min },
                Max = new Binding { Source = max }
            };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Invalid_Expression_Returns_FallbackValue()
        {
            // given
            var sut = new Calc(string.Empty) { FallbackValue = "FALLBACKVALUE" };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("FALLBACKVALUE", result);
        }

        public static IEnumerable<object[]> OneVariableParameterData()
        {
            // expression, first variable, expected result
            yield return new object[] { "x", 5, 5 };
            yield return new object[] { "x", 5.5, 5.5 };
            yield return new object[] { "{0}", 5, 5 };
            yield return new object[] { "11", 5, 11.0 };
            yield return new object[] { "a * a", 5, 25 };
            yield return new object[] { "0 * a", BindingNotification.UnsetValue, 0.0 };
        }

        public static IEnumerable<object[]> TwoVariablesParameterData()
        {
            // expression, first variable, second variable, expected result
            yield return new object[] { "x", 5, 0, 5 };
            yield return new object[] { "x-y", 5.5, 5, 0.5 };
            yield return new object[] { "{0} + y", 5, 8, 13 };
            yield return new object[] { "11", 5, 0, 11.0 };
            yield return new object[] { "a / b", 10, 5, 2 };
        }

        public static IEnumerable<object[]> ThreeVariablesParameterData()
        {
            // expression, first variable, second variable, third variable, expected result
            yield return new object[] { "y", 5, 0, 1, 0 };
            yield return new object[] { "x-y", 5.5, "5", 0, 0.5 };
            yield return new object[] { "{0} * (y-z)", 5, 8, 2, 30 };
            yield return new object[] { "11 * y + z", 5, 0, 7.0, 7.0 };
            yield return new object[] { "{2} + a / b", 10, 5, 2, 4 };
        }

        public static IEnumerable<object[]> FourVariablesParameterData()
        {
            // expression, first variable, second variable, third variable, fourth variable, expected result
            yield return new object[] { "y", 5, 0, 1, 2, 0 };
            yield return new object[] { "x-y+{3}", 5.5, "5", 0, 6, 6.5 };
            yield return new object[] { "{0} * (y-z)", 5, 8, 2, 9, 30 };
            yield return new object[] { "11 * y + z / {3}", 5, 0, 15.0, "5", 3.0 };
            yield return new object[] { "{2} % {3} + a / b", 10, 5, 10, 4, 4 };
        }

        public static IEnumerable<object[]> ParameterDataWithMinMax()
        {
            // expression, min value, max value, expected result
            yield return new object[] { "15", 5, 20, 15.0 };
            yield return new object[] { "15", 20, 25, 20 };
            yield return new object[] { "-5", double.NegativeInfinity, -10, -10 };
            yield return new object[] { "15", double.NegativeInfinity, double.PositiveInfinity, 15.0 };
        }
    }
}
