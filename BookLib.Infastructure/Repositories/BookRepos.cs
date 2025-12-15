using BookLib.App.Interfaces;
using BookLib.Domain.Entities;
using BookLib.Domain.Enums;
using BookLib.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookLib.Infastructure.Repositories
{
    public class BookRepos : IBookRepos
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public BookRepos(IDbContextFactory<AppDbContext> factory)
        {
            _contextFactory = factory;
        }

        public async Task AddAsync(Book book)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookIdAsync(Guid id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task UpdateBookAsync(Book book)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Books
                .Where(b => b.Title.Contains(searchTerm)
                         || b.AuthorFirst.Contains(searchTerm)
                         || b.AuthorLast.Contains(searchTerm)
                         || b.Series.Contains(searchTerm))
                .ToListAsync();
        }
        public async Task<List<Book>> SearchByNameAsync(string name)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            if (string.IsNullOrWhiteSpace(name))
                return await context.Books.ToListAsync();

            var search = name.ToLower();

            return await context.Books
                .Where(b =>
                    (b.Title != null &&
                     EF.Functions.Like(b.Title, $"%{name}%")) ||
                    (b.AuthorFirst != null &&
                     EF.Functions.Like(b.AuthorFirst, $"%{name}%")) ||
                     (b.AuthorLast != null &&
                     EF.Functions.Like(b.AuthorLast, $"%{name}%")) ||
                     (b.Series != null &&
                     EF.Functions.Like(b.Series, $"%{name}%"))
        )
        .ToListAsync();

        }
        public async Task<List<Book>> SearchByGenreAsync(Genre genre)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Books
                .Where(b => b.Genre == genre)
                .ToListAsync();
        }
    }
}
// This code was edited