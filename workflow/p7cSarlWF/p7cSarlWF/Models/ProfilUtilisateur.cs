using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace p7cSarlWF.Models
{
    public  class ProfilUtilisateur
    {

        public int ProfilUtilisateurID { get; set; }

        [DisplayName("Facebook Profile")]
        [DataType(DataType.Text)]
        public string Facebook { get; set; }

        [Required(ErrorMessage = "Please enter user address")]
        [DisplayName("User Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DisplayName("Google+ Profile")]
        [DataType(DataType.Text)]
        public string Googleplus { get; set; }

        [DisplayName("LinkedIn Profile")]
        [DataType(DataType.Text)]
        public string Linkedin { get; set; }

        [Required(ErrorMessage = "Please enter mobile phone number")]
        [DisplayName("Mobile phone")]
        [DataType(DataType.PhoneNumber)]
        public string MobPhone { get; set; }

        [DisplayName("Office phone")]
        [DataType(DataType.PhoneNumber)]
        public string OfficePhone { get; set; }

        [DisplayName("Postal Code")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        [DisplayName("Skype ID")]
        [DataType(DataType.Text)]
        public string Skype { get; set; }

        [DisplayName("Twitter ID")]
        [DataType(DataType.Text)]
        public string Twitter { get; set; }

        [DisplayName("City")]
        [DataType(DataType.Text)]
        public string Ville { get; set; }

        [DisplayName("Website URL")]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Key, ForeignKey("Utilisateur")]
        public int UtilisateurID { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
    }
}
