using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using TheProjector.Models;

namespace TheProjector.DAO
{
    public class ProjectDAL: IProjectRepository
    {

        private ProjectorEntities entityProjects = new ProjectorEntities();
        private static Logger _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());



        public List<ProjectModel> GetProjects()
        {
            var projectModel = new List<ProjectModel>();

            try
            {
                projectModel.AddRange(from proj in entityProjects.Projects
                                      select new ProjectModel
                                      {
                                          Code = proj.Code,
                                          Name = proj.Name,
                                          Budget = proj.Budget.GetValueOrDefault(),
                                          Remarks = proj.Remarks
                                      });
            }
            catch (Exception ex)
            {
                _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));             
                return new List<ProjectModel>();
            }

            return projectModel;                             
            
        }

        public List<ProjectModel> GetProjectByID(int projectId)
        {
            var project= new List<ProjectModel>();
            if (projectId == 0 || projectId < 1) return project;

            try
            {
                project.AddRange(from proj in entityProjects.Projects
                           where proj.ProjectId == projectId
                           select new ProjectModel
                           {
                               Code= proj.Code,
                               Name = proj.Name,
                               Remarks = proj.Remarks,
                               Budget = proj.Budget.GetValueOrDefault()
                           });
            }
            catch (Exception ex)
            {
                _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));               
                return new List<ProjectModel>();
            }

            return project;                
            
        }

        public string CreateProject(ProjectModel project)
        {
            var response = string.Empty;
            if (String.IsNullOrEmpty(project.Code) || String.IsNullOrEmpty(project.Name) || project.Budget == 0)

                return response = "All fields are required...";

                try
                {
                    var createNew = entityProjects.Projects.Add(new Project
                    {
                        Name = project.Name,
                        Code = project.Code,
                        Remarks = project.Remarks,
                        Budget = project.Budget
                    });
                    entityProjects.SaveChanges();
                    response = "Successfully Added";
                }
                catch (Exception ex)
                {
                    _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));
                    response = "Exception Error";
                }

            return response;

        }

        public string UpdateProject(ProjectModel project)
        {
            var response = string.Empty;
            if (String.IsNullOrEmpty(project.Code) || String.IsNullOrEmpty(project.Name) || project.Budget == 0)

                return response = "All fields are required...";

            try
            {
                var updateProject = entityProjects.Projects.Where(a=> a.ProjectId == project.ProjectId).FirstOrDefault();
                
                    updateProject.Name = project.Name;
                    updateProject.Code = project.Code;
                    updateProject.Remarks = project.Remarks;
                    updateProject.Budget = project.Budget;                
                       
                entityProjects.SaveChanges();
                response = "Successfully Updated";
            }
            catch (Exception ex)
            {
                _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));
                response = "Exception Error";
            }

            return response;

        }

        public string DeleteProject(int projectId)
        {
            var response = string.Empty;
            if (projectId == 0)
                return response = "Please select a record to delete";

            try
            {
                var record = entityProjects.Projects.Where(a => a.ProjectId == projectId).FirstOrDefault();
                entityProjects.Projects.Remove(record);
                entityProjects.SaveChanges();
                response = "Successfully deleted";
            }
            catch (Exception ex)
            {
                _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));
                response = "Exception Error";
            }

            return response;

        }

        public string AuthenticateUser(PersonModel person)
        {
            var authenticationStatus = string.Empty;

            if (String.IsNullOrEmpty(person.UserName) || String.IsNullOrEmpty(person.Password)) return authenticationStatus = "User name and password is required!";

            else
            {
                try
                {
                    var isAuthenticated = entityProjects.People.Where(a => a.UserName == person.UserName
                        && a.Password == a.Password);

                    if (isAuthenticated.Any())
                    {
                        authenticationStatus = "User found...";
                    }
                    else
                        authenticationStatus="Invalid user name or password!";
                }
                catch (Exception ex)
                {
                    _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));
                    authenticationStatus = "Exception Error";
                }
            }

            return authenticationStatus;
        }

        public string CreatePerson(PersonModel person)
        {
            var response = string.Empty;
            if (String.IsNullOrEmpty(person.FirstName) || String.IsNullOrEmpty(person.LastName) || String.IsNullOrEmpty(person.UserName)
                || String.IsNullOrEmpty(person.Password))

                return response = "All fields are required..."; 
          
            try
            {
                var createNew = entityProjects.People.Add(new Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    UserName = person.UserName,
                    Password = person.Password
                });
                entityProjects.SaveChanges();
                response = "User Successfully Added";
            }
            catch (Exception ex)
            {
                _logger.Fatal(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));
                response = "Exception Error";
            }
            
            return response;

        }
        
    }
}