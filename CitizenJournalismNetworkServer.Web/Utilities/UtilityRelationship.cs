using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Enumerations;

namespace CitizenJournalismNetworkServer.Web.Utilities
{
    public class UtilityRelationship
    {

        public static string LinkAlternateAttributeValue = "alternate";
        public static string LinkEnclosureAttributeValue = "enclosure";
        public static string LinkRelatedAttributeValue = "related";
        public static string LinkSelfAttributeValue = "self";
        public static string LinkViaAttributeValue = "via";
        public static string LinkNoneAttributeValue = "";

        public static string GetRelationshipAttributeValue(LinkRelationship rel)
        {
            switch (rel)
            {
                case LinkRelationship.Alternate:
                    return LinkAlternateAttributeValue;
                case LinkRelationship.Enclosure:
                    return LinkEnclosureAttributeValue;
                case LinkRelationship.Related:
                    return LinkRelatedAttributeValue;
                case LinkRelationship.Self:
                    return LinkSelfAttributeValue;
                case LinkRelationship.Via:
                    return LinkViaAttributeValue;
                case LinkRelationship.None:
                default:
                    return LinkNoneAttributeValue;
            }
        }

    }
}