using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Enumerations;
using System.Web.Script.Serialization;
using CitizenJournalismNetworkServer.Web.Utilities;
using CitizenJournalismNetworkServer.Domain.Repositories;
using CitizenJournalismNetworkServer.Domain.Factories;
using CitizenJournalismNetworkServer.Web.Attributes;

namespace CitizenJournalismNetworkServer.Web.Controllers
{   
	[JsonAllowGetAttribute]
	public class CollectionController : Controller
	{
	    private readonly ICollectionRepository _repository;
        private readonly IFeedFactory _feedFactory;
		

		public CollectionController(ICollectionRepository r, IFeedFactory feedFactory)
		{
			_repository = r;
            _feedFactory = feedFactory;
		}


        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        //-- ATOM Views
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------



		//
		// GET: /Collection/Details/5

		public ActionResult Details(int id, string type)
		{
            return View("Feed", _feedFactory.CreateByCollectionId(id));
		}




        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        //-- HTML Only Views (for temporary testing purposes only)
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------



		//
		// GET: /Collection/Create

		public ActionResult Create()
		{
			return View();
		}

		
		//
		// POST: /Collection/Create

		[HttpPost]
		public ActionResult Create(Collection d)
		{
			if (ModelState.IsValid)
			{
			  this._repository.Add(d);
			  this._repository.Save();
			  return RedirectToAction("Index");  
			}
			return View();
		}
		
		//
		// GET: /Collection/Edit/5
 
		public ActionResult Edit(int id)
		{
			 return View(this._repository.GetById(id));
		}

		//
		// POST: /Collection/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection form)
		{
			var d = this._repository.GetById(id);
			if (TryUpdateModel(d))
			{
				this._repository.Save();
				return RedirectToAction("Index");
			}
			return View();
		}

		//
		// GET: /Collection/Delete/5
 
		public ActionResult Delete(int id)
		{
			return View(this._repository.GetById(id));
		}

		//
		// POST: /Collection/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			this._repository.Delete(id);
			this._repository.Save();

			return RedirectToAction("Index");
		}
	}
}