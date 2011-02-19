using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Repositories
{ 
    public class LinkRepository : ILinkRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public IEnumerable<Link> GetAllLinks()
        {
            return this.context.Links.ToList();
        }

        public Link GetById(int id)
        {
            return this.context.Links.Find(id);
        }

        public void Add(Link link)
        {
            this.context.Links.Add(link);
        }

        public void Delete(int id)
        {
            var d = this.context.Links.Find(id);
            this.context.Links.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface ILinkRepository
    {
        void Add(Link link);
        void Delete(int id);
        IEnumerable<Link> GetAllLinks();
        Link GetById(int id);
        void Save();
    }
}