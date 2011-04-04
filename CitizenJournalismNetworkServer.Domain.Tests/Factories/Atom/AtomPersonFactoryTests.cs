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
    public class AtomPersonFactoryTests
    {
        [Test]
        public void CreateFromAtomXml_UnrecognizedFormat_Empty()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(TestConstants.UnrecognizableXml);
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomPersonFactory factory = new AtomPersonFactory();
            Person newPerson = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newPerson);
            Assert.IsEmpty(newPerson.Name);
        }

        [Test]
        public void CreateFromAtomXml_AllData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(GetPersonXml());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomPersonFactory factory = new AtomPersonFactory();
            Person newPerson = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newPerson);
            Assert.AreEqual(ValidEmail, newPerson.Email);
            Assert.AreEqual(ValidName, newPerson.Name);
            Assert.AreEqual(ValidUri, newPerson.Uri);
        }

        [Test]
        public void CreateFromAtomXml_PartialData_Success()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(GetPersonPartialXml());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomPersonFactory factory = new AtomPersonFactory();
            Person newPerson = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newPerson);
            Assert.IsEmpty(newPerson.Email);
            Assert.IsEmpty(newPerson.Uri);
            Assert.AreEqual(ValidName, newPerson.Name);
        }

        private const string ValidEmail = "somewhere@somewhere.com";
        private const string ValidName = "Bubba Bob";
        private const string ValidUri = "http://somewhere.com";


        private string GetPersonXml()
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<person xmlns='http://www.w3.org/2005/Atom'>");
            xml.Append(string.Format("<email>{0}</email>", ValidEmail));
            xml.Append(string.Format("<name>{0}</name>", ValidName));
            xml.Append(string.Format("<uri>{0}</uri>", ValidUri));
            xml.Append("</person>");

            return xml.ToString();
        }

        private string GetPersonPartialXml()
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<person xmlns='http://www.w3.org/2005/Atom'>");
            xml.Append(string.Format("<name>{0}</name>", ValidName));
            xml.Append("</person>");

            return xml.ToString();
        }

    }
}
