using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Term { get; set; }

        public string Scheme { get; set; }

        public string Label { get; set; }
    }
}