using Microsoft.EntityFrameworkCore;
using SmartPM.Api.Models;

namespace SmartPM.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
}