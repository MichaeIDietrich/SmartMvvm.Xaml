using System;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    public class Case : MarkupExtension
    {
        #region methods

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        #endregion

        #region constructors

        public Case()
        {
        }

        public Case(object key)
        {
            Key = key;
        }

        public Case(object key, object value) : this(key)
        {
            Value = value;
        }

        #endregion

        #region properties

        public object Key { get; set; }

        public object Value { get; set; }

        #endregion
    }
}