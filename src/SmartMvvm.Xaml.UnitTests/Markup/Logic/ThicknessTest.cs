using System.Collections.Generic;
using System.Windows.Data;
using SmartMvvm.Xaml.Markup.Logic;
using Xunit;
using WThickness = System.Windows.Thickness;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public sealed class ThicknessTest
    {
        [Fact]
        public void Default_Ctor_Returns_Zero()
        {
            // given
            var sut = new Thickness();

            // when
            var result = (WThickness)Evaluator.Evaluate(sut);

            // then
            Assert.Equal(0.0, result.Left);
            Assert.Equal(0.0, result.Top);
            Assert.Equal(0.0, result.Right);
            Assert.Equal(0.0, result.Bottom);
        }

        [Theory]
        [MemberData(nameof(SingleParameterData))]
        public void Ctor_With_Single_Value(double value)
        {
            // given
            var sut = new Thickness(value);

            // when
            var result = (WThickness)Evaluator.Evaluate(sut);

            // then
            Assert.Equal(value, result.Left);
            Assert.Equal(value, result.Top);
            Assert.Equal(value, result.Right);
            Assert.Equal(value, result.Bottom);
        }

        [Theory]
        [MemberData(nameof(TwoParametersData))]
        public void Ctor_With_Two_Values(object leftRight, object topBottom)
        {
            // given
            var sut = new Thickness(leftRight, topBottom);

            // when
            var result = (WThickness)Evaluator.Evaluate(sut);

            // then
            Assert.Equal(leftRight, result.Left);
            Assert.Equal(topBottom, result.Top);
            Assert.Equal(leftRight, result.Right);
            Assert.Equal(topBottom, result.Bottom);
        }

        [Theory]
        [MemberData(nameof(FourParametersData))]
        public void Ctor_With_Four_Values(object left, object top, object right, object bottom)
        {
            // given
            var sut = new Thickness(left, top, right, bottom);

            // when
            var result = (WThickness)Evaluator.Evaluate(sut);

            // then
            Assert.Equal(left, result.Left);
            Assert.Equal(top, result.Top);
            Assert.Equal(right, result.Right);
            Assert.Equal(bottom, result.Bottom);
        }

        [Theory]
        [MemberData(nameof(FourParametersData))]
        public void Set_Using_Properties(object left, object top, object right, object bottom)
        {
            // given
            var sut = new Thickness
            {
                Left = left,
                Top = top,
                Right = right,
                Bottom = bottom
            };

            // when
            var result = (WThickness)Evaluator.Evaluate(sut);

            // then
            Assert.Equal(left, result.Left);
            Assert.Equal(top, result.Top);
            Assert.Equal(right, result.Right);
            Assert.Equal(bottom, result.Bottom);
        }

        [Theory]
        [MemberData(nameof(FourParametersData))]
        public void Set_Using_Bing_Properties(object left, object top, object right, object bottom)
        {
            // given
            var sut = new Thickness
            {
                LeftBind = new Binding {Source = left},
                TopBind = new Binding {Source = top},
                RightBind = new Binding {Source = right},
                BottomBind = new Binding {Source = bottom},
            };

            // when
            var result = (WThickness)Evaluator.Evaluate(sut);

            // then
            Assert.Equal(left, result.Left);
            Assert.Equal(top, result.Top);
            Assert.Equal(right, result.Right);
            Assert.Equal(bottom, result.Bottom);
        }

        public static IEnumerable<object[]> SingleParameterData()
        {
            yield return new object[] { 0.0 };
            yield return new object[] { 1.0 };
            yield return new object[] { 2.0 };
            yield return new object[] { 5.0 };
            yield return new object[] { 10.0 };
            yield return new object[] { -1.0 };
            yield return new object[] { 0.5 };
            yield return new object[] { -0.5 };
        }

        public static IEnumerable<object[]> TwoParametersData()
        {
            yield return new object[] { 0.0, 0.0 };
            yield return new object[] { 1.0, 0.0 };
            yield return new object[] { 2.0, -1.0 };
            yield return new object[] { 5.0, 1.0 };
            yield return new object[] { 10.0, 10.0 };
            yield return new object[] { -1.0, 1.0 };
            yield return new object[] { -1.7, 7.7 };
        }

        public static IEnumerable<object[]> FourParametersData()
        {
            yield return new object[] { 0.0, 0.0, 0.0, 0.0 };
            yield return new object[] { 1.0, 0.0, 1.0, 0.0 };
            yield return new object[] { 2.0, -1.0, -2.0, 10.0 };
            yield return new object[] { 5.0, 1.0, 10000000.0, -10000000000.0 };
            yield return new object[] { 10.0, 10.0, -1.0, 2.0 };
            yield return new object[] { -1.0, 1.0, 1.0, -1.0 };
            yield return new object[] { -1.5, 1.2, 1.0, -1.7 };
        }

    }
}
