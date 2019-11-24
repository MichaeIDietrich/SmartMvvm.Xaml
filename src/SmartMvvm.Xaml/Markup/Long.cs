using System;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating a long value.
    /// </summary>
    public class Long : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Long"/>.
        /// </summary>
        /// <param name="value">The long value.</param>
        public Long(long value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the long value.
        /// </summary>
        public long Value { get; set; }

        /// <InheritDoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
