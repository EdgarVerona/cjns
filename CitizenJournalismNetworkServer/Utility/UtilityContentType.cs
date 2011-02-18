using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Enumerations;
using System.Web.Mvc;

namespace CitizenJournalismNetworkServer.Utility
{
    public class UtilityContentType
    {
        public static string GetAcceptTypeFromShortTypeCode(string shortTypeCode)
        {
            switch (shortTypeCode)
            {
                case ContentTypeConstants.Atom:
                    return AcceptTypeConstants.Atom;
                case ContentTypeConstants.Html:
                    return AcceptTypeConstants.Html;
                case ContentTypeConstants.Json:
                    return AcceptTypeConstants.Json;
                case ContentTypeConstants.Xml:
                    return AcceptTypeConstants.Xml;
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetHttpContentTypeFromShortTypeCode(string shortTypeCode)
        {
            switch(shortTypeCode)
            {
                case ContentTypeConstants.Atom:
                    return HttpContentTypeConstants.Atom;
                case ContentTypeConstants.Html:
                    return HttpContentTypeConstants.Html;
                case ContentTypeConstants.Json:
                    return HttpContentTypeConstants.Json;
                case ContentTypeConstants.Xml:
                    return HttpContentTypeConstants.Xml;
                default:
                    throw new NotImplementedException();
            }
        }


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