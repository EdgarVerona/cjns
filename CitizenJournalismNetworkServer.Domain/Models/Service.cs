using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Service
    {
        public Service()
        {
            this.Workspaces = new List<Workspace>();
        }

        public virtual IEnumerable<Workspace> Workspaces { get; set; }
    }
}