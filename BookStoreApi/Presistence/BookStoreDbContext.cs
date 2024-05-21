using BookStoreApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Presistence
{
  public class BookStoreDbContext : IdentityDbContext<AppUser>
  {
    public BookStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    //public DbSet<AppUser> Users { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Report> Reports { get; set; } = null!;

  }
}
