using FirstApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using customer;
using stream;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FirstApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Dashboard(string email, string password)
    {
        string fileName = @"d:\customersList.json";
        string jsonString = System.IO.File.ReadAllText(fileName);
        List<Customer> jsonCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString);
        Console.WriteLine("\n JSON :Deserializing data from json file\n \n");
        foreach (Customer c in jsonCustomer)
        {
            if(c.Email == email && c.Password == password){
                return View();
            }
            // Console.WriteLine($"{flower.Title} : {flower.Description}");
        }
        return Redirect("Index");

    }
    public IActionResult Login(string fname, string lname, string email, string password)
    {
        Customer c = new Customer(fname,lname,email,password);
        List<Customer> updatedList = Streaming.addData(c);
        var options = new JsonSerializerOptions { IncludeFields = true };
        var customerJson = JsonSerializer.Serialize<List<Customer>>(updatedList, options);
        string fileName = @"d:\customersList.json";
        System.IO.File.WriteAllText(fileName, customerJson);

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
