using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Nika1337.Library.Infrastructure.Identity.Dtos;
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

    public async Task<IEnumerable<NavigationMenuItemDto>> GetNavigationMenuDtos(ClaimsPrincipal claimsPrincipal)
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

        // Ensure distinct menu items
        return await GetNavigationMenuDtos(employee);
    }

    private async Task<IList<NavigationMenuItemDto>> GetNavigationMenuDtos(Employee employee)
    {
        var roleNames = await _userManager.GetRolesAsync(employee);

        var menuItems = await GetNavigationMenuItems(roleNames);

        var parentItems = FilterNonAccessibleChildren(menuItems);

        var menuItemDtos = MapToDtos(parentItems);

        return menuItemDtos;
    }

    private async Task<IList<NavigationMenuItem>> GetNavigationMenuItems(IList<string> roleNames)
    {
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
        return menuItems;
    }




    private IList<NavigationMenuItem> FilterNonAccessibleChildren(IList<NavigationMenuItem> menuItems)
    {
        var parentItems = menuItems.Where(nmi => nmi.ParentNavigationMenuItem is null).ToList();

        var childItems = menuItems.Where(nmi => nmi.ParentNavigationMenuItem is not null).ToList();

        foreach (var parentItem in parentItems)
        {
            RemoveAllChildrenNotIn(parentItem, childItems);
        }
        return parentItems;
    }

    private void RemoveAllChildrenNotIn(NavigationMenuItem parentItem, IList<NavigationMenuItem> childItems)
    {
        if (childItems.IsNullOrEmpty())
        {
            parentItem.ChildNavigationMenuItems?.Clear();
            return;
        }
        else if (parentItem.ChildNavigationMenuItems.IsNullOrEmpty()) {
            return;
        }
        else
        {
            foreach (var childItem in parentItem.ChildNavigationMenuItems)
            {
                if (childItems.Remove(childItem))
                {
                    RemoveAllChildrenNotIn(childItem, childItems);
                }
                else
                {
                    parentItem.ChildNavigationMenuItems.Remove(childItem);
                }
            }
        }
    }
    private IList<NavigationMenuItemDto> MapToDtos(IList<NavigationMenuItem> menuItems)
    {
        var dtos = new List<NavigationMenuItemDto>();
        foreach (var menuItem in menuItems) {
            var dto = MapToDto(menuItem);
            dtos.Add(dto);
        }
        return dtos;
    }

    private NavigationMenuItemDto MapToDto(NavigationMenuItem menuItem)
    {
        var dto = new NavigationMenuItemDto
        {
            Name = menuItem.Name,
            Route = menuItem.Route
        };

        foreach (var childItem in menuItem.ChildNavigationMenuItems)
        {
            var childDto = MapToDto(childItem); // Recursive call
            dto.ChildNavigationMenuItemDtos.Add(childDto);
        }

        return dto;
    }
}

// [(null, 1), (null,2), (null,3), (1,4), (1,5), (2,6), (6,7)]