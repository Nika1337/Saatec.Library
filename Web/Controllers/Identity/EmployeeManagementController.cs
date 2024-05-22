using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nika1337.Library.ApplicationCore.Interfaces;
using Nika1337.Library.Infrastructure.Identity.Entities;
using Nika1337.Library.Web.Models;

namespace Nika1337.Library.Web.Controllers.Identity;

public class EmployeeManagementController : Controller
{
    private readonly IAppLogger<EmployeeManagementController> _logger;
    private readonly RoleManager<EmployeeRole> _roleManager;
    private readonly UserManager<Employee> _userManager;
    private readonly SignInManager<Employee> _signInManager;
    public EmployeeManagementController(
        IAppLogger<EmployeeManagementController> logger,
        RoleManager<EmployeeRole> roleManager,
        UserManager<Employee> userManager,
        SignInManager<Employee> signInManager)
    {
        _logger = logger;
        _roleManager = roleManager;
        _userManager = userManager;
        _signInManager = signInManager; 
    }

    [HttpGet]
    public async Task<IActionResult> RegisterEmployee()
    {
        var roles = _roleManager.Roles.ToList();

        var roleSelectListItems = roles.Select(role => new SelectListItem
        {
            Value = role.Id,
            Text = role.Name
        }).ToList();

        var viewModel = new EmployeeRegistrationViewModel
        {
            AvailableRoles = roleSelectListItems
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterEmployee(EmployeeRegistrationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _

        return View();
    }


}
