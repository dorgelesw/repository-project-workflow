using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace p7cSarlWF.Models
{
    public  class Fichier
    {
        [Required]
        public int FichierID{get; set;}

        [Required]
        [DataType(DataType.Text)]
        public string CheminDisque { get; set; }

        [DisplayName("Last Updated Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm:ss")]
        public DateTime Updated_at { get; set; }

        public DateTime Deleted_at { get; set; }

        [Required]
        [DisplayName("Uploaded Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm:ss")]
        public DateTime Uplaoded_at { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Md5Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string OriginalFileName { get; set; }

        public int DeletedBy { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string taille { get; set; }

        public int UtilisateurID{set; get;}

        public int RessourceID { get; set; }
        public virtual Ressource Ressource { get; set; }
        //public virtual Utilisateur Utilisateur { get; set; }
    }
}
