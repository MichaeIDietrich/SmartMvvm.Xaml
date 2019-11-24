using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension that converts the value of an input into another one.
    /// </summary>
    public class As : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="As"/>.
        /// </summary>
        /// <param name="item">Input.</param>
        public As(object item)
            : base(item)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="As"/>.
        /// </summary>
        /// <param name="item">Input.</param>
        /// <param name="second">Type code of the resulting value.</param>
        public As(object item, TypeCode type)
            : base(item)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the type code that is used for converting.
        /// </summary>
        public TypeCode? Type { get; set; }

        /// <summary>
        /// Gets or sets a converter that is used for converting.
        /// </summary>
        public IValueConverter Converter { get; set; }

        /// <summary>
        /// Gets or sets a parameter that is used when converting with a converter.
        /// </summary>
        public object ConverterParameter { get; set; }

        /// <summary>
        /// Gets or sets a culture that is used when converting with a converter.
        /// </summary>
        public CultureInfo ConverterCulture { get; set; } = CultureInfo.CurrentCulture;

        /// <summary>
        /// Gets or sets a value that is used as result value if converting fails.
        /// </summary>
        public object FallbackValue { get; set; } = DependencyProperty.UnsetValue;

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            try
            {
                var value = values.Single();

                if (Type is TypeCode type)
                    return Convert.ChangeType(value, type);

                if (Converter != null)
                    return Converter.Convert(value, typeof(object), ConverterParameter, ConverterCulture);

                return value;
            }
            catch when (FallbackValue != DependencyProperty.UnsetValue)
            {
                return FallbackValue;
            }
        }
    }
}
