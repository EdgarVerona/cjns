using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Content
    {
        [Required]
        public string ContentType { get; set; }

        public string SourceUri { get; set; }

        [Required]
        public bool IsExternallySourced 
        {
            get
            {
                return (!string.IsNullOrEmpty(SourceUri));
            }
        }

        public string Text { get; set; }

    }
}