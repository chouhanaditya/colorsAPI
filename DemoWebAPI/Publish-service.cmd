@ECHO OFF
SET service-versionname=%1

:PromptForVersion
if /I ["%~1"]==[""] (set /P service-versionname=Enter version-name: )
if /I ["%service-versionname%"]==[""] ( goto PromptForVersion )

Echo.
Echo *** Creating Service-Publish folder ***
rmdir c:\Services-Publish /s /q
mkdir c:\Services-Publish
if errorlevel 1 goto ErrorMessage

Echo.
Echo *** dot net build of service ***
copy "ColorsWebAPI.csproj" c:\Services-Publish\ColorsWebAPI.csproj

dotnet publish -c Release -o c:\Services-Publish
if errorlevel 1 goto ErrorMessage

Echo.
Echo *** Copy Docker file ***
copy Dockerfile c:\Services-Publish\Dockerfile

if errorlevel 1 goto ErrorMessage

Echo.
Echo *** Docker build of service ***
docker build c:\Services-Publish -t achouhan0121/%service-versionname%

Echo.
Echo *** Docker Push of service ***
docker push achouhan0121/%service-versionname%