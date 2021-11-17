$project = "$PSScriptRoot\..\src\SmartMvvm.Xaml\SmartMvvm.Xaml.csproj"


$version = & "$PSScriptRoot\common\Get-VersionPrefix.ps1" -projectFilePath $project

$branch = & "$PSScriptRoot\common\Get-CurrentBranch.ps1"
$versionSuffix = & "$PSScriptRoot\common\Get-VersionSuffix.ps1" -branch $branch


$props = @($project, '-o', 'artifacts', '-c', 'Release', '-p:ContinuousIntegrationBuild=true')

if ($versionSuffix)
{
    $props = $props += "-p:VersionSuffix=$versionSuffix"
    $version = "$version-$versionSuffix"
}

Update-AppveyorBuild -Version "$version"

dotnet pack $props