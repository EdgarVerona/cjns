using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;

namespace CitizenJournalismNetworkServer.Web.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IWorkspaceRepository repository;


        public ServiceController(IWorkspaceRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /Service.[Format]
        public ActionResult Index()
        {
            Service service = new Service();

            service.Workspaces = repository.GetAll();

            return View("Service", service);
        }

    }
}
