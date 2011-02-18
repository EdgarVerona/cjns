using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Models
{
    public class Service
    {
        public virtual ICollection<Workspace> Workspaces { get; set; }
    }
}