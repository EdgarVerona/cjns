using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{ 
    public class CategoryRepository : Repository, ICategoryRepository
    {

        public CategoryRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }


        public IEnumerable<Category> GetAll()
        {
            return this.Context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return this.Context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            this.Context.Categories.Add(category);
        }

        public void Delete(int id)
        {
            var d = this.Context.Categories.Find(id);
            this.Context.Categories.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(Category domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}