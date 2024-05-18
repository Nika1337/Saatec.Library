
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Infrastructure.Identity.Entities;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class NavigationMenuItemConfiguration : IEntityTypeConfiguration<NavigationMenuItem>
{
    public void Configure(EntityTypeBuilder<NavigationMenuItem> builder)
    {

        builder
            .ToTable(builder =>
                builder.HasCheckConstraint("CK_NavigationMenuItem_ParentId", "Id <> ParentNavigationMenuItemId")
            )
            .ToTable("AspNetNavigationMenuItem");

        builder
            .Property(nmi => nmi.Name)
            .HasMaxLength(30);

        builder
            .Property(nmi => nmi.Name)
            .HasMaxLength(75);

        builder
            .HasOne(cnmi => cnmi.ParentNavigationMenuItem)
            .WithMany(pnmi => pnmi.ChildNavigationMenuItems)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
