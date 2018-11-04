using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using POC.EntityFramework.OData.Application.Commands;
using POC.EntityFramework.OData.Application.Queries;
using POC.EntityFramework.OData.Application.Services;
using POC.EntityFramework.OData.Domain.Commands;
using POC.EntityFramework.OData.Domain.Queries;
using POC.EntityFramework.OData.Domain.Repositories;
using POC.EntityFramework.OData.Domain.Services;
using POC.EntityFramework.OData.Infrastructure.Context;
using POC.EntityFramework.OData.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Linq;

namespace POC.EntityFramework.OData
{
    /// <summary>
    /// Classe de configuração da aplicação.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration">Configurações da aplicação.</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Método de configuração de serviços da aplicação.
        /// </summary>
        /// <param name="services">Serviços</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddOData();
            AddBusiness(services);
            AddSwagger(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

        }

        /// <summary>
        /// Método de configuração de pacotes da aplicaçào.
        /// </summary>
        /// <param name="app">Aplicaçào.</param>
        /// <param name="env">Ambiente</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "POC OData"));
            app.UseRouter(ODataContext.ConfigureOData);
            app.UseMvc();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                       new Info
                       {
                           Title = "POC OData",
                           Version = "v1",
                           Description = "POC de teste de odata nas apis."
                       });

                options.IncludeXmlComments("POC.EntityFramework.OData.xml");
            });
        }

        private static void AddBusiness(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICreatePersonCommand, CreatePersonCommand>();
            services.AddScoped<IGetPersonsQuery, GetPersonsQuery>();
            services.AddScoped<IPersonApplicationService, PersonApplicationService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICreateAddressCommand, CreateAddressCommand>();
            services.AddScoped<IGetAddressesByPersonQuery, GetAddressesByPersonQuery>();
            services.AddScoped<IGetAddressesQuery, GetAddressesQuery>();
            services.AddScoped<IAddressApplicationService, AddressApplicationService>();
        }
    }
}