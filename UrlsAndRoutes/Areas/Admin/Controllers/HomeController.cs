using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Areas.Admin.Models;

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private Person[] data = new Person[] {
            new Person {Name = "Alice", City = "London"},
            new Person {Name = "Jack", City = "Kansas City"},
            new Person {Name = "Rod", City = "Atlanta"}
        };

        public ViewResult Index() => View(data);
    }
}
