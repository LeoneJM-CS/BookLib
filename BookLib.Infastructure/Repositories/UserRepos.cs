using BookLib.App.Interfaces;
using BookLib.Domain.Entities;
using BookLib.Infastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace BookLib.Infastructure.Repositories
{
    public class UserRepos : IUserRepos
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserRepos(IDbContextFactory<AppDbContext> factory)
        {
            _contextFactory = factory;
        }

        public async Task<bool> AddUserAsync(Users users)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Users.Add(users);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Users?> GetUserIdAsync(Guid id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }
        public async Task UpdateUserAsync(Users users)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(users).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<Users?> LoginAsync(string username, string password)
        {
            Console.WriteLine($"Login attempt with {username} / {password}");
            await using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);

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
    }
}
// This code was edited
