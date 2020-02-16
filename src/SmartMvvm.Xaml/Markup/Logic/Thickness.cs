using System.Collections.Generic;
using System.Windows.Data;

namespace SmartMvvm.Xaml.Markup.Logic
{
    /// <summary>
    /// Represents a markup extension for creating a <see cref="System.Windows.Thickness"/> value.
    /// </summary>
    public class Thickness : LogicalBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/>.
        /// </summary>
        public Thickness()
            : base(0.0, 0.0, 0.0, 0.0)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/>.
        /// </summary>
        /// <param name="uniformSize">The uniform length applied to all four sides of the bounding rectangle.</param>
        public Thickness(object uniformSize)
            : base(uniformSize, uniformSize, uniformSize, uniformSize)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/>.
        /// </summary>
        /// <param name="horizontalSize">The thickness for the left and right side of the rectangle.</param>
        /// <param name="verticalSize">The thickness for the upper and lower side of the rectangle.</param>
        public Thickness(object horizontalSize, object verticalSize)
            : base(horizontalSize, verticalSize, horizontalSize, verticalSize)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/>.
        /// </summary>
        /// <param name="left">The thickness for the left side of the rectangle.</param>
        /// <param name="top">The thickness for the upper side of the rectangle.</param>
        /// <param name="right">The thickness for the right side of the rectangle</param>
        /// <param name="bottom">The thickness for the lower side of the rectangle.</param>
        public Thickness(object left, object top, object right, object bottom)
            : base(left, top, right, bottom)
        { }

        /// <summary>
        /// Gets or sets the width of the left side of the bounding rectangle.
        /// </summary>
        public object Left
        {
            get => this[0];
            set => this[0] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to the value that is used for the width of the left side of the bounding rectangle.
        /// </summary>
        public BindingBase LeftBind
        {
            get => this[0] as BindingBase;
            set => this[0] = value;
        }

        /// <summary>
        /// Gets or sets the width of the upper side of the bounding rectangle.
        /// </summary>
        public object Top
        {
            get => this[1];
            set => this[1] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to the value that is used for the width of the upper side of the bounding rectangle.
        /// </summary>
        public BindingBase TopBind
        {
            get => this[1] as BindingBase;
            set => this[1] = value;
        }

        /// <summary>
        /// Gets or sets the width of the right side of the bounding rectangle.
        /// </summary>
        public object Right
        {
            get => this[2];
            set => this[2] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to the value that is used for the width of the right side of the bounding rectangle.
        /// </summary>
        public BindingBase RightBind
        {
            get => this[2] as BindingBase;
            set => this[2] = value;
        }

        /// <summary>
        /// Gets or sets the width of the lower side of the bounding rectangle.
        /// </summary>
        public object Bottom
        {
            get => this[3];
            set => this[3] = value;
        }

        /// <summary>
        /// Gets or sets a binding that points to the value that is used for the width of the lower side of the bounding rectangle.
        /// </summary>
        public BindingBase BottomBind
        {
            get => this[3] as BindingBase;
            set => this[3] = value;
        }

        /// <InheritDoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            var left = (double) AsNumber(values[0]);
            var top = (double) AsNumber(values[1]);
            var right = (double) AsNumber(values[2]);
            var bottom = (double) AsNumber(values[3]);

            return new System.Windows.Thickness(left, top, right, bottom);
        }
    }
}
