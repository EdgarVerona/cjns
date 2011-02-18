using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;

namespace CitizenJournalismNetworkServer.Helpers
{
    public class JsonHelper
    {

        public static string RenderJsonCollection<T>(string partialClassName, IEnumerable<T> modelCollection, WebViewPage<T> page)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("[");

            int count = 0;

            foreach (T item in modelCollection)
            {
                count++;
                builder.Append(page.Html.Partial(partialClassName, item));
                if (count < modelCollection.Count())
                {
                    builder.Append(",");
                }
            }

            builder.Append("]");

            return builder.ToString();
        }

    }
}