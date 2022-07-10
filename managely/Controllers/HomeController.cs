using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}