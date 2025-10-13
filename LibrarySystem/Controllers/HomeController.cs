using System.Diagnostics;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int isLogged = 0)
        {

            List<Book> books = new List<Book>();
            books.Add(new Book { Author = "Jon Skeet", Title = "C# in Depth (4th edition)" });
            books.Add(new Book { Author = "Andrew", Title = "Pro C#" });
            //if (isLogged == 1)
                return View(books);
            //return View("Login");
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
}
