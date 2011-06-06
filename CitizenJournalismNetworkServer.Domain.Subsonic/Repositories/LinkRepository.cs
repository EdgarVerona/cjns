using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class LinkRepository : ILinkRepository
    {

        private SimpleRepository Repository;

        public LinkRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(Link domainEntity)
        {
            this.Repository.Add<Link>(domainEntity);
        }

        public void Delete(int id)
        {
            this.Repository.Delete<Link>(id);
        }

        public IEnumerable<Link> GetAll()
        {
            return this.Repository.All<Link>();
        }

        public Link GetById(int id)
        {
            return this.Repository.Single<Link>(id);
        }

        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(Link domainEntity)
        {
            this.Repository.Update<Link>(domainEntity);
        }

    }
}
