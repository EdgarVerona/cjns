using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Category : DomainEntity
    {
        [Required]
        public string Term { get; set; }

        public string Scheme { get; set; }

        public string Label { get; set; }
    }
}