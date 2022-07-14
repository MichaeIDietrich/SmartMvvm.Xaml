using Avalonia.Markup.Xaml;
using System;

namespace SmartMvvm.Avalonia.Xaml.Markup;

/// <summary>
/// Represents a markup extension for creating a short value.
/// </summary>
public class Short : MarkupExtension
{
    /// <summary>
    /// Initializes a new instance of <see cref="Short"/>.
    /// </summary>
    /// <param name="value">The short value</param>
    public Short(short value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the short value.
    /// </summary>
    public short Value { get; set; }

    /// <InheritDoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Value;
    }
}
