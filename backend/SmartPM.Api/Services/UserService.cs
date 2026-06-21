using Microsoft.EntityFrameworkCore;
using SmartPM.Api.Data;
using SmartPM.Api.Models;

namespace SmartPM.Api.Services;

public class UserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByUsernameAsync(
        string username)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(
                x => x.Username == username);
    }
    public async Task<User> CreateUserAsync(
    string username,
    string password)
{
    var user = new User
    {
        Username = username,
        PasswordHash = password
    };

    _dbContext.Users.Add(user);

    await _dbContext.SaveChangesAsync();

    return user;
}
 public async Task<bool> UserExistsAsync(
    string username)
{
    return await _dbContext.Users
        .AnyAsync(x => x.Username == username);
}
}