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
    private readonly IUserService _userService;
    public HomeController(ILogger<HomeController> logger, IFarmService service, IUserService userService)
    {
        _logger = logger;
        _service = service;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetFarms();
        var msg = JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync());
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> GetSelectedValue()
    {
        var selectedValue = Request.Form["FarmFilter"].ToString(); //this will get selected value

        var result = await _service.GetFarms();
        var msg = JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync());

        var filteredValue = msg.Where(x => x.Location.City == selectedValue).ToList();

        for (int i = 0; i < filteredValue.Count - 1; i++)
        {
            if (filteredValue[i] == filteredValue[i + 1])
            {
                RedirectToAction("Index");
                break;
            }
        }
        
        return View("Market", filteredValue);
    }

    public async Task<IActionResult> GetUser(int id = 0)
    {
        var result = await _userService.GetUser(id);
        var msg = JsonConvert.DeserializeObject<UserFarmsArea>(await result.Content.ReadAsStringAsync());
        return View("UserView", msg);
    }

    public async Task<IActionResult> GetFarmPosts(int id)
    {
        var result = await _service.GetFarm(id);
        var msg = JsonConvert.DeserializeObject<Farm>(await result.Content.ReadAsStringAsync());
        return View("Farmer", msg);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
