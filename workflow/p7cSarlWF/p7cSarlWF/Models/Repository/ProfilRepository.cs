using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models.Repository
{
    public class ProfilRepository : IProfilRepository
    {
        public Profil saveProfil(Profil Profil)
        {
            WorkFlowContext context = new WorkFlowContext();
            Profil = context.Profils.Add(Profil);
            context.SaveChanges();
            return Profil;
        }
    }
}