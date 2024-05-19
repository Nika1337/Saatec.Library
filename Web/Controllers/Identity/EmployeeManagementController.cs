using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Web.Controllers.Identity;

public class EmployeeManagementController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
