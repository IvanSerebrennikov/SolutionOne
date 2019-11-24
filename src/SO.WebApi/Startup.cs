using System;
using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SO.DataAccess.DbContext;
using SO.Domain.AppSettings;

namespace SO.WebApi
{
    public class Startup
    {
        private const string DomainAssemblyName = "SO.Domain";
        private const string DataAccessAssemblyName = "SO.DataAccess";
        private const string InfrastructureAssemblyName = "SO.Infrastructure";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<SolutionOneDbContext>(options =>
                SolutionOneDbContextOptionsConfiguration.Configure(options, Configuration));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SolutionOne API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                c.IncludeXmlComments(GetXmlFilePath(Assembly.GetExecutingAssembly().GetName().Name));
                c.IncludeXmlComments(GetXmlFilePath(DomainAssemblyName));
            });

            services.Configure<RabbitMQSettings>(Configuration.GetSection("rabbitMQ"));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblies = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load(DomainAssemblyName),
                Assembly.Load(DataAccessAssemblyName),
                Assembly.Load(InfrastructureAssemblyName)
            };

            builder.RegisterAssemblyModules(assemblies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolutionOne API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private string GetXmlFilePath(string assemblyName)
        {
            var xmlFile = $"{assemblyName}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            return xmlPath;
        }
    }
}