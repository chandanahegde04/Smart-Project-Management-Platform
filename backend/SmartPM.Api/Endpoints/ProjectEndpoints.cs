using SmartPM.Api.Models;
namespace SmartPM.Api.Endpoints;
using SmartPM.Api.Services;
using Microsoft.AspNetCore.Authorization;

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
        }).RequireAuthorization();
        app.MapPost("/api/projects", async (Project project,
        ProjectService projectService) =>
        {
            var createdProject =
            await projectService.CreateProjectAsync(project);
            return Results.Created( $"/api/projects/{createdProject.Id}", createdProject);
        });
        app.MapPut("/api/projects/{id}", async (int id, Project project, ProjectService projectService) =>
        {
        var updatedProject =
            await projectService.UpdateProjectAsync(id, project);
            return updatedProject is null ? Results.NotFound() : Results.Ok(updatedProject);
        }).RequireAuthorization();
        app.MapDelete("/api/projects/{id}", async (int id, ProjectService projectService) =>
        {
            var deleted = await projectService.DeleteProjectAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).RequireAuthorization();
    }
}