using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{
    public class CollectionRepository : Repository, ICollectionRepository
    {

        public CollectionRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }


        public IEnumerable<Collection> GetAll()
        {
            return this.Context.Collections.ToList();
        }

        public Collection GetById(int id)
        {
            Collection result = this.Context.Collections.Find(id);

            return result;
        }

        public void Add(Collection collection)
        {
            this.Context.Collections.Add(collection);
        }

        public void Delete(int id)
        {
            var d = this.Context.Collections.Find(id);
            this.Context.Collections.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(Collection domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}