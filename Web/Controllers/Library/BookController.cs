using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Web.Controllers.Library;

public class BookController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
