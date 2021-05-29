using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using API.SignalR;
using API.SignalR.API.SignalR;
using System;
using Microsoft.AspNetCore.Identity;
using Core.Entities;

namespace API
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
            services.AddDbContext<DatingAppDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DatingAppDb"], b => b.MigrationsAssembly("Infrastructure"));
            }, ServiceLifetime.Scoped);

            services.AddApplicationServices(Configuration);
            services.AddIdentityServices(Configuration);
            services.AddControllers();
            services.AddCors();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                //First we define the security scheme
                c.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Id = "Bearer", //The name of the previously defined security scheme.
                Type = ReferenceType.SecurityScheme
            }
        },new List<string>()
    }
});
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                

           // }
           
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors(x => x.WithOrigins(new string[] { "https://localhost:4200","https://localhost:61095", "https://dating.appmediatek.com" }).AllowAnyHeader().AllowAnyMethod().AllowCredentials());//

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PresenceHub>("hubs/presence");
                endpoints.MapHub<MessageHub>("hubs/message");
            });
        }
    }
}
