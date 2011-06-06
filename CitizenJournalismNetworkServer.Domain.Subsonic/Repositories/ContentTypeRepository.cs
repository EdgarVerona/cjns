using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class ContentTypeRepository : IContentTypeRepository
    {

        private SimpleRepository Repository;

        public ContentTypeRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(ContentType domainEntity)
        {
            this.Repository.Add<ContentType>(domainEntity);
        }

        public void Delete(int id)
        {
            this.Repository.Delete<ContentType>(id);
        }

        public IEnumerable<ContentType> GetAll()
        {
            return this.Repository.All<ContentType>();
        }

        public ContentType GetById(int id)
        {
            return this.Repository.Single<ContentType>(id);
        }

        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(ContentType domainEntity)
        {
            this.Repository.Update<ContentType>(domainEntity);
        }

    }
}
