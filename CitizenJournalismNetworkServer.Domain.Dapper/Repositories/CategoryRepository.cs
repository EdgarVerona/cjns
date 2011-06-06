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
    public class CategoryRepository: ICategoryRepository
    {

        private DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }


        public void Add(Category domainEntity)
        {
            string query = @"
                INSERT INTO Categories (Term, Scheme, Label)
                VALUES (@Term, @Scheme, @Label)
                SELECT @@IDENTITY;
                ";

            int newId = _context.Connection.Query<int>(query,
                                        new
                                        {
                                            Term = domainEntity.Term,
                                            Scheme = domainEntity.Scheme,
                                            Label = domainEntity.Label
                                        }).FirstOrDefault();

            if (newId != default(int))
            {
                domainEntity.Id = newId;
            }
        }



        public void Delete(int id)
        {
            string query = @"
                DELETE FROM Categories 
                WHERE Id = @ID";

            _context.Connection.Execute(
                query,
                new
                {
                    ID = id
                });
        }


        public void Update(Category domainEntity)
        {
            string query = @"
                UPDATE Categories 
                SET
                    Term = @Term,
                    Scheme = @Scheme,
                    Label = @Label
                WHERE Id = @ID";

            _context.Connection.Execute(
                query,
                new
                {
                    Term = domainEntity.Term,
                    Scheme = domainEntity.Scheme,
                    Label = domainEntity.Label,
                    ID = domainEntity.Id
                });
        }

        public IEnumerable<Category> GetAll()
        {
            string query = @"
                SELECT
                    *
                FROM
                    Categories";

            return _context.Connection.Query<Category>(query);
        }



        public Category GetById(int id)
        {
            string query = @"
                SELECT
                    *
                FROM
                    Categories
                WHERE
                    ID = @ID";

            return _context.Connection.Query<Category>(query, new { ID = id }).FirstOrDefault();
        }


        public void Save()
        {
            // This method Intentionally left blank. ;)
        }


    }
}
