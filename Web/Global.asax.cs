using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    using AutoMapper;

    using Castle.Facilities.FactorySupport;
    using Castle.Facilities.TypedFactory;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Models;

    using Plumbing;

   

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container
;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "public" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Products", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .AddFacility<FactorySupportFacility>()
                .AddFacility<TypedFactoryFacility>()
                .Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            Mapper.Initialize(x => GetProfiles().ToList().ForEach(type => x.AddProfile((Profile)container.Resolve(type))));
            Mapper.AssertConfigurationIsValid();

        }

        private static IEnumerable<Type> GetProfiles()
        {
            foreach (Type type in typeof(ProductProfile).Assembly.GetTypes())
            {
                if (!type.IsAbstract && typeof(Profile).IsAssignableFrom(type))
                    yield return type;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
           
          //  ModelBinders.Binders.DefaultBinder = new SmartBinder(new EntityModelBinder());
            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}