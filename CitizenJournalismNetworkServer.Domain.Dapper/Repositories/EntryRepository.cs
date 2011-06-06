using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;
using System.Data.Common;
using Dapper;
using CitizenJournalismNetworkServer.Domain.Dapper.Context;


namespace CitizenJournalismNetworkServer.Domain.Dapper.Repositories
{
    public class EntryRepository : IEntryRepository
    {

        private DapperContext _context;


        public EntryRepository(DapperContext context)
        {
            _context = context;
        }




        public void Add(Entry domainEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entry GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Entry domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
