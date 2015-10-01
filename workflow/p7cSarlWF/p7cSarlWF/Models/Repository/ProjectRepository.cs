using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p7cSarlWF.Models.Repository
{
    /**
     * Ce repository va gérer le concept Project
     * */
    public class ProjectRepository : IProjectRepository
    {
        
        public List<Project> GetAllProjects()
        {
            WorkFlowContext context = new WorkFlowContext();
            return context.Projects.ToList();
        }

        public Project GetProjectByID(int ProjectID)
        {
            
            WorkFlowContext context = new WorkFlowContext();
            Project Project = context.Projects.Find(ProjectID);            
            Project.ProjectRessources = context.ProjectRessources.Where(pr => pr.ProjectID==ProjectID).ToList();
            return Project;

        }

        public Project SaveProject(Project Project)
        {
            WorkFlowContext context = new WorkFlowContext();
            Project = context.Projects.Add(Project);
            context.SaveChanges();

            return Project;
        }
    }
}