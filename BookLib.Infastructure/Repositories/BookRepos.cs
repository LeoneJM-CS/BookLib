using System;
using BookLib.App.Interfaces;
using BookLib.Infastructure.Context;
using BookLib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Infastructure.Repositories
{
    public class BookRepos : IBookRepos
    {
        private readonly AppDbContext _contextFactory;
        public BookRepos(AppDbContext context)
        {
            _contextFactory = context;
        }
        public BookRepos(IDbContextFactory<AppDbContext> factory) 
        {
            _contextFactory = factory.CreateDbContext();
        }
        public async Task AddAsync(Book book)
        {
            _contextFactory.Books.Add(book);
            await _contextFactory.SaveChangesAsync();
        }
        public async Task<List<Book>> GetAllAsync()
        {
            var books = await _contextFactory.Books.ToListAsync();
            return books;
        }
        public async Task<Book?> GetBookIdAsync(Guid id)
        {
            var book = await _contextFactory.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }
        public async Task UpdateBookAsync(Book book)
        {
            _contextFactory.Entry(book).State = EntityState.Modified;
            await _contextFactory.SaveChangesAsync();
        }
        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            var search = await _contextFactory.Books.AnyAsync();
            return await _contextFactory.Books
                .Where(b => b.Title.Contains(searchTerm)
                         || b.AuthorFirst.Contains(searchTerm)
                         || b.AuthorLast.Contains(searchTerm)
                         || b.Series.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
