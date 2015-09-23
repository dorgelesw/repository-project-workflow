using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models
{
    public class Ressource
    {
        [Required]
        public int RessourceID { get; set; }

        [Required(ErrorMessage="Please enter ressource description.")]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string RessourceDescription { get; set; }

        [Required(ErrorMessage="Please enter ressource name.")]
        [DisplayName("Nom de la ressource")]
        [DataType(DataType.Text)]
        public string RessourceName { get; set; }

        [Required]
        public int TypeRessourceID { get; set; }
        public virtual TypeRessource TypeRessource { get; set; }
        public virtual List<Fichier> Fichiers { get; set; }
    }
}