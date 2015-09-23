using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace p7cSarlWF.Models.Context
{
    public class WorkFlowContextInitializer : DropCreateDatabaseAlways<WorkFlowContext> 
    {
        protected override void Seed(WorkFlowContext context)
        {
            //base.Seed(context);

            context.ProfilUtilisateurs.Add( new ProfilUtilisateur 
                { Address="Science", 
                    Facebook="franklinovic", 
                    Googleplus="franklinovic", 
                    Linkedin="franklinovic", 
                    MobPhone="00237696197828", 
                    OfficePhone="00237678796682", 
                    PostalCode=2587, 
                    Skype="franklinovic", 
                    Twitter="franklinovic", 
                    Ville="Yaoundé", 
                    Website="",
                    Utilisateur = context.Utilisateurs.Add(new Utilisateur { 
                            FirstName = "Yondjio", 
                            LastName = "Franklin", 
                            Password = "password", 
                            ActivationCode = "654ddqfqf465", 
                            Activated = true, 
                            Civilite = "Mr", 
                            email = "franklinovic@gmail.com", 
                            ParentID = 0, 
                            Username = "franklinovic",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            ResetPasswordCode = "654654646" })
            } );
            
            ////Utilisateur user = new Utilisateur { FirstName = "Yondjio", LastName = "Franklin", Password = "password", ActivationCode = "654ddqfqf465", Activated = true, Civilite = "Mr", email="franklinovic@gmail.com", ParentID=0, Username="franklinovic", CreatedAt=new DateTime(), UpdatedAt=new DateTime(), Projects=null, ResetPasswordCode="654654646"};
            ////user = context.Utilisateurs.Add(user);
            context.SaveChanges();

            TypeRessource type = new TypeRessource { TypeDescription = "Les ressources humaines", TypeName = "Human ressources", Utilisateur = context.Utilisateurs.First(), CreatedDate = DateTime.Now };//, Utilisateur=user
            type = context.TypeRessources.Add(type);
            context.SaveChanges();

            context.Ressources.Add(new Ressource { RessourceDescription = "Developper", RessourceName = "Franklin Yondjio", TypeRessource = type });
            context.SaveChanges();
        }
    }
}