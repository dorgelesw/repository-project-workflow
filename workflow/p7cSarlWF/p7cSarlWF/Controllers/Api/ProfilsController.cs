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
    public class ProfilsController : ApiController
    {
        public IProfilManager ProfilManager { get; set; }

        public Profil PostProfil(Profil Profil)
        {
            if (ModelState.IsValid)
            {
                return ProfilManager.saveProfil(Profil);
            }
            return null;
        }

        public ProfilsController()
        {
            ProfilManager = (IProfilManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProfilManager));
        }
    }
}
