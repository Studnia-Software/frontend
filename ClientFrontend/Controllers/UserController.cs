using ClientFrontend.Interfaces;
using APIClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientFrontend.Controllers;

public class UserController : Controller
{
    private readonly IUserService _service;

    public UserController(IUserService userService)
    {
        _service = userService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _service.GetUsers();
        
        return NoContent();
    }

    public async Task<IActionResult> GetUser(int id)
    {
        var result = await _service.GetUser(id);

        var response = JsonConvert.DeserializeObject<UserFarmsArea>(await result.Content.ReadAsStringAsync());
        return NoContent();
    }
}