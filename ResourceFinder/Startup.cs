using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceBusinessEntities.Interfaces.Models;
using ResourceCommonEntities.Interfaces;
using ResourceFinder.Handlers;
using ResourceFinder.Interfaces;
using ResourceServices;

namespace ResourceFinder
{
   public class Startup
   {
      public const string AllowCorsPolicy = "AllowCorsPolicy";

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMediatR(Assembly.GetExecutingAssembly());

         services.AddControllers();

         services.AddSingleton<ISpecialtyFactory, SpecialtyFactoryService>();
         services.AddSingleton<ISalesPersonFactory, SalesPersonFactoryService>();
         services.AddSingleton<ILanguageFactory, LanguageFactoryService>();
         services.AddSingleton<IRosterManager, RosterManagerService>();

         services.AddScoped<IDataAccess, DataAccessService>();

         services.AddCors(options =>
            options.AddPolicy(AllowCorsPolicy, builder =>
            {
               builder
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            }));
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
