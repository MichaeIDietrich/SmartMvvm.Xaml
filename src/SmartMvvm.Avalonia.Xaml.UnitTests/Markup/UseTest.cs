using Avalonia.Controls;
using Avalonia.Data;
using NSubstitute;
using SmartMvvm.Avalonia.Xaml.Markup;
using SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic;
using System;
using Xunit;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup
{
    public sealed class UseTest
    {
        [Fact]
        public void Finds_Variable_By_Key()
        {
            // given
            var key = "KEY";
            var value = "VALUE";
            var variable = new Var { Value = value };
            var resourceDictionary = new ResourceDictionary { { key, variable } };
            //var propertyValue = new AmbientPropertyValue(default, resourceDictionary);

            //var schemaContext = Substitute.For<XamlSchemaContext>();
            //var schemaContextProvider = Substitute.For<IXamlSchemaContextProvider>();
            //var ambientProvider = Substitute.For<IAmbientProvider>();
            var serviceProvider = Substitute.For<IServiceProvider>();

            //schemaContext.GetXamlType(default(Type)).ReturnsForAnyArgs(new XamlType(typeof(object), schemaContext));

            //schemaContextProvider.SchemaContext.Returns(schemaContext);

            //ambientProvider.GetAllAmbientValues(default, false, default, default).ReturnsForAnyArgs(new List<AmbientPropertyValue> { propertyValue });

            //serviceProvider.GetService(typeof(IXamlSchemaContextProvider)).Returns(schemaContextProvider);
            //serviceProvider.GetService(typeof(IAmbientProvider)).Returns(ambientProvider);

            var sut = new Use(key);

            // when
            var actual = Evaluator.Evaluate(sut, resourceDictionary);
            //var binding = (Binding)sut.ProvideValue(serviceProvider);

            // then
            Assert.Same(value, actual);
            //Assert.Same(Var.ValueProperty.Name, binding.Path);
        }
    }
}
