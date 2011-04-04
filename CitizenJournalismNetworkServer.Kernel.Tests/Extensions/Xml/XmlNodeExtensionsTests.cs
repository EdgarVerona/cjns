using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CitizenJournalismNetworkServer.Kernel.Extensions.Xml;
using System.Xml;

namespace CitizenJournalismNetworkServer.Test.Extensions.Xml
{
    [TestFixture]
    public class XmlNodeExtensionsTests
    {
        private XmlNode _node;
        private XmlNamespaceManager _ns;

        [TestFixtureSetUp]
        public void Setup()
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<TestData xmlns:sdstr='http://www.test.org/sdstr' xmlns:sdlng='http://www.test.org/sdlng' xmlns:sddt='http://www.test.org/sddt'>");
            xml.Append("    <sdstr:SubDataString>");
            xml.Append(string.Format("        <sdstr:StringValue>{0}</sdstr:StringValue>", StringValue));
            xml.Append(string.Format("        <sdstr:StringAttribute attribute-value='{0}'>{1}</sdstr:StringAttribute>", StringAttribute, InvalidValue));
            xml.Append("    </sdstr:SubDataString>");
            xml.Append("    <sdlng:SubDataLong>");
            xml.Append(string.Format("        <sdlng:LongValue>{0}</sdlng:LongValue>", LongValue));
            xml.Append(string.Format("        <sdlng:LongAttribute attribute-value='{0}'>{1}</sdlng:LongAttribute>", LongAttribute, InvalidValue));
            xml.Append(string.Format("        <sdlng:LongInvalid>{0}</sdlng:LongInvalid>", PatentlyInvalid));
            xml.Append("    </sdlng:SubDataLong>");
            xml.Append("    <sddt:SubDataDateTime>");
            xml.Append(string.Format("        <sddt:DateTimeValue>{0}</sddt:DateTimeValue>", DateTimeValue));
            xml.Append(string.Format("        <sddt:DateTimeAttribute attribute-value='{0}'>{1}</sddt:DateTimeAttribute>", DateTimeAttribute, InvalidValue));
            xml.Append(string.Format("        <sddt:DateTimeWithTimeZone>{0}</sddt:DateTimeWithTimeZone>", DateTimeWithTimeZone));
            xml.Append(string.Format("        <sddt:DateTimeInvalid>{0}</sddt:DateTimeInvalid>", PatentlyInvalid));
            xml.Append("    </sddt:SubDataDateTime>");
            xml.Append("    <SubDataBoolean>");
            xml.Append(string.Format("        <BooleanValueTrue>{0}</BooleanValueTrue>", BooleanYes));
            xml.Append(string.Format("        <BooleanValueFalse>{0}</BooleanValueFalse>", BooleanNo));
            xml.Append(string.Format("        <BooleanAttribute attribute-value='{0}'>{1}</BooleanAttribute>", BooleanYes, InvalidValue));
            xml.Append(string.Format("        <BooleanInvalid>{0}</BooleanInvalid>", PatentlyInvalid));
            xml.Append("    </SubDataBoolean>");
            xml.Append("</TestData>");

            XmlDocument doc = new XmlDocument();

            _ns = new XmlNamespaceManager(doc.NameTable);
            _ns.AddNamespace("sdstr", "http://www.test.org/sdstr");
            _ns.AddNamespace("sdlng", "http://www.test.org/sdlng");
            _ns.AddNamespace("sddt", "http://www.test.org/sddt");

            doc.LoadXml(xml.ToString());

            _node = doc.DocumentElement;
        }

        public const string DefaultValueString = "DEFAULT_VALUE";
        public const string StringValue = "AValidStringValue";
        public const string StringAttribute = "AValidStringAttribute";
        public const string InvalidValue = "Not Valid";
        public const long LongValue = 1024;
        public const long LongAttribute = 2048;
        public const string DateTimeValue = "2003-12-13T18:30:02Z";
        public static DateTime DateTimeValueAsDateTime = DateTime.Parse("12-13-2003 18:30:02");
        public const string DateTimeAttribute = "2009-02-23T18:30:02Z";
        public static DateTime DateTimeAttributeAsDateTime = DateTime.Parse("02-23-2009 18:30:02");
        public const string DateTimeWithTimeZone = "2005-11-15T18:30:02.25+01:00";
        public static DateTime DateTimeWithTimeZoneAsDateTime = DateTime.Parse("11-15-2005 17:30:02.25");
        public const string PatentlyInvalid = "Slartibartfast";
        public const string BooleanYes = "yes";
        public const string BooleanNo = "no";
        public const long DefaultValueLong = 24601;
        public static DateTime DefaultDateTime = DateTime.Parse("12-25-2008 05:05:05");

        [Test]
        public void GetNodeValueAsString_NodeNotFound_Default()
        {
            string result = _node.GetNodeValueAsString("/TestData/sdstr:SubDataString/sdstr:NonExistant", _ns, DefaultValueString);

            Assert.AreEqual(DefaultValueString, result);
        }

        [Test]
        public void GetNodeValueAsString_NodeFound_Success()
        {
            string result = _node.GetNodeValueAsString("/TestData/sdstr:SubDataString/sdstr:StringValue", _ns, DefaultValueString);

            Assert.AreEqual(StringValue, result);
        }

        [Test]
        public void GetNodeValueAsLong_NodeNotFound_Default()
        {
            long? result = _node.GetNodeValueAsLong("/TestData/sdstr:SubDataString/sdlng:InvalidNode", _ns, DefaultValueLong);

            Assert.AreEqual(DefaultValueLong, result);
        }

        [Test]
        public void GetNodeValueAsLong_NodeNotFound_NullDefault()
        {
            long? result = _node.GetNodeValueAsLong("/TestData/sdlng:SubDataLong/sdlng:InvalidNode", _ns, null);

            Assert.IsNull(result);
        }

        [Test]
        public void GetNodeValueAsLong_InvalidData_Default()
        {
            long? result = _node.GetNodeValueAsLong("/TestData/sdlng:SubDataLong/sdlng:LongInvalid", _ns, DefaultValueLong);

            Assert.AreEqual(DefaultValueLong, result);
        }

        [Test]
        public void GetNodeValueAsLong_InvalidData_NullDefault()
        {
            long? result = _node.GetNodeValueAsLong("/TestData/sdlng:SubDataLong/sdlng:LongInvalid", _ns, null);

            Assert.IsNull(result);
        }

        [Test]
        public void GetNodeValueAsLong_ValidData_Success()
        {
            long? result = _node.GetNodeValueAsLong("/TestData/sdlng:SubDataLong/sdlng:LongValue", _ns, LongValue);

            Assert.AreEqual(LongValue, result);
        }

        [Test]
        public void GetNodeValueAsDateTime_NodeNotFound_NullDefault()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sdlng:SubDataLong/sdlng:NodeNonexistant", _ns, null);

            Assert.IsNull(result);
        }

        [Test]
        public void GetNodeValueAsDateTime_NodeNotFound_Default()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sdlng:SubDataLong/sdlng:NodeNonexistant", _ns, DefaultDateTime);

            Assert.AreEqual(DefaultDateTime, result);
        }

        [Test]
        public void GetNodeValueAsDateTime_InvalidData_NullDefault()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sddt:SubDataDateTime/sddt:DateTimeInvalid", _ns, null);

            Assert.IsNull(result);
        }

        [Test]
        public void GetNodeValueAsDateTime_InvalidData_Default()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sddt:SubDataDateTime/sddt:DateTimeInvalid", _ns, DefaultDateTime);

            Assert.AreEqual(DefaultDateTime, result);
        }

        [Test]
        public void GetNodeValueAsDateTime_ValidDataGeneric_Success()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sddt:SubDataDateTime/sddt:DateTimeValue", _ns, DefaultDateTime);

            Assert.AreEqual(DateTimeValueAsDateTime, result);
        }

        [Test]
        public void GetNodeValueAsDateTime_ValidDataTimeZone_Success()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sddt:SubDataDateTime/sddt:DateTimeWithTimeZone", _ns, DefaultDateTime);

            Assert.AreEqual(DateTimeWithTimeZoneAsDateTime, result);
        }

        [Test]
        public void GetNodeValueAsBoolean_NodeNotFound_Default()
        {
            bool result = _node.GetNodeValueAsBoolean("/TestData/SubDataBoolean/NonexistantNode", _ns, false);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetNodeValueAsBoolean_InvalidData_Default()
        {
            bool result = _node.GetNodeValueAsBoolean("/TestData/SubDataBoolean/BooleanInvalid", _ns, false);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetNodeValueAsBoolean_ValidDataTrue_Success()
        {
            bool result = _node.GetNodeValueAsBoolean("/TestData/SubDataBoolean/BooleanValueTrue", _ns, false);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void GetNodeValueAsBoolean_ValidDataFalse_Success()
        {
            bool result = _node.GetNodeValueAsBoolean("/TestData/SubDataBoolean/BooleanValueFalse", _ns, true);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetNodeValueAsString_Attribute_Success()
        {
            string result = _node.GetNodeValueAsString("/TestData/sdstr:SubDataString/sdstr:StringAttribute/@attribute-value", _ns, DefaultValueString);

            Assert.AreEqual(StringAttribute, result);
        }

		[Test]
        public void GetNodeValueAsLong_Attribute_Success()
        {
            long? result = _node.GetNodeValueAsLong("/TestData/sdlng:SubDataLong/sdlng:LongAttribute/@attribute-value", _ns, DefaultValueLong);

            Assert.AreEqual(LongAttribute, result);
        }

		[Test]
        public void GetNodeValueAsDateTime_Attribute_Success()
        {
            DateTime? result = _node.GetNodeValueAsDateTime("/TestData/sddt:SubDataDateTime/sddt:DateTimeAttribute/@attribute-value", _ns, DefaultDateTime);

            Assert.AreEqual(DateTimeAttributeAsDateTime, result);
        }

		[Test]
        public void GetNodeValueAsBoolean_Attribute_Success()
        {
            bool result = _node.GetNodeValueAsBoolean("/TestData/SubDataBoolean/BooleanAttribute/@attribute-value", _ns, false);

            Assert.AreEqual(true, result);
        }

    }
}
