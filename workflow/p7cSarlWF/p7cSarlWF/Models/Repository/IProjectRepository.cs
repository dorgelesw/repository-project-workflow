using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Repository
{
    interface IProjectRepository
    {
        List<Project> GetAllProjects();
        Project SaveProject(Project Project);
        Project UpdateProject(Project Project);
        Project GetProjectByID(int ProjectID);
        ProjectRessource SaveProjectRessource(ProjectRessource pr);
        Project Delete(int id);
    }
}
