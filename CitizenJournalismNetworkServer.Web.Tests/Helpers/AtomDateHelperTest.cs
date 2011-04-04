using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using CitizenJournalismNetworkServer.Web.Helpers;

namespace CitizenJournalismNetworkServer.Test.Helpers
{
    [TestFixture]
    public class AtomDateHelperTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RenderDate_Null_Success()
        {
            string result = AtomDateHelper.RenderDate(null);

            Assert.IsEmpty(result);
        }

        [Test]
        public void RenderDate_DateTimeUTC_Success()
        {
            DateTime currentDate = DateTime.Parse("10/30/1981 15:25:00");
            string result = AtomDateHelper.RenderDate(currentDate);


            DateTime dateComponent = DateTime.Parse(result.Substring(0, result.IndexOf("T")));
            TimeSpan timeComponent = TimeSpan.Parse(result.Substring(result.IndexOf("T") + 1, result.IndexOf("Z") - (result.IndexOf("T") + 1)));

            Assert.AreEqual(currentDate.Day, dateComponent.Day);
            Assert.AreEqual(currentDate.Month, dateComponent.Month);
            Assert.AreEqual(currentDate.Year, dateComponent.Year);
            Assert.AreEqual(currentDate.TimeOfDay.Hours, timeComponent.Hours);
            Assert.AreEqual(currentDate.TimeOfDay.Minutes, timeComponent.Minutes);
            Assert.AreEqual(currentDate.TimeOfDay.Seconds, timeComponent.Seconds);
        }

        [Test]
        public void RenderDate_DateUTC_Success()
        {
            string result = AtomDateHelper.RenderDate(DateTime.Parse("10/30/1981"));

            DateTime dateComponent = DateTime.Parse(result.Substring(0, result.IndexOf("T")));
            TimeSpan timeComponent = TimeSpan.Parse(result.Substring(result.IndexOf("T") + 1, result.IndexOf("Z") - (result.IndexOf("T") + 1)));

            Assert.AreEqual(dateComponent.Day, 30);
            Assert.AreEqual(dateComponent.Month, 10);
            Assert.AreEqual(dateComponent.Year, 1981);
        }

        [Test]
        public void RenderDate_TimeUTC_Success()
        {
            string result = AtomDateHelper.RenderDate(DateTime.Parse("2:45:00"));

            DateTime dateComponent = DateTime.Parse(result.Substring(0, result.IndexOf("T")));
            TimeSpan timeComponent = TimeSpan.Parse(result.Substring(result.IndexOf("T") + 1, result.IndexOf("Z") - (result.IndexOf("T") + 1)));

            Assert.AreEqual(timeComponent.Hours, 2);
            Assert.AreEqual(timeComponent.Minutes, 45);
            Assert.AreEqual(timeComponent.Seconds, 0);
        }

    }
}
