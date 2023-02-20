using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class pdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PdfViewer()
        {
            return View();
        }

    }
}
