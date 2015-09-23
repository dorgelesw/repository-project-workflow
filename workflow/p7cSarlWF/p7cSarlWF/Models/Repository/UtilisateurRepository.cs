using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models.Repository
{
    /**
     * Ce repository va gérer les concepts Utilisateur, ProfilUtilisateur et Client pour le projet
     * */
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private static WorkFlowContext context
        {
            get { return new WorkFlowContext(); }
        }

        public List<Utilisateur> GetListeAllUtilisateur()
        {
            return context.Utilisateurs.ToList();
        }

    }
}