using CRMDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsProcess
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int id);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
        List<Project> GetProjectsByStatus(string status);
        bool ProjectExists(int projectId);

    }
}
