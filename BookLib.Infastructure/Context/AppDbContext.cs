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
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(entity => {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(100);
                entity.Property(b => b.Series).HasMaxLength(100);
                entity.Property(b => b.AuthorFirst).IsRequired().HasMaxLength(100);
                entity.Property(b => b.AuthorLast).IsRequired().HasMaxLength(100);
                entity.Property(b => b.Genre).IsRequired();
                entity.Property(b => b.Description).HasMaxLength(300);
                entity.Property(b => b.AgeLevel).IsRequired().HasMaxLength(50); });
            
            modelBuilder.Entity<Users>(entity => {
                entity.ToTable("Users");
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.UserPass).IsRequired().HasMaxLength(100);
                entity.Property(u => u.FavGenre);
                entity.Property(u => u.NoGenre);
            });

            //modelBuilder.Entity<UserFavs>(entity =>
            //{
            //    entity.ToTable("UserFavs");
            //    entity.HasKey(uf => new { uf.UserId, uf.BookId });

            //    entity.HasOne(uf => uf.User)
            //          .WithMany(u => u.FavoriteBooks)
            //          .HasForeignKey(uf => uf.UserId);

            //    entity.HasOne(uf => uf.Book)
            //          .WithMany(b => b.FavoritedBy)
            //          .HasForeignKey(uf => uf.BookId);
            //});
        }    
    }
}
