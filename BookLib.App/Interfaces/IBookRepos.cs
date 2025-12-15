using BookLib.Domain.Entities;
using BookLib.Domain.Enums;
using System;

namespace BookLib.App.Interfaces
{
    public interface IBookRepos
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetBookIdAsync(Guid id);
        Task UpdateBookAsync(Book book);
        Task<IEnumerable<Book>> SearchBooksAsync(string search);
        Task<List<Book>> SearchByNameAsync(string name);
        Task<List<Book>> SearchByGenreAsync(Genre genre);
    }
}
