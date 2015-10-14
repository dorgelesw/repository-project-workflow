using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Service
{
    public interface IUtilisateurManager
    {
        List<Utilisateur> GetListeAllUtilisateur();

        Utilisateur SaveUtilisateur(Utilisateur Utilisateur);

        Utilisateur GetUtilisateurByID(int id);

        Utilisateur UpdateUtilisateur(Utilisateur Utilisateur);

        Utilisateur Delete(int id);
    }
}
