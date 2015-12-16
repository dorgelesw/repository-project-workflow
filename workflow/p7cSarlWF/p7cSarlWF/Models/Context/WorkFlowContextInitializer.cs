﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace p7cSarlWF.Models.Context
{
    public class WorkFlowContextInitializer : CreateDatabaseIfNotExists<WorkFlowContext> 
    {
        protected override void Seed(WorkFlowContext context)
        {
            //base.Seed(context);

            //ajouter un utilisateur et son profil
            //context.Profils.Add( new Profil 
            //    { Address="Science", 
            //        Facebook="franklinovic", 
            //        Googleplus="franklinovic", 
            //        Linkedin="franklinovic", 
            //        MobPhone="00237696197828", 
            //        OfficePhone="00237678796682", 
            //        PostalCode=2587, 
            //        Skype="franklinovic", 
            //        Twitter="franklinovic", 
            //        Ville="Yaoundé", 
            //        Website="",
            //        Utilisateur = context.Utilisateurs.Add(new Utilisateur { 
            //                FirstName = "Yondjio", 
            //                LastName = "Franklin", 
            //                Password = "password", 
            //                ActivationCode = "654ddqfqf465", 
            //                Activated = true, 
            //                Civilite = "Mr", 
            //                email = "franklinovic@gmail.com", 
            //                ParentID = 0, 
            //                Username = "franklinovic",
            //                CreatedAt = DateTime.Now,
            //                UpdatedAt = DateTime.Now,
            //                ResetPasswordCode = "654654646" })
            //} );
            context.Utilisateurs.Add(new Utilisateur
            {
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
                ResetPasswordCode = "654654646",
                Profil = context.Profils.Add( new Profil 
                    { Address="Science", 
                        Facebook="franklinovic", 
                        Googleplus="franklinovic", 
                        Linkedin="franklinovic", 
                        MobPhone="00237696197828", 
                        OfficePhone="00237678796682", 
                        PostalCode="2587", 
                        Skype="franklinovic", 
                        Twitter="franklinovic", 
                        Ville="Yaoundé", 
                        Website=""
                    })
            });
            context.SaveChanges();
                              
            context.Clients.Add( new Client
            {
                FirstName = "KWOMGUE",
                LastName = "Dorgeles",
                Password = "1234",
                ActivationCode = "654ddqfqf465",
                Activated = true,
                Civilite = "Mr",
                email = "marrel.wagsong@p7c-sarl.com",
                ParentID = 0,
                Username = "dorgelesk",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ResetPasswordCode = "654654646",
                TypeClient = "P7C Sarl",
                Profil = context.Profils.Add(new Profil
                {
                    Address = "Nkolbisson",
                    Facebook = "marelle",
                    Googleplus = "marelle",
                    Linkedin = "marelle",
                    MobPhone = "00237696197828",
                    OfficePhone = "00237678796682",
                    PostalCode = "2587",
                    Skype = "marelle",
                    Twitter = "marelle",
                    Ville = "marelle",
                    Website = ""
                })
            });
            context.SaveChanges();

            //ajouter un type de ressource
            TypeRessource type = new TypeRessource { TypeDescription = "Les ressources humaines", TypeName = "Human ressources", Utilisateur = context.Utilisateurs.First(), CreatedDate = DateTime.Now };//, Utilisateur=user
            type = context.TypeRessources.Add(type);
            context.SaveChanges();

            //ajouter une ressource
            context.Ressources.Add(new Ressource { RessourceDescription = "Developper", RessourceName = "Franklin Yondjio", TypeRessource = type });
            context.SaveChanges();
        }
    }
}