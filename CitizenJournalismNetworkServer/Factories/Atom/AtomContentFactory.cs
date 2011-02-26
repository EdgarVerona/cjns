using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public class AtomContentFactory : IAtomFactory<Content>
    {
        #region IAtomFactory<Content> Members

        public Content CreateFromAtomXml(string atomXml)
        {
            throw new NotImplementedException();
        }

        public Content CreateFromAtomXml(System.Xml.XmlDocument atomDocument)
        {
            throw new NotImplementedException();
        }

        public Content CreateFromAtomXml(System.Xml.XmlNode atomDocument, System.Xml.XmlNamespaceManager nsManager)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}