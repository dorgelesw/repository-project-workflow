using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Repository
{
    interface IRessourceRepository
    {
        List<TypeRessource> GetAllTypesRessources();
        List<TypeRessource> GetAllTypesRessourcesByUserID(int UtilisateurID);


        List<Ressource> GetAllRessources();
        List<Ressource> GetAllRessourcesByType(int TypeRessourceID);

        TypeRessource SaveTypeRessource(TypeRessource type);
    }
}
