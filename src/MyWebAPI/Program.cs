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

                    // TODO: (demo) �}�o�̨M�w�n���J�� module config, �����P�B�аO�� manifest, IS �~��������p�C�i�Ҽ{��g�o�q code ��� manifest
                    // TODO: (demo) �]�˪��{���X�A���F�n check required file, �]�n check required version, ���������̤p�����n�D�C�� SemVer ���W�h�A�n�D�ۦP�� major version number, �n�D�̧C�� minor version number. �ܩ� patch / build �h���b����
                    config.AddJsonFile("config/module1.json", false, true);

                    // TODO: (demo)
                    var _mkt = Environment.GetEnvironmentVariable("N1ENV_MARKET");

                    config.AddJsonFile($"config/91app.json", false, false);
                    config.AddJsonFile($"config/91app.{_mkt}.json", true, false);

                    // TODO: (template) �b�˪O�N���[�J app manifest
                    config.AddJsonFile("config/manifest.app.json", true, false);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
