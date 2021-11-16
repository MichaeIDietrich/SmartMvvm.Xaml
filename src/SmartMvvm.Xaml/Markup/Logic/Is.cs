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
        /// Initializes a new instance of <see cref="Is"/>.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <param name="comparisonMode">Against what the <paramref name="value"/> is compared to.</param>
        public Is(object value, ComparisonMode comparisonMode)
            : base(value)
        {
            _comparisonMode = comparisonMode;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Is"/>.
        /// </summary>
        /// <param name="value">Input value to check for either being <c>true</c>, not empty or at least not <c>null</c>.</param>
        public Is(object value)
            : base(value)
        {
            _comparisonMode = ComparisonMode.TrueOrNotEmpty;
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
                    return Any(value) == false;

                case ComparisonMode.NonEmpty:
                    return Any(value) == true;

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

                case ComparisonMode.True:
                    return Equals(value, true);

                case ComparisonMode.False:
                    return Equals(value, false);

                case ComparisonMode.TrueOrNotEmpty:
                    return Equals(value, true) || (Any(value) ?? !Equals(value, null));

                default:
                    throw new InvalidOperationException($"{value} is not value");
            }
        }

        private static bool? Any(object value)
        {
            return (value as IEnumerable)?.Cast<object>().Any();
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
            /// Checks whether the input value is equal to <c>null</c>.
            /// </summary>
            Null,

            /// <summary>
            /// Checks whether the input value is not equal to <c>null</c>.
            /// </summary>
            NotNull,

            /// <summary>
            /// Checks whether the input value is equal to 0.
            /// </summary>
            Zero,

            /// <summary>
            /// Checks whether the input value is not equal to 0.
            /// </summary>
            NonZero,

            /// <summary>
            /// Checks whether the input value is equal to 1.
            /// </summary>
            One,

            /// <summary>
            /// Checks whether the input value is equal <c>true</c>.
            /// </summary>
            True,

            /// <summary>
            /// Checks whether the input value is equal to <c>false</c>.
            /// </summary>
            False,

            /// <summary>
            /// Checks whether the input value is either <c>true</c>, not empty or at least not <c>null</c>.
            /// </summary>
            TrueOrNotEmpty
        }
    }
}
