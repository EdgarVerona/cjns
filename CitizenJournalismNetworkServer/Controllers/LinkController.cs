using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Repositories;

namespace CitizenJournalismNetworkServer.Controllers
{   
    public class LinkController : Controller
    {
        private readonly ILinkRepository repository;

		// If you are using Dependency Injection, you can delete the following constructor
        public LinkController() : this(new LinkRepository())
        {
        }

        public LinkController(ILinkRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /Link/

        public ActionResult Index()
        {
            return View(this.repository.GetAllLinks());
        }

        //
        // GET: /Link/Details/5

        public ActionResult Details(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /Link/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Link/Create

        [HttpPost]
        public ActionResult Create(Link d)
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
        // GET: /Link/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /Link/Edit/5

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
        // GET: /Link/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /Link/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}