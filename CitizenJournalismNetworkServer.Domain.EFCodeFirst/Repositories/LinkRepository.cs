using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;
using CitizenJournalismNetworkServer.Domain.Repositories;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{ 
    public class LinkRepository : Repository, ILinkRepository
    {
        public LinkRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }


        public IEnumerable<Link> GetAll()
        {
            return this.Context.Links.ToList();
        }

        public Link GetById(int id)
        {
            return this.Context.Links.Find(id);
        }

        public void Add(Link link)
        {
            this.Context.Links.Add(link);
        }

        public void Delete(int id)
        {
            var d = this.Context.Links.Find(id);
            this.Context.Links.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(Link domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}