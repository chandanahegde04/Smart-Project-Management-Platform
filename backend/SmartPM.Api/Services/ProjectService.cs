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
}