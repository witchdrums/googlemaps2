using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using googlemaps2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace googlemaps2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var Transportes = new Dictionary<string, string>
        {
            {"DRIVING", "Automóvil"},
            {"WALKING", "Caminando"},
            {"BICYCLING", "Bicileta"},
        };
        var selectList = new SelectList(Transportes, "Key", "Value");

        var model = new UbicacionViewModel
        {
            Transportes = selectList,
            Ruta = true,
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
