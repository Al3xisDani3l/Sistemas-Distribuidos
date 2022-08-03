using System;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;


namespace A9___Server_SignalR
{
    class Program
    {

       

        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            Console.ReadKey();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
          

       

    }

   
}
