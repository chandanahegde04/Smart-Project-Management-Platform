using SmartPM.Api.Models;
namespace SmartPM.Api.Endpoints;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this WebApplication app)
    {
        app.MapGet("/api/projects", () =>
        {
            var projects = new[]
            {
                new Project
                {
                    Id = 1,
                    Name = "Smart Project Management Platform",
                    Status = "In Progress"
                },
                new Project
                {
                    Id = 2,
                    Name = "Learning ASP.NET Core",
                    Status = "Completed"
                }
            };

            return Results.Ok(projects);
        });
    }
}