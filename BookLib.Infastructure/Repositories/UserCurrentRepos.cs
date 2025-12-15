using BookLib.App.Interfaces;
using BookLib.Domain.Entities;
using BookLib.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.Infastructure.Repositories
{
    public class UserCurrentRepos : IUserCurrentRepos
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserCurrentRepos(IDbContextFactory<AppDbContext> factory)
        {
            _contextFactory = factory;
        }

        public async Task<List<UserCurrent>> GetAllCurrentAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var currUser = await context.UserCurrent.ToListAsync();
            return currUser;
        }

        public async Task<bool> AddUserCurrentAsync(UserCurrent usercurrent)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.UserCurrent.Add(usercurrent);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
        public async Task UpdateCurrentUserAsync(UserCurrent usercurrent)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(usercurrent).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<UserCurrent?> GetCurrentIdAsync(Guid id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var currUser = await context.UserCurrent.FirstOrDefaultAsync(uc => uc.UserId == id);
            return currUser;
        }

        public async Task<UserCurrent?> LogoutUserAsync(string username, string password)
        {
            Console.WriteLine($"Logout attempt with {username} / {password}");
            await using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.UserCurrent.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return null;
            }

            //var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Users>();
            //var result = hasher.VerifyHashedPassword(user, user.UserPass, password);
            //if (result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
            //{
            //    // successful login - navigate to home
            //    NavigationManager.NavigateTo("/home");
            //}
            //else
            //{
            //    error = "Invalid username or password.";
            //}
            return user;
        }

        public async Task<bool> RemoveUserCurrentAsync(UserCurrent userCurrent)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.UserCurrent.Remove(userCurrent);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
// This code was edited