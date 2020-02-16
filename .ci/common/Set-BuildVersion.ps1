param( [string] $version )

if (!$version -and (Get-Command "appveyor.exe" -ErrorAction SilentlyContinue))
{
    appveyor UpdateBuild -Version $version
}