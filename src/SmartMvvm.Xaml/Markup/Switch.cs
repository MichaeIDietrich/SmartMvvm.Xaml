using SmartMvvm.Xaml.Markup.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartMvvm.Xaml.Markup
{
    /// <summary>
    /// Represents a markup extension for creating a switch expression.
    /// </summary>
    [ContentProperty(nameof(Cases))]
    public sealed class Switch : LogicalBase
    {
        #region members

        private bool _isFirstEvaluation = true;

        // use a separate store for the null key, since those are not allowed in a ResourceDictionary
        private object _nullValue = DependencyProperty.UnsetValue;

        #endregion

        #region constructors
        
        /// <summary>
        /// Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        public Switch()
            : base(new List<object> { null })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        public Switch(object binding)
            : base(new List<object> { binding })
        {
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        public Switch(object binding, Case first)
            : base(new List<object> { binding })
        {
            AddCase(first);
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        public Switch(object binding, Case first, Case second)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        public Switch(object binding, Case first, Case second, Case third)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="Switch"/>.
        /// </summary>
        /// <param name="binding">The <see cref="Binding"/></param>
        /// <param name="first">The first <see cref="Case"/></param>
        /// <param name="second">The second <see cref="Case"/></param>
        /// <param name="third">The third <see cref="Case"/></param>
        /// <param name="fourth">The fourth <see cref="Case"/></param>
        public Switch(object binding, Case first, Case second, Case third, Case fourth)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
            AddCase(fourth);
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
        public Switch(object binding, Case first, Case second, Case third, Case fourth, Case fifth)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
            AddCase(fourth);
            AddCase(fifth);
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
        public Switch(object binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
            AddCase(fourth);
            AddCase(fifth);
            AddCase(sixth);
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
        public Switch(object binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth, Case seventh)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
            AddCase(fourth);
            AddCase(fifth);
            AddCase(sixth);
            AddCase(seventh);
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
        /// <param name="eighth">The eighth <see cref="Case"/></param>
        public Switch(object binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth, Case seventh, Case eighth)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
            AddCase(fourth);
            AddCase(fifth);
            AddCase(sixth);
            AddCase(seventh);
            AddCase(eighth);
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
        /// <param name="eighth">The eight <see cref="Case"/></param>
        /// <param name="ninth">The ninth <see cref="Case"/></param>
        public Switch(object binding, Case first, Case second, Case third, Case fourth, Case fifth, Case sixth, Case seventh, Case eighth, Case ninth)
            : base(new List<object> { binding })
        {
            AddCase(first);
            AddCase(second);
            AddCase(third);
            AddCase(fourth);
            AddCase(fifth);
            AddCase(sixth);
            AddCase(seventh);
            AddCase(eighth);
            AddCase(ninth);
        }
        
        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the <see cref="BindingBase" /> used a s switch value.
        /// </summary>
        public BindingBase Binding 
        {
            get => Items[0] as BindingBase;
            set => Items[0] = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="Case"/>s.
        /// </summary>
        public ResourceDictionary Cases { get; set; } = new();

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        public object Default { get; set; } = DependencyProperty.UnsetValue;

        /// <summary>
        /// Gets or sets a value indicating whether the cases might change after each evaluation.
        /// </summary>
        /// <remarks>Leaving this flag disabled can lead to a better performance for subsequent evaluations.</remarks>
        public bool HasDynamicCases { get; set; }

        #endregion

        #region methods

        private void AddCase(Case newCase)
        {
            if (newCase.Key is null)
                _nullValue = newCase.Value;
            else
                Cases.Add(newCase.Key, newCase.Value);
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (HasDynamicCases && Items.Count > 1)
            {
                var binding = Items[0];

                Items.Clear();
                Items.Add(binding);
            }

            if ( (_isFirstEvaluation || HasDynamicCases) && HasAnyMarkupExtensionInCases())
            {
                foreach (DictionaryEntry entry in Cases)
                {
                    Items.Add(entry.Key);
                    Items.Add(entry.Value);
                }

                Items.Add(_nullValue);
                Items.Add(Default);
            }

            _isFirstEvaluation = false;

            return base.ProvideValue(serviceProvider);
        }

        private bool HasAnyMarkupExtensionInCases()
        {
            if (_nullValue is MarkupExtension)
                return true;

            if (Default is MarkupExtension)
                return true;

            foreach (DictionaryEntry entry in Cases)
            {
                if (entry.Key is MarkupExtension)
                    return true;

                if (entry.Value is MarkupExtension)
                    return true;
            }

            return false;
        }

        /// <inheritdoc />
        protected override object Evaluate(IReadOnlyList<object> values)
        {
            var key = values[0];

            // value count will be one if cases contained no markup extensions
            if (values.Count == 1)
            {
                if (key is null)
                    return _nullValue;

                return Cases.Contains(key) ? Cases[key] : Default;
            }

            if (key is null)
                return values[values.Count - 2];

            // since keys could contain bindings we need to do a manual lookup
            for (var i = 1; i < values.Count - 2; i += 2)
            {
                if (Equals(key, values[i]))
                    return values[i + 1];
            }

            return values[values.Count - 1];
        }

        #endregion
    }
}