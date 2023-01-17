using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Players.Models;

using BOL;
using BLL;

namespace Players.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Register(){
        return View();
    }
    [HttpPost]
    public IActionResult Register(string name, string city, string email, string password)
    {
        PlayerManager manager = new PlayerManager();
        manager.RegisterUser(name, city, email, password);
        Console.WriteLine("in register auth controller");
        return RedirectToAction("Login");
    }
    [HttpGet]
    public IActionResult Login(){
        return View();
    }
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        PlayerManager manager = new PlayerManager();
        bool status = manager.LoginUser(email, password);
        if (status)
        {
            Console.WriteLine(status);
            return RedirectToAction("Index","Player");
        }
        return View();
    }
}