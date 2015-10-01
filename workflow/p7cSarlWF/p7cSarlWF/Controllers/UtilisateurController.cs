using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p7cSarlWF.Controllers
{
    public class UtilisateurController : Controller
    {
        public IUtilisateurManager UtilisateurManager { get; set; }
        //
        // GET: /Utilisateur/
        public ActionResult Index()
        {
            List<Utilisateur> users = UtilisateurManager.GetListeAllUtilisateur(); ;
            return View(users);
        }

        
        public UtilisateurController()
        {
            UtilisateurManager = (IUtilisateurManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
        }
	}
}