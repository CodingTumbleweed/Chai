using Chai.API.ExceptionHandlers;
using Chai.API.Loggers;
using Chai.API.Utility;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity.WebApi;

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

            //Configure Unity IOC
            var container = UnityConfig.RegisterComponents();
            config.DependencyResolver = new UnityDependencyResolver(container);

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            config.MessageHandlers.Add(new CustomResponseHandler());



        }
    }
}
