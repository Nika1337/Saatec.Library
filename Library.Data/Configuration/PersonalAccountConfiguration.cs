using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Library.Model;


namespace Library.Data.Configuration;

public class PersonalAccountConfiguration : IEntityTypeConfiguration<CompanyAccount>
{
    public void Configure(EntityTypeBuilder<CompanyAccount> builder)
    {
        builder
            .ToTable("PersonalAccount");
    }
}
