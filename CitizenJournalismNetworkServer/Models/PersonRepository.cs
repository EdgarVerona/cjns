using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Models
{ 
    public class PersonRepository : IPersonRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public IEnumerable<Person> GetAllPeople()
        {
            return this.context.People.ToList();
        }

        public Person GetById(int id)
        {
            return this.context.People.Find(id);
        }

        public void Add(Person person)
        {
            this.context.People.Add(person);
        }

        public void Delete(int id)
        {
            var d = this.context.People.Find(id);
            this.context.People.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface IPersonRepository
    {
        void Add(Person person);
        void Delete(int id);
        IEnumerable<Person> GetAllPeople();
        Person GetById(int id);
        void Save();
    }
}