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
    public class AtomEntryFactory: IAtomFactory<Entry>
    {
        private IAtomFactory<Person> _authorFactory;
        private IAtomFactory<Person> _contributorFactory;
        private IAtomFactory<Category> _categoryFactory;
        private IAtomFactory<Link> _linkFactory;
        private IAtomFactory<Content> _contentFactory;
        
        
        public AtomEntryFactory(IAtomFactory<Person> authorFactory, 
                                IAtomFactory<Category> categoryFactory, 
                                IAtomFactory<Person> contributorFactory,
                                IAtomFactory<Link> linkFactory,
                                IAtomFactory<Content> contentFactory)
        {
            _authorFactory = authorFactory;
            _categoryFactory = categoryFactory;
            _contributorFactory = contributorFactory;
            _linkFactory = linkFactory;
            _contentFactory = contentFactory;
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
            newEntry.DatePublished = atomNode.GetNodeValueAsDateTime("/atom:entry/atom:published", namespaceManager, null);
            newEntry.DateUpdated = atomNode.GetNodeValueAsDateTime("/atom:entry/atom:updated", namespaceManager, DateTime.Now);
            newEntry.IsDraft = atomNode.GetNodeValueAsBoolean("/atom:entry/atom:id", namespaceManager, false);
            newEntry.Rights = atomNode.GetNodeValueAsString("/atom:entry/atom:rights", namespaceManager, "");
            newEntry.Summary = atomNode.GetNodeValueAsString("/atom:entry/atom:summary", namespaceManager, "");
            newEntry.Title = atomNode.GetNodeValueAsString("/atom:entry/atom:title", namespaceManager, "");

            newEntry.Links = UtilityAtomEntity.GetCollection<Link>("/atom:entry/atom:link", atomNode, namespaceManager, _linkFactory);
            newEntry.Authors = UtilityAtomEntity.GetCollection<Person>("/atom:entry/atom:author", atomNode, namespaceManager, _authorFactory);
            newEntry.Categories = UtilityAtomEntity.GetCollection<Category>("/atom:entry/atom:category", atomNode, namespaceManager, _categoryFactory);
            newEntry.Contributors = UtilityAtomEntity.GetCollection<Person>("/atom:entry/atom:contributor", atomNode, namespaceManager, _contributorFactory);

            newEntry.Content = UtilityAtomEntity.GetEntity<Content>("/atom:entry/atom:content", atomNode, namespaceManager, _contentFactory);
            newEntry.Source = UtilityAtomEntity.GetEntity<Entry>("/atom:entry/atom:source", atomNode, namespaceManager, this);

            return newEntry;
        }

        #endregion


    }
}