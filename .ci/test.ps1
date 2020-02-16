$project = "$PSScriptRoot\..\src\SmartMvvm.Xaml.UnitTests\SmartMvvm.Xaml.UnitTests.csproj"


$props = @($project, '-c', 'Release')

dotnet test $props