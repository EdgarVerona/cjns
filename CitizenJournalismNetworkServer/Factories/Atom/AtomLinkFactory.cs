using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;
using System.Xml;
using CitizenJournalismNetworkServer.Extensions.Xml;
using CitizenJournalismNetworkServer.Utility;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public class AtomLinkFactory : AtomFactory<Link>
    {
        #region IAtomFactory<Link> Members

        
        public override Link CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager nsManager)
        {
            Link result = new Link();

            result.Href = atomNode.GetNodeValueAsString("@atom:href", nsManager, "");
            result.Language = atomNode.GetNodeValueAsString("@atom:hreflang", nsManager, "");
            result.Length = atomNode.GetNodeValueAsLong("@atom:length", nsManager, 0);
            result.RelationshipLiteral = atomNode.GetNodeValueAsString("@atom:rel", nsManager, "");
            result.Title = atomNode.GetNodeValueAsString("@atom:title", nsManager, "");
            result.Type = atomNode.GetNodeValueAsString("@atom:type", nsManager, "");

            return result;
        }

        #endregion
    }
}