using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;

namespace CitizenJournalismNetworkServer.Web.Controllers
{   
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repository;

        // If you are using Dependency Injection, you can delete the following constructor
        public CategoryController() : this(new CategoryRepository())
        {
        }

        public CategoryController(ICategoryRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(this.repository.GetAllCategories());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category d)
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
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /Category/Edit/5

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
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}