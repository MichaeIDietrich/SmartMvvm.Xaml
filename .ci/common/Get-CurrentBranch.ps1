$branch = $env:APPVEYOR_REPO_BRANCH
if (!$branch -and (Get-Command "git.exe" -ErrorAction SilentlyContinue))
{
    $branch = git rev-parse --abbrev-ref HEAD
}

if (!$branch)
{
    $branch = 'unknown';
}

return $branch