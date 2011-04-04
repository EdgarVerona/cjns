using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Repositories
{ 
    public class WorkspaceRepository : IWorkspaceRepository
    {
        CitizenJournalismNetworkServerContext context = new CitizenJournalismNetworkServerContext();

        public IEnumerable<Workspace> GetAllWorkspaces()
        {
            return this.context.Workspaces.ToList();
        }

        public Workspace GetById(int id)
        {
            return this.context.Workspaces.Find(id);
        }

        public void Add(Workspace workspace)
        {
            this.context.Workspaces.Add(workspace);
        }

        public void Delete(int id)
        {
            var d = this.context.Workspaces.Find(id);
            this.context.Workspaces.Remove(d);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

	public interface IWorkspaceRepository
    {
        void Add(Workspace workspace);
        void Delete(int id);
        IEnumerable<Workspace> GetAllWorkspaces();
        Workspace GetById(int id);
        void Save();
    }
}