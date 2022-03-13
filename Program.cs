using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SunAPI
{
    public class Program
    {
        public static string name = "Raspberry Pi 4B+";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:5100");
                });
    }
}
