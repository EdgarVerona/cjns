using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public class AtomLinkFactory : IAtomFactory<Link>
    {
        #region IAtomFactory<Link> Members

        public Link CreateFromAtomXml(string atomXml)
        {
            throw new NotImplementedException();
        }

        public Link CreateFromAtomXml(System.Xml.XmlDocument atomDocument)
        {
            throw new NotImplementedException();
        }

        public Link CreateFromAtomXml(System.Xml.XmlNode atomDocument, System.Xml.XmlNamespaceManager nsManager)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}