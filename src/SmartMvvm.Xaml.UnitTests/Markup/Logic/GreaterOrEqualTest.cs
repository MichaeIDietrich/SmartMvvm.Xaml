﻿using SmartMvvm.Xaml.Markup;
using SmartMvvm.Xaml.Markup.Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public sealed class GreaterOrEqualTest
    {
        [Theory]
        [MemberData(nameof(ParametersData))]
        public void Check_Whether_First_Is_Greater_Than_Or_Equal_To_Second(object param1, object param2, bool expected)
        {
            // given
            var sut = new GreaterOrEqual(param1, param2);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> ParametersData()
        {
            yield return new object[] { 0, 1, false };
            yield return new object[] { 1, 1, true };
            yield return new object[] { "1", 1, true };
            yield return new object[] { 1, 0, true };
            yield return new object[] { 1.23, 123, false };
            yield return new object[] { new Int(20), "10", true };
            yield return new object[] { -19, "-20", true };
            yield return new object[] { new Binding { Source = -100 }, new Int(10), false };
            yield return new object[] { "155", new Binding { Source = "144" }, true };
            yield return new object[] { 10, DependencyProperty.UnsetValue, true };
            yield return new object[] { DependencyProperty.UnsetValue, 10, false };
        }
    }
}
