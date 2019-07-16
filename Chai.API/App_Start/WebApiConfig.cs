using Chai.API.ExceptionHandlers;
using Chai.API.Loggers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Chai.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            config.Services.Replace(typeof(IExceptionHandler), new UnhandledExceptionHandler());

            // Web API routes

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            
        }
    }
}
