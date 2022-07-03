using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Core;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using System;

namespace SmartMvvm.Avalonia.Xaml.Markup;

/// <summary>
/// Represents a markup extension that is used to retrieve the value of a <see cref="Var"/>.
/// 
/// Usage:
/// &lt;TextBlock Text="{Use MyVariable}" /&gt; or &lt;TextBlock Text="{Use {StaticResource MyVariable}}" /&gt;
/// </summary>
/// <remarks>
/// This markup extension is simply a shortcut for '{Binding Source={StaticResource MyVariable}, Path=Value}'.
/// Nevertheless this syntax can be used to keep IDE support for referenced resources (x:Key).
/// </remarks>
public class Use : MarkupExtension, IBinding
{
    private readonly object _variableKey;
    private readonly Var _variable;
    private IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of <see cref="Use"/>.
    /// </summary>
    /// <param name="variableKey">Key of the variable.</param>
    public Use(object variableKey)
    {
        _variableKey = variableKey;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Use"/>.
    /// </summary>
    /// <param name="variable">Variable reference.</param>
    public Use(Var variable)
    {
        _variable = variable;
    }

    /// <InheritDoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        return this;
    }

    /// <InheritDoc />
    public InstancedBinding Initiate(IAvaloniaObject target, AvaloniaProperty targetProperty, object anchor = null, bool enableDataValidation = false)
    {
        if (_variable is not null)
        {
            return new Binding
            {
                Source = _variable,
                Path = nameof(Var.Value)
            }.Initiate(target, targetProperty, anchor, enableDataValidation);
        }

        var obj = new StaticResourceExtension(_variableKey).ProvideValue(_serviceProvider);

        if (obj is not Var variable)
            throw new InvalidOperationException($"{_variableKey} is no variable");

        return new Binding
        {
            Source = variable,
            Path = nameof(Var.Value)
        }.Initiate(target, targetProperty, anchor, enableDataValidation);
    }
}
