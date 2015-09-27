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
    public class ClientController : Controller
    {
        public IClientManager ClientManager { get; set; }
        public IUtilisateurManager UtilisateurManager { get; set; }

        public ClientController()
        {
            ClientManager = (IClientManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IClientManager));
            //UtilisateurManager = (IUtilisateurManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
        }

        // GET: Client
        public ActionResult Index()
        {
            List<Client> clients = ClientManager.GetListeAllClient();
            return View("ClientList", clients);
        }

        /**
         * Get list des clients
         * */
        public ActionResult ClientList()
        {
           
            List<Client> clients = ClientManager.GetListeAllClient();
            return View(clients);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult CreateClient()
        {
            //ViewBag.Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreateClient(Client client)
        {
            //complete model
            client.Activated = false;
            client.ActivationCode = "";
            client.CreatedAt = DateTime.Now;
            client.ParentID = 0;
            client.ResetPasswordCode = "";
            client.UpdatedAt = DateTime.Now;
            //client.ProfilUtilisateur = new ProfilUtilisateur();

            if (ModelState.IsValid)
            {
                ClientManager.saveClient(client);
                return RedirectToAction("ClientList");
            }

            return View(client);
        }
    }
}