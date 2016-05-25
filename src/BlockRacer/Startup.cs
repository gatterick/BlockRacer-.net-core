using System;
using System.IO;
using BlockRacer;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace BlockRacer {
    public class Startup {
   
        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            //services.AddDbContext<BRDbContext>(options =>
            //    options.UseSqlServer("Filename=./blockracer.db"));
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment())
            {
            }
        }
        
        public static void Main(string[] args) {
            Console.WriteLine("hello World");
             var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();
            Console.WriteLine(host);
            host.Run();
            
        }
    }
}