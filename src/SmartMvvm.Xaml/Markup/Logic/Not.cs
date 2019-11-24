using System.Collections.Generic;
using System.Linq;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension negates the value of a given input.
    /// </summary>
    public class Not : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Not"/>.
        /// </summary>
        /// <param name="item">Input value to negate.</param>
        public Not(object item)
            : base(item)
        { }

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            return !values.Cast<bool>().Single();
        }
    }
}
