using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;

namespace A9___Server_SignalR
{

    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection app)
        {
            app.AddSignalR();
           
        }

        public void Configure(IApplicationBuilder app)
        {


           
           

            app.UseRouting();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<FibonnaciHub>("/fibonnaci");
            });





        }

    }

}

