using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace CitizenJournalismNetworkServer.Extensions.Xml
{
    /// <summary>
    /// Provides basic services for interpreting Xml Entities and values.
    /// </summary>
    public static class XmlNodeExtensions
    {

        /// <summary>
        /// This extension method obtains the value of a given node, if it exists.
        /// Otherwise, a default value is returned.
        /// Only the first match of the XPath query will be returned.
        /// </summary>
        /// <param name="doc">The XmlDocument being searched.</param>
        /// <param name="xPath">The XPath query being performed.</param>
        /// <param name="nsManager">The XML namespace manager used in the evaluation of the XPath Query.</param>
        /// <param name="defaultValue">The value to return if the node cannot be found.</param>
        /// <returns>A string representing either the value found or the default value passed in.</returns>
        public static string GetNodeValueAsString(this XmlNode nodeRoot, string xPath, XmlNamespaceManager nsManager, string defaultValue)
        {
            XmlNode node = nodeRoot.SelectSingleNode(xPath, nsManager);

            if (node == null)
            {
                return defaultValue;
            }

            return node.Value;
        }

    }
}