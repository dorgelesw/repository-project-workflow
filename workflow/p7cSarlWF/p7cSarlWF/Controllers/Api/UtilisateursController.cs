using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace p7cSarlWF.Controllers.Api
{
    public class UtilisateursController : ApiController
    {
        public IUtilisateurManager UtilisateurManager { get; set; }

        // GET api/User
        [HttpGet]
        public List<Utilisateur> GetUsers()
        {
            return UtilisateurManager.GetListeAllUtilisateur();
        }

        [HttpDelete]
        public Utilisateur Delete(int id)
        {
            return UtilisateurManager.Delete(id);
        }

        public UtilisateursController()
        {
            UtilisateurManager = (IUtilisateurManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
        }
    }
}
