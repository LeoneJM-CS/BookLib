using System;
using BookLib.Domain.Entities;

namespace BookLib.App.Interfaces
{
    public interface IBookRepos
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetBookIdAsync(Guid id);
        Task UpdateBookAsync(Book book);
        Task<IEnumerable<Book>> SearchBooksAsync(string search);
    }
}
