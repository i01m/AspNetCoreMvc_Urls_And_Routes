using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;


namespace UrlsAndRoutes.Controllers
{
    //creating more complex route with constraint
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController: Controller
    {
       //create action specific route using attribute
       // [Route("[controller]/MyAction")]
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });

        public ViewResult List(string id)
        {   Result r = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };
            r.Data ["id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View ("Result",r);
        }
    }
}
