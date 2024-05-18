using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nika1337.Library.Infrastructure.Data.Config;
using Nika1337.Library.Infrastructure.Identity.Entities;

namespace Nika1337.Library.Infrastructure.Identity.Config;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .OwnsOne(ac => ac.Address, Helpers.GetAddressBuildAction<Employee>());

        builder
            .Property(er => er.Id)
            .ValueGeneratedOnAdd();

        builder.ToTable(builder =>
        {
            // Ensure TerminationDate is after StartDate
            builder.HasCheckConstraint("CK_Employee_TerminationDate", "TerminationDate IS NULL OR TerminationDate >= StartDate");

            // Ensure Employee is at least 18 when starting the job
            builder.HasCheckConstraint("CK_Employee_AgeRequirement", "DATEDIFF(year, DateOfBirth, StartDate) >= 18");
        });
    }
}
