using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace p7cSarlWF.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        public IRessourceManager RessourceManager { get; set; }
        public IUtilisateurManager UtilisateurManager { get; set; }
        public IProjectManager ProjectManager { get; set; }
        public IClientManager ClientManager { get; set; }

        public ProjectRessource PostRessource([Bind(Include = "ProjectID,RessourceID,Quantite,Note")]ProjectRessource ProjectRessource)
        {
            if (ModelState.IsValid)
            {
                ProjectRessource.AffectationDate = DateTime.Now;
                ProjectRessource.Deleted = false;
                ProjectRessource.DeleteDate = DateTime.MaxValue;

                //Project projet = ProjectManager.GetProjectByID(ProjectRessource.ProjectID);
                //ProjectRessource.Project = projet;
                //Ressource Ressource = RessourceManager.GetRessourceByID(ProjectRessource.RessourceID);
                ProjectRessource = ProjectManager.SaveProjectRessource(ProjectRessource);

                //Project projet = ProjectManager.GetProjectByID(ProjectRessource.ProjectID);
                //projet.ProjectRessources.Add(ProjectRessource);

                //projet = ProjectManager.UpdateProject(projet);

                //ProjectRessource = projet.ProjectRessources.Last();

                return ProjectRessource;
            }
            return null;
        }

        public ProjectsController()
        {
            RessourceManager = (IRessourceManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceManager));
            UtilisateurManager = (IUtilisateurManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
            ProjectManager = (IProjectManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProjectManager));
            ClientManager = (IClientManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IClientManager));
        }
    }
}
