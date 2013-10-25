using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Models;

namespace TheProjector.DAO
{
    public interface IProjectRepository
    {

        List<ProjectModel> GetProjects();
        List<ProjectModel> GetProjectByID(int projectId);
        string CreateProject(ProjectModel project);
        string UpdateProject(ProjectModel project);
        string DeleteProject(int projectId);
        string AuthenticateUser(PersonModel person);
        string CreatePerson(PersonModel person);

    }
}
