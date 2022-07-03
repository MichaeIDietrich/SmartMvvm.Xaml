using Avalonia.Markup.Xaml;
using SmartMvvm.Avalonia.Xaml.Markup.Logic;
using System;

namespace SmartMvvm.Avalonia.Xaml.Markup;

/// <summary>
/// Represents a markup extension for defining a <see cref="Case"/> inside a <see cref="Switch"/>.
/// </summary>
public class Case
{
    #region methods

    /// <inheritdoc cref="MarkupExtension.ProvideValue(IServiceProvider)" />
    public Case ProvideValue() => this;

    #endregion

    #region constructors

    /// <summary>
    /// Initializes a new instance of <see cref="Case"/>.
    /// </summary>
    public Case()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Case"/>.
    /// </summary>
    /// <param name="key">The key of the <see cref="Case"/></param>
    public Case(object key)
    {
        Key = key;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Case"/>.
    /// </summary>
    /// <param name="key">The key of the <see cref="Case"/></param>
    /// <param name="value">The value of the <see cref="Case"/></param>
    public Case(object key, object value) : this(key)
    {
        Value = value;
    }

    #endregion

    #region properties

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    public object Key { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public object Value { get; set; }

    #endregion
}