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