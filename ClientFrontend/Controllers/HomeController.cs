using System.Diagnostics;
using System.Net;
using ClientFrontend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using APIClient.Models;
using ClientFrontend.Services;
using Newtonsoft.Json;
using System.Linq;
using ClientFrontend.Exception;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Web;
using Microsoft.Net.Http.Headers;

namespace ClientFrontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFarmService _service;
    private readonly IUserService _userService;
    private readonly IPostService _postService;
    private readonly IOrderService _orderService;
    public HomeController(ILogger<HomeController> logger, IFarmService service, IUserService userService, IPostService postService, IOrderService orderService)
    {
        _logger = logger;
        _service = service;
        _userService = userService;
        _postService = postService;
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetFarms();
        var farms = JsonConvert.DeserializeObject<List<Farm>>(await result.Content.ReadAsStringAsync());
        
        return View(farms);
    }
    
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePost(int farmid, string name, string nazwa, string opis_produktu, float cena, float cena1)
    {
        var dto = new CreatePost()
        {
            Farm_id = farmid,
            Title = nazwa,
            Product_Name = name,
            Product_Description = opis_produktu,
            Amount = cena,
            Quantity = cena1,
            Per_kg = true
        };
        Console.WriteLine(JsonConvert.SerializeObject(dto));
        var result = await _postService.CreatePost(dto);

        if (!result.IsSuccessStatusCode)
        {
            Console.WriteLine(JsonConvert.SerializeObject(dto));
            return View("Error");
        }

        Console.WriteLine(await result.Content.ReadAsStreamAsync());
        return Redirect($"http://localhost:8080/GetFarmPosts/{farmid}");
    }
    
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrder(CreateOrder dto)
    {
        var result = await _orderService.CreateOrder(dto);

        if (!result.IsSuccessStatusCode)
        {
            return View("Error");
        }
        Console.WriteLine(dto.ToString());
        return RedirectToAction("CreateOrder");
    }
    
    public async Task<IActionResult> GetFarmPosts(int id)
    {
        var result = await _service.GetFarm(id);
        
        var msg = JsonConvert.DeserializeObject<Farm>(await result.Content.ReadAsStringAsync());
        return View("Farmer", msg);
    }

    public async Task<IActionResult> GetOrders()
    {
        return NoContent();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}