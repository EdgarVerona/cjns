using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace CitizenJournalismNetworkServer.Utility
{
    /// <summary>
    /// A class that provides basic services for extracting data from an Http Request.
    /// </summary>
    public class UtilityRequest
    {

        public static string GetContent(HttpRequestBase request)
        {
            StreamReader reader = new StreamReader(request.InputStream);

            string result = reader.ReadToEnd();

            return result;
        }

    }
}