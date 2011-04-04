using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace CitizenJournalismNetworkServer.Domain.Factories.Atom
{
    public abstract class AtomFactory<T>: IAtomFactory<T>
    {
        public T CreateFromAtomXml(string atomXml, string xPath)
        {
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(atomXml);

            return CreateFromAtomXml(doc, xPath);
        }


        public T CreateFromAtomXml(XmlDocument atomDocument, string xPath)
        {

            XmlNamespaceManager nsManager = new XmlNamespaceManager(atomDocument.NameTable);
            nsManager.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            nsManager.AddNamespace("app", "http://www.w3.org/2007/app");
            
            // Attempt to obtain the node for the creation of this Entity.
            XmlNode nodeEntity = atomDocument.DocumentElement.SelectSingleNode(xPath);

            return CreateFromAtomXml(nodeEntity, nsManager);
        }

        public abstract T CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager namespaceManager);
    }
}