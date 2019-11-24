using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension that is used to retrieve the value of a <see cref="Var"/>.
    /// 
    /// Usage:
    /// &lt;TextBlock Text="{Use MyVariable}" /&gt;
    /// </summary>
    /// <remarks>
    /// This markup extension is simply a shortcut for '{Binding Source={StaticResource MyVariable}, Path=Value}'.
    /// Nevertheless this syntax can be used to keep IDE support for referenced resources (x:Key).
    /// </remarks>
    public class Use : MarkupExtension
    {
        private readonly object _variableKey;

        /// <summary>
        /// Initializes a new instance of <see cref="Use"/>.
        /// </summary>
        /// <param name="variableKey">Key of the variable.</param>
        public Use(object variableKey)
        {
            _variableKey = variableKey;
        }

        /// <InheritDoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var variable = new StaticResourceExtension(_variableKey).ProvideValue(serviceProvider);

            if (!(variable is Var))
                throw new InvalidOperationException($"{_variableKey} is no variable");
                
            return new Binding { Source = variable, Path = new PropertyPath(Var.ValueProperty) }.ProvideValue(serviceProvider);
        }
    }
}
