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
        private WorkFlowContext context
        {
            get { return new WorkFlowContext(); }
        }



    }
}