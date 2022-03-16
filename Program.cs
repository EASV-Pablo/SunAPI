using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SunAPI.Models;
using System;
using System.IO;

namespace SunAPI
{
    public class Program
    {
        public static Server server;
        public static string fileConfig = @"initialConfig.json";

        public static void Main(string[] args)
        {
            chargeInitialConfig(fileConfig);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    if (server.Type == 0)
                    {
                        webBuilder.UseUrls("http://*:5100");
                    }
                });

        public static bool chargeInitialConfig(string file)
        {
            try
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    server = JsonConvert.DeserializeObject<Server>(json);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                server = new Server { Name = DateTime.Now.ToString(), Type = 1 };
                return false;
            }
        }

    }
}
