using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CitizenJournalismNetworkServer.Domain.Factories.Atom;
using Moq;
using System.Xml;
using CitizenJournalismNetworkServer.Domain.Utilities;

namespace CitizenJournalismNetworkServer.Test.Utilities
{
    [TestFixture]
    public class UtilityAtomEntityTests
    {

        private XmlNode _node;
        private XmlNamespaceManager _ns;

        private static string[] StringValues = { "Value1", "Value2", "Value3" };
        

        [TestFixtureSetUp]
        public void Setup()
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<TestData xmlns:sdstr='http://www.test.org/sdstr'>");
            xml.Append("    <sdstr:SubDataString>");
            xml.Append(string.Format("        <sdstr:StringValue>{0}</sdstr:StringValue>", StringValues[0]));
            xml.Append("    </sdstr:SubDataString>");
            xml.Append("    <sdstr:SubDataString>");
            xml.Append(string.Format("        <sdstr:StringValue>{0}</sdstr:StringValue>", StringValues[1]));
            xml.Append("    </sdstr:SubDataString>");
            xml.Append("    <sdstr:SubDataString>");
            xml.Append(string.Format("        <sdstr:StringValue>{0}</sdstr:StringValue>", StringValues[2]));
            xml.Append("    </sdstr:SubDataString>");
            xml.Append("</TestData>");

            XmlDocument doc = new XmlDocument();

            _ns = new XmlNamespaceManager(doc.NameTable);
            _ns.AddNamespace("sdstr", "http://www.test.org/sdstr");
            _ns.AddNamespace("sdlng", "http://www.test.org/sdlng");
            _ns.AddNamespace("sddt", "http://www.test.org/sddt");

            doc.LoadXml(xml.ToString());

            _node = doc.DocumentElement;
        }


        [Test]
        public void GetEntity_PathNotFound_Null()
        {
            int resultCount = 0;
            Mock<IAtomFactory<string>> mockFactory = new Mock<IAtomFactory<string>>();

            mockFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<XmlNode>(), Moq.It.IsAny<XmlNamespaceManager>())).Returns("Success").Callback(new Action(delegate() { resultCount++; }));

            string result = UtilityAtomEntity.GetEntity<string>("/TestData/sdstr:NonExistantPath", _node, _ns, mockFactory.Object);

            Assert.IsNull(result);
            Assert.AreEqual(0, resultCount);
        }

		[Test]
        public void GetEntity_PathFound_Success()
        {
            int resultCount = 0;
            Mock<IAtomFactory<string>> mockFactory = new Mock<IAtomFactory<string>>();

            mockFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<XmlNode>(), Moq.It.IsAny<XmlNamespaceManager>())).Returns("Success").Callback(new Action(delegate() { resultCount++; }));

            string result = UtilityAtomEntity.GetEntity<string>("/TestData/sdstr:SubDataString", _node, _ns, mockFactory.Object);

            Assert.AreEqual("Success", result);
            Assert.AreEqual(1, resultCount);
        }

        [Test]
        public void GetEntity_CannotGenerate_Exception()
        {
            Mock<IAtomFactory<string>> mockFactory = new Mock<IAtomFactory<string>>();

            mockFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<XmlNode>(), Moq.It.IsAny<XmlNamespaceManager>())).Throws(new Exception());

            try
            {
                string result = UtilityAtomEntity.GetEntity<string>("/TestData/sdstr:SubDataString", _node, _ns, mockFactory.Object);
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail("Did not propagate expected exception!");
        }

		[Test]
        public void GetCollection_PathNotFound_Empty()
        {
            int resultCount = 0;
            Mock<IAtomFactory<string>> mockFactory = new Mock<IAtomFactory<string>>();

            mockFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<XmlNode>(), Moq.It.IsAny<XmlNamespaceManager>())).Returns("Success").Callback(new Action(delegate() { resultCount++; }));

            ICollection<string> result = UtilityAtomEntity.GetCollection<string>("/TestData/sdstr:NonexistantPath", _node, _ns, mockFactory.Object);

            Assert.AreEqual(0, resultCount);
            Assert.AreEqual(0, resultCount);
        }

		[Test]
        public void GetCollection_PathFound_Success()
        {
            int resultCount = 0;
            Mock<IAtomFactory<string>> mockFactory = new Mock<IAtomFactory<string>>();

            mockFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<XmlNode>(), Moq.It.IsAny<XmlNamespaceManager>())).Returns("Success").Callback(new Action(delegate() { resultCount++; }));

            ICollection<string> result = UtilityAtomEntity.GetCollection<string>("/TestData/sdstr:SubDataString", _node, _ns, mockFactory.Object);

            // Check that 3 results were returned.
            Assert.AreEqual(3, result.Count);
            // Check that the factory was called 3 times.
            Assert.AreEqual(3, resultCount);
        }

        [Test]
        public void GetCollection_CannotGenerate_Exception()
        {
            Mock<IAtomFactory<string>> mockFactory = new Mock<IAtomFactory<string>>();

            mockFactory.Setup(factory => factory.CreateFromAtomXml(Moq.It.IsAny<XmlNode>(), Moq.It.IsAny<XmlNamespaceManager>())).Throws(new Exception());

            try
            {
                ICollection<string> result = UtilityAtomEntity.GetCollection<string>("/TestData/sdstr:SubDataString", _node, _ns, mockFactory.Object);
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail("Did not propagate expected exception!");
        }

    }
}
