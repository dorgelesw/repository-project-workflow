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


        public List<Project> GetAllProjects()
        {
            return Repository.GetAllProjects();
        }

        public Project SaveProject(Project Project)
        {
            return Repository.SaveProject(Project);
        }

        public Project GetProjectByID(int ProjectID)
        {
            return Repository.GetProjectByID(ProjectID);
        }








        public ProjectManager()
        {//injection de la dépendance
            Repository = (IProjectRepository) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProjectRepository));

        }

    }
}