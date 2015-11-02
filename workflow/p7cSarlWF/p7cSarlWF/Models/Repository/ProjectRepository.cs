using p7cSarlWF.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Project UpdateProject(Project Project)
        {
            WorkFlowContext context = new WorkFlowContext();
            context.Entry(Project).State = EntityState.Modified;
            context.SaveChanges();
            return Project;
        }

        public ProjectRessource SaveProjectRessource(ProjectRessource pr)
        {

            WorkFlowContext context = new WorkFlowContext();
            Project Project = context.Projects.Find(pr.ProjectID);
            Project.ProjectRessources.Add(pr);
            context.Entry(Project).State = EntityState.Modified;
            //pr = context.ProjectRessources.Add(pr);
            context.SaveChanges();
            return pr;

        }

        public Project Delete(int id)
        {
            WorkFlowContext context = new WorkFlowContext();
            Project Project = context.Projects.Find(id);
            context.Entry(Project).State = EntityState.Deleted;
            context.SaveChanges();
            return Project;
        }

    }
}