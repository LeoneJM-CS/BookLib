using BookLib.App.Interfaces;
using BookLib.Domain.Entities;
using BookLib.Infastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace BookLib.Infastructure.Repositories
{
    public class UserRepos : IUserRepos
    {
        private readonly AppDbContext _context;
        public UserRepos(AppDbContext context)
        {
            _context = context;
        }
        public UserRepos(IDbContextFactory<AppDbContext> factory) 
        {
            _context = factory.CreateDbContext();
        }
        public async Task<bool> AddUserAsync(Users users)
        {
            _context.Users.Add(users);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Users?> GetUserIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }
        public async Task<Users?> LoginAsync(string username, string password)
        {
            Console.WriteLine($"Login attempt with {username} / {password}");
            //string error = string.Empty;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

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
