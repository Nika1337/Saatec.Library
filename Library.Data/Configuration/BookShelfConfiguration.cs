using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Library.Model;

namespace Library.Data.Configuration;

public class BookShelfConfiguration : IEntityTypeConfiguration<Bookshelf>
{
    public void Configure(EntityTypeBuilder<Bookshelf> builder)
    {
      // TODO
    }
}