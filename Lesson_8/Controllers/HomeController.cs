using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lesson_8.Models;

namespace Lesson_8.Controllers;

public class HomeController : Controller
{
    private static readonly List<ProductModel> _products = new()
    {
        new()
        {
            Id = 1, Name = "Книга", Description = "Волшебник Земноморья", PriceForPiece = 144.57, Quantity = 4,
            Sign = "✎⌫"
        },
        new()
        {
            Id = 2, Name = "Сериал", Description = "Игра престолов", PriceForPiece = 184.91, Quantity = 7, Sign = "✎⌫"
        },
        new() { Id = 3, Name = "Фильм", Description = "Ведьмак", PriceForPiece = 137.34, Quantity = 8, Sign = "✎⌫" },
    };


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new ListProductsModel
        {
            Products = _products
        };
        return View(model);
    }


    [HttpPost("create-new-product")]
    public IActionResult CreateNewProductFromUser([FromForm] ProductModel newProduct)
    {
        newProduct.Id = _products.Last().Id + 1;
        _products.Add(newProduct);
        return RedirectToAction("Index", "Home");
    }

    /*[HttpGet("get-product")]
    public IActionResult GetProduct(int id)
    {
        var model1 = _products.Find(product => product.Id == id);

        return View(model);
    }*/

    [HttpPost("change-product")]
    public IActionResult ChangeProduct([FromForm] ProductModel newProduct)
    {
        _products.Find(product => product.Id == newProduct.Id)!.Name = newProduct.Name;
        _products.Find(product => product.Id == newProduct.Id)!.Description = newProduct.Description;
        _products.Find(product => product.Id == newProduct.Id)!.PriceForPiece = newProduct.PriceForPiece;
        _products.Find(product => product.Id == newProduct.Id)!.Quantity = newProduct.Quantity;

        return RedirectToAction("Index");
    }

    [HttpPost("delete-product")]
    public IActionResult DeleteProduct(int id)
    {
        var model = _products.Find(product => product.Id == id);
        _products.Remove(model);

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}