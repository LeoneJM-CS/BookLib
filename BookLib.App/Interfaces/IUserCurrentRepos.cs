using BookLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.App.Interfaces
{
    public  interface IUserCurrentRepos
    {
        Task<bool> AddUserCurrentAsync(UserCurrent usercurrent);
        Task<List<UserCurrent>> GetAllCurrentAsync();
        Task<UserCurrent?> GetCurrentIdAsync(Guid id);
        Task<UserCurrent> LogoutUserAsync(string username, string password);
        Task<bool> RemoveUserCurrentAsync(UserCurrent usercurrent);
        Task UpdateCurrentUserAsync(UserCurrent usercurrent);
    }
}
