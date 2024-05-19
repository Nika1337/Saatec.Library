using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Web.Controllers.Library;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
