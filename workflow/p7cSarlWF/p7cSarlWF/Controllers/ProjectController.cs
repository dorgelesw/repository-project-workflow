using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p7cSarlWF.Controllers
{
    public class ProjectController : BaseController
    {
        public IRessourceManager RessourceManager { get; set; }
        public IUtilisateurManager UtilisateurManager { get; set; }
        public IProjectManager ProjectManager { get; set; }
        public IClientManager ClientManager { get; set; }
        //
        // GET: /Project/
        public ActionResult Index()
        {
            List<Project> Projects = ProjectManager.GetAllProjects();
            return View(Projects);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Client> clients = ClientManager.GetListeAllClient();
            List<Utilisateur> Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            List<Project> Projects = ProjectManager.GetAllProjects();
            ViewBag.Clients = clients;
            ViewBag.Utilisateurs = Utilisateurs;
            ViewBag.Projects = Projects;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorIdentifier,ParentID,PriorityID,StartDate,EndDate,ProjectLocation,ProjectBudget,ProjectDescription,ProjectFullName,ProjectShortName,ProjectManager,ProjectResponsible,ProjectStatus,ProjectUrl,ClientID")]Project Project)
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

                return RedirectToAction("Ressources", new {@id=Project.ProjectID});
            }
            return View(Project);
        }

        [HttpGet]
        public ActionResult Ressources(int id)
        {
            Project Project = ProjectManager.GetProjectByID(id);

            List<TypeRessource> TypesRessources = RessourceManager.GetAllTypesRessources();

            List<Ressource> Ressources = RessourceManager.GetAllRessourcesByType(TypesRessources.ElementAt(0).TypeRessourceID);
                        
            ViewBag.TypesRessources = TypesRessources;
            ViewBag.Ressources = Ressources;

            return View(Project);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Project projet = ProjectManager.GetProjectByID(id);
            if (projet != null)
            {
                List<Client> clients = ClientManager.GetListeAllClient();
                List<Utilisateur> Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
                List<Project> Projects = ProjectManager.GetAllProjects();
                ViewBag.Clients = clients;
                ViewBag.Utilisateurs = Utilisateurs;
                ViewBag.Projects = Projects;
                return View(projet);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Project Project)
        {
            if (ModelState.IsValid)
            {
                Project = ProjectManager.UpdateProject(Project);
                return RedirectToAction("Index");
            }
            else
            {
                List<Client> clients = ClientManager.GetListeAllClient();
                List<Utilisateur> Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
                List<Project> Projects = ProjectManager.GetAllProjects();
                ViewBag.Clients = clients;
                ViewBag.Utilisateurs = Utilisateurs;
                ViewBag.Projects = Projects;
                return View(Project);
            }
        }

        public ActionResult Delete(int id)
        {
            Project Project = ProjectManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ProjectController()
        {
            RessourceManager = (IRessourceManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceManager));
            UtilisateurManager = (IUtilisateurManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
            ProjectManager = (IProjectManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProjectManager));
            ClientManager = (IClientManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IClientManager));
        }
	}
}