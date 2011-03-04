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

            result.Href = atomNode.GetNodeValueAsString("@href", nsManager, "");
            result.Language = atomNode.GetNodeValueAsString("@hreflang", nsManager, "");
            result.Length = atomNode.GetNodeValueAsLong("@length", nsManager, null);
            result.RelationshipLiteral = atomNode.GetNodeValueAsString("@rel", nsManager, "");
            result.Title = atomNode.GetNodeValueAsString("@title", nsManager, "");
            result.Type = atomNode.GetNodeValueAsString("@type", nsManager, "");

            return result;
        }

        #endregion
    }
}