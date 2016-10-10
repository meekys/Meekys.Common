param (
    [parameter(Mandatory=$true)]
    [string] $projectName,
    [string] $configuration = "Debug",
    [string] $outputPath = ".",
    [string] $versionSuffix
)

$project = ls project.json -recurse | `
    ? {
        $_.Directory.Name -eq $projectName
    }

Write-Host Write-Host -ForegroundColor Cyan "dotnet pack $project"

if ($versionSuffix -eq $null) {
    dotnet pack $project -c $configurtion -o $outputPath
}
else {
    dotnet pack $project -c $configurtion -o $outputPath --version-suffix $versionSuffix
}