using SmartPM.Api.Models;
namespace SmartPM.Api.Endpoints;
using SmartPM.Api.Services;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this WebApplication app)
    {
        app.MapGet("/api/projects", async (ProjectService projectService) =>
        {
            var projects = await projectService.GetProjectsAsync();

            return Results.Ok(projects);
        });
        app.MapGet("/api/projects/{id}", async (int id, ProjectService projectService) =>
        {
            var project =
            await projectService.GetProjectByIdAsync(id);

            return project is null? Results.NotFound() : Results.Ok(project);
        });
    }
}