using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Servidor_Signalr_Adivinador
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
