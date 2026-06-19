using SmartPM.Api.Models;
using SmartPM.Api.Endpoints;
using SmartPM.Api.Services;
using Microsoft.EntityFrameworkCore;
using SmartPM.Api.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ProjectService>();   
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapProjectEndpoints();
app.MapAuthEndpoints();
app.Run();