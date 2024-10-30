using CRMDataModel.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectsProcess;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET: api/Projects
    [HttpGet]
    public IActionResult GetAllProjects()
    {
        var projects = _projectService.GetAllProjects();
        return Ok(projects);
    }

    // GET: api/Projects/{id}
    [HttpGet("{id}")]
    public IActionResult GetProjectById(int id)
    {
        var project = _projectService.GetProjectById(id);
        if (project == null)
        {
            return NotFound("Projekti nuk u gjet.");
        }
        return Ok(project);
    }

    // POST: api/Projects
    [HttpPost]
    public IActionResult AddProject([FromBody] Project project)
    {
        if (project == null)
        {
            return BadRequest("Të dhënat e projektit janë të pavlefshme.");
        }

        _projectService.AddProject(project);
        return CreatedAtAction(nameof(GetProjectById), new { id = project.ProjectId }, project);
    }

    // PUT: api/Projects/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, [FromBody] Project project)
    {
        if (project == null || project.ProjectId != id)
        {
            return BadRequest("Të dhënat e projektit janë të pavlefshme.");
        }

        var existingProject = _projectService.GetProjectById(id);
        if (existingProject == null)
        {
            return NotFound("Projekti nuk u gjet.");
        }

        _projectService.UpdateProject(project);
        return NoContent();
    }

    // DELETE: api/Projects/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        var existingProject = _projectService.GetProjectById(id);
        if (existingProject == null)
        {
            return NotFound("Projekti nuk u gjet.");
        }

        _projectService.DeleteProject(id);
        return NoContent();
    }
}
