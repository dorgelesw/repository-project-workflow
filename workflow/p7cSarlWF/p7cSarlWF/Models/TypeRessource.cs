using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace p7cSarlWF.Models
{
    /**
     * Cette classe est l'abstraction d'un type de ressource. Une type de ressource a plusieurs ressources
     * 
     */
    public class TypeRessource
    {
        [Required]
        public int TypeRessourceID { get; set; }

        [Required(ErrorMessage = "Please entre type's description")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description du type")]
        public string TypeDescription { get; set; }

        [Required(ErrorMessage = "Please enter type's name")]
        [DisplayName("Ressource Name")]
        [DataType(DataType.Text)]
        public string TypeName { get; set; }

        public virtual List<Ressource> Ressources { get; set; }

        //ID de l'utilisateur qui a créé le type de ressource
        [ForeignKey("Utilisateur")]
        public int CreatedBy { get; set; }
                
        [DisplayName("Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
    }
}
