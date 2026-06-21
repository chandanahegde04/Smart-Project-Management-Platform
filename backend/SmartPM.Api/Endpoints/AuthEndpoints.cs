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
        app.MapPost("/api/auth/register",
async (
    RegisterRequest request,
    UserService userService
) =>
{
    if (await userService
        .UserExistsAsync(request.Username))
    {
        return Results.BadRequest(
            "Username already exists");
    }

    var user =
        await userService.CreateUserAsync(
            request.Username,
            request.Password);

    return Results.Created(
        $"/api/users/{user.Id}",
        new
        {
            user.Id,
            user.Username
        });
});
    }
}