// Startup.cs: Copyright (c) Santosh Kumar Janapala. All rights Reserved

using System;
using DemoAsyncAwait.Concrete;
using DemoAsyncAwait.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DemoAsyncAwait
{
    /// <summary>
    /// Class for Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor for Startup
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets or Sets Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// ConfigureServices Method
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Demo Async Await",
                    Version = "v1",
                    Description = "Demo project for Async Await including the test project",
                    Contact = new OpenApiContact
                    {
                        Name = "Santosh Kumar Janapala",
                        Email = string.Empty,
                        Url = new Uri("https://google.com")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure Method
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IWebHostEnvironment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("TEST"))
            {
                app.UseDeveloperExceptionPage();

                //Enable middleware to serve the generated swagger as a JSON endpoint
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Async Await Api");

                    //To serve SwaggerUI at application's root page
                    //c.RoutePrefix = string.Empty; //enable in production
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
