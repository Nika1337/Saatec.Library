using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Identity.Entities;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
{
    public void Configure(EntityTypeBuilder<EmployeeRole> builder)
    {
        builder
            .HasMany(er => er.NavigationMenuItems)
            .WithMany();

        builder.HasData(
            new EmployeeRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new EmployeeRole
            {
                Name = "Librarian",
                NormalizedName = "LIBRARIAN"
            },
            new EmployeeRole
            {
                Name = "Consultant",
                NormalizedName = "CONSULTANT"
            },
            new EmployeeRole
            {
                Name = "Core Librarian",
                NormalizedName = "CORELIBRARIAN"
            },
            new EmployeeRole
            {
                Name = "Human Resources Manager",
                NormalizedName = "HRMANAGER"
            }
        );
    }
}