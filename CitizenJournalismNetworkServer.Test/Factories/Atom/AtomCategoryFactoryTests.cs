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
using System.Xml.Linq;

namespace CitizenJournalismNetworkServer.Test.Factories.Atom
{
    [TestFixture]
    public class AtomCategoryFactoryTests
    {
        private const string ValidTerm = "science";
        private const string ValidScheme = "http://scheme.com/scheme";
        private const string ValidLabel = "Science Is Cool";

        [Test]
        public void CreateFromAtomXml_UnrecognizedFormat_Empty()
        {
            XmlDocument doc = UtilityTestXml.CreateDocument(TestConstants.UnrecognizableXml);
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomCategoryFactory factory = new AtomCategoryFactory();

            Category newCategory = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.IsNotNull(newCategory);
            Assert.IsEmpty(newCategory.Label);
        }

        [Test]
		public void CreateFromAtomXml_AllData_Success()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(string.Format("<atom:Category term='{0}' scheme='{1}' label='{2}' xmlns:atom='http://www.w3.org/2005/Atom' />", ValidTerm, ValidScheme, ValidLabel));
            XmlDocument doc = UtilityTestXml.CreateDocument(xml.ToString());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomCategoryFactory factory = new AtomCategoryFactory();

            Category newCategory = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.AreEqual(ValidTerm, newCategory.Term);
            Assert.AreEqual(ValidScheme, newCategory.Scheme);
            Assert.AreEqual(ValidLabel, newCategory.Label);
        }

        [Test]
        public void CreateFromAtomXml_PartialData_Success()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(string.Format("<atom:Category term='{0}' xmlns:atom='http://www.w3.org/2005/Atom' />", ValidTerm));
            XmlDocument doc = UtilityTestXml.CreateDocument(xml.ToString());
            XmlNamespaceManager nsManager = UtilityTestXml.CreateAtomNamespaceManager(doc);

            AtomCategoryFactory factory = new AtomCategoryFactory();

            Category newCategory = factory.CreateFromAtomXml(doc.DocumentElement, nsManager);

            Assert.AreEqual(ValidTerm, newCategory.Term);
            Assert.IsEmpty(newCategory.Scheme);
            Assert.IsEmpty(newCategory.Label);
        }

    }
}
