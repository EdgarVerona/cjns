using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;

namespace CitizenJournalismNetworkServer.Web.Controllers
{   
    public class ContentTypeController : Controller
    {
        private readonly IContentTypeRepository repository;

        public ContentTypeController(IContentTypeRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /ContentType/

        public ViewResult Index()
        {
            return View(this.repository.GetAll());
        }

        //
        // GET: /ContentType/Details/5

        public ViewResult Details(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /ContentType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ContentType/Create

        [HttpPost]
        public ActionResult Create(ContentType d)
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
        // GET: /ContentType/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /ContentType/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var d = this.repository.GetById(id);
            if (TryUpdateModel(d))
            {
                this.repository.Update(d);
                this.repository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /ContentType/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /ContentType/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}