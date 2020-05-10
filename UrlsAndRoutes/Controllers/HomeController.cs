using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;


namespace UrlsAndRoutes.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        //accessing a request parameters through Action method parameters
        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            r.Data["id"] = id ?? "<no value>";
            r.Data["Url"] = Url.Action("CustomerVariable", "Home", new { id = 100 });
            return View("Result",r);
        }


        ////accessing a request parameters using RouteData.Values
        //public ViewResult CustomVariable()
        //{
        //    Result r = new Result
        //    {
        //        Controller = nameof(HomeController),
        //        Action = nameof(CustomVariable)
        //    };
        //    r.Data["id"] = RouteData.Values["id"];
        //    return View("Result",r);
        //}
    }
}
