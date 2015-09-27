using p7cSarlWF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace p7cSarlWF.Models.Service
{
    public class ClientManager : IClientManager
    {
        private IUtilisateurRepository Repository { get; set; }

        public List<Client> GetListeAllClient()
        {
            return Repository.GetListeAllClient();
        }

        public Client saveClient(Client client)
        {
            return Repository.saveClient(client);
        }

        public ClientManager()
        {//injection de la dépendance
            Repository = (IUtilisateurRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurRepository));
        }
    }
}