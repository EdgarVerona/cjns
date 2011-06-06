using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Workspace : DomainEntity
    {
        public Workspace()
        {
            this.Collections = new List<Collection>();
        }
        
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }

    }
}