using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Players.Models;
using BOL;
using BLL;

namespace Players.Controllers;

public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        PlayerManager player = new PlayerManager();
        List<Player> allPlayers = player.getAllPlayers();
        this.ViewData["players"] = allPlayers;
        return View();
    }

    public IActionResult Details(int id)
    {
        Console.WriteLine(id);
        PlayerManager ply = new PlayerManager();
        Player player = ply.getPlayerById(id);
        this.ViewData["details"] = player;
        return View();
    }

    // public IActionResult Insert()
    // {
    //     Player player = new Player();
    //     return View(player);
    // }

    // [HttpPost]
    public IActionResult Insert(Player playerToInsert)
    {
        Console.WriteLine("Post method invoked.... " + playerToInsert);
        if (!ModelState.IsValid)
        {


            return View();

        }
        Console.WriteLine(playerToInsert.Id +
                           " " +
                           playerToInsert.Name + " " +
                           playerToInsert.City + " " +
                           playerToInsert.Matches);
        //insert product data into mysql using database connectivity
        PlayerManager ply = new PlayerManager();
        Console.WriteLine("Inserting player");
        bool status = false;
        status = ply.InsertPlayer(playerToInsert);
        Console.WriteLine(status);
        if (status == true)
        {
            Console.WriteLine("Inserting player");
        }
        return RedirectToAction("Index");

        // return View();

    }

    public IActionResult Update(int id)
    {
        // Console.WriteLine("In player controller update method dal");

        PlayerManager manager = new PlayerManager();
        Player player = manager.getPlayerById(id);
        return View(player);
    }

    [HttpPost]
    public IActionResult Update(Player playerToUpdate)
    {
        Console.WriteLine(" " + playerToUpdate);

        if (!ModelState.IsValid)
        {
            // Console.WriteLine("In player controller update post method 1");

            return View();
        }
        PlayerManager manager = new PlayerManager();
        bool status = manager.UpdatePlayer(playerToUpdate);
        if (status == true)
        {
            Console.WriteLine("In player controller update post method 2");

        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Console.WriteLine("In player controller delete method ");

        PlayerManager manager = new PlayerManager();
        bool status = manager.DeletePlayer(id);
        if(status == true){
            return View();
        }
        return RedirectToAction("Index");
    }

}