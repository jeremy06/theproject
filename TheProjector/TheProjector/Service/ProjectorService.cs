using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheProjector.DAO;
using TheProjector.Models;

namespace TheProjector.Service
{
    public class ProjectorService
    {

        ProjectDAL projectorDAL = new ProjectDAL();

        public Object GetProjectList()
        {           
            var projects = projectorDAL.GetProjects();

            var data = new { projects };

            return data;
        }

        public Object GetProject(int projectId)
        {
            var project = projectorDAL.GetProjectByID(projectId);

            var data = new { project};

            return data;
        }

        public Object CreateProjectResponse(ProjectModel project)
        {
            var status = projectorDAL.CreateProject(project);

            var data = new { status };

            return data;

        }

        public Object UpdateProjectResponse(ProjectModel project)
        {
            var status = projectorDAL.UpdateProject(project);

            var data = new { status };

            return data;

        }

        public Object RemoveProjectResponse(int projectId)
        {
            var status = projectorDAL.DeleteProject(projectId);

            var data = new { status };

            return data;

        }
    }
}