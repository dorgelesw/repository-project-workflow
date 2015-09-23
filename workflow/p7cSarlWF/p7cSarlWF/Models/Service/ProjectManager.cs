using p7cSarlWF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace p7cSarlWF.Models.Service
{
    public class ProjectManager : IProjectManager
    {
        private IProjectRepository Repository { get; set; }















        public ProjectManager()
        {//injection de la dépendance
            Repository = (IProjectRepository) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProjectRepository));

        }

    }
}