using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Utility;
using CitizenJournalismNetworkServer.Factories.Atom;

namespace CitizenJournalismNetworkServer.ModelBinders
{

    public class AtomEntryModelBinder: IModelBinder
    {
        IAtomFactory<Entry> _entryFactory;

        public AtomEntryModelBinder(IAtomFactory<Entry> entryFactory)
        {
            _entryFactory = entryFactory;
        }


        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Entry newEntry = new Entry();

            string requestInput = UtilityRequest.GetContent(controllerContext.HttpContext.Request);

            return _entryFactory.CreateFromAtomXml(requestInput);
        }

    }

}