using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension for formatting input values to a string representation.
    /// </summary>
    public class Format : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <param name="first">First input value.</param>
        public Format(string format, object first)
            : base(format, first)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <param name="first">First input value.</param>
        /// <param name="second">Second input value.</param>
        public Format(string format, object first, object second)
            : base(format, first, second)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <param name="first">First input value.</param>
        /// <param name="second">Second input value.</param>
        /// <param name="third">Third input value.</param>
        public Format(string format, object first, object second, object third)
            : base(format, first, second, third)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <param name="first">First input value.</param>
        /// <param name="second">Second input value.</param>
        /// <param name="third">Third input value.</param>
        /// <param name="fourth">Fourth input value.</param>
        public Format(string format, object first, object second, object third, object fourth)
            : base(format, first, second, third, fourth)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="first">First input value.</param>
        public Format(object first)
            : base(string.Empty, first)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="first">First input value.</param>
        /// <param name="second">Second input value.</param>
        public Format(object first, object second)
            : base(string.Empty, first, second)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="first">First input value.</param>
        /// <param name="second">Second input value.</param>
        /// <param name="third">Third input value.</param>
        public Format(object first, object second, object third)
            : base(string.Empty, first, second, third)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Format"/>.
        /// </summary>
        /// <param name="first">First input value.</param>
        /// <param name="second">Second input value.</param>
        /// <param name="third">Third input value.</param>
        /// <param name="fourth">Fourth input value.</param>
        public Format(object first, object second, object third, object fourth)
            : base(string.Empty, first, second, third, fourth)
        { }

        /// <summary>
        /// Gets or sets the format string that is used for formatting the input values.
        /// </summary>
        public string FormatString
        {
            get => this[0] as string;
            set => this[0] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to the format string that is used for formatting the input values.
        /// </summary>
        public BindingBase FormatBind
        {
            get => this[0] as BindingBase;
            set => this[0] = value;
        }

        /// <summary>
        /// Gets or sets the culture information that is used for formatting.
        /// </summary>
        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            var format = (string)values[0];
            var args = values
                .Skip(1)
                .ToArray();

            return string.Format(Culture, format, args);
        }
    }
}
