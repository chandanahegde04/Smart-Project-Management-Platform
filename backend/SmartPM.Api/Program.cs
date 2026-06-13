var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/api/projects", () =>
{
    var projects = new[]
    {
        new
        {
            Id = 1,
            Name = "Smart Project Management Platform",
            Status = "In Progress"
        },
        new
        {
            Id = 2,
            Name = "Learning ASP.NET Core",
            Status = "Completed"
        }
    };

    return Results.Ok(projects);
});
app.Run();