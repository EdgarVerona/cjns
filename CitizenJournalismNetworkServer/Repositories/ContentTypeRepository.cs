using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Repositories
{ 
    public class ContentTypeRepository : IContentTypeRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public IEnumerable<ContentType> GetAllContentTypes()
        {
            return this.context.ContentTypes.ToList();
        }

        public ContentType GetById(int id)
        {
            return this.context.ContentTypes.Find(id);
        }

        public void Add(ContentType contenttype)
        {
            this.context.ContentTypes.Add(contenttype);
        }

        public void Delete(int id)
        {
            var d = this.context.ContentTypes.Find(id);
            this.context.ContentTypes.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface IContentTypeRepository
    {
        void Add(ContentType contenttype);
        void Delete(int id);
        IEnumerable<ContentType> GetAllContentTypes();
        ContentType GetById(int id);
        void Save();
    }
}