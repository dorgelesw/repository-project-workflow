using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models.Repository
{
    /**
     * Ce repository va gérer les concepts Utilisateur, ProfilUtilisateur et Client pour le projet
     * */
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private WorkFlowContext context
        {
            get { return new WorkFlowContext(); }
        }

        public List<Utilisateur> GetListeAllUtilisateur()
        {
            return context.Utilisateurs.Where(u => u.deleted != true).ToList();
        }

        public List<Client> GetListeAllClient()
        {
            return context.Clients.Where(u => u.deleted != true).ToList();
        }

        public Client saveClient(Client client)
        {
           WorkFlowContext context = new WorkFlowContext();
          context.Clients.Add(client);
          context.SaveChanges();
           return client;
        }

        public Utilisateur SaveUtilisateur(Utilisateur Utilisateur)
        {
            WorkFlowContext context = new WorkFlowContext();
            Utilisateur = context.Utilisateurs.Add(Utilisateur);
            context.SaveChanges();
            return Utilisateur;
        }

        public Utilisateur GetUtilisateurByID(int id)
        {
            WorkFlowContext context = new WorkFlowContext();
            return context.Utilisateurs.Find(id);
        }

        public Utilisateur UpdateUtilisateur(Utilisateur Utilisateur)
        {
            WorkFlowContext context = new WorkFlowContext();

            //Utilisateur = context.Utilisateurs.Find(Utilisateur.UtilisateurID);

            context.Entry(Utilisateur).State = EntityState.Modified;

            context.SaveChanges();

            return Utilisateur;
        }

        public Utilisateur Delete(int id)
        {
            WorkFlowContext context = new WorkFlowContext();
            Utilisateur Utilisateur = context.Utilisateurs.Find(id);
            Utilisateur.deleted = true;
            context.Entry(Utilisateur).State = EntityState.Modified;
            context.SaveChanges();
            return Utilisateur;
        }

        public Client UpdateClient(Client Client)
        {
            WorkFlowContext context = new WorkFlowContext();

            context.Entry(Client).State = EntityState.Modified;

            context.SaveChanges();

            return Client;
        }

        public Client GetClientByID(int id)
        {
            WorkFlowContext context = new WorkFlowContext();
            Client Client = context.Clients.Find(id);
            return Client;

        }
    }
}