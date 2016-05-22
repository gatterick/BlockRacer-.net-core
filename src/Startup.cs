using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using Configuration;

namespace BlockRacer {
    public class MainEntrypoint {
        public static void Main(string[] args) {
            System.Console.WriteLine("Starting webservice");
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();
            Console.WriteLine("Shutting down webservice");
            
            
        }
    }
    
    class Startup {
        public void ConfigureServices(IServiceCollection services) {
            
        }
        
        public void Configure(IApplicationBuilder app) {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}