
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Library.Model;

namespace Library.Data.Configuration;

public class CompanyAccountConfiguration : IEntityTypeConfiguration<CompanyAccount>
{
    public void Configure(EntityTypeBuilder<CompanyAccount> builder)
    {
        builder
            .ToTable("CompanyAccount");
    }
}
