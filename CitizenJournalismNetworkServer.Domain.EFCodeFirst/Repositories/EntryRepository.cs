using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{ 
    public class EntryRepository : Repository, IEntryRepository
    {

        public EntryRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }


        public IEnumerable<Entry> GetAll()
        {
            return this.Context.Entries.ToList();
        }

        public Entry GetById(int id)
        {
            return this.Context.Entries.Find(id);
        }

        public void Add(Entry entry)
        {
            this.Context.Entries.Add(entry);
        }

        public void Delete(int id)
        {
            var d = this.Context.Entries.Find(id);
            this.Context.Entries.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(Entry domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}