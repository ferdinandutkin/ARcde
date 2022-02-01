using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    public class PartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
