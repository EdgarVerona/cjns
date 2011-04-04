using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Enumerations;
using CitizenJournalismNetworkServer.Domain.Constants;
using CitizenJournalismNetworkServer.Domain.Utilities;
using CitizenJournalismNetworkServer.Web.Utilities;

namespace CitizenJournalismNetworkServer.Web.Engine
{
    public class MultiOutputViewEngine: RazorViewEngine
    {
        
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            string contentType = UtilityContentTypeWeb.GetContentType(controllerContext);

            if (contentType.Equals(ContentTypeConstants.Html))
            {
                return new ViewEngineResult(new string[] { });
            }
            else
            {
                return base.FindPartialView(controllerContext, string.Format("{0}/{1}", contentType, partialViewName), useCache);
            }
        }


        
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            string contentType = UtilityContentTypeWeb.GetContentType(controllerContext);

            if (contentType.Equals(ContentTypeConstants.Html))
            {
                return new ViewEngineResult(new string[] { });
            }
            else
            {
                SetResponseType(controllerContext, contentType);

                return base.FindView(controllerContext, string.Format("{0}/{1}", contentType, viewName), "", useCache);
            }
        }

        
        
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-- PRIVATE MEMBERS
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        

        private static void SetResponseType(ControllerContext controllerContext, string contentType)
        {
            string httpContentType = UtilityContentType.GetHttpContentTypeFromShortTypeCode(contentType);
            controllerContext.HttpContext.Response.ContentType = httpContentType;
        }



    }
}