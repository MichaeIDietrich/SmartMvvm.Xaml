﻿using Avalonia.Data;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System.Collections.Generic;
using Xunit;
using static SmartMvvm.Avalonia.Xaml.Markup.Logic.Is;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public sealed class IsTest
    {
        [Theory]
        [MemberData(nameof(ComparisonParameterData))]
        public void Check_Comparison(object input, ComparisonMode comparisonMode, bool expected)
        {
            // given
            var sut = new Is(input, comparisonMode);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> ComparisonParameterData()
        {
            // input value, comparison mode, expected result
            yield return new object[] { "", ComparisonMode.Empty, true };
            yield return new object[] { "test", ComparisonMode.Empty, false };
            yield return new object[] { new[] { 1, 2, 3 }, ComparisonMode.Empty, false };
            yield return new object[] { "", ComparisonMode.NonEmpty, false };
            yield return new object[] { "test", ComparisonMode.NonEmpty, true };
            yield return new object[] { new[] { 1, 2, 3 }, ComparisonMode.NonEmpty, true };
            yield return new object[] { null, ComparisonMode.Null, true };
            yield return new object[] { 1, ComparisonMode.Null, false };
            yield return new object[] { new object(), ComparisonMode.Null, false };
            yield return new object[] { null, ComparisonMode.NonNull, false };
            yield return new object[] { 1, ComparisonMode.NonNull, true };
            yield return new object[] { new object(), ComparisonMode.NonNull, true };
            yield return new object[] { 0, ComparisonMode.Zero, true };
            yield return new object[] { "0", ComparisonMode.Zero, true };
            yield return new object[] { 1, ComparisonMode.Zero, false };
            yield return new object[] { 0, ComparisonMode.NonZero, false };
            yield return new object[] { "0", ComparisonMode.NonZero, false };
            yield return new object[] { 1, ComparisonMode.NonZero, true };
            yield return new object[] { 0, ComparisonMode.One, false };
            yield return new object[] { "0", ComparisonMode.One, false };
            yield return new object[] { "1", ComparisonMode.One, true };
            yield return new object[] { 1, ComparisonMode.One, true };
            yield return new object[] { true, ComparisonMode.TrueOrNonEmpty, true };
            yield return new object[] { false, ComparisonMode.TrueOrNonEmpty, false };
            yield return new object[] { "abc", ComparisonMode.TrueOrNonEmpty, true };
            yield return new object[] { "", ComparisonMode.TrueOrNonEmpty, false };
            yield return new object[] { null, ComparisonMode.TrueOrNonEmpty, false };
            yield return new object[] { BindingNotification.UnsetValue, ComparisonMode.TrueOrNonEmpty, false };
        }
    }
}
