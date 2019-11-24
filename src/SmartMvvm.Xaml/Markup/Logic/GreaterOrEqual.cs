using System.Collections.Generic;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension that check whether an input value is greater or equal to another input value.
    /// </summary>
    public class GreaterOrEqual : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GreaterOrEqual"/>
        /// </summary>
        /// <param name="left">Left input value.</param>
        /// <param name="right">Right input value.</param>
        public GreaterOrEqual(object left, object right)
            : base(left, right)
        { }

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            return AsNumber(values[0]) >= AsNumber(values[1]);
        }
    }
}
