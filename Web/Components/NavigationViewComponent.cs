using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Infrastructure.Identity.Dtos;
using Nika1337.Library.Infrastructure.Identity.Services;
namespace Nika1337.Library.Web.Components;

public class NavigationViewComponent(IdentityNavigationService navigationService) : ViewComponent
{
    private IEnumerable<NavigationMenuItemDto> testItems = [new NavigationMenuItemDto
    {
        Name = "Home",
        Route = "/home",
        ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
    },
    new NavigationMenuItemDto
    {
        Name = "About",
        Route = "/about",
        ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
    },
    new NavigationMenuItemDto
    {
        Name = "Services",
        Route = "/services",
        ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>
        {

            new NavigationMenuItemDto
            {
                Name = "Support",
                Route = "/services/support",
                ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
                {
                    new NavigationMenuItemDto
                    {
                        Name = "Home",
                        Route = "/home",
                        ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
                    },
                    new NavigationMenuItemDto
                    {
                        Name = "About",
                        Route = "/about",
                        ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
                    },
                }
            },
            new NavigationMenuItemDto
            {
                Name = "Consulting",
                Route = "/services/consulting",
                ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
            },
        }
    },
    new NavigationMenuItemDto
    {
        Name = "Contact",
        Route = "/contact",
        ChildNavigationMenuItemDtos = new List<NavigationMenuItemDto>()
    }];

   public async Task<IViewComponentResult> InvokeAsync()
   {
        //var navigationMenuItems = await navigationService.GetNavigationMenuDtos(UserClaimsPrincipal);
        var navigationMenuItems = testItems;
        return View(navigationMenuItems);
   }
}
