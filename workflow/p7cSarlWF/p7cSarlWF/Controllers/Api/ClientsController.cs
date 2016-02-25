using p7cSarlWF.Models;
//using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace p7cSarlWF.Controllers.Api
{
    public class ClientsController : ApiController
    {
        public IClientManager ClientManager { get; set; }

        // GET api/Client
        [HttpGet]
        public List<Client> GetClients()
        {
            return ClientManager.GetListeAllClient();
        }

        public ClientsController()
        {
            ClientManager = (IClientManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IClientManager));
        }
    }
}
