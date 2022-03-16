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
        public static string name;
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
                    //webBuilder.UseUrls("http://*:5100");
                });

        public static bool chargeInitialConfig(string file)
        {
            try
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    name = JsonConvert.DeserializeObject<MachineName>(json).Name;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                name = DateTime.Now.ToString();
                return false;
            }
        }

    }
}
