using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class WorkspaceRepository : IWorkspaceRepository
    {

        private SimpleRepository Repository;

        public WorkspaceRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(Workspace domainEntity)
        {
            this.Repository.Add<Workspace>(domainEntity);
        }

        public void Delete(int id)
        {
            this.Repository.Delete<Workspace>(id);
        }

        public IEnumerable<Workspace> GetAll()
        {
            return this.Repository.All<Workspace>();
        }

        public Workspace GetById(int id)
        {
            return this.Repository.Single<Workspace>(id);
        }

        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(Workspace domainEntity)
        {
            this.Repository.Update<Workspace>(domainEntity);
        }

    }
}
