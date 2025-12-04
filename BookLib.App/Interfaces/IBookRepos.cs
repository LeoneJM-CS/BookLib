using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
using BookLib.Domain.Entities;

namespace BookLib.App.Interfaces
{
    public interface IBookRepos
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetBookIdAsync(Guid id);
        Task UpdateBookAsync(Book book);
        Task<List<Book>> SearchBooksAsync(string search);
    }
}
