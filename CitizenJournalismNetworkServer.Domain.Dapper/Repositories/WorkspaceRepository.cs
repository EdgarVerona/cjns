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
    public class WorkspaceRepository: IWorkspaceRepository
    {

        private DapperContext _context;


        public WorkspaceRepository(DapperContext context)
        {
            _context = context;
        }




        public void Add(Workspace domainEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Workspace> GetAll()
        {
            throw new NotImplementedException();
        }

        public Workspace GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Workspace domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
