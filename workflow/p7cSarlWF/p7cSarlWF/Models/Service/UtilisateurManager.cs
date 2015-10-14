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


        public Utilisateur SaveUtilisateur(Utilisateur Utilisateur)
        {
            return Repository.SaveUtilisateur(Utilisateur);
        }

        public Utilisateur GetUtilisateurByID(int id)
        {
            return Repository.GetUtilisateurByID(id);
        }

        public Utilisateur Delete(int id)
        {
            return Repository.Delete(id);
        }

        public Utilisateur UpdateUtilisateur(Utilisateur Utilisateur)
        {
            Utilisateur.UpdatedAt = DateTime.Now;

            return Repository.UpdateUtilisateur(Utilisateur);

        }









        public UtilisateurManager()
        {//injection de la dépendance
            Repository = (IUtilisateurRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurRepository));
        }
    }
}