using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public class AtomCategoryFactory : IAtomFactory<Category>
    {
        #region IAtomFactory<Category> Members

        public Category CreateFromAtomXml(string atomXml)
        {
            throw new NotImplementedException();
        }

        public Category CreateFromAtomXml(System.Xml.XmlDocument atomDocument)
        {
            throw new NotImplementedException();
        }

        public Category CreateFromAtomXml(System.Xml.XmlNode atomDocument, System.Xml.XmlNamespaceManager nsManager)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}