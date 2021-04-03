using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using nudgeapi.AutoMapper;
using nudgeapi.Helpers;
using NudgeApi.Contracts.Interfaces;
using NudgeApi.DAL.Laptop;
using NudgeApi.DAL.ShoppingCartDAL;
using NudgeApi.Providers.LaptopProvider;
using NudgeApi.Providers.ObjectProvider;
using NudgeApi.Providers.ShoppingCartProvider;
using NudgeApi.Services.LaptopService;
using NudgeApi.Services.ShoppingService;

namespace nudgeapi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod();
                                  });
            });

            AutoMapperConfigurationsHelper.ConfigureAutomapper(services);

            //Below settings active
            services.AddScoped<ILaptopDAL,LaptopDAL>();
            services.AddScoped<IObjectProvider, ObjectProvider>();
            services.AddScoped<ILaptopProvider, LaptopProvider>();
            services.AddScoped<ILaptopService, LaptopService>();

            services.AddScoped<IShoppingCartDAL, ShoppingCartDAL>();
            services.AddScoped<IShoppingCartProvider, ShoppingCartProvider>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ORXe API");
                options.RoutePrefix = "docs";
                options.DefaultModelExpandDepth(2);
                options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.EnableDeepLinking();
            });

            app.UseReDoc(options =>
            {
                options.RoutePrefix = "api/v1.0";
                options.SpecUrl("/swagger/v1/swagger.json");
                options.EnableUntrustedSpec();
                options.ExpandResponses("200,201");

            });
        }
    }
}
