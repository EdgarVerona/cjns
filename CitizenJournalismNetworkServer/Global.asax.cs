using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CitizenJournalismNetworkServer.Web.Engine;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using CitizenJournalismNetworkServer.Web.Controllers;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Factories;
using CitizenJournalismNetworkServer.Web.ModelBinders;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Injection;
using CitizenJournalismNetworkServer.Domain.Subsonic.Injection;
using CitizenJournalismNetworkServer.Domain.Dapper.Injection;

namespace CitizenJournalismNetworkServer
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "TypeUnpecifiedGeneral", // Route name
                "{controller}", // URL with parameters
                new { controller = "Home", action = "Index", type = "html" } // Parameter defaults
            );

            routes.MapRoute(
                "TypeSpecifiedGeneral", // Route name
                "{controller}.{type}", // URL with parameters
                new { controller = "Home", action = "Index", type = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "TypeUnspecified", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = "html" } // Parameter defaults
            );

            routes.MapRoute(
                "TypeSpecified", // Route name
                "{controller}/{action}/{id}.{type}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // By default, we're going to use EFCodeFirst as our persistence mechanism.
            // Register its repositories and persistence implementations.
            //EFCodeFirstPersistenceInjector persistenceInjector = new EFCodeFirstPersistenceInjector();
            //DapperPersistenceInjector persistenceInjector = new DapperPersistenceInjector();
            SubsonicPersistenceInjector persistenceInjector = new SubsonicPersistenceInjector();
            persistenceInjector.RegisterRepositories(builder);

            // Register any dependent factories.
            RegisterFactories(builder);

            // Register various MVC mechanisms.
            RegisterControllers(builder);
            RegisterModelBinders(builder);

            // Build our IoC Container from the registration rules we've set forth.
            var container = builder.Build();
            
            // Set our IoC container to be the dependency resolver of the application.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Register our MultiOutputViewEngine to route before passing off to the standard Razor engine.
            AreaRegistration.RegisterAllAreas();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MultiOutputViewEngine());
            ViewEngines.Engines.Add(new RazorViewEngine());

            // Register routes and filters as normal.
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }



        private static void RegisterModelBinders(ContainerBuilder builder)
        {
            //+++ TODO: Need to check that this will actually provide the binding we desire.
            builder.RegisterModelBinderProvider();
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(AtomEntryModelBinder).Assembly);
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(CollectionController).Assembly);
        }


        private static void RegisterFactories(ContainerBuilder builder)
        {
            builder.Register<GeneratorFactory>(component => new GeneratorFactory()).As<IGeneratorFactory>();
            builder.Register<FeedFactory>(component => new FeedFactory(component.Resolve<ICollectionRepository>(), component.Resolve<IEntryRepository>(), component.Resolve<IGeneratorFactory>())).As<IFeedFactory>();
        }

    }
}