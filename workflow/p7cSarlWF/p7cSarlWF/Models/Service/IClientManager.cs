using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Service
{
    public interface IClientManager
    {
        List<Client> GetListeAllClient();

        Client saveClient(Client client);
    }
}
