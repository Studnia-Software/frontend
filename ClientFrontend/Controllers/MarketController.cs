using ClientFrontend.Interfaces;
using ClientFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientFrontend.Controllers;

public class MarketController : Controller
{
    private readonly IFarmService _service;

    public MarketController(IFarmService service)
    {
        _service = service;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _service.GetFarms();
        var msg = JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync());
        return View("Index", msg);
    }

    public async Task<IActionResult> Farm(int id)
    {
        var result = await _service.GetFarm(id);
        var msg = JsonConvert.DeserializeObject<Farm>(await result.Content.ReadAsStringAsync());
        return View("Farm", msg);
    }

    // public async Task<IActionResult> Create(CreateFarm dto)
    // {
    //     var result = await _service.CreateFarm(dto);
    //     
    // }

    // public async Task<IActionResult> Delete(int id)
    // {
    //     var result = await _service.DeleteFarm(id);
    //     
    // }
}