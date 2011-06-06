using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Injection;
using Autofac;
using CitizenJournalismNetworkServer.Domain.Subsonic.Repositories;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using Autofac.Integration.Mvc;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Injection
{
    public class SubsonicPersistenceInjector : IPersistenceInjector
    {
        public void RegisterRepositories(ContainerBuilder builder)
        {
            builder.Register<SimpleRepository>(component => new SimpleRepository("CitizenJournalismNetworkServerContextSubsonic", SimpleRepositoryOptions.RunMigrations)).InstancePerHttpRequest();
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository(component.Resolve<SimpleRepository>())).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository(component.Resolve<SimpleRepository>())).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository(component.Resolve<SimpleRepository>())).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository(component.Resolve<SimpleRepository>())).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository(component.Resolve<SimpleRepository>())).As<IContentTypeRepository>();
            builder.Register<CollectionRepository>(component => new CollectionRepository(component.Resolve<SimpleRepository>())).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository(component.Resolve<SimpleRepository>())).As<ICategoryRepository>();
        }


        public void RegisterRepositoriesTest(ContainerBuilder builder)
        {
            builder.Register<SimpleRepository>(component => new SimpleRepository("CitizenJournalismNetworkServerContextSubsonic", SimpleRepositoryOptions.RunMigrations)).SingleInstance();
            builder.Register<WorkspaceRepository>(component => new WorkspaceRepository(component.Resolve<SimpleRepository>())).As<IWorkspaceRepository>();
            builder.Register<PersonRepository>(component => new PersonRepository(component.Resolve<SimpleRepository>())).As<IPersonRepository>();
            builder.Register<LinkRepository>(component => new LinkRepository(component.Resolve<SimpleRepository>())).As<ILinkRepository>();
            builder.Register<EntryRepository>(component => new EntryRepository(component.Resolve<SimpleRepository>())).As<IEntryRepository>();
            builder.Register<ContentTypeRepository>(component => new ContentTypeRepository(component.Resolve<SimpleRepository>())).As<IContentTypeRepository>();
            builder.Register<CollectionRepository>(component => new CollectionRepository(component.Resolve<SimpleRepository>())).As<ICollectionRepository>();
            builder.Register<CategoryRepository>(component => new CategoryRepository(component.Resolve<SimpleRepository>())).As<ICategoryRepository>();
        }
    }
}
