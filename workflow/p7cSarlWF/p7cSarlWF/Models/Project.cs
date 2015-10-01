using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace p7cSarlWF.Models
{
    public class Project
    {
        [Required]
        public int ProjectID { get; set; }

        [Required(ErrorMessage="Please choose color Identifier for project")]
        [DisplayName("Color Identifier")]
        [DataType(DataType.Text)]
        public string ColorIdentifier { get; set; }

        [Required]
        [DisplayName("Parent Project")]        
        public int ParentID { get; set; }

        [Required]
        [DisplayName("Project Priority")]
        public int PriorityID { get; set; }

        [Required]
        [DisplayName("Created Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm:ss")]
        public DateTime CreatedAt { get; set; }

        public int DeletedBy { get; set; }

        [Required(ErrorMessage="Please specify start date")]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please specify end date")]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayName("Project Location")]
        [DataType(DataType.Text)]
        public string Projectlocation { get; set; }

        [Required]
        [DisplayName("Project Budget")]
        public double ProjectBudget { get; set; }

        [Required(ErrorMessage="Please Enter project's description")]
        [DisplayName("Project Description")]
        [DataType(DataType.MultilineText)]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Please Enter project's full name")]
        [DisplayName("Project Full Name")]
        [DataType(DataType.Text)]
        public string ProjectFullName { get; set; }

        [Required(ErrorMessage = "Please Enter project's short name")]
        [DisplayName("Project Short Name")]
        [DataType(DataType.Text)]
        public string ProjectShortName { get; set; }

        [Required]
        [DisplayName("Project Manager")]
        public int ProjectManager { get; set; }

        [Required]
        [DisplayName("Project Responsible")]
        public int ProjectResponsible { get; set; }

        [DisplayName("Project Status")]
        public int ProjectStatus { get; set; }

        public double ProjectPercentComplete { get; set; }

        [DisplayName("Project URL")]
        [DataType(DataType.Url)]
        public string ProjectUrl { get; set; }

        public int TaskCount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        [Required]
        public int ClientID { get; set; }

        /**
         * Le client du projet
         * */
        public virtual Client Client { get; set; }
        [Required]
        public int ProjectCreator { get; set; }
        /**
         * Il s'agit ici des utilisateurs associés au projet
         * */
        public virtual List<Utilisateur> Utilisateurs { get; set; }
        //les ressources qui sont affectées au projet
        public virtual List<ProjectRessource> ProjectRessources { get; set; }
    }
}
