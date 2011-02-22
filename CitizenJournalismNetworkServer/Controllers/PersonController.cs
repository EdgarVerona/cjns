using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Repositories;

namespace CitizenJournalismNetworkServer.Controllers
{   
    public class PersonController : Controller
    {
        private readonly IPersonRepository repository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PersonController() : this(new PersonRepository())
        {
        }

        public PersonController(IPersonRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View(this.repository.GetAllPeople());
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(Person d)
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
        // GET: /Person/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /Person/Edit/5

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
        // GET: /Person/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /Person/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}