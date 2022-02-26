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

                // TODO: add 91APP custom environment with prefix
                .ConfigureAppConfiguration(config =>
                {
                    config.AddEnvironmentVariables("N1Env_");

                    // TODO: 開發者決定要載入的 module config, 必須同步標記於 manifest, IS 才能對應部署。可考慮改寫這段 code 對齊 manifest
                    config.AddJsonFile("config/module1.json", false, true);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
