using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class CompanyPositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
