using SmartPM.Api.Models;
using SmartPM.Api.Services;

namespace SmartPM.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth/login",
        (
            LoginRequest request,
            JwtService jwtService
        ) =>
        {
            if (request.Username == "admin" && request.Password == "password")
            {
                var token =jwtService.GenerateToken(request.Username);

                return Results.Ok(
                    new
                    {
                        Token = token
                    });
            }

            return Results.Unauthorized();
        });
    }
}