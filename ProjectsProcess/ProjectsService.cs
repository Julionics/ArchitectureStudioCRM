using CRMDataModel;
using ProjectsProcess;
using CRMDataModel.Models;

public class ProjectsService : IProjectService
{
    private readonly CRMContext _context;
    public ProjectsService(CRMContext context)
    {
        _context = context;
    }

    public List<Project> GetAllProjects()
    {
        return _context.Projects.ToList();
    }

    public Project GetProjectById(int id)
    {
        return _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
    }

    public void AddProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }
    public void UpdateProject(Project project)
    {
        var existingProject = _context.Projects.Where(p => p.ProjectId == project.ProjectId).FirstOrDefault();

        if 
           
            (existingProject != null)
        { 
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            existingProject.Status = project.Status;

            _context.SaveChanges();
        }

        else
        {
            throw new InvalidOperationException("Projekti nuk u gjet ne bazen e te dhenave.");
        }
    }


public void DeleteProject(int id)
{
    var project = _context.Projects.Find(id);
    if(project !=null)
    {
        _context.Projects.Remove(project);
        _context.SaveChanges();
    }
}

public List<Project>GetProjectsByStatus(string status)
{
    return _context.Projects.Where(p => p.Status == status).ToList();
}

   public bool ProjectExists(int projectId)
   {
     return _context.Projects.Any(p => p.ProjectId == projectId);
   }
}
