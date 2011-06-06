using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{ 
    public class PersonRepository : Repository, IPersonRepository
    {
        public PersonRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }


        public IEnumerable<Person> GetAll()
        {
            return this.Context.People.ToList();
        }

        public Person GetById(int id)
        {
            return this.Context.People.Find(id);
        }

        public void Add(Person person)
        {
            this.Context.People.Add(person);
        }

        public void Delete(int id)
        {
            var d = this.Context.People.Find(id);
            this.Context.People.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(Person domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}