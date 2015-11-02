using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7cSarlWF.Models.Service
{
    public interface IProjectManager
    {
        List<Project> GetAllProjects();
        Project GetProjectByID(int ProjectID);
        Project SaveProject(Project Project);
        Project UpdateProject(Project Project);
        ProjectRessource SaveProjectRessource(ProjectRessource pr);

        Project Delete(int id);
    }
}
