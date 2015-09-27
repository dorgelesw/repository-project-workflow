using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models
{
    /**
     * 
     */
    public class Utilisateur
    {
        [Required]
        public int UtilisateurID { get; set; }

        
        public Boolean Activated{ get; set; }

        [DisplayName("Activation Code")]
        [DataType(DataType.Text)]
        public string ActivationCode { get; set; }

        [Required]
        [DisplayName("Mr, Mme, Mlle")]
        [DataType(DataType.Text)]
        public string Civilite { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString="dd/MM/yyyy HH:mm:ss")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Chief Responsible")]
        [DataType(DataType.Text)]
        public int ParentID { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [DisplayName("Reset Password Code")]
        [DataType(DataType.Text)]
        public string ResetPasswordCode { get; set; }
                
        [DisplayName("Last Updated Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm:ss")]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [DisplayName("Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }


        public virtual ProfilUtilisateur ProfilUtilisateur { get; set; }
        /**
         * Les projets auquel l'utilisateur est lié
         * */
        public virtual List<Project> Projects { get; set; }
        public virtual List<TypeRessource> TypeRessources { get; set; }
    }
}