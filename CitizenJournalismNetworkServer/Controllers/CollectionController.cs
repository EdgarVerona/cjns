using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Enumerations;
using CitizenJournalismNetworkServer.Attributes;
using System.Web.Script.Serialization;
using CitizenJournalismNetworkServer.Utility;

namespace CitizenJournalismNetworkServer.Controllers
{   
	[JsonAllowGetAttribute]
	public class CollectionController : Controller
	{
	    private readonly ICollectionRepository repository;
		

		// If you are using Dependency Injection, you can delete the following constructor
		public CollectionController() : this(new CollectionRepository())
		{
		}

		public CollectionController(ICollectionRepository r)
		{
			this.repository = r;
		}

		//
		// GET: /Collection/

		public ActionResult Index(string type)
		{
			return View(this.repository.GetAllCollections());
		}

		//
		// GET: /Collection/Details/5

		public ActionResult Details(int id, string type)
		{
			return View(this.repository.GetById(id));
		}

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
			  this.repository.Add(d);
			  this.repository.Save();
			  return RedirectToAction("Index");  
			}
			return View();
		}
		
		//
		// GET: /Collection/Edit/5
 
		public ActionResult Edit(int id)
		{
			 return View(this.repository.GetById(id));
		}

		//
		// POST: /Collection/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection form)
		{
			var d = this.repository.GetById(id);
			if (TryUpdateModel(d))
			{
				this.repository.Save();
				return RedirectToAction("Index");
			}
			return View();
		}

		//
		// GET: /Collection/Delete/5
 
		public ActionResult Delete(int id)
		{
			return View(this.repository.GetById(id));
		}

		//
		// POST: /Collection/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			this.repository.Delete(id);
			this.repository.Save();

			return RedirectToAction("Index");
		}
	}
}