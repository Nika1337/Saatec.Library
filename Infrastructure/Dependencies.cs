using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nika1337.Library.Infrastructure.Data;
using Nika1337.Library.Infrastructure.Identity;

namespace Nika1337.Library.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        bool useOnlyInMemoryDatabase = false;
        if (configuration["UseOnlyInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]!);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<LibraryContext>(c =>
               c.UseInMemoryDatabase("Catalog"));

            services.AddDbContext<IdentityContext>(options =>
                options.UseInMemoryDatabase("Identity"));
        }
        else
        {
            // use real database
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryConnection")));

            // Add Identity DbContext
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}