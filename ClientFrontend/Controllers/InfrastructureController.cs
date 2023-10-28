using ClientFrontend.Interfaces;
using ClientFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientFrontend.Controllers;

public class InfrastructureController : Controller
{
    private readonly IInfrastructureService _service;

    public InfrastructureController(IInfrastructureService service)
    {
        _service = service;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _service.Ping();
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        
        ModelState.AddModelError(await result.Content.ReadAsStringAsync(), "Error");
        return View(JsonConvert.DeserializeObject<Infrastructure>(await result.Content.ReadAsStringAsync()));
    }
}