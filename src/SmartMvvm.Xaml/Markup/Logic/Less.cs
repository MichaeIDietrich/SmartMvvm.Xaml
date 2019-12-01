using System.Collections.Generic;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension that check whether an input value is less than another input value.
    /// </summary>
    public class Less : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Less"/>
        /// </summary>
        /// <param name="left">Left input value.</param>
        /// <param name="right">Right input value.</param>
        public Less(object left, object right)
            : base(left, right)
        { }

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            return AsNumber(values[0]) < AsNumber(values[1]);
        }
    }
}
