using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    [ContentProperty(nameof(Cases))]
    public class Switch : MarkupExtension
    {
        #region class CaseConverter

        private class CaseConverter : IValueConverter
        {
            #region members

            private readonly Switch _switch;

            #endregion

            #region constructors

            public CaseConverter(Switch switchExtension)
            {
                _switch = switchExtension;
            }

            #endregion

            #region methods

            private object FindValue(object key)
            {
                if (key == null)
                {
                    return _switch._nullValue;
                }

                return _switch.Cases.Contains(key) ? _switch.Cases[key] : _switch.Default;
            }

            #endregion

            #region interface IValueConverter

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return FindValue(value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DependencyProperty.UnsetValue;
            }

            #endregion
        }

        #endregion

        #region members

        private object _nullValue = DependencyProperty.UnsetValue;

        #endregion

        #region constructors

        public Switch()
        {
        }

        private Switch(Binding binding, params Case[] cases)
        {
            Binding = binding;

            foreach (var @case in cases)
            {
                AddCase(@case);
            }
        }

        public Switch(Binding binding) : this(binding, new Case[0])
        {
        }

        public Switch(Binding binding, Case first) : this(binding, new[] { first })
        {
        }

        public Switch(Binding binding, Case first, Case second) : this(binding, new[] { first, second })
        {
        }

        public Switch(Binding binding, Case first, Case second, Case third) : this(binding,
            new[] { first, second, third })
        {
        }

        public Switch(Binding binding, Case first, Case second, Case third, Case fourth) : this(binding,
            new[] { first, second, third, fourth })
        {
        }

        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth) : this(binding,
            new[] { first, second, third, fourth, fifth })
        {
        }

        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth) : this(
            binding, new[] { first, second, third, fourth, fifth, sixth })
        {
        }

        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth,
            Case seventh) : this(binding, new[] { first, second, third, fourth, fifth, sixth, seventh })
        {
        }

        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth,
            Case seventh, Case eight) : this(binding,
            new[] { first, second, third, fourth, fifth, sixth, seventh, eight })
        {
        }

        #endregion

        #region properties

        public Binding Binding { get; set; }

        public ResourceDictionary Cases { get; set; } = new();

        public object Default { get; set; } = DependencyProperty.UnsetValue;

        #endregion

        #region methods

        private void AddCase(Case newCase)
        {
            if (newCase.Key == null)
            {
                _nullValue = newCase.Value;
            }
            else
            {
                Cases.Add(newCase.Key, newCase.Value);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Binding ??= new Binding();

            if (Binding.Converter is not CaseConverter)
            {
                Binding.Converter = new CaseConverter(this);

                ProcessCases(serviceProvider);
            }

            return Binding.ProvideValue(serviceProvider);
        }

        private void ProcessCases(IServiceProvider serviceProvider)
        {
            foreach (DictionaryEntry dictionaryEntry in Cases)
            {
                if (dictionaryEntry.Value is MarkupExtension bindingBase)
                {
                    Cases[dictionaryEntry.Key] = bindingBase.ProvideValue(serviceProvider);
                }
            }
        }

        #endregion
    }
}