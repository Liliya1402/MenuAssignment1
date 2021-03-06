using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAssignment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllers();
            services.AddSwaggerGen(
                c =>
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Restarant Api Help"
                })
                );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/mylog-{Date}.log");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI( c=>
              { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Api");
                  c.SwaggerEndpoint("/swagger/v2/swagger.json", "Test Api");
                  c.RoutePrefix = string.Empty;
        });
               
            

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
            });
        }
    }
}
