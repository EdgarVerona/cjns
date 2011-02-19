using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitizenJournalismNetworkServer.Models;
using CitizenJournalismNetworkServer.Repositories;

namespace CitizenJournalismNetworkServer.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IWorkspaceRepository repository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ServiceController() : this(new WorkspaceRepository())
        {
            
        }

        public ServiceController(IWorkspaceRepository r)
        {
            this.repository = r;
        }

        //
        // GET: /Service.[Format]
        public ActionResult Index()
        {
            Service service = new Service();

            service.Workspaces = repository.GetAllWorkspaces();

            return View("Service", service);
        }

    }
}
