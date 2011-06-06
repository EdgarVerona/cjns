using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Factories;
using CitizenJournalismNetworkServer.Domain.Models;
using NUnit.Framework;
using Moq;
using CitizenJournalismNetworkServer.Domain.Repositories;

namespace CitizenJournalismNetworkServer.Test.Factories
{
    [TestFixture]
    public class FeedFactoryTests
    {
        private FeedFactory _factory;

        private const int CollectionSingleId = 1;
        private const int CollectionMultipleId = 2;
        private const int CollectionEmptyId = 3;
        private const int CollectionNonexistantId = 4;

        private const string CollectionSingleAtomId = "24601";
        private const string CollectionMultipleAtomId = "24602";
        private const string CollectionEmptyAtomId = "24603";

        [TestFixtureSetUp]
        public void Setup()
        {
            Collection collectionSingle = new Collection()
            {
                AreCategoriesFixed = true,
                AtomId = CollectionSingleAtomId,
                DateCreated = DateTime.Now,
                Href = "testHref",
                Id = CollectionSingleId,
                Title = "SingleItemCollection"
            };
            Collection collectionMultiple = new Collection()
            {
                AreCategoriesFixed = true,
                AtomId = CollectionMultipleAtomId,
                DateCreated = DateTime.Now,
                Href = "testHref2",
                Id = CollectionMultipleId,
                Title = "MultipleItemCollection"
            };
            Collection collectionEmpty = new Collection()
            {
                AreCategoriesFixed = true,
                AtomId = CollectionEmptyAtomId,
                DateCreated = DateTime.Now,
                Href = "testHref3",
                Id = CollectionEmptyId,
                Title = "EmptyItemCollection"
            };
            Entry entrySingle = new Entry()
            {
                AtomId = "SingleEntry",
                Collection = collectionSingle
            };
            Entry entryMultipleFirst = new Entry()
            {
                AtomId = "entryMultipleFirst",
                Collection = collectionMultiple
            };
            Entry entryMultipleSecond = new Entry()
            {
                AtomId = "entryMultipleSecond",
                Collection = collectionMultiple
            };

            List<Collection> collections = new List<Collection>();
            collections.Add(collectionSingle);
            collections.Add(collectionMultiple);
            collections.Add(collectionEmpty);

            List<Entry> entries = new List<Entry>();
            entries.Add(entrySingle);
            entries.Add(entryMultipleFirst);
            entries.Add(entryMultipleSecond);

            Mock<ICollectionRepository> mockCollectionRepo = new Mock<ICollectionRepository>();
            mockCollectionRepo.Setup(repo => repo.GetAll()).Returns(collections);
            mockCollectionRepo.Setup(repo => repo.GetById(CollectionSingleId)).Returns(collectionSingle);
            mockCollectionRepo.Setup(repo => repo.GetById(CollectionMultipleId)).Returns(collectionMultiple);
            mockCollectionRepo.Setup(repo => repo.GetById(CollectionEmptyId)).Returns(collectionEmpty);
            mockCollectionRepo.Setup(repo => repo.GetById(CollectionNonexistantId)).Returns((Collection)null);
            Mock<IEntryRepository> mockEntryRepo = new Mock<IEntryRepository>();
            mockEntryRepo.Setup(repo => repo.GetAll()).Returns(entries);

            // Use the mock Collection and Entry repos, and the real Generator Repo because it doesn't matter.
            _factory = new FeedFactory(mockCollectionRepo.Object, mockEntryRepo.Object, new GeneratorFactory());
        }

        [Test]
        public void CreateByCollectionId_NotFound_Null()
        {
            Feed newFeed = _factory.CreateByCollectionId(CollectionNonexistantId);

            Assert.IsNull(newFeed);
        }

		[Test]
        public void CreateByCollectionId_SingleEntry_Success()
        {
            Feed newFeed = _factory.CreateByCollectionId(CollectionSingleId);

            Assert.AreEqual(CollectionSingleAtomId, newFeed.AtomId);
            Assert.AreEqual(1, newFeed.Entries.Count);
        }

		[Test]
        public void CreateByCollectionId_MultipleEntry_Success()
        {
            Feed newFeed = _factory.CreateByCollectionId(CollectionMultipleId);

            Assert.AreEqual(CollectionMultipleAtomId, newFeed.AtomId);
            Assert.AreEqual(2, newFeed.Entries.Count);
        }

		[Test]
        public void CreateByCollectionId_NoEntries_Success()
        {
            Feed newFeed = _factory.CreateByCollectionId(CollectionEmptyId);

            Assert.AreEqual(CollectionEmptyAtomId, newFeed.AtomId);
            Assert.AreEqual(0, newFeed.Entries.Count);
        }

    }
}
