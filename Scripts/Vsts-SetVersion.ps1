$date = Get-Date -Format "yyyyMMdd"

./Scripts/SetVersion.ps1 "$env:VERSION_MAJOR.$env:VERSION_MINOR.$date"