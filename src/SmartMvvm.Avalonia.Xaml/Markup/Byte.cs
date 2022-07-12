using Avalonia.Markup.Xaml;
using System;

namespace SmartMvvm.Avalonia.Xaml.Markup;

/// <summary>
/// Represents a markup extension for creating an byte value.
/// </summary>
public class Byte : MarkupExtension
{
    /// <summary>
    /// Initializes a new instance of <see cref="Byte"/>.
    /// </summary>
    /// <param name="value">The byte value.</param>
    public Byte(byte value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the byte value.
    /// </summary>
    public byte Value { get; set; }

    /// <InheritDoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Value;
    }
}
