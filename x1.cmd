docker rm -f demo
docker run --rm --name demo -e ASPNETCORE_ENVIRONMENT=Production -e N1ENV_MARKET=HK   -e N1Env_SETTING2=6741 -v %CD%/config:/app/config andrew.mywebapi:build