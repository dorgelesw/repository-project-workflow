using p7cSarlWF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace p7cSarlWF.Models.Service
{
    public class RessourceManager : IRessourceManager
    {

        public RessourceManager()
        {//injection de la dépendance
            Repository = (IRessourceRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceRepository));

        }

        private IRessourceRepository Repository { get; set; }

        public List<TypeRessource> GetAllTypesRessources()
        {
            return Repository.GetAllTypesRessources();
        }

        public List<TypeRessource> GetAllTypesRessourcesByUserID(int UtilisateurID)
        {
            return Repository.GetAllTypesRessourcesByUserID(UtilisateurID);
        }


        public List<Ressource> GetAllRessources()
        {
            return Repository.GetAllRessources();
        }

        public List<Ressource> GetAllRessourcesByType(int TypeRessourceID)
        {
            return Repository.GetAllRessourcesByType(TypeRessourceID);
        }

        public TypeRessource SaveTypeRessource(TypeRessource type)
        {
            return Repository.SaveTypeRessource(type);
        }

        public TypeRessource GetTypeRessourceByID(int TypeRessourceID)
        {
            return Repository.GetTypeRessourceByID(TypeRessourceID);
        }




        public Ressource SaveRessource(Ressource Ressource)
        {
            return Repository.SaveRessource(Ressource);
        }


        public Ressource GetRessourceByID(int id)
        {
            return Repository.GetRessourceByID(id);
        }

        public void SaveFichier(Fichier fichier)
        {
            Repository.SaveFichier(fichier);
        }

        public bool DeleteType(int id)
        {
            List<Ressource> ressources = GetAllRessourcesByType(id);
            if (ressources.Count == 0)
            {
                Repository.DestroyType(id);
                return true;
            }
            else
            {
                return Repository.DeleteType(id);
            }
        }

        public Ressource UpdateRessource(Ressource Ressource)
        {
            return Repository.UpdateRessource(Ressource);
        }
    }
}