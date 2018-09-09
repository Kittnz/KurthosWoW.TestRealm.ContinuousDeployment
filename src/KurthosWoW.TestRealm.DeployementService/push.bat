cd C:\Users\Administrator\Documents\GitHub\KurthosWoW.Trinitycore
git pull

taskkill /f /im worldserver.exe

call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
cd C:\Users\Administrator\Documents\GitHub\KurthosWoW.Trinitycore\build\src\server\worldserver\
msbuild worldserver.vcxproj /t:build /p:configuration=release

cd C:\Users\Administrator\Documents\GitHub\KurthosWoW.Trinitycore\build\bin\Release
start worldserver.exe