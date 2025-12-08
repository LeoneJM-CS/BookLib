using BookLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.App.Interfaces
{
    public interface IUserRepos
    {
        Task<bool> AddUserAsync(Users users);
        //Task AddFavBookAsync(UserFavs userFavs);
    }
}
