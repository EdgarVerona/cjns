using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Subsonic.Injection;
using Autofac;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CJNS.PopulateTestData
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();

            // By default, we're going to use EFCodeFirst as our persistence mechanism.
            // Register its repositories and persistence implementations.
            //EFCodeFirstPersistenceInjector persistenceInjector = new EFCodeFirstPersistenceInjector();
            //DapperPersistenceInjector persistenceInjector = new DapperPersistenceInjector();
            SubsonicPersistenceInjector persistenceInjector = new SubsonicPersistenceInjector();
            persistenceInjector.RegisterRepositoriesTest(builder);

            // Build our IoC Container from the registration rules we've set forth.
            var container = builder.Build();


            ICollectionRepository collectionRepo = container.Resolve<ICollectionRepository>();

            Collection col = new Collection()
            {
                AreCategoriesFixed = true,
                AtomId = "testatomid",
                DateCreated = DateTime.UtcNow,
                Title = "TestCategory",
                Href = "blah"
            };

            col.AcceptedTypes.Add(new ContentType() { Text = "text" });
            col.AcceptedTypes.Add(new ContentType() { Text = "mp3" });
            col.AcceptedTypes.Add(new ContentType() { Text = "html" });

            col.Categories.Add(new Category() { Label = "Cool Stuff", Scheme = "", Term = "Cool"});
            col.Categories.Add(new Category() { Label = "Bad Stuff", Scheme = "", Term = "Bad"});

            collectionRepo.Add(col);
            collectionRepo.Save();
        }


    }
}
