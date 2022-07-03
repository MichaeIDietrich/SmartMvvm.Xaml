using System.Collections.Generic;
using System.Linq;

namespace SmartMvvm.Avalonia.Xaml.Markup.Logic;

/// <summary>
/// Represents a markup extension for combining multiple input values with a logical and operation.
/// </summary>
public class And : LogicalBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="And"/>.
    /// </summary>
    /// <param name="first">First input value.</param>
    /// <param name="second">Second input value.</param>
    public And(object first, object second)
        : base(first, second)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="And"/>.
    /// </summary>
    /// <param name="first">First input value.</param>
    /// <param name="second">Second input value.</param>
    /// <param name="third">Third input value.</param>
    public And(object first, object second, object third)
        : base(first, second, third)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="And"/>.
    /// </summary>
    /// <param name="first">First input value.</param>
    /// <param name="second">Second input value.</param>
    /// <param name="third">Third input value.</param>
    /// <param name="fourth">Fourth input value.</param>
    public And(object first, object second, object third, object fourth)
        : base(first, second, third, fourth)
    { }

    /// <InheritDoc />
    protected override object Evaluate(IReadOnlyList<object> values)
    {
        var preview = string.Join(", ", values);

        var res = values.All(b => Equals(b, true));

        return res;
    }
}
