using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Library.Interfaces;
using Library.Logic;

namespace Library
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IBooksRentalLogic, BookRentalLogic>();
            container.RegisterType<IClientLogic, ClientLogic>();
            container.RegisterType<IBookLogic, BookLogic>();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}