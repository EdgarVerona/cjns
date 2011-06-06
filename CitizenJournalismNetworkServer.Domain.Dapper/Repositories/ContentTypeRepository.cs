using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;
using System.Data.Common;
using Dapper;
using CitizenJournalismNetworkServer.Domain.Dapper.Context;


namespace CitizenJournalismNetworkServer.Domain.Dapper.Repositories
{
    public class ContentTypeRepository: IContentTypeRepository
    {

        private DapperContext _context;


        public ContentTypeRepository(DapperContext context)
        {
            _context = context;
        }


    
        public void  Add(ContentType domainEntity)
        {
 	        throw new NotImplementedException();
        }

        public void  Delete(int id)
        {
 	        throw new NotImplementedException();
        }

        public IEnumerable<ContentType>  GetAll()
        {
 	        throw new NotImplementedException();
        }

        public ContentType  GetById(int id)
        {
 	        throw new NotImplementedException();
        }

        public void  Save()
        {
 	        throw new NotImplementedException();
        }

        public void  Update(ContentType domainEntity)
        {
 	        throw new NotImplementedException();
        }
    }
}
