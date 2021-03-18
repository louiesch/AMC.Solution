using Microsoft.AspNetCore.Mvc;

namespace AMC.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}