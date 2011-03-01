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
    public class AtomEntryFactory: AtomFactory<Entry>, IAtomFactory<Entry>
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


        public override Entry CreateFromAtomXml(XmlNode atomNode, XmlNamespaceManager namespaceManager)
        {
            Entry newEntry = new Entry();

            newEntry.AtomId = atomNode.GetNodeValueAsString("atom:id", namespaceManager, "");
            newEntry.DatePublished = atomNode.GetNodeValueAsDateTime("atom:published", namespaceManager, null);
            newEntry.DateUpdated = atomNode.GetNodeValueAsDateTime("atom:updated", namespaceManager, DateTime.Now);
            newEntry.IsDraft = atomNode.GetNodeValueAsBoolean("atom:id", namespaceManager, false);
            newEntry.Rights = atomNode.GetNodeValueAsString("atom:rights", namespaceManager, "");
            newEntry.Summary = atomNode.GetNodeValueAsString("atom:summary", namespaceManager, "");
            newEntry.Title = atomNode.GetNodeValueAsString("atom:title", namespaceManager, "");

            newEntry.Links = UtilityAtomEntity.GetCollection<Link>("atom:link", atomNode, namespaceManager, _linkFactory);
            newEntry.Authors = UtilityAtomEntity.GetCollection<Person>("atom:author", atomNode, namespaceManager, _authorFactory);
            newEntry.Categories = UtilityAtomEntity.GetCollection<Category>("atom:category", atomNode, namespaceManager, _categoryFactory);
            newEntry.Contributors = UtilityAtomEntity.GetCollection<Person>("atom:contributor", atomNode, namespaceManager, _contributorFactory);

            newEntry.Content = UtilityAtomEntity.GetEntity<Content>("atom:content", atomNode, namespaceManager, _contentFactory);
            newEntry.Source = UtilityAtomEntity.GetEntity<Entry>("atom:source", atomNode, namespaceManager, this);

            return newEntry;
        }

        #endregion


    }
}