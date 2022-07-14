$sharedBuildProps = "$PSScriptRoot\..\src\Directory.Build.props"
$wpfProject = "$PSScriptRoot\..\src\SmartMvvm.Xaml\SmartMvvm.Xaml.csproj"
$avaloniaProject = "$PSScriptRoot\..\src\SmartMvvm.Avalonia.Xaml\SmartMvvm.Avalonia.Xaml.csproj"


$version = & "$PSScriptRoot\common\Get-VersionPrefix.ps1" -projectFilePath $sharedBuildProps

$branch = & "$PSScriptRoot\common\Get-CurrentBranch.ps1"
$versionSuffix = & "$PSScriptRoot\common\Get-VersionSuffix.ps1" -branch $branch


$wpfProjectProps = @($wpfProject, '-o', 'artifacts', '-c', 'Release', '-p:ContinuousIntegrationBuild=true')
$avaloniaProjectProps = @($avaloniaProject, '-o', 'artifacts', '-c', 'Release', '-p:ContinuousIntegrationBuild=true')

if ($versionSuffix)
{
    $wpfProjectProps += "-p:VersionSuffix=$versionSuffix"
    $avaloniaProjectProps += "-p:VersionSuffix=$versionSuffix"
    $version = "$version-$versionSuffix"
}

if (Test-Path env:APPVEYOR)
{
    Update-AppveyorBuild -Version "$version"
}

dotnet pack $wpfProjectProps

if ($LASTEXITCODE)
{
    exit $LASTEXITCODE
}

dotnet pack $avaloniaProjectProps

if ($LASTEXITCODE)
{
    exit $LASTEXITCODE
}