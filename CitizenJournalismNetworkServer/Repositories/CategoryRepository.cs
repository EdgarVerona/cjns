using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Repositories
{ 
    public class CategoryRepository : ICategoryRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public IEnumerable<Category> GetAllCategories()
        {
            return this.context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return this.context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            this.context.Categories.Add(category);
        }

        public void Delete(int id)
        {
            var d = this.context.Categories.Find(id);
            this.context.Categories.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAllCategories();
        Category GetById(int id);
        void Save();
    }
}