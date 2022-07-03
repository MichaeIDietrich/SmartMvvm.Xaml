using Avalonia.Data;
using NSubstitute;
using SmartMvvm.Avalonia.Xaml.Markup;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public sealed class EqualTest
    {
        [Theory]
        [MemberData(nameof(ParametersData))]
        public void Check_Whether_First_Is_Equal_To_Second(object param1, object param2, bool expected)
        {
            // given
            var sut = new Equal(param1, param2);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ParametersDataWithEpsilon))]
        public void Check_Whether_First_Is_Equal_To_Second_With_Epsilon(object param1, object param2, object epsilon, bool expected)
        {
            // given
            var sut = new Equal(param1, param2) { Epsilon = epsilon };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ParametersDataWithEpsilonBinding))]
        public void Check_Whether_First_Is_Equal_To_Second_With_EpsilonBinding(object param1, object param2, Binding epsilon, bool expected)
        {
            // given
            var sut = new Equal(param1, param2) { EpsilonBind = epsilon };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Use_Comparer_For_Comparison()
        {
            // given
            var comparer = Substitute.For<IEqualityComparer>();
            comparer.Equals(default, default).ReturnsForAnyArgs(true);

            var sut = new Equal(true, false) { Comparer = comparer };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(true, result);
            comparer.ReceivedWithAnyArgs().Equals(default, default);
        }

        [Fact]
        public void Use_FallbackValue_On_Error()
        {
            // given
            var sut = new Equal(true, 'a') { Epsilon = 0, FallbackValue = "FALLBACK" };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("FALLBACK", result);
        }

        public static IEnumerable<object[]> ParametersData()
        {
            // left param, right param, expected result
            yield return new object[] { 0, 1, false };
            yield return new object[] { 1, 1, true };
            yield return new object[] { "1", 1, false };
            yield return new object[] { 1, 0, false };
            yield return new object[] { 1.23, 123, false };
            yield return new object[] { new Int(20), "10", false };
            yield return new object[] { -19, "-20", false };
            yield return new object[] { new Binding { Source = -100 }, new Int(-100), true };
            yield return new object[] { "155", new Binding { Source = "144" }, false };
            yield return new object[] { "abc", new Binding { Source = "abc" }, true };
            yield return new object[] { 155, new Binding { Source = "155" }, false };
            yield return new object[] { 155, "155", false };
            yield return new object[] { BindingNotification.UnsetValue, "155", false };
            yield return new object[] { BindingNotification.UnsetValue, BindingNotification.UnsetValue, true };
        }

        public static IEnumerable<object[]> ParametersDataWithEpsilon()
        {
            // left param, right param, epsilon, expected result
            yield return new object[] { 0, 1, null, false };
            yield return new object[] { 0, 1, 1, true };
            yield return new object[] { 1, 1, 0, true };
            yield return new object[] { "1", 1, null, false };
            yield return new object[] { "1", 1, 0, true };
            yield return new object[] { 1, 0, 0, false };
            yield return new object[] { 1.23, 123, 10, false };
            yield return new object[] { 1, 0.99999, 0.001, true };
            yield return new object[] { new Int(20), "10", 0, false };
            yield return new object[] { -19, "-20", 1, true };
            yield return new object[] { new Binding { Source = -100 }, new Int(-100), null, true };
            yield return new object[] { "155", new Binding { Source = "144" }, 20, true };
            yield return new object[] { 155, new Binding { Source = "155" }, 0, true };
            yield return new object[] { 155, "155", null, false };
        }

        public static IEnumerable<object[]> ParametersDataWithEpsilonBinding()
        {
            // left param, right param, epsilon Binding, expected result
            yield return new object[] { 0, 1, new Binding { Source = null }, false };
            yield return new object[] { 0, 1, new Binding { Source = 1 }, true };
            yield return new object[] { 1, 1, new Binding { Source = "0" }, true };
            yield return new object[] { 1.23, 123, new Binding { Source = 10 }, false };
        }
    }
}
