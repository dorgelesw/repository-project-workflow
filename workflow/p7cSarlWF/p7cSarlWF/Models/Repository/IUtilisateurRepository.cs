using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Repository
{
    interface IUtilisateurRepository
    {
        List<Utilisateur> GetListeAllUtilisateur();

        List<Client> GetListeAllClient();

        Client saveClient(Client client);
        Utilisateur SaveUtilisateur(Utilisateur Utilisateur);
        Utilisateur GetUtilisateurByID(int id);
        Utilisateur UpdateUtilisateur(Utilisateur Utilisateur);

        Utilisateur Delete(int id);

        Client UpdateClient(Client Client);

        Client GetClientByID(int id);
    }
}
