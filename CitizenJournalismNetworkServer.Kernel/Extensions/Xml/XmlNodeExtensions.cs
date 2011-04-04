using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


namespace CitizenJournalismNetworkServer.Kernel.Extensions.Xml
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

            if (node is XmlElement)
            {
                return node.InnerXml;
            }
            else
            {
                return node.Value;
            }
        }

        public static long? GetNodeValueAsLong(this XmlNode nodeRoot, string xPath, XmlNamespaceManager nsManager, long? defaultValue)
        {
            long? result = defaultValue;

            string value = nodeRoot.GetNodeValueAsString(xPath, nsManager, "");

            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    result = XmlConvert.ToInt64(value);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public static DateTime? GetNodeValueAsDateTime(this XmlNode nodeRoot, string xPath, XmlNamespaceManager nsManager, DateTime? defaultValue)
        {
            DateTime? result = defaultValue;

            string value = nodeRoot.GetNodeValueAsString(xPath, nsManager, "");

            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    result = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public static DateTime GetNodeValueAsDateTime(this XmlNode nodeRoot, string xPath, XmlNamespaceManager nsManager, DateTime defaultValue)
        {
            DateTime result = defaultValue;

            string value = nodeRoot.GetNodeValueAsString(xPath, nsManager, "");

            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    result = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public static bool GetNodeValueAsBoolean(this XmlNode nodeRoot, string xPath, XmlNamespaceManager nsManager, bool defaultValue)
        {
            bool result = defaultValue;

            string value = nodeRoot.GetNodeValueAsString(xPath, nsManager, "");

            if (!string.IsNullOrEmpty(value))
            {
                switch (value.ToLower())
                {
                    case "yes":
                        result = true;
                        break;
                    case "no":
                        result = false;
                        break;
                }
            }

            return result;
        }
        

    }
}