using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{ 
    public class WorkspaceRepository : Repository, IWorkspaceRepository
    {

        public WorkspaceRepository(CitizenJournalismNetworkServerContext context)
            : base(context)
        {
        }


        public IEnumerable<Workspace> GetAll()
        {
            return this.Context.Workspaces.ToList();
        }

        public Workspace GetById(int id)
        {
            return this.Context.Workspaces.Find(id);
        }

        public void Add(Workspace workspace)
        {
            this.Context.Workspaces.Add(workspace);
        }

        public void Delete(int id)
        {
            var d = this.Context.Workspaces.Find(id);
            this.Context.Workspaces.Remove(d);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Update(Workspace domainEntity)
        {
            // This method left blank: for purposes of standardization with other implementations.
        }
    }

}