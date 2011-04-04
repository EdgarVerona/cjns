using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using System.Xml;
using CitizenJournalismNetworkServer.Kernel.Extensions.Xml;
using CitizenJournalismNetworkServer.Domain.Utilities;

namespace CitizenJournalismNetworkServer.Domain.Factories.Atom
{
    public class AtomContentFactory : AtomFactory<Content>
    {
        #region IAtomFactory<Content> Members

        public override Content CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager nsManager)
        {
            Content result = new Content();

            result.ContentType = atomNode.GetNodeValueAsString("@type", nsManager, "");
            result.SourceUri = atomNode.GetNodeValueAsString("@src", nsManager, "");
            result.Text = atomNode.GetNodeValueAsString(".", nsManager, "");

            return result;
        }

        #endregion
    }
}