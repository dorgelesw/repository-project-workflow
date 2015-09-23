using p7cSarlWF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace p7cSarlWF.Models.Service
{
    public class UtilisateurManager : IUtilisateurManager
    {

        private IUtilisateurRepository Repository { get; set; }

        public List<Utilisateur> GetListeAllUtilisateur()
        {
            return Repository.GetListeAllUtilisateur();
        }
















        public UtilisateurManager()
        {//injection de la dépendance
            Repository = (IUtilisateurRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurRepository));
        }
    }
}