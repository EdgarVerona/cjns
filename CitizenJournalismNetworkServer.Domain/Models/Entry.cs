using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Entry : DomainEntity
    {

        public Entry()
        {
            this.Authors = new List<Person>();
            this.Categories = new List<Category>();
            this.Collection = new Collection();
            this.Content = new Content();
            this.Contributors = new List<Person>();
            this.Links = new List<Link>();
        }


        public virtual ICollection<Person> Authors { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual Collection Collection { get; set; }

        public Content Content { get; set; }

        public virtual ICollection<Person> Contributors { get; set; }

        public string AtomId { get; set; }

        public virtual ICollection<Link> Links { get; set; }

        public DateTime? DatePublished { get; set; }

        public string Rights { get; set; }

        public Entry Source { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsDraft { get; set; }



    }
}