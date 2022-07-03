Introduction
-------------

SmartMvvm.Avalonia.Xaml contains a set of useful markup extensions and other objects to simplify writing Avalonia XAML code without the need of code behind or unnecessary UI behavior logic in view model code.

 - Supported are projects using at least .NET Standard 2.0.

Getting Started
-------------------

To use these XAML utilities in your project, simply install the [SmartMvvm.Avalonia.Xaml](https://www.nuget.org/packages/SmartMvvm.Avalonia.Xaml) NuGet package to your project.

Check out the [sample application](https://github.com/MichaeIDietrich/SmartMvvm.Xaml/tree/develop/src/SmartMvvm.Avalonia.Xaml.Sample) to see how you can use these utilities in your project.

Samples
-------

```xml
<!-- combine multiple Bindings and automatically convert the result -->
<ProgressBar IsVisible="{And {Binding IsLoading}, {Binding IsConnected}}" />

<!-- evaluate mathematical expressions and format the result -->
<TextBlock Text="{Format 'Results in {0} cells', 
                         {Calc 'x * y', 
                               {Binding NumberOfColumns}, 
                               {Binding NumberOfRows}}}" />

<!-- Conditionally style an element by reusing a stored value -->
<Window.Resources>
  <Var x:Key="TooManyItems" Value="{Greater {Binding ElementName=CountTextBox, Path=Text},
                                            {Int 10000}}" />
</Window.Resources>

<TextBox x:Name="CountTextBox" Text="100" />
<TextBlock Text="{If {Use TooManyItems}, 
                     Then='Too many items!'},
                     Else='Enter the number of items to generate.'}"
           Foreground="{If {Use TooManyItems},
                           Then={x:Static Brushes.Red},
                           Else={x:Static Brushes.Black}}" />
```