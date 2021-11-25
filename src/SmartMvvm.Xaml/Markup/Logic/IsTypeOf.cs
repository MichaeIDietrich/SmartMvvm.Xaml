using System;
using System.Collections.Generic;
using System.Windows;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    ///     Represents a markup extension that checks if a given object is equal to a given type.
    /// </summary>
    public class IsTypeOf : LogicalBase
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="IsTypeOf" />.
        /// </summary>
        /// <param name="left">Input value.</param>
        /// <param name="right">type.</param>
        public IsTypeOf(object left, Type right)
            : base(left, right, null)
        {
        }

        /// <summary>
        ///     Gets or sets a value that is used as return value if comparing fails.
        /// </summary>
        public object FallbackValue { get; set; } = DependencyProperty.UnsetValue;

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            try
            {
                if (values[0] != null && values[1] is Type)
                    return ReferenceEquals(values[0].GetType(), values[1]);

                return false;
            }
            catch when (FallbackValue != DependencyProperty.UnsetValue)
            {
                return FallbackValue;
            }
        }
    }
}