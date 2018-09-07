cd C:\Users\Administrator\Documents\GitHub\KurthosWoW.Trinitycore
git pull
taskill /f /im worldserver.exe
msbuild C:\Users\Administrator\Documents\GitHub\KurthosWoW.Trinitycore\build\src\server\worldserver\worldserver.vcxproj /t:build /c:Release
cd C:\Users\Administrator\Documents\GitHub\KurthosWoW.Trinitycore\build\bin\Release
start worldserver.exe