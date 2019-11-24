using System;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating an integer value.
    /// </summary>
    public class Int : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Int"/>.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public Int(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the integer value.
        /// </summary>
        public int Value { get; set; }

        /// <InheritDoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
