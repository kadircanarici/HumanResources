using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.Employee.GetAll().ToList() }) ;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            employee.Phone.Replace("-", string.Empty);
            unitOfWork.Employee.Add(employee);
            unitOfWork.Save();
            return Json(employee);

        }
    }
}
