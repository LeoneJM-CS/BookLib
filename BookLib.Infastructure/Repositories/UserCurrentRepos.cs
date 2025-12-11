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
        private readonly AppDbContext _context;
        public UserCurrentRepos(AppDbContext context)
        {
            _context = context;
        }
        public UserCurrentRepos(IDbContextFactory<AppDbContext> factory)
        {
            _context = factory.CreateDbContext();
        }

        public async Task<List<UserCurrent>> GetAllCurrentAsync()
        {
            var currUser = await _context.UserCurrent.ToListAsync();
            return currUser;
        }
        public async Task<bool> AddUserCurrentAsync(UserCurrent usercurrent)
        {
            _context.UserCurrent.Add(usercurrent);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<UserCurrent?> GetCurrentIdAsync(Guid id)
        {
            var currUser = await _context.UserCurrent.FirstOrDefaultAsync(uc => uc.UserId == id);
            return currUser;
        }
        public async Task<UserCurrent?> LogoutUserAsync(string username, string password)
        {
            Console.WriteLine($"Logout attempt with {username} / {password}");
            //string error = string.Empty;
            var user = await _context.UserCurrent.FirstOrDefaultAsync(u => u.UserName == username);

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
            _context.UserCurrent.Remove(userCurrent);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
