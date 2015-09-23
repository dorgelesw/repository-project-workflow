using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace p7cSarlWF.Controllers
{
    public class DashboardController : Controller
    {
        public IUtilisateurManager UtilisateurManager { get; set; }
        public IProjectManager ProjectManager { get; set; }
        public IRessourceManager RessourceManager { get; set; }
        // GET: /Dashboard/
        public ActionResult Index()
        {
            
            return View();
        }


        public DashboardController()
        {
            UtilisateurManager = (IUtilisateurManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
            ProjectManager = (IProjectManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProjectManager));
            RessourceManager = (IRessourceManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceManager));
        }
	}
}