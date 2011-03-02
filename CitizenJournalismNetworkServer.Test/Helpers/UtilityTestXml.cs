using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CitizenJournalismNetworkServer.Test.Helpers
{
    public class UtilityTestXml
    {

        public static XmlDocument CreateDocument(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return doc;
        }

        public static XmlNamespaceManager CreateAtomNamespaceManager(XmlDocument doc)
        {
            XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);

            nsManager.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            nsManager.AddNamespace("app", "http://www.w3.org/2007/app");

            return nsManager;
        }

    }
}
