if (Test-Path -Path .\MagicCucaBakeryServer -PathType Container)
{
    Remove-Item .\MagicCucaBakeryServer -Recurse
}
mkdir .\MagicCucaBakeryServer
dotnet publish ..\API\MagicCucaBakeryAPI\MagicCucaBakery.API.csproj -r win-x64 -c release --output .\MagicCucaBakeryServer
Set-Location .\MagicCucaBakeryServer
Start-Process "MagicCucaBakery.API.exe" -ArgumentList "-http 5000 -https 5001"
Set-Location ..\
Start-Sleep -Seconds 10
Start-Transcript -path ./testResults.txt
dotnet test ..\AcceptanceTests\MagicCucaBakeryAPI.Specs\MagicCucaBakeryAPI.Specs\MagicCucaBakeryAPI.Specs.csproj
Stop-Transcript | out-null
Stop-Process -Name "MagicCucaBakery.API"
pause