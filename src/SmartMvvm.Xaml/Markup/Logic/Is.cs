using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension that is used to check a single value for a specific property.
    /// </summary>
    public class Is : LogicalBase
    {
        private readonly ComparisonMode _comparisonMode;

        /// <summary>
        /// Initializes a new instance of <see cref="If"/>.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <param name="comparisonMode">Against what the <paramref name="value"/> is compared to.</param>
        public Is(object value, ComparisonMode comparisonMode)
            : base(value)
        {
            _comparisonMode = comparisonMode;
        }

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            return EvaluateInternal(values.Single());
        }

        private bool EvaluateInternal(object value)
        {
            switch (_comparisonMode)
            {
                case ComparisonMode.Empty:
                    return (value as IEnumerable)?.Cast<object>().Any() == false;

                case ComparisonMode.NonEmpty:
                    return (value as IEnumerable)?.Cast<object>().Any() == true;

                case ComparisonMode.Null:
                    return value is null;

                case ComparisonMode.NotNull:
                    return !(value is null);

                case ComparisonMode.Zero:
                    return AsNumber(value) == 0;

                case ComparisonMode.NonZero:
                    return AsNumber(value) != 0;

                case ComparisonMode.One:
                    return AsNumber(value) == 1;

                default:
                    throw new InvalidOperationException($"{value} is not value");
            }
        }

        /// <summary>
        /// Represents the available modes for checking a given input value.
        /// </summary>
        public enum ComparisonMode
        {
            /// <summary>
            /// Checks whether the input value is enumeration that returns no items.
            /// </summary>
            Empty,

            /// <summary>
            /// Checks whether the input value is enumeration that returns at least one item.
            /// </summary>
            NonEmpty,

            /// <summary>
            /// Checks whether the input value equals to <c>null</c>.
            /// </summary>
            Null,

            /// <summary>
            /// Checks whether the input value does not equal to <c>null</c>.
            /// </summary>
            NotNull,

            /// <summary>
            /// Checks whether the input value equals to 0.
            /// </summary>
            Zero,

            /// <summary>
            /// Checks whether the input value does not equal to 0.
            /// </summary>
            NonZero,

            /// <summary>
            /// Checks whether the input value equals to 1.
            /// </summary>
            One,
        }
    }
}
