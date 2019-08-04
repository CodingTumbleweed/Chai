using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;
using Swashbuckle.Application;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Chai.API.App_Start.Startup))]
namespace Chai.API.App_Start
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; set; } = new HttpConfiguration();

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = Startup.HttpConfiguration;

            var json = config.Formatters.JsonFormatter.SerializerSettings;
            //json.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            
            //HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);

            ConfigureSwashbuckle(config);

            AutoMapperConfig.Initialize();
        }

        private void ConfigureSwashbuckle(HttpConfiguration config)
        {
            //config.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
            //    .EnableSwaggerUi();
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Chai API");
                    var xmlDocPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\Chai.API.xml";
                    c.IncludeXmlComments(xmlDocPath);
                })
                .EnableSwaggerUi();
        }
    }
}