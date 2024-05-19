using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Infrastructure.Identity.Services;

namespace Nika1337.Library.Web.Components;

public class NavigationViewComponent(IdentityNavigationService navigationService) : ViewComponent
{
   public async Task<IViewComponentResult> InvokeAsync()
   {
        var navigationMenuItems = await navigationService.GetNavigationMenuItems(UserClaimsPrincipal);
        return View(navigationMenuItems);
   }
}
