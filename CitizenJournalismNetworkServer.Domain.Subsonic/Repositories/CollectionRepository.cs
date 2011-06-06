using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Subsonic.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {

        private class CollectionCategory
        {
            // With Subsonic's SimpleRepository, everything (even many-to-many tables)
            // need to have some single identifier column.
            public int Id { get; set; }

            public int CollectionId { get; set; }
            public int CategoryId { get; set; }
        }

        private class CollectionContentType
        {
            // With Subsonic's SimpleRepository, everything (even many-to-many tables)
            // need to have some single identifier column.
            public int Id { get; set; }

            public int CollectionId { get; set; }
            public int ContentTypeId { get; set; }
        }

        private SimpleRepository Repository;

        public CollectionRepository(SimpleRepository repo)
        {
            this.Repository = repo;
        }


        public void Add(Collection domainEntity)
        {
            this.Repository.Add<Collection>(domainEntity);

            foreach (Category category in domainEntity.Categories)
            {
                if (category.Id == 0)
                {
                    this.Repository.Add<Category>(category);
                }

                this.Repository.Add<CollectionCategory>(new CollectionCategory() { CategoryId = category.Id, CollectionId = domainEntity.Id });
            }

            foreach (ContentType contentType in domainEntity.AcceptedTypes)
            {
                if (contentType.Id == 0)
                {
                    this.Repository.Add<ContentType>(contentType);
                }

                this.Repository.Add<CollectionContentType>(new CollectionContentType() { ContentTypeId = contentType.Id, CollectionId = domainEntity.Id });
            }

        }

        public void Delete(int id)
        {
            this.Repository.Delete<Collection>(id);

            this.Repository.DeleteMany<CollectionCategory>(colcat => colcat.CollectionId == id);
            this.Repository.DeleteMany<CollectionContentType>(coltype => coltype.CollectionId == id);
        }

        public IEnumerable<Collection> GetAll()
        {
            List<Collection> results = this.Repository.All<Collection>().ToList();

            // Eager loading, yuck.
            // ... But with SimpleRepository, we'd have to build our own lazy loading infrastructure, which I don't have time for.
            foreach (Collection result in results)
            {
                PopulateCollectionMembers(result);
            }

            return results;
        }

        

        public Collection GetById(int id)
        {
            Collection result = this.Repository.Single<Collection>(id);

            PopulateCollectionMembers(result);

            return result;
        }


        public void Save()
        {
            // This method intentionally left blank.  Sigh.
        }


        public void Update(Collection domainEntity)
        {
            this.Repository.Update<Collection>(domainEntity);
        }



        private void PopulateCollectionMembers(Collection result)
        {
            result.AcceptedTypes = (from ct in this.Repository.All<ContentType>()
                                    join cct in this.Repository.All<CollectionContentType>() on ct.Id equals cct.ContentTypeId
                                    where
                                         cct.CollectionId == result.Id
                                    select ct).ToList();

            result.Categories = (from cat in this.Repository.All<Category>()
                                 join ccat in this.Repository.All<CollectionCategory>() on cat.Id equals ccat.CategoryId
                                 where
                                      ccat.CollectionId == result.Id
                                 select cat).ToList();
        }

    }
}
