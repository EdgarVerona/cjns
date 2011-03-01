using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Enumerations;
using System.ComponentModel.DataAnnotations;
using CitizenJournalismNetworkServer.Constants;

namespace CitizenJournalismNetworkServer.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string Href { get; set; }

        
        public LinkRelationship RelationshipType 
        {
            get
            {
                switch (RelationshipLiteral.ToLower())
                {
                    case LinkRelationshipConstants.Alternate:
                        return LinkRelationship.Alternate;
                    case LinkRelationshipConstants.Enclosure:
                        return LinkRelationship.Enclosure;
                    case LinkRelationshipConstants.Related:
                        return LinkRelationship.Related;
                    case LinkRelationshipConstants.Self:
                        return LinkRelationship.Self;
                    case LinkRelationshipConstants.Via:
                        return LinkRelationship.Via;
                    default:
                        return LinkRelationship.Alternate;
                }
            }
        }

        [Required]
        public string RelationshipLiteral { get; set; }

        [Required]
        public string Type { get; set; }

        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        public long? Length { get; set; }

    }
}