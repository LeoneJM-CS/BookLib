using System;
using BookLib.App.Interfaces;
using BookLib.Infastructure.Context;
using BookLib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Infastructure.Repositories
{
    public class BookRepos : IBookRepos
    {
        private readonly AppDbContext context;
        public BookRepos(IDbContextFactory<AppDbContext> factory) 
        {
            context = factory.CreateDbContext();
        }
        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }
        public async Task<List<Book>> GetAllAsync()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }
        public async Task<Book?> GetBookIdAsync(Guid id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }
        public async Task UpdateBookAsync(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            var search = await context.Books.AnyAsync();
            return await context.Books
                .Where(b => b.Title.Contains(searchTerm)
                         || b.AuthorFirst.Contains(searchTerm)
                         || b.AuthorLast.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
