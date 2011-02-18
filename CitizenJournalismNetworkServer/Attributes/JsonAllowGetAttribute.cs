using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitizenJournalismNetworkServer.Attributes
{

    public class JsonAllowGetAttribute : ActionFilterAttribute
    {
        private JsonRequestBehavior Behavior { get; set; }

        public JsonAllowGetAttribute()
        {
            Behavior = JsonRequestBehavior.AllowGet;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var result = filterContext.Result as JsonResult;

            if (result != null)
            {
                result.JsonRequestBehavior = Behavior;
            }
        }
    }


}