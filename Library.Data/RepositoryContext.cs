using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library.Data.Configuration;
using Library.Model;

namespace Library.Data;

public class RepositoryContext(DbContextOptions options) : IdentityDbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookEdition> BookEditions { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bookshelf> Bookshelves { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CompanyAccount> CompanyAccounts { get; set; }
    public DbSet<PersonalAccount> PersonalAccounts { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookCopyConfiguration());
        modelBuilder.ApplyConfiguration(new BookEditionConfiguration());
        modelBuilder.ApplyConfiguration(new BookShelfConfiguration());
        modelBuilder.ApplyConfiguration(new ShelfConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}