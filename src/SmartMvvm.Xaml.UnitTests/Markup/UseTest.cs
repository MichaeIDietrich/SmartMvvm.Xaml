using NSubstitute;
using SmartMvvm.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Xaml;
using Xunit;

namespace SmartMvvm.Xaml.UnitTests.Markup
{
    public sealed class UseTest
    {
        [Fact]
        public void Finds_Variable_By_Key()
        {
            // given
            var key = "KEY";
            var variable = new Var();
            var resourceDictionary = new ResourceDictionary { { key, variable } };
            var propertyValue = new AmbientPropertyValue(default, resourceDictionary);

            var schemaContext = Substitute.For<XamlSchemaContext>();
            var schemaContextProvider = Substitute.For<IXamlSchemaContextProvider>();
            var ambientProvider = Substitute.For<IAmbientProvider>();
            var serviceProvider = Substitute.For<IServiceProvider>();

            schemaContext.GetXamlType(default(Type)).ReturnsForAnyArgs(new XamlType(typeof(object), schemaContext));

            schemaContextProvider.SchemaContext.Returns(schemaContext);

            ambientProvider.GetAllAmbientValues(default, false, default, default).ReturnsForAnyArgs(new List<AmbientPropertyValue> { propertyValue });

            serviceProvider.GetService(typeof(IXamlSchemaContextProvider)).Returns(schemaContextProvider);
            serviceProvider.GetService(typeof(IAmbientProvider)).Returns(ambientProvider);

            var sut = new Use(key);

            // when
            var binding = (Binding) sut.ProvideValue(serviceProvider);

            // then
            Assert.Same(variable, binding.Source);
            Assert.Same(Var.ValueProperty, binding.Path.PathParameters.Single());
        }
    }
}
