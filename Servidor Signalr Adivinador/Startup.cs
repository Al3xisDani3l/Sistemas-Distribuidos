using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor_Signalr_Adivinador
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
                endpoints.MapHub<AdivinadorHub>("/adivina");
            });





        }

    }
}
