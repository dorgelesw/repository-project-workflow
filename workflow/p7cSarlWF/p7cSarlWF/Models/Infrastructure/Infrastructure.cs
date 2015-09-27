using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using p7cSarlWF.Models;
using p7cSarlWF.Models.Repository;
using p7cSarlWF.Models.Service;

namespace p7cSarlWF.Models.Infrastructure
{
    /**
     * Dans cette classe je vai configurer l'injection des dépendances des interface repository dans les manager, ainsi que 
     *  des interfaces manager dans les controller
     * */
    public class CustomResolver : IDependencyResolver, IDependencyScope 
    {
        public object GetService(Type serviceType)
        {
            if(serviceType == typeof(IUtilisateurRepository)){
                return new UtilisateurRepository();
            }
            else if(serviceType == typeof(IProjectRepository)){
                return new ProjectRepository();
            }
            else if(serviceType == typeof(IRessourceRepository)){
                return new RessourceRepository();
            }
            else if (serviceType == typeof(IUtilisateurManager))
            {
                return new UtilisateurManager();
            }
            else if (serviceType == typeof(IProjectManager))
            {
                return new ProjectManager();
            }
            else if (serviceType == typeof(IRessourceManager))
            {
                return new RessourceManager();
            }
            else if (serviceType == typeof(IClientManager))
            {
                return new ClientManager();
            }
            else{
                return null;
            }
                        
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            // do nothing - not required
        }

    }
}