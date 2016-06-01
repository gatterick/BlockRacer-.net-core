using System;
using System.IO;
using BlockRacer.Repositories;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlockRacer {
    public class Startup {
   
        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services.AddDbContext<BRDbContext>();
            
            //only for dev.
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader()));     
            services.AddMvc();
            
            services.AddTransient<PlayerRepository, PlayerRepository>();
            services.AddTransient<RaceRepository, RaceRepository>();
            
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseMvc(); 
        }
        
        public static void Main(string[] args) {
             var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .CaptureStartupErrors(true)
                .Build();
            Console.WriteLine(host);
            host.Run();
        }
    }
}