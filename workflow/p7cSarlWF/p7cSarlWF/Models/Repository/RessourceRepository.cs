using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models.Repository
{
    /**
     * Dans ce repository je vais gérer les concepts TypeRessource, Ressource et Fichier pour le projet 
     * */
    public class RessourceRepository : IRessourceRepository
    {
        private static WorkFlowContext context
        {
            get{ return  new WorkFlowContext(); }
        }

        public List<TypeRessource> GetAllTypesRessources()
        {
            return context.TypeRessources.ToList();
        }
               
        public List<TypeRessource> GetAllTypesRessourcesByUserID(int UtilisateurID)
        {
            return context.TypeRessources.Where(type => type.CreatedBy == UtilisateurID).ToList();
        }
        
        public List<Ressource> GetAllRessources()
        {
            return context.Ressources.ToList();
        }

        public List<Ressource> GetAllRessourcesByType(int TypeRessourceID)
        {
            return context.Ressources.Where(r => r.TypeRessourceID == TypeRessourceID).ToList();
        }
        
        public TypeRessource SaveTypeRessource(TypeRessource type)
        {
           
            WorkFlowContext ctx = new WorkFlowContext();
            Utilisateur user = ctx.Utilisateurs.Find(type.CreatedBy);
            type.Utilisateur = user;
            
            type = ctx.TypeRessources.Add(type);
            ctx.SaveChanges();
            type = ctx.TypeRessources.Find(type.TypeRessourceID);
            
            return type;
        }











    }
}