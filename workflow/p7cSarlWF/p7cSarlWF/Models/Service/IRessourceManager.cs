using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Service
{
    public interface IRessourceManager
    {

        List<TypeRessource> GetAllTypesRessources();
        List<TypeRessource> GetAllTypesRessourcesByUserID(int UtilisateurID);


        List<Ressource> GetAllRessources();
        List<Ressource> GetAllRessourcesByType(int TypeRessourceID);

        TypeRessource SaveTypeRessource(TypeRessource type);

        TypeRessource GetTypeRessourceByID(int TypeRessourceID);

        Ressource SaveRessource(Ressource Ressource);

        Ressource GetRessourceByID(int id);

        void SaveFichier(Fichier fichier);
    }
}
