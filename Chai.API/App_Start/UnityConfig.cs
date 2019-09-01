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
          
            //Register new IOC mappings here
            container.RegisterType<IRepository<AccountModel>, AccountRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<CityModel>, CityRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<StateModel>, StateRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<CountryModel>, CountryRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<GenderModel>, GenderRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<AppConfigModel>, AppConfigRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<PasswordRecoveryModel>, PasswordRepository>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}