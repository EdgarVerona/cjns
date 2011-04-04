using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CitizenJournalismNetworkServer.Domain.Factories.Atom;
using System.Xml;
using CitizenJournalismNetworkServer.Test.Constants;
using CitizenJournalismNetworkServer.Test.Helpers;
using CitizenJournalismNetworkServer.Domain.Models;


namespace CitizenJournalismNetworkServer.Test.Factories.Atom
{
    [TestFixture]
    public class AtomContentFactoryTests
    {
        
        [Test]
        public void CreateFromAtomXml_UnrecognizedFormat_Empty()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(TestConstants.UnrecognizableXml);
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomContentFactory factory = new AtomContentFactory();

            Content newContent = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newContent);
            Assert.IsEmpty(newContent.ContentType);
        }

        public const string ValidContentHtml = "<div>This is awesome</div>";
        public const string ValidTypeHtml = "html";

        [Test]
        public void CreateFromAtomXml_InlineHtml_Success()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(string.Format("<atom:content type='{0}'  xmlns:atom='http://www.w3.org/2005/Atom'>", ValidTypeHtml));
            xml.Append(ValidContentHtml);
            xml.Append("</atom:content>");
            XmlDocument doc = UtilityTestXml.CreateDocument(xml.ToString());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomContentFactory factory = new AtomContentFactory();

            Content newContent = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.AreEqual(ValidTypeHtml, newContent.ContentType);
            Assert.AreEqual(ValidContentHtml, newContent.Text);
            Assert.IsFalse(newContent.IsExternallySourced);
            Assert.IsEmpty(newContent.SourceUri);
        }

        public const string ValidContentPlain = "Some Plain content.  Nothing to see here.";
        public const string ValidTypePlain = "text";

        [Test]
        public void CreateFromAtomXml_InlineOther_Success()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(string.Format("<atom:content type='{0}' xmlns:atom='http://www.w3.org/2005/Atom'>", ValidTypePlain));
            xml.Append(ValidContentPlain);
            xml.Append("</atom:content>");
            XmlDocument doc = UtilityTestXml.CreateDocument(xml.ToString());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomContentFactory factory = new AtomContentFactory();

            Content newContent = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.AreEqual(ValidTypePlain, newContent.ContentType);
            Assert.AreEqual(ValidContentPlain, newContent.Text);
            Assert.IsFalse(newContent.IsExternallySourced);
            Assert.IsEmpty(newContent.SourceUri);
        }

        public const string ValidTypeImage = "png";
        public const string ValidSourceUri = "http://somewhere.com/something.png";

        [Test]
        public void CreateFromAtomXml_OutOfLine_Success()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(string.Format("<atom:content type='{0}' src='{1}' xmlns:atom='http://www.w3.org/2005/Atom' />", ValidTypeImage, ValidSourceUri));
            XmlDocument doc = UtilityTestXml.CreateDocument(xml.ToString());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomContentFactory factory = new AtomContentFactory();

            Content newContent = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.AreEqual(ValidTypeImage, newContent.ContentType);
            Assert.IsEmpty(newContent.Text);
            Assert.AreEqual(ValidSourceUri, newContent.SourceUri);
            Assert.IsTrue(newContent.IsExternallySourced);
        }

    }
}
