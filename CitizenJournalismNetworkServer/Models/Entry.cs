using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Enumerations;
using System.ComponentModel.DataAnnotations;
using CitizenJournalismNetworkServer.Attributes;

namespace CitizenJournalismNetworkServer.Models
{
    public class Entry
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGenerationOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<Person> Authors { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        //+++ Temporarily disabled until I figure out how to set up the composite relationship.
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


        public Entry()
        {
            this.Content = new Content();
        }

    }
}