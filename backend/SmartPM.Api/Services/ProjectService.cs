using Microsoft.EntityFrameworkCore;
using SmartPM.Api.Data;
using SmartPM.Api.Models;

namespace SmartPM.Api.Services;

public class ProjectService
{
    private readonly AppDbContext _dbContext;

    public ProjectService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Project>> GetProjectsAsync()
    {
        return await _dbContext.Projects.ToListAsync();
    }
    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _dbContext.Projects
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<Project> CreateProjectAsync(Project project)
    {
        _dbContext.Projects.Add(project);

        await _dbContext.SaveChangesAsync();

        return project;
    }
    public async Task<Project?> UpdateProjectAsync(int id, Project updatedProject)
    {
        var existingProject =
            await _dbContext.Projects.FindAsync(id);
        if (existingProject == null)
            return null;
        existingProject.Name = updatedProject.Name;
        existingProject.Status = updatedProject.Status;

        await _dbContext.SaveChangesAsync();

        return existingProject;
    }
    public async Task<bool> DeleteProjectAsync(int id)
    {
        var project =
        await _dbContext.Projects.FindAsync(id);

        if (project == null)
            return false;

        _dbContext.Projects.Remove(project);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}