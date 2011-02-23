using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitizenJournalismNetworkServer.ModelBinders
{

    public class AtomEntryModelBinder: DefaultModelBinder
    {

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return base.BindModel(controllerContext, bindingContext);
        }

    }

}