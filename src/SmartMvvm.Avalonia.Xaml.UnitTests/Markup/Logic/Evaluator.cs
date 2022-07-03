using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using NSubstitute;
using System;
using System.Reactive.Linq;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public static class Evaluator
    {
        public static object Evaluate(MarkupExtension markupExtension, ResourceDictionary resources = null)
        {
            var target = new TargetElement();

            var provideValueTarget = Substitute.For<IProvideValueTarget>();
            var serviceProvider = Substitute.For<IServiceProvider>();

            provideValueTarget.TargetObject.Returns(target);
            provideValueTarget.TargetProperty.Returns(TargetElement.ValueProperty);

            serviceProvider.GetService(typeof(IProvideValueTarget)).Returns(provideValueTarget);

            if (resources is not null)
            {
                var stackProvider = Substitute.For<IAvaloniaXamlIlParentStackProvider>();
                var resourceHost = Substitute.For<IResourceHost>();

                resourceHost
                    .TryGetResource(default, out Arg.Any<object>())
                    .ReturnsForAnyArgs(x =>
                    {
                        var result = resources.TryGetValue(x[0], out var value);
                        x[1] = value;
                        return result;
                    });

                stackProvider.Parents.Returns(new[] { resourceHost });

                serviceProvider.GetService(typeof(IAvaloniaXamlIlParentStackProvider)).Returns(stackProvider);
            }

            var result = markupExtension.ProvideValue(serviceProvider);

            if (result is IBinding binding)
            {
                var expression = binding.Initiate(target, TargetElement.ValueProperty);

                result = expression.Observable.First();
            }

            return result;
        }

        private class TargetElement : AvaloniaObject, IDataContextProvider
        {
            public object Value
            {
                get { return GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }

            public object DataContext { get => null; set => throw new NotImplementedException(); }

            public static readonly StyledProperty<object> ValueProperty = AvaloniaProperty.Register<TargetElement, object>(nameof(Value));
        }
    }
}
