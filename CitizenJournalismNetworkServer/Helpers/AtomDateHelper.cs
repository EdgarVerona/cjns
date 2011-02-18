using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Helpers
{
    public class AtomDateHelper
    {
        public static string RenderDate(DateTime dateToRender)
        {
            // +++TODO: A naive, temporary approach.
            //          We're going to need to also support partial seconds, and possibly non-UTC times if from external sources
            //          that decided to give us non-UTC times.
            return string.Format("{0}T{1}Z", dateToRender.ToString("yyyy-MM-dd"), dateToRender.ToString("hh:mm:ss"));
        }

        public static string RenderDate(DateTime? dateToRender)
        {
            if (dateToRender == null)
            {
                return "";
            }
            else
            {
                return RenderDate(dateToRender.Value);
            }
        }
    }
}