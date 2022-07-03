using System.Collections.Generic;

namespace SmartMvvm.Avalonia.Xaml.Markup.Logic;

/// <summary>
/// Represents a markup extension that check whether an input value is less or equal to another input value.
/// </summary>
public class LessOrEqual : LogicalBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="LessOrEqual"/>
    /// </summary>
    /// <param name="left">Left input value.</param>
    /// <param name="right">Right input value.</param>
    public LessOrEqual(object left, object right)
        : base(left, right)
    { }

    /// <InheritDoc />
    protected override object Evaluate(IReadOnlyList<object> values)
    {
        return AsNumber(values[0]) <= AsNumber(values[1]);
    }
}
