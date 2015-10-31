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
            get { return new WorkFlowContext(); }
        }

        public List<TypeRessource> GetAllTypesRessources()
        {
            return context.TypeRessources.Where(type => type.deleted != true).ToList();
        }
               
        public List<TypeRessource> GetAllTypesRessourcesByUserID(int UtilisateurID)
        {
            return context.TypeRessources.Where(type => type.CreatedBy == UtilisateurID && type.deleted!=true).ToList();
        }
        
        public List<Ressource> GetAllRessources()
        {
            return context.Ressources.ToList();
        }

        public List<Ressource> GetAllRessourcesByType(int TypeRessourceID)
        {
            return context.Ressources.Where(r => r.TypeRessourceID == TypeRessourceID && r.deleted==false).ToList();
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

        public bool DeleteType(int id)
        {
            WorkFlowContext ctx = new WorkFlowContext();
            TypeRessource type = ctx.TypeRessources.Find(id);
            type.deleted = true;
            ctx.Entry(type).State = EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            WorkFlowContext ctx = new WorkFlowContext();
            List<ProjectRessource> projectRessources = ctx.ProjectRessources.Where(pr => pr.RessourceID == id).ToList();
            if (projectRessources != null & projectRessources.Count != 0)
            {
                //la ressource a déjà été affecté à des projets, on change juste son statut
                Ressource ressource = ctx.Ressources.Find(id);
                ressource.deleted = true;
                ctx.Entry(ressource).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            else
            {
                // la ressource n'a pas encore été affecté à des projets, on peut simplement la supprimer de la BD
                Ressource ressource = ctx.Ressources.Find(id);
                ctx.Ressources.Remove(ressource);
                ctx.SaveChanges();
                return true;
            }
        }

        public void DestroyType(int id)
        {
            WorkFlowContext ctx = new WorkFlowContext();
            TypeRessource type = ctx.TypeRessources.Find(id);
            type.deleted = true;
            ctx.Entry(type).State = EntityState.Deleted;
            ctx.SaveChanges();
        }

        public Ressource UpdateRessource(Ressource Ressource)
        {
            WorkFlowContext contex = new WorkFlowContext();
            contex.Entry(Ressource).State = EntityState.Modified;
            contex.SaveChanges();
            return Ressource;
        }
    }
}