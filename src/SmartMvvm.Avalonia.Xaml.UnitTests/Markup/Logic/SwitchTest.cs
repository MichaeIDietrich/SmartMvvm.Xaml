using Avalonia.Data;
using SmartMvvm.Avalonia.Xaml.Markup;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public class SwitchTest
    {
        private const int DefaultValue = 0;
        private readonly Case _firstCase = new Case(1, 10);
        private readonly Case _secondCase = new Case(2, 20);
        private readonly Case _thirdCase = new Case(3, 30);
        private readonly Case _fourthCase = new Case(4, 40);
        private readonly Case _fifthCase = new Case(5, 50);
        private readonly Case _sixthCase = new Case(6, 60);
        private readonly Case _seventhCase = new Case(7, 70);
        private readonly Case _eightCase = new Case(8, 80);
        private readonly Case _nullCase = new Case(null, -10);

        [Fact]
        public void Resolve_Value_NoDefaultDefined()
        {
            // given
            var sut = new Switch(new Binding { Source = 100 });

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Null(result);
        }

        [Fact]
        public void Resolve_Value_NoNullDefined()
        {
            // given
            var sut = new Switch(new Binding { Source = null });

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Null(result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_OneCase(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(2, 20)] // second case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_TwoCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(2, 20)] // second case
        [InlineData(3, 30)] // third case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_ThreeCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _thirdCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(2, 20)] // second case
        [InlineData(3, 30)] // third case
        [InlineData(4, 40)] // fourth case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_FourthCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _thirdCase, _fourthCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(2, 20)] // second case
        [InlineData(3, 30)] // third case
        [InlineData(4, 40)] // fourth case
        [InlineData(5, 50)] // fifth case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_FifthCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _thirdCase, _fourthCase, _fifthCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(2, 20)] // second case
        [InlineData(3, 30)] // third case
        [InlineData(4, 40)] // fourth case
        [InlineData(5, 50)] // fifth case
        [InlineData(6, 60)] // sixth case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_SixthCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _thirdCase, _fourthCase, _fifthCase, _sixthCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 10)] // first case
        [InlineData(2, 20)] // second case
        [InlineData(3, 30)] // third case
        [InlineData(4, 40)] // fourth case
        [InlineData(5, 50)] // fifth case
        [InlineData(6, 60)] // sixth case
        [InlineData(7, 70)] // seventh case
        [InlineData(null, -10)] // null case
        [InlineData(10, 0)] // default
        public void Resolve_Value_SeventhCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _thirdCase, _fourthCase, _fifthCase, _sixthCase, _seventhCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Theory]
        //[InlineData(1, 10)] // first case
        //[InlineData(2, 20)] // second case
        //[InlineData(3, 30)] // third case
        //[InlineData(4, 40)] // fourth case
        //[InlineData(5, 50)] // fifth case
        //[InlineData(6, 60)] // sixth case
        //[InlineData(7, 70)] // seventh case
        //[InlineData(8, 80)] // eight case
        [InlineData(null, -10)] // null case
        //[InlineData(10, 0)] // default
        public void Resolve_Value_EigthCases(object input, object expected)
        {
            // given
            var sut = new Switch(new Binding { Source = input }, _firstCase, _secondCase, _thirdCase, _fourthCase, _fifthCase, _sixthCase, _seventhCase, _eightCase, _nullCase) { Default = DefaultValue };

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Resolve_CasesContainBindings_AllBindingsAreResolved()
        {
            // given
            var conditionBinding = new Binding { Source = 11 };
            var keyBinding = new Binding { Source = 11 };
            var valueBinding = new Binding { Source = 22 };

            var sut = new Switch(conditionBinding, new Case(keyBinding, valueBinding));

            // when
            var result = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(22, result);
        }

        [Fact]
        public void Resolve_CasesContainChangingBindings_AllBindingsAreResolvedEachEvaluation()
        {
            // given
            var conditionBinding = new Binding("[0]") { Source = new[] { 11 } };
            var keyBinding = new Binding("[0]") { Source = new[] { 11 } };
            var valueBinding = new Binding("[0]") { Source = new[] { 22 } };
            var keyBinding2 = new Binding("[0]") { Source = new[] { 33 } };
            var valueBinding2 = new Binding("[0]") { Source = new[] { 44 } };

            var sut = new Switch(conditionBinding, new Case(keyBinding, valueBinding), new Case(keyBinding2, valueBinding2));

            // when
            var result = Evaluator.Evaluate(sut);

            ((int[])conditionBinding.Source)[0] = 333;
            ((int[])keyBinding.Source)[0] = 111;
            ((int[])valueBinding.Source)[0] = 222;
            ((int[])keyBinding2.Source)[0] = 333;
            ((int[])valueBinding2.Source)[0] = 444;

            var result2 = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(22, result);
            Assert.Equal(444, result2);
        }

        [Fact]
        public void Resolve_CaseAddedWithoutDynamicFlag_NewCaseIsIgnored()
        {
            // given
            var conditionBinding = new Binding { Source = 11 };
            var keyBinding = new Binding { Source = 33 };
            var valueBinding = new Binding { Source = 44 };

            var sut = new Switch(conditionBinding, new Case(keyBinding, valueBinding)) { Default = 99 };

            // when
            var result = Evaluator.Evaluate(sut);

            sut.Cases.Add(new Binding { Source = 11 }, new Binding { Source = 22 });

            var result2 = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(99, result);
            Assert.Equal(99, result2);
        }

        [Fact]
        public void Resolve_CaseAddedWithDynamicFlag_NewCaseIsRecognized()
        {
            // given
            var conditionBinding = new Binding { Source = 11 };
            var keyBinding = new Binding { Source = 33 };
            var valueBinding = new Binding { Source = 44 };

            var sut = new Switch(conditionBinding, new Case(keyBinding, valueBinding)) { Default = 99, HasDynamicCases = true };

            // when
            var result = Evaluator.Evaluate(sut);

            sut.Cases.Add(new Binding { Source = 11 }, new Binding { Source = 22 });

            var result2 = Evaluator.Evaluate(sut);

            // then
            Assert.Equal(99, result);
            Assert.Equal(22, result2);
        }
    }
}