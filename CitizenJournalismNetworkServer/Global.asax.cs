using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CitizenJournalismNetworkServer.Engine;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using CitizenJournalismNetworkServer.Controllers;
using CitizenJournalismNetworkServer.Repositories;
using CitizenJournalismNetworkServer.Factories;

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
                "TypeSpecifiedGeneral", // Route name
                "{controller}.{type}", // URL with parameters
                new { controller = "Home", action = "Index", type = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "TypeSpecified", // Route name
                "{controller}/{action}/{id}.{type}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = UrlParameter.Optional } // Parameter defaults
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterFactories(builder);
            RegisterControllers(builder);

            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MultiOutputViewEngine());
            ViewEngines.Engines.Add(new RazorViewEngine());

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }



        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            /* +++ NOTE: Essentially, the above should be doing something like the following for each Controller, wiring up to as many constructor params as it can find.
             * builder.Register<ServiceController>(
                component => new ServiceController(
                    [RESOLVE AS MANY PARAMS AS IT CAN]
                )
            ).InstancePerHttpRequest();
            */
        }


        private static void RegisterRepositories(ContainerBuilder builder)
        {
            // Register repositories with the Builder.
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository()).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository()).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository()).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository()).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository()).As<IContentTypeRepository>();
            builder.Register<CollectionRepository>(component => new CollectionRepository()).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository()).As<ICategoryRepository>();
        }

        private static void RegisterFactories(ContainerBuilder builder)
        {
            builder.Register<GeneratorFactory>(component => new GeneratorFactory()).As<IGeneratorFactory>();
            builder.Register<FeedFactory>(component => new FeedFactory(component.Resolve<ICollectionRepository>(), component.Resolve<IEntryRepository>(), component.Resolve<IGeneratorFactory>())).As<IFeedFactory>();
        }

    }
}