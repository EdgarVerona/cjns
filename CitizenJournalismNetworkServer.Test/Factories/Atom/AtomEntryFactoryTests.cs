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


namespace CitizenJournalismNetworkServer.Test.Factories.Atom
{
    [TestFixture]
    public class AtomEntryFactoryTests
    {
        private static AtomEntryFactory _factory;


        [TestFixtureSetUp]
        public void Setup()
        {
            Moq.Mock<IAtomFactory<Person>> personFactory = new Moq.Mock<IAtomFactory<Person>>();
            personFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(new Person());
            Moq.Mock<IAtomFactory<Category>> categoryFactory = new Moq.Mock<IAtomFactory<Category>>();
            categoryFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(new Category());
            Moq.Mock<IAtomFactory<Link>> linkFactory = new Moq.Mock<IAtomFactory<Link>>();
            linkFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(new Link());
            Moq.Mock<IAtomFactory<Content>> contentFactory = new Moq.Mock<IAtomFactory<Content>>();
            contentFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(new Content());

            _factory = new AtomEntryFactory(personFactory.Object, categoryFactory.Object, personFactory.Object, linkFactory.Object, contentFactory.Object);
        }

        [Test]
        public void CreateFromAtomXml_UnrecognizedFormat_Empty()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(TestConstants.UnrecognizableXml);
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            Entry newEntry = _factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newEntry);
            Assert.IsEmpty(newEntry.Title);
        }

        private const string InvalidDateTimePublished = "No Way this will convert to DateTime";
        private const string ValidDateTimePublished = "2005-07-31T12:29:29Z";
        private static DateTime ValidDateTimePublishedAsDateTime = DateTime.Parse("07/31/2005 12:29:29");

        [Test]
		public void CreateFromAtomXml_InvalidData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(BuildExampleEntry(InvalidDateTimePublished));
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            Entry newEntry = _factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNull(newEntry.DatePublished);
        }

        [Test]
		public void CreateFromAtomXml_AllData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(BuildExampleEntry(ValidDateTimePublished));
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            Entry newEntry = _factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.AreEqual(ValidDateTimePublishedAsDateTime, newEntry.DatePublished);
        }

        [Test]
		public void CreateFromAtomXml_PartialData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(BuildExampleEntry(""));
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            Entry newEntry = _factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNull(newEntry.DatePublished);
        }



        private string BuildExampleEntry(string dateTimePublished)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<entry xmlns='http://www.w3.org/2005/Atom'>");
            xml.Append("<title>Atom draft-07 snapshot</title>");
            xml.Append("<link rel='alternate' type='text/html' ");
            xml.Append("href='http://example.org/2005/04/02/atom'/>");
            xml.Append("<link rel='enclosure' type='audio/mpeg' length='1337' ");
            xml.Append("href='http://example.org/audio/ph34r_my_podcast.mp3'/>");
            xml.Append("<id>tag:example.org,2003:3.2397</id>");
            xml.Append(string.Format("<published>{0}</published>", dateTimePublished));
            xml.Append("<updated>2003-12-13T08:29:29-04:00</updated>");
            xml.Append("<author>");
            xml.Append("<name>Mark Pilgrim</name>");
            xml.Append("<uri>http://example.org/</uri>");
            xml.Append("<email>f8dy@example.com</email>");
            xml.Append("</author>");
            xml.Append("<contributor>");
            xml.Append("<name>Sam Ruby</name>");
            xml.Append("</contributor>");
            xml.Append("<contributor>");
            xml.Append("<name>Joe Gregorio</name>");
            xml.Append("</contributor>");
            xml.Append("<content type='xhtml' xml:lang='en' ");
            xml.Append("xml:base='http://diveintomark.org/'>");
            xml.Append("<div xmlns='http://www.w3.org/1999/xhtml'>");
            xml.Append("<p><i>[Update: The Atom draft is finished.]</i></p>");
            xml.Append("</div>");
            xml.Append("</content>");
            xml.Append("</entry>");

            return xml.ToString();
        }

    }
}
