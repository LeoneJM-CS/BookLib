using System;
using BookLib.App.Interfaces;
using BookLib.Infastructure.Context;
using BookLib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Infastructure.Repositories
{
    public class UserRepos : IUserRepos
    {
        private readonly AppDbContext context;
        public UserRepos(IDbContextFactory<AppDbContext> factory) 
        {
            context = factory.CreateDbContext();
        }
        public async Task<bool> AddUserAsync(Users users)
        {
            context.Users.Add(users);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<Users?> GetUserByIdAsync(string userId)
        {
            if (!Guid.TryParse(userId, out var guid))
            {
                return null;
            }
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == guid);
        }
        public async Task<Users?> GetUsersAsync(string username, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.UserPass == password);
        }
    }
}
