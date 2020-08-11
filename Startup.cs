using System.Globalization;
using AutoMapper;
using KensMort.MappingProfiles;
using KensMort.Repositories;
using KensMort.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using KensMort.Helpers;
using Microsoft.AspNetCore.Localization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace KensMort
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
            services.AddOptions();
            services.AddDbContext<TestDbContext>(opt => 
                opt.UseInMemoryDatabase("KensMort"));
            services.AddCustomCors("AllowAllOrigins");
            
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IScenarioRepository, ScenarioRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IScenarioService, ScenarioService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddVersioning();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(PortfolioMappings));
            services.AddAutoMapper(typeof(LoanMappings));
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-GB");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            ILoggerFactory loggerFactory, 
            IWebHostEnvironment env, 
            IApiVersionDescriptionProvider provider)
        {

            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture("en-GB");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.AddProductionExceptionHandling(loggerFactory);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseRequestLocalization(localizationOptions);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
