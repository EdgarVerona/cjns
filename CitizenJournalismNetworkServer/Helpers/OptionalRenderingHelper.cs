using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Helpers
{
    public class OptionalRenderingHelper
    {

        public static string RenderTagifExists(string tagName, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return string.Format("<{0}>{1}</{0}>", tagName, value);
            }
            else
            {
                return "";
            }
        }

        public static string RenderAttributeIfExists<T>(string attributeName, T value)
        {
            if (value != null)
            {
                return string.Format("{0}=\"{1}\"", attributeName, value);
            }
            else
            {
                return "";
            }
        }

        public static string RenderAttributeifExists(string attributeName, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return string.Format("{0}=\"{1}\"", attributeName, value);
            }
            else
            {
                return "";
            }
        }

    }
}