$revision = ($env:BUILD_DEFINITIONVERSION -split "\.")[-1]
$tag = if ($env:VERSION_TAG -ne $null) { "$($env:VERSION_TAG)$revision"}

./Scripts/Pack.ps1 `
    -projectName $env:SYSTEM_TEAMPROJECT `
    -configuration $env:BUILD_CONFIGURATION `
    -output $env:BUILD_ARTIFACTSTAGINGDIRECTORY `
    -versionSuffix $env:VERSION_TAG