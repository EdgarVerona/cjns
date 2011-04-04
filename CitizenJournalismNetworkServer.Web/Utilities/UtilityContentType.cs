using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Constants;
using System.Web.Mvc;

namespace CitizenJournalismNetworkServer.Web.Utilities
{
    public class UtilityContentTypeWeb
    {
        
        public static string GetContentType(ControllerContext controllerContext)
        {
            string contentType = ContentTypeConstants.Html;

            if (controllerContext.RouteData.Values.ContainsKey("type"))
            {
                contentType = controllerContext.RouteData.Values["type"].ToString();
            }
            return contentType;
        }

    }
}