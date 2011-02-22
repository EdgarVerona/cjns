using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Models
{
    public class Workspace
    {
        public Workspace()
        {
            this.Collections = new List<Collection>();
        }
        
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }

    }
}