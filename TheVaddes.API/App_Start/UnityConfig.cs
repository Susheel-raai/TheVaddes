using System.Web.Http;
using TheVaddes.Data.DAL;
using TheVaddes.Data.IDAL;
using Unity;
using Unity.WebApi;

namespace TheVaddes.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();
      container.RegisterType<IFoodItemsRepository, FoodItemsRepository>();
      container.RegisterType<IUserRepository, UserRepository>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
