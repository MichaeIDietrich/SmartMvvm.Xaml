function Get-CurrentBranch
{
    $branch = $env:APPVEYOR_REPO_BRANCH
    if (!$branch)
    {
        $branch = git rev-parse --abbrev-ref HEAD
    }

    if (!$branch)
    {
        $branch = 'unknown';
    }

    return $branch
}

function Get-VersionSuffix
{
    param( [string] $branch )

    $buildNumber = 0

    [int]::TryParse($env:APPVEYOR_BUILD_NUMBER, [ref]$buildNumber) | Out-Null

    $buildNumber = "{0:d4}" -f $buildNumber

    if ($branch -eq 'master')
    {
        return ''
    }

    if ($branch -eq 'develop')
    {
        return "alpha$buildNumber"
    }

    if ($branch.StartsWith('release/'))
    {
        return "beta$buildNumber"
    }

    $branchEscaped = $branch.Replace('/', '-').Replace('_', '-')

    return "$branchEscaped$buildNumber"
}

$branch = Get-CurrentBranch
$suffix = Get-VersionSuffix $branch

$props = @('src\SmartMvvm.Xaml\SmartMvvm.Xaml.csproj', '-o', 'artifacts', '-c', 'Release')

if ($suffix)
{
    $props = $props += "-p:VersionSuffix=$suffix"
}

dotnet pack $props