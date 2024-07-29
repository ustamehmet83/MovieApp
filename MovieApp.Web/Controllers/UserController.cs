using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
