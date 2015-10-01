using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models
{
    /**
     * 
     * Cette classe coceptualise l'affectation d'une ressource à un projet
     * 
     * */
    public class ProjectRessource
    {

        [Required]
        public int ProjectRessourceID { get; set; }
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public int RessourceID { get; set; }
        [Required]
        public int Quantite { get; set; }
        [Required]
        public string Note { get; set; }
        //la date où la ressource a été affectée
        [Required]
        public DateTime AffectationDate { get; set; }
        public DateTime DeleteDate { get; set; }
        [Required]
        public Boolean Deleted { get; set; }

        public virtual Ressource Ressource { get; set; }
        public virtual Project Project { get; set; }

    }
}