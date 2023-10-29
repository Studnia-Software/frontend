using System.Diagnostics;
using System.Net;
using ClientFrontend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClientFrontend.Models;
using ClientFrontend.Services;
using Newtonsoft.Json;
using System.Linq;
using ClientFrontend.Exception;

namespace ClientFrontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFarmService _service;
    private readonly IUserService _userService;
    private readonly IPostService _postService;
    public HomeController(ILogger<HomeController> logger, IFarmService service, IUserService userService, IPostService postService)
    {
        _logger = logger;
        _service = service;
        _userService = userService;
        _postService = postService;
    }

    public async Task<IActionResult> Index()
    {
        var modeles = new MultipleModels();
        
        var result = await _service.GetFarms();
        var result1 = await _userService.GetUsers();
        modeles.Farms = JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync());
        modeles.Users = JsonConvert.DeserializeObject<List<User>>(await result.Content.ReadAsStringAsync());
        
        return View(modeles);
    }

    public async Task<IActionResult> FarmerIndex([FromRoute] int )
    {
        var result = _service.GetFarms();
        var msg = 
        return View("FarmerIndex");
    }
    
    public async Task<IActionResult> CreatePost(CreatePost dto)
    {
        var result = await _postService.CreatePost(dto);

        if (result.IsSuccessStatusCode)
        {
            return RedirectToAction("FarmerIndex");
        }
        throw new BadRequestException("Bad Request");
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
    
    [HttpPost]
    public async Task<IActionResult> GetUserValue()
    {
        var selectedValue = Request.Form["userGetter"].ToString();
        //user -> posts in user's area
        //farmer -> posts in area + add panel

        if (selectedValue == "1")
        {
            return RedirectToAction("Index");
        }
       
        return RedirectToAction("FarmerIndex", selectedValue);
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
