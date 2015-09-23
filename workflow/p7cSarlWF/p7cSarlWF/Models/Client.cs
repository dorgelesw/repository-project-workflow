using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models
{
    public class Client : Utilisateur
    {

       public virtual new List<Project> Projects { get; set; }
    }
}