$project = "$PSScriptRoot\..\src\SmartMvvm.Xaml\SmartMvvm.Xaml.csproj"


$branch = & "$PSScriptRoot\common\Get-CurrentBranch.ps1"
$suffix = & "$PSScriptRoot\common\Get-VersionSuffix.ps1" -branch $branch


$version = & "$PSScriptRoot\common\Get-VersionPrefix.ps1" -projectFilePath $project

$props = @($project, '-o', 'artifacts', '-c', 'Release')

if ($suffix)
{
    $props = $props += "-p:VersionSuffix=$suffix"
    $version = "$verion-$suffix"
}

dotnet pack $props

& "$PSScriptRoot\common\Set-BuildVersion.ps1" -Version $version