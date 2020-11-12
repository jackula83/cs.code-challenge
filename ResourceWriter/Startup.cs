using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceServices;

namespace ResourceWriter
{
   public class Startup
   {
      public const string AllowCorsPolicy = "AllowCorsPolicy";

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMediatR(Assembly.GetExecutingAssembly());

         services.AddCors(options =>
            options.AddPolicy(AllowCorsPolicy, builder =>
            {
               builder
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            }));

         services.AddControllers();
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseRouting();

         app.UseCors(AllowCorsPolicy);

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
