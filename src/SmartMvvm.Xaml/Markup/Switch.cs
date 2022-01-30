using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating a switch expression.
    /// </summary>
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
        
        /// <summary>
        /// Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
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

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        public Switch(Binding binding) : this(binding, new Case[0])
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        public Switch(Binding binding, Case first) : this(binding, new[] { first })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second) : this(binding, new[] { first, second })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third) : this(binding,
            new[] { first, second, third })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third, Case fourth) : this(binding,
            new[] { first, second, third, fourth })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        /// <param name="fifth">The fifth <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth) : this(binding,
            new[] { first, second, third, fourth, fifth })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        /// <param name="fifth">The fifth <see cref="Case"/></param>
        /// <param name="sixth">The sixth <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth) : this(
            binding, new[] { first, second, third, fourth, fifth, sixth })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        /// <param name="fifth">The fifth <see cref="Case"/></param>
        /// <param name="sixth">The sixth <see cref="Case"/></param>
        /// <param name="seventh">The seventh <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth,
            Case seventh) : this(binding, new[] { first, second, third, fourth, fifth, sixth, seventh })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        /// <param name="fifth">The fifth <see cref="Case"/></param>
        /// <param name="sixth">The sixth <see cref="Case"/></param>
        /// <param name="seventh">The seventh <see cref="Case"/></param>
        /// <param name="eight">The eight <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth,
            Case seventh, Case eight) : this(binding,
            new[] { first, second, third, fourth, fifth, sixth, seventh, eight })
        {
        }
        
        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        /// <param name="fifth">The fifth <see cref="Case"/></param>
        /// <param name="sixth">The sixth <see cref="Case"/></param>
        /// <param name="seventh">The seventh <see cref="Case"/></param>
        /// <param name="eight">The eight <see cref="Case"/></param>
        /// <param name="ninth">The ninth <see cref="Case"/></param>
        public Switch(Binding binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth,
            Case seventh, Case eight, Case ninth) : this(binding,
            new[] { first, second, third, fourth, fifth, sixth, seventh, eight, ninth })
        {
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the <see cref="Binding"/>.
        /// </summary>
        public Binding Binding { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Case"/>s.
        /// </summary>
        public ResourceDictionary Cases { get; set; } = new();

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
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

        /// <inheritdoc />
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
                if (dictionaryEntry.Key is MarkupExtension markupExtension)
                {
                    Cases[dictionaryEntry.Key] = markupExtension.ProvideValue(serviceProvider);
                }
            }
        }

        #endregion
    }
}