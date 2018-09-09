dotnet publish src/KurthosWoW.TestRealm.DeployementService/KurthosWoW.TestRealm.DeployementService.csproj -c Release -r win10-x64
mkdir artifacts
xcopy /s /y src\KurthosWoW.TestRealm.DeployementService\bin\Release\netcoreapp2.1\win10-x64\publish artifacts

dotnet publish src/KurthosWoW.Compilation.Bootstrapper/KurthosWoW.Compilation.Bootstrapper.csproj -c Release -r win10-x64
mkdir artifacts
xcopy /s /y src\KurthosWoW.Compilation.Bootstrapper\bin\Release\netcoreapp2.1\win10-x64\publish artifacts