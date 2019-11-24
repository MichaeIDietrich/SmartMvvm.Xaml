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
        : base(condition, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="If"/>.
        /// </summary>
        /// <param name="condition">Condition to evaluate.</param>
        /// <param name="then">Input value that is returned <paramref name="condition"/> evaluates to <c>true</c>.</param>
        /// <param name="else">Input value that is returned <paramref name="condition"/> evaluates to <c>false</c>.</param>
        public If(object condition, object then, object @else)
        : base(condition, then, @else)
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
        /// Gets or sets a value that is returned if the given conditiion evaluates to <c>false</c>.
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
    }
}
