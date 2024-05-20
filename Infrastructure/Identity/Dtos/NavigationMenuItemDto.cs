using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Dtos;

public class NavigationMenuItemDto
{
    public required string Name { get; set; }
    public required string Route { get; set; }
    public ICollection<NavigationMenuItemDto> ChildNavigationMenuItemDtos { get; set; } = [];
}
