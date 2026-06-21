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
}