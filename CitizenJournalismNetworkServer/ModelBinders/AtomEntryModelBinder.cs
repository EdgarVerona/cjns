using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Utility;

namespace CitizenJournalismNetworkServer.ModelBinders
{

    public class AtomEntryModelBinder: IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Entry newEntry = new Entry();

            string requestInput = UtilityRequest.GetContent(controllerContext.HttpContext.Request);

            return null;   
        }

    }

}