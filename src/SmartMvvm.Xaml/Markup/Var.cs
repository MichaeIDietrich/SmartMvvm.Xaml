using System.Windows;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a dependency object that can be used variable to store a value in XAML resource dictionaries.
    /// Value can be retrieved using <see cref="Use"/>.
    /// 
    /// Usage:
    /// &lt;Var x:Key="MyVariable" Value="{Binding Path=Expression}" /&gt;
    /// </summary>
    public class Var : Freezable
    {
        /// <summary>
        /// Dependency Property for <see cref="Value"/>.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(object), typeof(Var));

        /// <summary>
        /// Gets or sets any value.
        /// </summary>
        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <InheritDoc />
        protected override Freezable CreateInstanceCore()
        {
            return new Var();
        }
    }
}
