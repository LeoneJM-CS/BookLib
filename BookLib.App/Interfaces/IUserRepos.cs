using BookLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.App.Interfaces
{
    public interface IUserRepos
    {
        Task<Users?> GetUserIdAsync(Guid id);
        Task<bool> AddUserAsync(Users users);
        //Task AddFavBookAsync(UserFavs userFavs);
        Task<Users> LoginAsync(string username, string password);
        
    }
}
