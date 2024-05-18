using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Data;

namespace Nika1337.Library.Web.Extensions;

public static partial class Extensions
{
    public static void ConfigureLibraryContext(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LibraryConnection"))
        );
    }
}