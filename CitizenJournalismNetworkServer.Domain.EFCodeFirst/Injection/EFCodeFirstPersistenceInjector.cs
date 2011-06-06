using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Injection;
using Autofac;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;
using Autofac.Integration.Mvc;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Injection
{

    public class EFCodeFirstPersistenceInjector : IPersistenceInjector
    {

        public void RegisterRepositories(ContainerBuilder builder)
        {
            // Register repositories with the Builder.
            builder.Register<CitizenJournalismNetworkServerContext>(component => new CitizenJournalismNetworkServerContext()).InstancePerHttpRequest();
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IContentTypeRepository>();
            builder.Register<CollectionRepository>(component => new CollectionRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<ICategoryRepository>();
        }



        public void RegisterRepositoriesTest(ContainerBuilder builder)
        {
            // Register repositories with the Builder.
            builder.Register<CitizenJournalismNetworkServerContext>(component => new CitizenJournalismNetworkServerContext()).SingleInstance();
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<IContentTypeRepository>();
            builder.Register<CollectionRepository>(component => new CollectionRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository(component.Resolve<CitizenJournalismNetworkServerContext>())).As<ICategoryRepository>();
        }
    }
}
