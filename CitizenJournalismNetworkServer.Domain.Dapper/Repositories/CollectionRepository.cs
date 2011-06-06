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
    public class CollectionRepository: ICollectionRepository
    {

        private DapperContext _context;


        public CollectionRepository(DapperContext context)
        {
            _context = context;
        }


        public void Add(Collection domainEntity)
        {
            string query = @"
                INSERT INTO Collections (AreCategoriesFixed, AtomId, DateCreated, Title)
                VALUES (@AreCategoriesFixed, @AtomId, @DateCreated, Title);
                SELECT @@IDENTITY;";

            int newId = _context.Connection.Query<int>(query,
                                        new
                                        {
                                            AreCategoriesFixed = domainEntity.AreCategoriesFixed,
                                            AtomId = domainEntity.AtomId,
                                            DateCreated = domainEntity.DateCreated,
                                            Title = domainEntity.Title,
                                        }).FirstOrDefault();

            if (newId != default(int))
            {
                domainEntity.Id = newId;
            }
        }



        public void Delete(int id)
        {
            string query = @"
                DELETE FROM Collections 
                WHERE Id = @ID;
                DELETE FROM CollectionCategories
                WHERE Collection_Id = @ID;
                DELETE FROM CollectionContentTypes
                WHERE Collection_Id = @ID;";

            _context.Connection.Execute(
                query,
                new
                {
                    ID = id
                });
        }


        public void Update(Collection domainEntity)
        {
            string query = @"
                UPDATE Collections 
                SET
                    AreCategoriesFixed = @AreCategoriesFixed,
                    AtomId = @AtomId,
                    DateCreated = @DateCreated,
                    Title = @Title
                WHERE Id = @ID";

            _context.Connection.Execute(
                query,
                new
                {
                    AreCategoriesFixed = domainEntity.AreCategoriesFixed,
                    AtomId = domainEntity.AtomId,
                    DateCreated = domainEntity.DateCreated,
                    Title = domainEntity.Title,
                    ID = domainEntity.Id
                });
        }

        public IEnumerable<Collection> GetAll()
        {

            // An example of querying for and using a single joined query.
            string query = @"
                SELECT 
                    Collections.*,
                    ContentTypes.*,
                    Categories.*
                FROM 
                    Collections
                    LEFT OUTER JOIN CollectionContentTypes
                        ON CollectionContentTypes.Collection_Id = Collections.Id
                    LEFT OUTER JOIN ContentTypes 
                        ON ContentTypes.Id = CollectionContentTypes.ContentType_Id
                    LEFT OUTER JOIN CollectionCategories
                        ON CollectionCategories.Collection_Id = Collections.Id
                    LEFT OUTER JOIN Categories 
                        ON Categories.Id = CollectionCategories.Category_Id";

            Dictionary<int, Collection> collections = new Dictionary<int, Collection>();

            return _context.Connection.Query<Collection, ContentType, Category, Collection>(query,
                (collection, contentType, category) => 
                {
                    Collection existing = null;

                    if (!collections.TryGetValue(collection.Id, out existing))
                    {
                        collections.Add(collection.Id, collection);
                        existing = collection;
                    }
                    if (existing.AcceptedTypes.Where(type => type.Id == contentType.Id).Count() == 0)
                    {
                        existing.AcceptedTypes.Add(contentType);
                    }
                    if (existing.Categories.Where(cat => cat.Id == category.Id).Count() == 0)
                    {
                        existing.Categories.Add(category);
                    }
                    return existing;
                }).Distinct();
        }



        public Collection GetById(int id)
        {
            Collection result = null;

            // An example of querying for and using multiple result sets.
            string query =
            @"
            SELECT * FROM Collections WHERE Id = @ID
            SELECT ContentTypes.* 
                FROM ContentTypes 
                INNER JOIN CollectionContentTypes
                    ON ContentTypes.Id = CollectionContentTypes.ContentType_Id
                WHERE CollectionContentTypes.Collection_Id = @ID
            SELECT Categories.* 
                FROM Categories 
                INNER JOIN CollectionCategories
                    ON Categories.Id = CollectionCategories.Category_Id
                WHERE CollectionCategories.Collection_Id = @ID";

            using (var multi = _context.Connection.QueryMultiple(query, new { ID = id }))
            {
                result = multi.Read<Collection>().Single();
                if (result != null)
                {
                    result.AcceptedTypes = multi.Read<ContentType>().ToList();
                    result.Categories = multi.Read<Category>().ToList();
                }
            }

            return result;
        }


        public void Save()
        {
            // This method Intentionally left blank. ;)
        }


    }
}
