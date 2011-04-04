using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class MediaContent
    {
        public string ContentType { get; set; }
        public string ContentBase64 { get; set; }
        public string SlugData { get; set; }

    }
}