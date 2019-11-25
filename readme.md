# SmartMvvm.Xaml

[![Build status](https://ci.appveyor.com/api/projects/status/mw21p6jogh4v4cgh/branch/test?svg=true)](https://ci.appveyor.com/project/FrecherxDachs/smartmvvm-xaml/branch/test)

Introduction
-------------

SmartMvvm.Xaml contains a set of useful markup extensions and other objects to simplify writing WPF XAML code without the need of code behind or unnecessary UI behavior logic in view model code.

 - Supported are projects using .NET Framework 4.5+ or .NET Core 3.0+

Getting Started
-------------------

Pre release NuGet can be found here: https://www.nuget.org/packages/SmartMvvm.Xaml

 - _following soon_

Samples
-------

```xml
<!-- combine multiple Bindings and automatically convert the result -->
<ProgressBar Visibility="{And {Binding IsLoading}, {Binding IsConnected}}" />

<!-- evaluate mathematical expressions and format the result -->
<TextBlock Text="{Format '{}{0} cells', 
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
                     'Too many items!'},
                     'Enter the number of items to generate.'}"
           Foreground="{If {Use TooManyItems},
                           {x:Static Brushes.Red},
                           {x:Static Brushes.Black}}" />
```