using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public interface IAtomFactory<T>
    {
        T CreateFromAtomXml(string atomXml);

        T CreateFromAtomXml(XmlDocument atomDocument);

        T CreateFromAtomXml(XmlNode atomDocument, XmlNamespaceManager nsManager);
    }
}