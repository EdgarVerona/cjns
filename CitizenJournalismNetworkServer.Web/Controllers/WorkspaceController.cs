using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Models;
using System.Globalization;
using CitizenJournalismNetworkServer.Domain.Repositories;


namespace CitizenJournalismNetworkServer.Web.Controllers
{   
    public class WorkspaceController : Controller
    {
        private readonly IWorkspaceRepository repository;


        public WorkspaceController(IWorkspaceRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /Workspace/

        public ActionResult Index(string type)
        {
            return View(this.repository.GetAll());
        }

        //
        // GET: /Workspace/Details/5

        public ActionResult Details(int id, string type)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /Workspace/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Workspace/Create

        [HttpPost]
        public ActionResult Create(Workspace d)
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
        // GET: /Workspace/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /Workspace/Edit/5

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
        // GET: /Workspace/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /Workspace/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}