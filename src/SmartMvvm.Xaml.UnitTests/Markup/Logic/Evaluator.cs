using NSubstitute;
using System;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public static class Evaluator
    {
        public static object Evaluate(MarkupExtension markupExtension)
        {
            object result = null;

            RunOnStaThread(() =>
            {
                var target = new TargetElement();

                var provideValueTarget = Substitute.For<IProvideValueTarget>();
                var serviceProvider = Substitute.For<IServiceProvider>();

                provideValueTarget.TargetObject.Returns(target);
                provideValueTarget.TargetProperty.Returns(TargetElement.ValueProperty);

                serviceProvider.GetService(typeof(IProvideValueTarget)).Returns(provideValueTarget);

                target.Value = markupExtension.ProvideValue(serviceProvider);

                result = target.Value;
            });

            return result;
        }

        private class TargetElement : DependencyObject
        {
            public object Value
            {
                get { return GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }

            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(object), typeof(TargetElement));
        }

        private static void RunOnStaThread(Action action)
        {
            Exception exception = null;

            var thread = new Thread(_ =>
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                    action();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            if (exception != null)
                ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }
}
