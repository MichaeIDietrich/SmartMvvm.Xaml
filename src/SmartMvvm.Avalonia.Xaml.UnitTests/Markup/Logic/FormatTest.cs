using Avalonia.Data;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public sealed class FormatTest
    {
        [Theory]
        [MemberData(nameof(OneVariableParameterData))]
        public void Format_With_One_Variable(string format, object first, string expected)
        {
            // given
            var sut = new Format(format, first) { Culture = CultureInfo.InvariantCulture };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(OneVariableParameterData))]
        public void Format_With_One_Variable_With_Binding(string format, object first, string expected)
        {
            // given
            var sut = new Format(first)
            {
                Culture = CultureInfo.InvariantCulture,
                FormatBind = new Binding { Source = format }
            };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(OneVariableParameterData))]
        public void Format_With_One_Variable_With_FormatString(string format, object first, string expected)
        {
            // given
            var sut = new Format(first)
            {
                Culture = CultureInfo.InvariantCulture,
                FormatString = format
            };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TwoVariablesParameterData))]
        public void Format_With_Two_Variables(string format, object first, object second, string expected)
        {
            // given
            var sut = new Format(format, first, second) { Culture = CultureInfo.InvariantCulture };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ThreeVariablesParameterData))]
        public void Format_With_Three_Variables(string format, object first, object second, object third, string expected)
        {
            // given
            var sut = new Format(format, first, second, third) { Culture = CultureInfo.InvariantCulture };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(FourVariablesParameterData))]
        public void Format_With_Four_Variables(string format, object first, object second, object third, object fourth, string expected)
        {
            // given
            var sut = new Format(format, first, second, third, fourth) { Culture = CultureInfo.InvariantCulture };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> OneVariableParameterData()
        {
            // format string, first variable, expected result
            yield return new object[] { "{0}", 10, "10" };
            yield return new object[] { "result: {0}", 15, "result: 15" };
            yield return new object[] { "{0}", BindingNotification.UnsetValue, "{Value: (unset)}" };
        }

        public static IEnumerable<object[]> TwoVariablesParameterData()
        {
            // format string, first variable, second variable, expected result
            yield return new object[] { "{1}", 10, 20, "20" };
            yield return new object[] { "result: {0}", 15, 11, "result: 15" };
            yield return new object[] { "{0} : {0}", 15, 6, "15 : 15" };
            yield return new object[] { "{0} : {1}", 15, 6, "15 : 6" };
        }

        public static IEnumerable<object[]> ThreeVariablesParameterData()
        {
            // format string, first variable, second variable, third variable, expected result
            yield return new object[] { "{0}", 10, 11, 12, "10" };
            yield return new object[] { "result: {0}", 15, 16, 17, "result: 15" };
            yield return new object[] { "{2} - {1}", 15, 16, 17, "17 - 16" };
        }

        public static IEnumerable<object[]> FourVariablesParameterData()
        {
            // format string, first variable, second variable, third variable, fourth variable, expected result
            yield return new object[] { "{0}", 10, 11, 12, 13, "10" };
            yield return new object[] { "result: {0} {3}", 15, 12, 5, 6, "result: 15 6" };
            yield return new object[] { "{0} {1} {2} {3}", 1, 2, 3, 4, "1 2 3 4" };
            yield return new object[] { "{0:000.###} {1:0.##} {2} {3}", 1.555, 2.555, 3.555, 4.555, "001.555 2.56 3.555 4.555" };
        }
    }
}
