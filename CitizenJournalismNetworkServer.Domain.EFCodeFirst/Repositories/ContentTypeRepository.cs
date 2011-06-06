using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{ 
    public class ContentTypeRepository : Repository, IContentTypeRepository
    {

        public ContentTypeRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }



        public IEnumerable<ContentType> GetAll()
        {
            return this.Context.ContentTypes.ToList();
        }

        public ContentType GetById(int id)
        {
            return this.Context.ContentTypes.Find(id);
        }

        public void Add(ContentType contenttype)
        {
            this.Context.ContentTypes.Add(contenttype);
        }

        public void Delete(int id)
        {
            var d = this.Context.ContentTypes.Find(id);
            this.Context.ContentTypes.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(ContentType domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}