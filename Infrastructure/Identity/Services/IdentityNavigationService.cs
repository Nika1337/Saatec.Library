using Microsoft.AspNetCore.Identity;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Identity.Services;

public class IdentityNavigationService(UserManager<Employee> userManager, RoleManager<EmployeeRole> roleManager)
{
    private readonly UserManager<Employee> _userManager = userManager;
    private readonly RoleManager<EmployeeRole> _roleManager = roleManager;

    public async Task<IEnumerable<NavigationMenuItem>> GetNavigationMenuItems(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal == null)
        {
            return [];
        }
        // Get employee for given claims principal
        var employee = await _userManager.GetUserAsync(claimsPrincipal);

        if (employee == null)
        {
            return [];
        }
        // Get role names assigned to the employee
        var roleNames = await _userManager.GetRolesAsync(employee);

        // Query roles and navigation menu items
        var menuItems = new List<NavigationMenuItem>();

        foreach (var roleName in roleNames)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role != null)
            {
                // Add navigation menu items associated with this role
                menuItems.AddRange(role.NavigationMenuItems);
            }
        }

        // Ensure distinct menu items
        return menuItems.Distinct().ToList();
    }
}