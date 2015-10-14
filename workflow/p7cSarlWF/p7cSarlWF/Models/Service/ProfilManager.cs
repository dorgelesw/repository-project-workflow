using p7cSarlWF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace p7cSarlWF.Models.Service
{
    public class ProfilManager : IProfilManager
    {
        public IProfilRepository Repository{get; set;}

        public Profil saveProfil(Profil Profil)
        {
            return Repository.saveProfil(Profil);
        }

        public ProfilManager()
        {//injection de la dépendance
            Repository = (IProfilRepository) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProfilRepository));
        }
    }
}