using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class PositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
