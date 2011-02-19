using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Repositories
{ 
    public class CollectionRepository : ICollectionRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public CollectionRepository()
        {
        }

        public IEnumerable<Collection> GetAllCollections()
        {
            return this.context.Collections.ToList();
        }

        public Collection GetById(int id)
        {
            Collection result = this.context.Collections.Find(id);

            return result;
        }

        public void Add(Collection collection)
        {
            this.context.Collections.Add(collection);
        }

        public void Delete(int id)
        {
            var d = this.context.Collections.Find(id);
            this.context.Collections.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface ICollectionRepository
    {
        void Add(Collection collection);
        void Delete(int id);
        IEnumerable<Collection> GetAllCollections();
        Collection GetById(int id);
        void Save();
    }
}