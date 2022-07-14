# SmartMvvm.Xaml / SmartMvvm.Avalonia.Xaml

[![NuGet](https://img.shields.io/nuget/v/SmartMvvm.Xaml.svg?label=nuget%20(WPF))](https://www.nuget.org/packages/SmartMvvm.Xaml/)
[![NuGet](https://img.shields.io/nuget/v/SmartMvvm.Avalonia.Xaml.svg?label=nuget%20(Avalonia))](https://www.nuget.org/packages/SmartMvvm.Avalonia.Xaml/)

[![Build status (master)](https://ci.appveyor.com/api/projects/status/mw21p6jogh4v4cgh/branch/master?svg=true&passingText=master%20-%20passing&pendingText=master%20-%20pending&failingText=master%20-%20FAILED)](https://ci.appveyor.com/project/MichaeIDietrich/SmartMvvm.Xaml/branch/master)
[![Build status (develop)](https://ci.appveyor.com/api/projects/status/mw21p6jogh4v4cgh/branch/develop?svg=true&passingText=develop%20-%20passing&pendingText=develop%20-%20pending&failingText=develop%20-%20FAILED)](https://ci.appveyor.com/project/MichaeIDietrich/SmartMvvm.Xaml/branch/develop)

Introduction
-------------

SmartMvvm.Xaml contains a set of useful markup extensions and other objects to simplify writing **WPF** and **Avalonia** XAML code without the need of code behind or unnecessary UI behavior logic in view model code.

 - Supported are projects using at least .NET Framework 4.5 or at least .NET Core 3.1 for **WPF** and at least .NET Standard 2.0 for **Avalonia**.

Getting Started
-------------------

To use these XAML utilities in your project, simply install the [SmartMvvm.Xaml (WPF)](https://www.nuget.org/packages/SmartMvvm.Xaml) or [SmartMvvm.Avalonia.Xaml (Avalonia)](https://www.nuget.org/packages/SmartMvvm.Xaml) NuGet package to your project.

Check out the [sample application (WPF)](https://github.com/MichaeIDietrich/SmartMvvm.Xaml/tree/develop/src/SmartMvvm.Xaml.Sample) or [sample application (Avalonia)](https://github.com/MichaeIDietrich/SmartMvvm.Xaml/tree/develop/src/SmartMvvm.Avalonia.Xaml.Sample) to see how you can use these utilities in your project.

Samples
-------

```xml
<!-- combine multiple Bindings and automatically convert the result -->
<ProgressBar Visibility="{And {Binding IsLoading}, {Binding IsConnected}}" />

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