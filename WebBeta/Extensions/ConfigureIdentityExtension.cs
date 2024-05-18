using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Data;
using Nika1337.Library.Infrastructure.Identity;
using Nika1337.Library.Infrastructure.Identity.Entities;

namespace Nika1337.Library.Web.Extensions;

public partial class Extensions
{
    public static void ConfigureIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        services
                .AddIdentity<Employee, IdentityRole>(a =>
                {
                    a.Password.RequireDigit = true;
                    a.Password.RequireLowercase = true;
                    a.Password.RequireUppercase = true;
                    a.Password.RequireNonAlphanumeric = false;
                    a.Password.RequiredLength = 8;
                    a.User.RequireUniqueEmail = true;
                }
                )
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
    }
}
