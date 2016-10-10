./Scripts/Pack.ps1 `
    -projectName $env:SYSTEM_TEAMPROJECT `
    -configuration $env:BUILD_CONFIGURATION `
    -output $env:BUILD_ARTIFACTSTAGINGDIRECTORY `
    -versionSuffix $env:BUILD_DEFINITIONVERSION