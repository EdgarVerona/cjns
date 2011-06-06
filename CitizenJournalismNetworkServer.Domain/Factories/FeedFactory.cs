using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;

namespace CitizenJournalismNetworkServer.Domain.Factories
{

    public interface IFeedFactory
    {
        Feed CreateByCollectionId(int collectionId);
    }

    public class FeedFactory : IFeedFactory
    {
        private ICollectionRepository _collectionRepository;
        private IEntryRepository _entryRepository;
        private IGeneratorFactory _generatorFactory;

        public FeedFactory(ICollectionRepository collectionRepository, IEntryRepository entryRepository, IGeneratorFactory generatorFactory)
        {
            _collectionRepository = collectionRepository;
            _entryRepository = entryRepository;
            _generatorFactory = generatorFactory;
        }

        public Feed CreateByCollectionId(int collectionId)
        {
            Collection collection = _collectionRepository.GetById(collectionId);

            if (collection == null)
            {
                return null;
            }

            ICollection<Entry> entries = (from entry in _entryRepository.GetAll()
                                          where entry.Collection.Id == collectionId
                                          orderby entry.DatePublished descending
                                          select entry).ToList();

            Feed newFeed = new Feed()
            {
                Entries = entries,
                Categories = collection.Categories,
                Authors = new List<Person>(),
                Contributors = new List<Person>(),
                AtomId = collection.AtomId,
                Generator = _generatorFactory.CreateGenerator(),
                Title = collection.Title
            };

            if (entries.Count > 0)
            {
                newFeed.DateUpdated = entries.First().DatePublished.GetValueOrDefault();
            }
            else
            {
                newFeed.DateUpdated = collection.DateCreated;
            }


            return newFeed;
        }
    }
}