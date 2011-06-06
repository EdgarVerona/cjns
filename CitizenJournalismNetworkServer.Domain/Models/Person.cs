using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Person : DomainEntity
    {

        [Required]
        public string Name { get; set; }

        public string Uri { get; set; }

        public string Email { get; set; }

    }
}