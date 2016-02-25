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
    /// <summary>
    /// Project controller API.
    /// This class implement all the services associated to a project.
    /// </summary>
    public class ProjectsController : ApiController
    {
        public IRessourceManager RessourceManager { get; set; }
        public IUtilisateurManager UtilisateurManager { get; set; }
        public IProjectManager ProjectManager { get; set; }
        public IClientManager ClientManager { get; set; }

        // GET api/Projects
        //This service return the list of all project wiithout filter.
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/projects")]
        public List<Project> getProjects()
        {
            return ProjectManager.GetAllProjects();
        }


        /// <summary>
        /// This service return a project by his knowing ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns name="Project"></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/project/{Id:int}")]
        public Project getProject(int Id)
        {
            return ProjectManager.GetProjectByID(Id);
        }

        //POST api/Project
        //This service add a new project.
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/project")]
        public Project postProject([Bind(Include = "ColorIdentifier,ParentID,PriorityID,StartDate,EndDate,ProjectLocation,ProjectBudget,ProjectDescription,ProjectFullName,ProjectShortName,ProjectManager,ProjectResponsible,ProjectStatus,ProjectUrl,ClientID")]Project Project)
        {
            if (ModelState.IsValid)
            {
                Project.CreatedAt = DateTime.Now;
                Project.DeletedBy = 0;
                Project.ProjectCreator = 1;
                Project.ProjectPercentComplete = 0;
                Project.ProjectStatus = 0;
                Project.TaskCount = 0;
                Project.UpdatedBy = 0;
                Project.UpdatedDate = DateTime.Now;

                Project = ProjectManager.SaveProject(Project);

                return Project;
            }
            else
                return null;
        }

        /// <summary>
        /// This service update a project.
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/project")]
        public Project putProject([Bind(Include = "ColorIdentifier,ParentID,PriorityID,StartDate,EndDate,ProjectLocation,ProjectBudget,ProjectDescription,ProjectFullName,ProjectShortName,ProjectManager,ProjectResponsible,ProjectStatus,ProjectUrl,ClientID")]Project Project)
        {
            if (ModelState.IsValid)
            {
                Project = ProjectManager.SaveProject(Project);

                return Project;
            }
            else
                return null;
        }

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
