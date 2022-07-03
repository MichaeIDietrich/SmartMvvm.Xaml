$solution = "$PSScriptRoot\..\src\SmartMvvm.Xaml.sln"


$props = @($solution, '-c', 'Release')

dotnet test $props

if ($LASTEXITCODE)
{
    exit $LASTEXITCODE
}