using EggLink.DanhengServer.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace EggLink.DanhengServer.WebServer
{
    public class WebProgram
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Start();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>//ÉèÖÃKestrel·þÎñÆ÷
                {
                    options.Listen(IPAddress.Any, 443, listenOptions =>
                    {
                        listenOptions.UseHttps(
                            ConfigManager.Config.KeyStore.KeyStorePath,
                            ConfigManager.Config.KeyStore.KeyStorePassword);
                    });
                })
                .ConfigureLogging((hostingContext, logging) => 
                { 
                    logging.ClearProviders();
                })
                .Build();
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
