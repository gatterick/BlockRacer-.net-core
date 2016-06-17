using BlockRacer.Repositories;
using BlockRacer.Repositories.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlockRacer.Mvc.Middleware;
using Microsoft.Extensions.Logging;
using Lohmann.HALight.Formatters;

namespace BlockRacer.Configuration {
    ///<summary>
    /// The following class describes what services and application
    /// configurations are needed for this application. The main takeaways
    /// are: Sqllite, Swagger and Mvc and some authentication middleware.
    public class Startup {

        /// <summary>
        /// Used for creating logs.
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="env">Interface to configure the environment.</param>
        /// <param name="loggerFactory">Logger factory.</param>
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Callback for configuring .AspNetCore services.
        /// </summary>
        /// <param name="services">Configuration handle to AspNetCore.</param>
        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services.AddDbContext<BRDbContext>();
            
            //only for dev.
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));     
            
            var logger = loggerFactory.CreateLogger<HalInputFormatter>();
            
            services.AddMvc(options =>
            {                
                options.InputFormatters.Add(new HalInputFormatter(logger));
                options.OutputFormatters.Add(new HalOutputFormatter());
            });

            services.AddSwaggerGen();

            // Dependency Injection.
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
    }
}