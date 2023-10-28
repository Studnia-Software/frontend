using AspNetCoreHero.ToastNotification.Abstractions;
using ClientFrontend.Interfaces;
using ClientFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientFrontend.Controllers;

public class InfrastructureController : Controller
{
    private readonly IInfrastructureService _service;
    private readonly INotyfService _notyf;

    public InfrastructureController(IInfrastructureService service, INotyfService notyf)
    {
        _service = service;
        _notyf = notyf;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _service.Ping();
        Console.WriteLine(await result.Content.ReadAsStringAsync());

        if (result.IsSuccessStatusCode)
        {
            _notyf.Success("Success!");
        }
        
        ModelState.AddModelError(await result.Content.ReadAsStringAsync(), "Error");
        return View(JsonConvert.DeserializeObject<Infrastructure>(await result.Content.ReadAsStringAsync()));
    }
}