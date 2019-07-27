using Chai.API.Controllers;
using Chai.DataService.Contract;
using Chai.DataService.Repository;
using Chai.Models.POCO;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace Chai.API
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
			var container = new UnityContainer();


            // Register new controllers here
            container.RegisterType<AccountController>();
            container.RegisterType<CityController>();

            //ContainerControlledLifetimeManager creates a singleton object 
            //on first call and then returns the same object on subsequent call
            container.RegisterType<IRepository<AccountModel>, AccountRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<CityModel>, CityRepository>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}