using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;
using System.Xml;
using CitizenJournalismNetworkServer.Extensions.Xml;

namespace CitizenJournalismNetworkServer.Factories.Atom
{
    public class AtomEntryFactory: IAtomFactory<Entry>
    {

        private IAtomFactory<Person> _authorFactory;
        private IAtomFactory<Person> _contributorFactory;
        private IAtomFactory<Category> _categoryFactory;
        
        
        public AtomEntryFactory(IAtomFactory<Person> authorFactory, 
                                IAtomFactory<Category> categoryFactory, 
                                IAtomFactory<Person> contributorFactory)
        {
            _authorFactory = authorFactory;
            _categoryFactory = categoryFactory;
            _contributorFactory = contributorFactory;
        }

        #region IAtomFactory<Entry> Members

        public Entry CreateFromAtomXml(string atomXml)
        {
            NameTable nameTable = new NameTable();
            nameTable.Add("atom");
            nameTable.Add("app");

            XmlDocument doc = new XmlDocument(nameTable);
            doc.LoadXml(atomXml);

            return CreateFromAtomXml(doc);
        }


        public Entry CreateFromAtomXml(XmlDocument atomDocument)
        {
            NameTable nameTable = new NameTable();
            nameTable.Add("atom");
            nameTable.Add("app");
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(nameTable);

            return CreateFromAtomXml(atomDocument, namespaceManager);
        }

        public Entry CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager namespaceManager)
        {
            Entry newEntry = new Entry();

            newEntry.AtomId = atomNode.GetNodeValueAsString("/atom:entry/atom:id", namespaceManager, "");
            newEntry.Authors = GetAuthors(atomNode, namespaceManager);

            return newEntry;
        }

        #endregion


        private List<Person> GetAuthors(XmlNode rootNode, XmlNamespaceManager namespaceManager)
        {
            XmlNodeList authors = rootNode.SelectNodes("/atom:entry/atom:author", namespaceManager);
            List<Person> newAuthors = new List<Person>();

            foreach (XmlNode author in authors)
            {
                newAuthors.Add(_authorFactory.CreateFromAtomXml(author, namespaceManager));
            }

            return newAuthors;
        }

    }
}