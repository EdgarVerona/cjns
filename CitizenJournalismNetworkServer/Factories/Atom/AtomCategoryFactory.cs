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
    public class AtomCategoryFactory : AtomFactory<Category>
    {
        #region IAtomFactory<Category> Members

        public override Category CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager nsManager)
        {
            Category result = new Category();

            result.Label = atomNode.GetNodeValueAsString("@label", nsManager, "");
            result.Scheme = atomNode.GetNodeValueAsString("@scheme", nsManager, "");
            result.Term = atomNode.GetNodeValueAsString("@term", nsManager, "");

            return result;
        }

        #endregion
    }
}