using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string Href { get; set; }

        [Required]
        public LinkRelationship Rel { get; set; }

        [Required]
        public string Type { get; set; }

        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        public long? Length { get; set; }

    }
}