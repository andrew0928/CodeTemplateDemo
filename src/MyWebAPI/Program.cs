using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                // TODO: (template) add 91APP custom environment with prefix
                .ConfigureAppConfiguration(config =>
                {
                    config.AddEnvironmentVariables("N1ENV_");

                    // TODO: (demo) 開發者決定要載入的 module config, 必須同步標記於 manifest, IS 才能對應部署。可考慮改寫這段 code 對齊 manifest
                    // TODO: (demo) 包裝的程式碼，除了要 check required file, 也要 check required version, 必須滿足最小版號要求。用 SemVer 的規則，要求相同的 major version number, 要求最低的 minor version number. 至於 patch / build 則不在此限
                    config.AddJsonFile("config/module1.json", false, true);

                    // TODO: (demo)
                    var _mkt = Environment.GetEnvironmentVariable("N1ENV_MARKET");

                    config.AddJsonFile($"config/91app.json", false, false);
                    config.AddJsonFile($"config/91app.{_mkt}.json", true, false);

                    // TODO: (template) 在樣板就先加入 app manifest
                    config.AddJsonFile("config/manifest.app.json", true, false);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
