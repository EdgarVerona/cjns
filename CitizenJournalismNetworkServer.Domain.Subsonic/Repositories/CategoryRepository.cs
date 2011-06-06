using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private SimpleRepository Repository;

        public CategoryRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(Category domainEntity)
        {
            this.Repository.Add<Category>(domainEntity);
        }

        public void Delete(int id)
        {
            this.Repository.Delete<Category>(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.Repository.All<Category>();
        }

        public Category GetById(int id)
        {
            return this.Repository.Single<Category>(id);
        }

        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(Category domainEntity)
        {
            this.Repository.Update<Category>(domainEntity);
        }

    }
}
