﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Data.Config;

internal class BookEditionConfiguration : IEntityTypeConfiguration<BookEdition>
{
    public void Configure(EntityTypeBuilder<BookEdition> builder)
    {
        builder
            .Property(be => be.Isbn)
            .HasMaxLength(20);

        builder
            .HasOne(bk => bk.Language)
            .WithMany()
            .HasForeignKey("LanguageId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(be => be.Publisher)
            .WithMany(pu => pu.PublishedBooks)
            .HasForeignKey("PublisherId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(be => be.Shelf)
            .WithMany(sh => sh.BookEditions)
            .HasForeignKey("ShelfId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(be => be.Book)
            .WithMany(bk => bk.Editions)
            .HasForeignKey("BookId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
