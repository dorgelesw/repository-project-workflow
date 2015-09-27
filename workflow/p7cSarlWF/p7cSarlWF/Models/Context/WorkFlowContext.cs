using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models.Context
{
    public class WorkFlowContext : DbContext
    {

        public WorkFlowContext() : base("P7CWorkflowFDB") { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProfilUtilisateur> ProfilUtilisateurs { get; set; }
        public DbSet<Fichier> Fichiers { get; set; }
        public DbSet<TypeRessource> TypeRessources { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
    }
}