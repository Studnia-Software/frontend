using System.Diagnostics;
using ClientFrontend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClientFrontend.Models;
using ClientFrontend.Services;
using Newtonsoft.Json;

namespace ClientFrontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFarmService _service;

    public HomeController(ILogger<HomeController> logger, FarmService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetFarms();
        
        return View(JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync()));
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
