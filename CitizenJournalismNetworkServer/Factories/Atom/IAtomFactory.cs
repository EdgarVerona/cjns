using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public interface IAtomFactory<T>
    {
        T CreateFromAtomXml(string atomXml, string xPath);

        T CreateFromAtomXml(XmlDocument atomDocument, string xPath);

        T CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager nsManager);
    }
}