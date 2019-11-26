using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension that is used to return one of two inputs values depending on a condition.
    /// </summary>
    public class If : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="If"/>.
        /// </summary>
        /// <param name="condition">Condition to evaluate.</param>
        public If(object condition)
        : base(condition, true, false)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="If"/>.
        /// </summary>
        /// <param name="left">Left input value.</param>
        /// <param name="comparisonMode">How the <paramref name="left"/> is compared to <paramref name="right"/>.</param>
        /// <param name="right">Right input value.</param>
        public If(object left, ComparisonMode comparisonMode, object right)
        : base(ModeToComparison(comparisonMode, left, right), true, false)
        { }

        /// <summary>
        /// Gets or sets a value that is returned if the given condition evaluates to <c>true</c>.
        /// </summary>
        public object Then
        {
            get => this[1];
            set => this[1] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to a value that is returned if the given condition evaluates to <c>true</c>.
        /// </summary>
        public BindingBase ThenBind
        {
            get => this[1] as BindingBase;
            set => this[1] = value;
        }

        /// <summary>
        /// Gets or sets a value that is returned if the given condition evaluates to <c>false</c>.
        /// </summary>
        public object Else
        {
            get => this[2];
            set => this[2] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to a value that is returned if the given condition evaluates to <c>false</c>.
        /// </summary>
        public BindingBase ElseBind
        {
            get => this[2] as BindingBase;
            set => this[2] = value;
        }

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            return Equals(values[0], true) ? values[1] : values[2];
        }

        private static object ModeToComparison(ComparisonMode mode, object left, object right)
        {
            switch (mode)
            {
                case ComparisonMode.Equals:
                    return new Equal(left, right);

                case ComparisonMode.NotEquals:
                    return new Not(new Equal(left, right));

                case ComparisonMode.GreaterThan:
                    return new Greater(left, right);

                case ComparisonMode.GreaterOrEquals:
                    return new GreaterOrEqual(left, right);

                case ComparisonMode.LessThan:
                    return new Less(left, right);

                case ComparisonMode.LessOrEquals:
                    return new LessOrEqual(left, right);

                case ComparisonMode.Or:
                    return new Or(left, right);
                
                case ComparisonMode.And:
                    return new And(left, right);

                default:
                    throw new ArgumentException($"Invalid value {mode}", nameof(mode));
            }
        }

        /// <summary>
        /// Represents the available modes for combining two input values.
        /// </summary>
        public enum ComparisonMode
        {
            /// <summary>
            /// Checks whether the left and the right input value are equal.
            /// </summary>
            Equals,

            /// <summary>
            /// Checks whether the left and the right input value are not equal.
            /// </summary>
            NotEquals,

            /// <summary>
            /// Checks whether the left input value is greater than the right input value.
            /// </summary>
            GreaterThan,

            /// <summary>
            /// Checks whether the left input value is greater than or equal to the right input value.
            /// </summary>
            GreaterOrEquals,

            /// <summary>
            /// Checks whether the left input value is less than the right input value.
            /// </summary>
            LessThan,

            /// <summary>
            /// Checks whether the left input value is less than or equal to the right input value.
            /// </summary>
            LessOrEquals,

            /// <summary>
            /// Checks whether the left and the right input value evaluate to true when combined with a logical or operation.
            /// </summary>
            Or,

            /// <summary>
            /// Checks whether the left and the right input value evaluate to true when combined with a logical and operation.
            /// </summary>
            And
        }
    }
}
