using System;
using Microsoft.EntityFrameworkCore;
using BookLib.Domain.Entities;

namespace BookLib.Infastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Series).HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.AuthorFirst).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.AuthorLast).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Genre).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Description).HasMaxLength(300);
            modelBuilder.Entity<Book>().Property(b => b.AgeLevel).IsRequired().HasMaxLength(50);
        }
    }
}
