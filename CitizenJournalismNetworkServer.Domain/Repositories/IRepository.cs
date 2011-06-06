using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitizenJournalismNetworkServer.Domain.Repositories
{
    public interface IRepository<DomainEntityType>
    {
        void Add(DomainEntityType domainEntity);

        void Delete(int id);

        IEnumerable<DomainEntityType> GetAll();

        DomainEntityType GetById(int id);

        void Save();

        void Update(DomainEntityType domainEntity);
    }
}
