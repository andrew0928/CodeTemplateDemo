# 示範案例


準備階段:
1. visual studio 產生 asp.net webapi project, 勾選 docker support
1. vs: build and run -> OK

開發階段:
1. ~~指定需要載入的 config module~~
1. local run (native app)
1. build and remote run (container + mount config ~~module~~)



# 需要定義的規格

config 管理流程


config 結構
- (TBD) 打包後攤平成 appsettings.{market}.json
- (TBD) 打包後攤平成 {module name}.{market}.json
- 需要定義 config (schema) version, 並且在載入時指定需要的 config module 與 min version 要求

container 規格
- ASPNETCORE_ENVIRONMENT, 指定正式, 開發, 預備環境
- N1ENV_XXXXXX, 91APP 定義的環境變數
- /app/config, 需要被載入的 config module 位置 (由 code 來宣告? 由 manifest.json 來宣告 + template 準備好 code 來載入?)
- /app/appsettings.json 專案內建設定檔載入的位置 (怎麼區分?)
- /app/secrets.json 專案內建 secrets 檔案載入的位置

ci/cd
