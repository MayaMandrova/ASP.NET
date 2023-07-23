using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lesson_5.Models;

namespace Lesson_5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public string[] name = { "Книга", "Полнометражный фильм", "Сериал", "Комикс", "Короткометражный фильм", "Мультфильм", "Журнал" };

    public string[] description = { "Ведьмак", "Игра престолов", "Волшебник Земноморья", "Стрелок", "Лабиринты Ехо", "Меч короля Артура", "Эдвар руки-ножницы", 
        "Варкрафт", "Звездная пыль", "Другой мир", "Морбиус", "Всё везде и сразу", "Чёрный Адам", "Страна снов", "Фантастические твари", "Три тысячи лет желаний",
        "Тролль", "Пиноккио", "Сердце Пармы", "Этерна"
    };
   
    public double[] priceForPiece = { 1200, 500, 900, 450, 1160, 460, 444, 512, 777, 994, 1031, 846, 117, 462, 654, 951, 753, 357, 159, 852 };
    
    public int[] quantity = { 51, 92, 4, 6, 74, 88, 64, 888, 210, 99, 61, 75, 111, 642, 132, 845, 67, 52, 77, 100 };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = CreateProductModels();
        return View(model);
    }

    public IActionResult NewTabForChecking()
    {
        return View();
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

    private List<ProductModel> CreateProductModels()
    {
        List<ProductModel> productModels = new List<ProductModel>();
        Random randomName = new Random();
        Random randomDescription = new Random();
        Random randomPriceForPiece = new Random(); 
        Random randomQuantity = new Random();

        for (int i = 0; i < 20; i++)
        {
            productModels.Add(new ProductModel()
            {
                Id = i + 1,
                Name = name[randomName.Next(name.Length)],
                Description = description[randomDescription.Next(description.Length)],
                PriceForPiece = priceForPiece[randomPriceForPiece.Next(priceForPiece.Length)],
                Quantity = quantity[randomQuantity.Next(quantity.Length)],
                Sign = "✎⌫"
            });
        }

        return productModels;
    }
}