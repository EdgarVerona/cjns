using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public class AtomPersonFactory : IAtomFactory<Person>
    {
        #region IAtomFactory<Person> Members

        public Person CreateFromAtomXml(string atomXml)
        {
            throw new NotImplementedException();
        }

        public Person CreateFromAtomXml(System.Xml.XmlDocument atomDocument)
        {
            throw new NotImplementedException();
        }

        public Person CreateFromAtomXml(System.Xml.XmlNode atomDocument, System.Xml.XmlNamespaceManager nsManager)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}