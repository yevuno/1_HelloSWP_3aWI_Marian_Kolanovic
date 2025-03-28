using Microsoft.AspNetCore.Mvc;

namespace MyRestApi;

public class Controller1 : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}