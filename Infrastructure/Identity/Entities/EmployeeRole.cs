using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

public class EmployeeRole : IdentityRole
{
    public ICollection<NavigationMenuItem> NavigationMenuItems { get; } = [];
}
