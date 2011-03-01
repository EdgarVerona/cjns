﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Utility;
using CitizenJournalismNetworkServer.Factories.Atom;
using CitizenJournalismNetworkServer.Controllers;
using Autofac.Integration.Mvc;
using CitizenJournalismNetworkServer.Enumerations;

namespace CitizenJournalismNetworkServer.ModelBinders
{
    [ModelBinderType(typeof(Entry))]
    public class AtomEntryModelBinder: IModelBinder
    {
        IAtomFactory<Entry> _entryFactory;

        public AtomEntryModelBinder(IAtomFactory<Entry> entryFactory)
        {
            _entryFactory = entryFactory;
        }


        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string contentType = controllerContext.HttpContext.Request.Headers["Content-Type"];

            if (contentType != HttpContentTypeConstants.Atom)
            {
                return null;
            }

            Entry newEntry = new Entry();

            string requestInput = UtilityRequest.GetContent(controllerContext.HttpContext.Request);

            return _entryFactory.CreateFromAtomXml(requestInput, "/atom:entry");
        }

    }

}