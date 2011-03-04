using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CitizenJournalismNetworkServer.Factories.Atom;
using System.Xml;
using CitizenJournalismNetworkServer.Test.Constants;
using CitizenJournalismNetworkServer.Test.Helpers;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Enumerations;

namespace CitizenJournalismNetworkServer.Test.Factories.Atom
{

    [TestFixture]
    public class AtomLinkFactoryTests
    {
        private const string InvalidLength = "Adfhawoenrqwdf";
        private const string ValidHref = "http://somewhere.com/something.php";
        private const string ValidHrefLang = "en";
        private const string ValidLength = "500";
        private const string ValidRel = "self";
        private const string ValidTitle = "Some Title";
        private const string ValidType = "text/html";


        [Test]
        public void CreateFromAtomXml_UnrecognizedFormat_Empty()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(TestConstants.UnrecognizableXml);
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomLinkFactory factory = new AtomLinkFactory();
            Link newLink = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newLink);
            Assert.IsEmpty(newLink.Href);
        }

        

		[Test]
        public void CreateFromAtomXml_InvalidData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(GetLinkEntity(ValidHrefLang, InvalidLength));
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomLinkFactory factory = new AtomLinkFactory();
            Link newLink = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);
            
            Assert.IsNotNull(newLink);
            Assert.AreEqual(ValidHref, newLink.Href);
            Assert.IsNull(newLink.Length);
        }

		[Test]
        public void CreateFromAtomXml_AllData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(GetLinkEntity(ValidHrefLang, ValidLength));
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomLinkFactory factory = new AtomLinkFactory();
            Link newLink = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newLink);
            Assert.AreEqual(ValidHref, newLink.Href);
            Assert.AreEqual(ValidLength, newLink.Length.ToString());
            Assert.AreEqual(ValidHrefLang, newLink.Language);
            Assert.AreEqual(ValidRel, newLink.RelationshipLiteral);
            Assert.AreEqual(LinkRelationship.Self, newLink.RelationshipType);
            Assert.AreEqual(ValidTitle, newLink.Title);
            Assert.AreEqual(ValidType, newLink.Type);
        }

		[Test]
        public void CreateFromAtomXml_PartialData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(GetLinkPartialEntity());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomLinkFactory factory = new AtomLinkFactory();
            Link newLink = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newLink);
            Assert.AreEqual(ValidHref, newLink.Href);
            Assert.IsEmpty(newLink.Language);
            Assert.IsEmpty(newLink.RelationshipLiteral);
            // By default, links without a specified RelationshipType are considered "Alternate".
            Assert.AreEqual(LinkRelationship.Alternate, newLink.RelationshipType);
            Assert.AreEqual(ValidTitle, newLink.Title);
            Assert.IsEmpty(newLink.Type);
        }


        private string GetLinkPartialEntity()
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<link xmlns='http://www.w3.org/2005/Atom' ");
            xml.Append(string.Format("href='{0}' ", ValidHref));
            xml.Append(string.Format("length='{0}' ", ValidLength));
            xml.Append(string.Format("title='{0}' ", ValidTitle));
            xml.Append("/>");

            return xml.ToString();
        }

        private string GetLinkEntity(string hrefLang, string length)
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<link xmlns='http://www.w3.org/2005/Atom' ");
            xml.Append(string.Format("href='{0}' ", ValidHref));
            xml.Append(string.Format("hreflang='{0}' ", hrefLang));
            xml.Append(string.Format("length='{0}' ", length));
            xml.Append(string.Format("rel='{0}' ", ValidRel));
            xml.Append(string.Format("title='{0}' ", ValidTitle));
            xml.Append(string.Format("type='{0}' ", ValidType));
            xml.Append("/>");

            return xml.ToString();
        }

    }
}
