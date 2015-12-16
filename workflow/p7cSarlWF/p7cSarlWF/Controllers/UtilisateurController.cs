using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace p7cSarlWF.Controllers
{
    public class UtilisateurController : BaseController
    {
        public IUtilisateurManager UtilisateurManager { get; set; }
        //
        // GET: /Utilisateur/
        public ActionResult Index()
        {
            List<Utilisateur> users = UtilisateurManager.GetListeAllUtilisateur(); ;
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Utilisateur Utilisateur)
        {

            Utilisateur.Activated = false;
            Utilisateur.ActivationCode = "";
            Utilisateur.CreatedAt = DateTime.Now;
            Utilisateur.ParentID = 0;
            Utilisateur.ResetPasswordCode = "";
            Utilisateur.UpdatedAt = DateTime.Now;
            //client.ProfilUtilisateur = new ProfilUtilisateur();
            string password = Membership.GeneratePassword(6, 1);
            Utilisateur.ActivationCode = password;

            if (ModelState.IsValid)
            {
                UtilisateurManager.SaveUtilisateur(Utilisateur);
                return RedirectToAction("Index");
            }

            return View(Utilisateur);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Utilisateur Utilisateur = UtilisateurManager.GetUtilisateurByID(id);
            return View(Utilisateur);
        }

        [HttpPost]
        public ActionResult Edit(Utilisateur Utilisateur)
        {
            if (ModelState.IsValid)
            {
                UtilisateurManager.UpdateUtilisateur(Utilisateur);
                return RedirectToAction("Index");
            }
            return View(Utilisateur);
        }

        public ActionResult Delete(int id)
        {
            Utilisateur Utilisateur = UtilisateurManager.Delete(id);
            return RedirectToAction("Index");
        }
        
        public UtilisateurController()
        {
            UtilisateurManager = (IUtilisateurManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
        }
	}
}