$revision = ($env:BUILD_DEFINITIONVERSION -split "\.")[-1]
$tag = if ($env:VERSION_TAG -ne $null) { "$($env:VERSION_TAG)$revision"}

Write-Host "BUILD_DEFINITION" $env:BUILD_DEFINITIONVERSION
Write-Host "VERSION_TAG" $env:VERSION_TAG
Write-Host "Revision: $revision"
Write-Host "Tag: $tag"

./Scripts/Pack.ps1 `
    -projectName $env:SYSTEM_TEAMPROJECT `
    -configuration $env:BUILD_CONFIGURATION `
    -output $env:BUILD_ARTIFACTSTAGINGDIRECTORY `
    -versionSuffix $env:VERSION_TAG