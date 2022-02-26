pushd .
cd src/MyWebAPI
docker rm -f demo
rd /s /q bin
dotnet build -c Release
dotnet publish -c Release
copy dockerfile-stdalone bin\Release\netcoreapp3.1\publish\dockerfile
copy ..\.dockerignore   bin\Release\netcoreapp3.1\publish
cd  bin\Release\netcoreapp3.1\publish
docker build -t andrew.mywebapi:build .
popd



:: cd config
:: docker run -d --rm --name demo -e ASPNETCORE_ENVIRONMENT=TW -e N1Env_SETTING1=91APP -e N1Env_SETTING2=6741 -v %CD%/appsettings.json:/app/appsettings.json -v %CD%/appsettings.TW.json:/app/appsettings.TW.json andrew.mywebapi:build
:: docker logs demo
:: cd ..

@goto end


:: launch for global settings
docker run -d --rm --name demo -e ASPNETCORE_ENVIRONMENT=Production -e N1Env_SETTING1=TW -e N1Env_SETTING2=6741 -v %CD%/config/module1.json:/app/config/module1.json andrew.mywebapi:build

:: launch for TW settings
docker run -d --rm --name demo -e ASPNETCORE_ENVIRONMENT=Production -e N1Env_SETTING1=TW -e N1Env_SETTING2=6741 -v %CD%/config/module1.TW.json:/app/config/module1.json andrew.mywebapi:build

:end