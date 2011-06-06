using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context;

namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Repositories
{

    public abstract class Repository
    {

        protected CitizenJournalismNetworkServerContext Context { get; set; } 


        public Repository(CitizenJournalismNetworkServerContext context)
        {
            this.Context = context;
        }


    }

}
