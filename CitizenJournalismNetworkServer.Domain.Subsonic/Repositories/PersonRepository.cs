using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private SimpleRepository Repository;

        public PersonRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(Person domainEntity)
        {
            this.Repository.Add<Person>(domainEntity);
        }

        public void Delete(int id)
        {
            this.Repository.Delete<Person>(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return this.Repository.All<Person>();
        }

        public Person GetById(int id)
        {
            return this.Repository.Single<Person>(id);
        }

        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(Person domainEntity)
        {
            this.Repository.Update<Person>(domainEntity);
        }

    }
}
