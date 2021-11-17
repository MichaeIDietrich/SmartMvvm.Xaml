using NSubstitute;
using SmartMvvm.Xaml.Markup.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public sealed class AsTest
    {
        [Theory]
        [MemberData(nameof(TypeCodeParameterData))]
        public void Input_value_Is_Converted_Using_TypeCode(object input, TypeCode typeCode, object expected)
        {
            // given
            var sut = new As(input, typeCode);

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TypeCodeParameterData))]
        public void Input_value_Is_Converted_Using_TypeCode_Using_Property(object input, TypeCode typeCode, object expected)
        {
            // given
            var sut = new As(input) { Type = typeCode };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_Using_Converter_Parameters()
        {
            // given
            var input = new object();
            var converter = Substitute.For<IValueConverter>();
            var parameter = "PARAMETER";
            var culture = CultureInfo.GetCultureInfo("de");
            var converterResult = new object();

            converter
                .Convert(input, Arg.Any<Type>(), parameter, culture)
                .Returns(converterResult);

            var sut = new As(input)
            {
                Converter = converter,
                ConverterParameter = parameter,
                ConverterCulture = culture
            };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(converterResult, result);
            converter.Received(1).Convert(input, Arg.Any<Type>(), parameter, culture);
        }        
        
        [Fact]
        public void FallbackValue_Is_Used_For_Invalid_Conversions()
        {
            // given
            var sut = new As("", TypeCode.Int32) { FallbackValue = "FALLBACK" };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal("FALLBACK", result);
        }

        public static IEnumerable<object[]> TypeCodeParameterData()
        {
            // input value, type code, expected result
            yield return new object[] { 12, TypeCode.Double, 12.0 };
            yield return new object[] { 11.0, TypeCode.Int32, 11 };
            yield return new object[] { 5.5, TypeCode.String, "5.5" };
            yield return new object[] { 1.4, TypeCode.Int16, (short)1 };
            yield return new object[] { 1.5, TypeCode.Int16, (short)2 };
            yield return new object[] { "17", TypeCode.Int32, 17 };
            yield return new object[] { "19.5", TypeCode.Single, 19.5f };
            yield return new object[] { DependencyProperty.UnsetValue, TypeCode.Single, null };
        }
    }
}
