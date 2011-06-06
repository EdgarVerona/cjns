using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Injection;
using CitizenJournalismNetworkServer.Domain.Dapper.Repositories;
using CitizenJournalismNetworkServer.Domain.Dapper.Context;
using CitizenJournalismNetworkServer.Domain.Repositories;
using System.Data.SqlClient;
using System.Configuration;
using Autofac;
using Autofac.Integration.Mvc;

namespace CitizenJournalismNetworkServer.Domain.Dapper.Injection
{


    public class DapperPersistenceInjector : IPersistenceInjector
    {

        public void RegisterRepositories(ContainerBuilder builder)
        {
            // Register repositories with the Builder.
            builder.Register<DapperContext>(component => new DapperContext(new SqlConnection(ConfigurationManager.ConnectionStrings["CitizenJournalismNetworkServerContext"].ConnectionString))).InstancePerHttpRequest();
            
            // I implemented these... but the rest...
            builder.Register<CollectionRepository>(component => new CollectionRepository(component.Resolve<DapperContext>())).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository(component.Resolve<DapperContext>())).As<ICategoryRepository>();

            // Got bored, not going to bother with these ones.  Dapper's pretty tedious for building up a full ORM solution.
            // They exist, but they're just placeholders: if you try to use them for now, you'll get NotImplementedExceptions.
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository(component.Resolve<DapperContext>())).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository(component.Resolve<DapperContext>())).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository(component.Resolve<DapperContext>())).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository(component.Resolve<DapperContext>())).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository(component.Resolve<DapperContext>())).As<IContentTypeRepository>();
        }


        public void RegisterRepositoriesTest(ContainerBuilder builder)
        {
            // Register repositories with the Builder.
            builder.Register<DapperContext>(component => new DapperContext(new SqlConnection(ConfigurationManager.ConnectionStrings["CitizenJournalismNetworkServerContext"].ConnectionString))).SingleInstance();

            // I implemented these... but the rest...
            builder.Register<CollectionRepository>(component => new CollectionRepository(component.Resolve<DapperContext>())).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository(component.Resolve<DapperContext>())).As<ICategoryRepository>();

            // Got bored, not going to bother with these ones.  Dapper's pretty tedious for building up a full ORM solution.
            // They exist, but they're just placeholders: if you try to use them for now, you'll get NotImplementedExceptions.
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository(component.Resolve<DapperContext>())).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository(component.Resolve<DapperContext>())).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository(component.Resolve<DapperContext>())).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository(component.Resolve<DapperContext>())).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository(component.Resolve<DapperContext>())).As<IContentTypeRepository>();
        }
    }

}
