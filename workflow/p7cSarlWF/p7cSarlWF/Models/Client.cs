using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models
{
    public class Client : Utilisateur
    {
        [Required]
        [DisplayName("TypeClient")]
        [DataType(DataType.Text)]
        public string TypeClient { get; set; }

        public virtual new List<Project> Projects { get; set; }
    }
}