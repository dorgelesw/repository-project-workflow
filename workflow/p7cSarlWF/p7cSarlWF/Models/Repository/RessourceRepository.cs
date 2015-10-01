using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            if (type.TypeRessourceID == 0)
            {
                Utilisateur user = ctx.Utilisateurs.Find(type.CreatedBy);
                type.Utilisateur = user;

                type = ctx.TypeRessources.Add(type);
                ctx.SaveChanges();
                type = ctx.TypeRessources.Find(type.TypeRessourceID);
                Console.WriteLine(type);
                return type;
            }
            else
            {
                ctx.Entry(type).State = EntityState.Modified;
                ctx.SaveChanges();
                type = ctx.TypeRessources.Find(type.TypeRessourceID);
                Console.WriteLine(type);
                return type;
            }

            
        }


        public TypeRessource GetTypeRessourceByID(int TypeRessourceID)
        {
            return context.TypeRessources.Find(TypeRessourceID);
        }


        public Ressource SaveRessource(Ressource Ressource)
        {
            WorkFlowContext ctx = new WorkFlowContext();
            Ressource = ctx.Ressources.Add(Ressource);
            ctx.SaveChanges();

            return Ressource;
        }


        public Ressource GetRessourceByID(int id)
        {
            WorkFlowContext ctx = new WorkFlowContext();
            return ctx.Ressources.Find(id);
        }

        public void SaveFichier(Fichier fichier)
        {
            WorkFlowContext ctx = new WorkFlowContext();
            ctx.Fichiers.Add(fichier);
            ctx.SaveChanges();
            
            
        }
    }
}