using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Web.Utilities;
using Autofac.Integration.Mvc;
using CitizenJournalismNetworkServer.Domain.Enumerations;
using CitizenJournalismNetworkServer.Domain.Constants;

namespace CitizenJournalismNetworkServer.Web.ModelBinders
{
    [ModelBinderType(typeof(MediaContent))]
    public class AtomMediaContentModelBinder: IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string contentType = controllerContext.HttpContext.Request.Headers["Content-Type"];
            
            if (contentType == HttpContentTypeConstants.Atom)
            {
                return null;
            }

            MediaContent content = new MediaContent();
            
            content.ContentBase64 = UtilityRequest.GetContent(controllerContext.HttpContext.Request);
            content.ContentType = contentType;
            content.SlugData = controllerContext.HttpContext.Request.Headers["Slug"];


            return content;
        }

    }
}