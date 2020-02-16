param( [string] $projectFilePath )

[xml]$content = Get-Content -Path $projectFilePath

$prefix = $content.DocumentElement.SelectSingleNode("/Project/PropertyGroup/VersionPrefix")

if (!$prefix)
{
    $prefix = "1.0.0"
}

return $prefix