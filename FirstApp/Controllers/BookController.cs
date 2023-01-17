using FirstApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(){
        //fetch data from Model
        //send list of products to ViewData Collection
        
        List<Book>  allBooks=BookManager.getAllBooks();
        ViewData["library"]=allBooks;
        return View();
    }

}