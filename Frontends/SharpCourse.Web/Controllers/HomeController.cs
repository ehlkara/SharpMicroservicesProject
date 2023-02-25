using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SharpCourse.Web.Models;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICatalogService _catalogService;

    public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _catalogService.GetAllCourseAsync());
    }

    public async Task<IActionResult> Detail(string id)
    {
        return View(await _catalogService.GetByCourseIdAsync(id));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

