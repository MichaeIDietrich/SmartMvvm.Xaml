using System;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating a bool value.
    /// </summary>
    public class Bool : MarkupExtension
    {
        private static readonly object TrueBox = true;
        private static readonly object FalseBox = false;

        /// <summary>
        /// Initializes a new instance of <see cref="Bool"/>.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public Bool(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the boolean value.
        /// </summary>
        public bool Value { get; set; }

        /// <InheritDoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value ? TrueBox : FalseBox;
        }
    }
}
