using HumanResources.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class UtilityController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CityList = new List<string>();
            ViewBag.CityList = CityUtility.GetAllCities();
            return View();
        }
    }
}
