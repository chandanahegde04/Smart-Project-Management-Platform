using SmartPM.Api.Models;
namespace SmartPM.Api.Endpoints;
using SmartPM.Api.Services;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this WebApplication app)
    {
        app.MapGet("/api/projects", (ProjectService projectService) =>
        {
            var projects = projectService.GetProjects();

            return Results.Ok(projects);
        });
    }
}