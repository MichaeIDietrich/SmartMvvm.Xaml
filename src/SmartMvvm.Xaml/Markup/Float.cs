using System;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating float values.
    /// </summary>
    public class Float : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Float"/>.
        /// </summary>
        /// <param name="value">The float value.</param>
        public Float(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the float value.
        /// </summary>
        public float Value { get; set; }

        /// <InheritDoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
