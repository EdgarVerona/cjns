using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Repositories;

namespace CitizenJournalismNetworkServer.Controllers
{   
    public class EntryController : Controller
    {
        private readonly IEntryRepository repository;


		// If you are using Dependency Injection, you can delete the following constructor
        public EntryController() : this(new EntryRepository())
        {
        }

        public EntryController(IEntryRepository r)
        {
            this.repository = r;
        }


        //
        // GET: /Entry/
        public ActionResult Index(string type)
        {
            return View(this.repository.GetAllEntries());
        }

        //
        // GET: /Entry/Details/5

        public ActionResult Details(int id, string type)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /Entry/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Entry/Create

        [HttpPost]
        public ActionResult Create(Entry d)
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
        // GET: /Entry/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /Entry/Edit/5

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
        // GET: /Entry/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /Entry/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}