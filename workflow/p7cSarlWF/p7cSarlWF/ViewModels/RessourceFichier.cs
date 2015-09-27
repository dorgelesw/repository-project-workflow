using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p7cSarlWF.ViewModels
{
    /**
     * Cette classe implémente le viewModel pour l'upload des fichiers pour une ressource
     * 
     * */
    public class RessourceFichier
    {        
        public int RessourceID { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}