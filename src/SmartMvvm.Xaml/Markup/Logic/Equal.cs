using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension that checks two inputs for equality.
    /// </summary>
    public class Equal : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Equal"/>.
        /// </summary>
        /// <param name="left">Left input value.</param>
        /// <param name="right">Right input value.</param>
        public Equal(object left, object right)
            : base(left, right, null)
        { }

        /// <summary>
        /// Gets or sets a value that is used as maximum difference to define that two values are equal.
        /// </summary>
        public object Epsilon
        {
            get => this[2];
            set => this[2] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to a value that is used as maximum difference to define that two values are equal.
        /// </summary>
        public BindingBase EpsilonBind
        {
            get => this[2] as BindingBase;
            set => this[2] = value;
        }

        /// <summary>
        /// Gets or sets a comparer that is used for comparing.
        /// </summary>
        public IEqualityComparer Comparer { get; set; }

        /// <summary>
        /// Gets or sets a value that is used as return value if comparing fails.
        /// </summary>
        public object FallbackValue { get; set; } = DependencyProperty.UnsetValue;

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            try
            {
                var epsilon = values[2];

                if (Comparer != null)
                    return Comparer.Equals(values[0], values[1]);

                if (epsilon == null)
                {
                    if (values[0] != null && values[1] is Type)
                    {
                        // if first parameter is an object and the second a type, check if the object is of the type
                        return ReferenceEquals(values[0].GetType(), values[1]);
                    }
                    return Equals(values[0], values[1]);
                }

                var difference = Math.Abs(AsNumber(values[0]) - AsNumber(values[1]));

                if (difference < 0)
                    return -difference <= AsNumber(epsilon);

                return difference <= AsNumber(epsilon);
            } 
            catch when (FallbackValue != DependencyProperty.UnsetValue)
            {
                return FallbackValue;
            }
        }
    }
}
