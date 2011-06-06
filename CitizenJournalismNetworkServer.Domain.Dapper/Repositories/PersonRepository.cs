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
    public class PersonRepository: IPersonRepository
    {

        private DapperContext _context;


        public PersonRepository(DapperContext context)
        {
            _context = context;
        }


        public void Add(Person domainEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Person domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
