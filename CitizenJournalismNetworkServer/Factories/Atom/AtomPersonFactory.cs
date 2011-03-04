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
    public class AtomPersonFactory : AtomFactory<Person>
    {
        #region IAtomFactory<Person> Members

        
        public override Person CreateFromAtomXml(System.Xml.XmlNode atomNode, System.Xml.XmlNamespaceManager nsManager)
        {
            Person result = new Person();

            result.Email = atomNode.GetNodeValueAsString("atom:email", nsManager, "");
            result.Name = atomNode.GetNodeValueAsString("atom:name", nsManager, "");
            result.Uri = atomNode.GetNodeValueAsString("atom:uri", nsManager, "");

            return result;
        }

        #endregion
    }
}