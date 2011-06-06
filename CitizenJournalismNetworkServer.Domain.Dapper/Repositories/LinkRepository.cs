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
    public class LinkRepository: ILinkRepository
    {

        private DapperContext _context;


        public LinkRepository(DapperContext context)
        {
            _context = context;
        }



        public void Add(Link domainEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Link> GetAll()
        {
            throw new NotImplementedException();
        }

        public Link GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Link domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
