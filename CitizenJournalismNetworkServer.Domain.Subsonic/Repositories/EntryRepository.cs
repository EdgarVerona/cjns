using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class EntryRepository : IEntryRepository
    {

        private SimpleRepository Repository;

        public EntryRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(Entry domainEntity)
        {
            this.Repository.Add<Entry>(domainEntity);
        }

        public void Delete(int id)
        {
            this.Repository.Delete<Entry>(id);
        }

        public IEnumerable<Entry> GetAll()
        {
            return this.Repository.All<Entry>();
        }

        public Entry GetById(int id)
        {
            return this.Repository.Single<Entry>(id);
        }

        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(Entry domainEntity)
        {
            this.Repository.Update<Entry>(domainEntity);
        }

    }
}
