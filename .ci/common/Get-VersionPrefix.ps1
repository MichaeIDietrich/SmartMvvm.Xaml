param( [string] $projectFilePath )

[xml]$content = Get-Content -Path $projectFilePath

$prefix = "1.0.0"

$versionNode = $content.DocumentElement.SelectSingleNode("/Project/PropertyGroup/VersionPrefix")

if ($versionNode)
{
    $prefix = $versionNode.InnerText
}

return $prefix