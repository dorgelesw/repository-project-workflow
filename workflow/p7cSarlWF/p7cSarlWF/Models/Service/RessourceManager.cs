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
        

        public RessourceManager()
        {//injection de la dépendance
            Repository = (IRessourceRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceRepository));

        }
    }
}