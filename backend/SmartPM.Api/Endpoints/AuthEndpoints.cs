using SmartPM.Api.Models;

namespace SmartPM.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth/login",
            (LoginRequest request) =>
            {
                if (
                    request.Username == "admin" &&
                    request.Password == "password")
                {
                    return Results.Ok(
                        new
                        {
                            Token = "JWT_COMES_HERE"
                        });
                }

                return Results.Unauthorized();
            });
    }
}