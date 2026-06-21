using SmartPM.Api.Models;
using SmartPM.Api.Services;

namespace SmartPM.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth/login",
        async (
            LoginRequest request,
            UserService userService,
            JwtService jwtService
        ) =>
        {
            var user = await userService
                .GetByUsernameAsync(request.Username);

            if (user is not null &&
                user.PasswordHash == request.Password)
            {
                var token =
                    jwtService.GenerateToken(
                        user.Username);

                return Results.Ok(new
                {
                    Token = token
                });
            }

            return Results.Unauthorized();
        });
    }
}