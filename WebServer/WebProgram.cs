using EggLink.DanhengServer.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace EggLink.DanhengServer.WebServer
{
    public class WebProgram
    {
        public static void Main(string[] args, int port, string address)
        {
            BuildWebHost(args, port, address).Start();
        }

        public static IWebHost BuildWebHost(string[] args, int port, string address) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, port, listenOptions =>
                    {
                        listenOptions.UseHttps(
                            ConfigManager.Config.KeyStore.KeyStorePath,
                            ConfigManager.Config.KeyStore.KeyStorePassword
                        );
                    });
                })
                .ConfigureLogging((hostingContext, logging) => 
                { 
                    logging.ClearProviders();
                })
                .UseUrls(address)
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
