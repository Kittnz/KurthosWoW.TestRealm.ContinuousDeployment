dotnet publish src/KurthosWoW.TestRealm.DeployementService/KurthosWoW.TestRealm.DeployementService.csproj -c Release -r win10-x64
mkdir artifacts
xcopy /s src\KurthosWoW.TestRealm.DeployementService\bin\Release\netcoreapp2.1\win10-x64\publish artifacts