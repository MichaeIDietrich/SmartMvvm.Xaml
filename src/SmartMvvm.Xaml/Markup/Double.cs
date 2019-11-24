using System;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating a double value.
    /// </summary>
    public class Double : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Double"/>.
        /// </summary>
        /// <param name="value">The double value.</param>
        public Double(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the double value.
        /// </summary>
        public double Value { get; set; }

        /// <InheritDoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
