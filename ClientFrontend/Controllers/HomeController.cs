using System.Diagnostics;
using System.Net;
using ClientFrontend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClientFrontend.Models;
using ClientFrontend.Services;
using Newtonsoft.Json;
using System.Linq;

namespace ClientFrontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFarmService _service;

    public HomeController(ILogger<HomeController> logger, IFarmService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetFarms();
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        return View(JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync()));
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> GetSelectedValue()
    {
        var selectedValue = Request.Form["FarmFilter"].ToString(); //this will get selected value

        var result = await _service.GetFarms();
        var msg = JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync());

        var filteredValue = msg.Where(x => x.Location.City == selectedValue).ToList();
        
        return View("Market", filteredValue);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
