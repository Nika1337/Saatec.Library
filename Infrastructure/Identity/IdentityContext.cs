using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Identity.Config;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;

namespace Nika1337.Library.Infrastructure.Identity;

public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<Employee, EmployeeRole, string>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new EmployeeRoleConfiguration());
        builder.ApplyConfiguration(new NavigationMenuItemConfiguration());
        builder.ApplyConfiguration(new EmployeeConfiguration());
    }
}