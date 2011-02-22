using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CitizenJournalismNetworkServer.Attributes;


namespace CitizenJournalismNetworkServer.Models
{
    public class Feed
    {
        public Feed()
        {
            this.Authors = new List<Person>();
            this.Categories = new List<Category>();
            this.Generator = new Generator();
            this.Entries = new List<Entry>();
            this.Contributors = new List<Person>();
            this.Links = new List<Link>();
        }

        public virtual ICollection<Person> Authors { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Person> Contributors { get; set; }

        public virtual Generator Generator { get; set; }

        public string IconUri { get; set; }

        public string AtomId { get; set; }

        public virtual ICollection<Link> Links { get; set; }

        public string LogoUri { get; set; }

        public string Rights { get; set; }

        public string Subtitle { get; set; }

        public string Title { get; set; }

        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }

    }
}