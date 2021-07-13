using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Test.Data;
using Test.Data.Repository;
using Test.Services.Services;

namespace Test.Backend
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test.Backend", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<DataContext>(x =>
                    x.UseNpgsql(Configuration.GetConnectionString("default"))
                        .EnableSensitiveDataLogging(),
                ServiceLifetime.Transient);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAnalyticService, AnalyticService>();


            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "./ClientApp";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test.Backend v1"));

            if (env.IsStaging())
            {
                app.UseStaticFiles();
                app.UseSpaStaticFiles();
                app.UseSpa(spa => { spa.Options.SourcePath = "ClientApp"; });
            }


            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetService<DataContext>();
            ctx?.Database.Migrate();
        }
    }
}
