using SmartPM.Api.Models;

namespace SmartPM.Api.Services;

public class ProjectService
{
    public List<Project> GetProjects()
    {
        return new List<Project>
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
    }
}