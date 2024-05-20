

using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

public class NavigationMenuItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Route { get; set; }
    public NavigationMenuItem? ParentNavigationMenuItem { get; set; }
    public ICollection<NavigationMenuItem> ChildNavigationMenuItems { get; } = [];
}
