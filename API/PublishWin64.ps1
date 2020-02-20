if (-not (Test-Path -Path .\MagicCucaBakeryServer -PathType Container))
{
    mkdir .\MagicCucaBakeryServer
}
dotnet publish .\MagicCucaBakeryAPI\MagicCucaBakery.API.csproj -r win-x64 -c release --output .\MagicCucaBakeryServer
Set-Location .\MagicCucaBakeryServer
Start-Process "MagicCucaBakery.API.exe"