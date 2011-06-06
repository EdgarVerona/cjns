using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Dapper.Repositories;

namespace CitizenJournalismNetworkServer.Domain.Dapper.Context
{

    public class DapperContext
    {

        public DbConnection Connection { get; private set; }

        
        // /yaoming
        // It is definitely not worth it to try and get Dapper to emulate Entity Framework's notion of "Context".
        /*
        private CategoryRepository CategoryRepo { get; set; }

        private HashSet<DomainEntity> AddedEntities { get; set; }
        private HashSet<DomainEntity> AcquiredEntities { get; set; }
        private HashSet<int> DeletedIds { get; set; }
        */

        public DapperContext(DbConnection connection)
        {
            this.Connection = connection;

            if (this.Connection.State != System.Data.ConnectionState.Open)
            {
                this.Connection.Open();
            }
            /*
            this.AddedEntities = new HashSet<DomainEntity>();
            this.AcquiredEntities = new HashSet<DomainEntity>();
            this.DeletedIds = new HashSet<int>();

            this.CategoryRepo = new CategoryRepository(this);
             */
        }

        /*
        public void Add(DomainEntity entity)
        {
            AddedEntities.Add(entity);
        }

        public void Delete(int id)
        {
            DeletedIds.Add(id);
        }

        public void Save()
        {
            foreach (DomainEntity entity in this.AcquiredEntities)
            {
                if (!this.DeletedIds.Contains(entity.Id))
                {
                    if (entity is Category)
                    {
                        this.CategoryRepo.UpdateQuery(entity.Id);
                    }
                }
            }

            foreach (DomainEntity entity in this.AddedEntities)
            {
                if (entity is Category)
                {
                    this.CategoryRepo.InsertQuery(entity);
                }

                // Add the item to the acquired entities set.
                this.AcquiredEntities.Add(entity);
            }

            foreach (DomainEntity entity in this.DeletedEntities)
            {
                if (entity is Category)
                {
                    this.CategoryRepo.DeleteQuery(entity.Id);
                }

                // Remove any deleted entity from the acquired entities set.
                this.AcquiredEntities.Remove(entity);
            }

            this.AddedEntities.Clear();
            this.DeletedEntities.Clear();
        }
        */

    }
    
}
