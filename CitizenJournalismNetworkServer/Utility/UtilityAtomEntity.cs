using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using CitizenJournalismNetworkServer.Factories.Atom;

namespace CitizenJournalismNetworkServer.Utility
{
    public class UtilityAtomEntity
    {

        /// <summary>
        /// Given a root node to search, an xPath to the XML for the entity to be created, 
        /// a NamespaceManager for the XML and a factory for creation of the entity, 
        /// this method attempts to parse and generate the Entity.
        /// </summary>
        /// <typeparam name="T">The Entity type to be created.  Must be a class.</typeparam>
        /// <param name="xPath">The path relative to the node to search for the Entity's data.</param>
        /// <param name="atomNode">The node to search for the Entity's data.</param>
        /// <param name="namespaceManager">The manager for Namespaces used in the XML node.</param>
        /// <param name="factory">The IAtomFactory used to create the entity.</param>
        /// <returns>An instance of T, if possible to create it.</returns>
        public static T GetEntity<T>(string xPath, XmlNode atomNode, XmlNamespaceManager namespaceManager, IAtomFactory<T> factory) where T : class
        {
            XmlNode sourceNode = atomNode.SelectSingleNode(xPath, namespaceManager);

            if (sourceNode != null)
            {
                T source = factory.CreateFromAtomXml(sourceNode, namespaceManager);

                return source;
            }

            return null;
        }

        /// <summary>
        /// Given a root node to search, an xPath to the XML for the entity to be created, 
        /// a NamespaceManager for the XML and a factory for creation of the entity, 
        /// this method attempts to parse and generate as many Entities as it finds that match the passed-in xPath.
        /// </summary>
        /// <typeparam name="T">The Entity type to be created.  Must be a class.</typeparam>
        /// <param name="xPath">The path relative to the node to search for the Entity's data.</param>
        /// <param name="atomNode">The node to search for the Entity's data.</param>
        /// <param name="namespaceManager">The manager for Namespaces used in the XML node.</param>
        /// <param name="factory">The IAtomFactory used to create the entity.</param>
        /// <returns>A collection of instances of T, if possible to create them.</returns>
        public static ICollection<T> GetCollection<T>(string xPath, XmlNode atomNode, XmlNamespaceManager namespaceManager, IAtomFactory<T> factory) where T : class
        {
            XmlNodeList entities = atomNode.SelectNodes(xPath, namespaceManager);
            List<T> newEntities = new List<T>();

            foreach (XmlNode entity in entities)
            {
                newEntities.Add(factory.CreateFromAtomXml(entity, namespaceManager));
            }

            return newEntities;
        }


    }
}