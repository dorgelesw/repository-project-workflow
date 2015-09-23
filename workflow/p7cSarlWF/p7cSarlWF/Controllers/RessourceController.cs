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
    public class RessourceController : Controller
    {
        public IRessourceManager RessourceManager { get; set; }
        public IUtilisateurManager UtilisateurManager { get; set; }
        //
        // GET: /Ressource/
        public ActionResult Index()
        {
            List<TypeRessource> typesRessources = RessourceManager.GetAllTypesRessources();
            return View(typesRessources);
        }

        //liste des types de ressources
        public ActionResult TypeList()
        {
            List<TypeRessource> typesRessources = RessourceManager.GetAllTypesRessources();
            return View(typesRessources);
        }

        //liste de toutes les ressources
        public ActionResult RessourceList()
        {
            List<Ressource> Ressources = RessourceManager.GetAllRessources();
            return View(Ressources);
        }

        //liste des ressources d'un type
        public ActionResult RessourceList(int TyperessourceID)
        {
            List<Ressource> Ressources = RessourceManager.GetAllRessourcesByType(TyperessourceID);
            return View(Ressources);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult CreateType()
        {
            ViewBag.Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreateType(TypeRessource typeRessource)
        {
            if (ModelState.IsValid)
            {
                RessourceManager.SaveTypeRessource(typeRessource);
                return RedirectToAction("TypeList");
            }

            return View(typeRessource);
        }

        public ActionResult EditType(int TypeRessourceID)
        {
            return null;
        }



        public RessourceController()
        {
            RessourceManager = (IRessourceManager) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceManager));
            UtilisateurManager = (IUtilisateurManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
        }
	}
}