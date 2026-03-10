using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Models;

namespace Kutuphane.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
