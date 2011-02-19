using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Repositories
{ 
    public class EntryRepository : IEntryRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public IEnumerable<Entry> GetAllEntries()
        {
            return this.context.Entries.ToList();
        }

        public Entry GetById(int id)
        {
            return this.context.Entries.Find(id);
        }

        public void Add(Entry entry)
        {
            this.context.Entries.Add(entry);
        }

        public void Delete(int id)
        {
            var d = this.context.Entries.Find(id);
            this.context.Entries.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface IEntryRepository
    {
        void Add(Entry entry);
        void Delete(int id);
        IEnumerable<Entry> GetAllEntries();
        Entry GetById(int id);
        void Save();
    }
}