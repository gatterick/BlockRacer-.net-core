using System;
using System.IO;
using BlockRacer.Repositories;
using BlockRacer.Repositories.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlockRacer.Mvc.Middleware;
using Microsoft.Extensions.Logging;
using Lohmann.HALight.Formatters;

namespace BlockRacer {
    public class Startup {
   
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services.AddDbContext<BRDbContext>();
            
            //only for dev.
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));     
            
            var logger = _loggerFactory.CreateLogger<HalInputFormatter>();
            
            services.AddMvc(options =>
            {                
                options.InputFormatters.Add(new HalInputFormatter(logger));
                options.OutputFormatters.Add(new HalOutputFormatter());
            });

            services.AddSwaggerGen();

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IRaceRepository, RaceRepository>();
            services.AddTransient<IMapRepository, MapRepository>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseMvc();
            app.UseSwaggerGen();
            app.UseSwaggerUi();
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