using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CitizenJournalismNetworkServer.Web.Helpers;
using Moq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CitizenJournalismNetworkServer.Test.Helpers
{
    [TestFixture]
    public class JsonHelperTests
    {
        //+++TODO: Find a way to mock the "Partial" extension method, or these unit tests become uncomfortably cumbersome.
        /*
        [Test]
        public void RenderJsonCollection_Empty_Success()
        {
            string result = JsonHelper.RenderJsonCollection<string>("test", new List<string>(), UtilityTestJson.GetMockHelper());

            UtilityJsonChecker.ValidateJsonText(result);
        }

        [Test]
		public void RenderJsonCollection_Null_Success()
        {
            string result = JsonHelper.RenderJsonCollection<string>("test", null, UtilityTestJson.GetMockHelper());

            UtilityJsonChecker.ValidateJsonText(result);
        }

        [Test]
		public void RenderJsonCollection_Single_Success()
        {
            List<string> items = new List<string>();
            items.Add("blah");
            string result = JsonHelper.RenderJsonCollection<string>("test", items, UtilityTestJson.GetMockHelper());

            UtilityJsonChecker.ValidateJsonText(result);
        }

        [Test]
        public void RenderJsonCollection_Multiple_Success()
        {
            List<string> items = new List<string>();
            for (int x = 0; x < 50; x++)
            {
                items.Add("blah");
            }
            string result = JsonHelper.RenderJsonCollection<string>("test", items, UtilityTestJson.GetMockHelper());

            UtilityJsonChecker.ValidateJsonText(result);
        }
        */

    }
}
