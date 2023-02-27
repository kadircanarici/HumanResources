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
        public IActionResult Personal(Guid id)
        {
            Employee employee = unitOfWork.Employee.GetFirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            //    View Model

            EmployeeDetail employeeDetail = unitOfWork.EmployeeDetail.GetFirstOrDefault(x => x.EmployeeId == id);
            EmployeeCompanyPosition employeeCompanyPosition = unitOfWork.EmployeeCompanyPosition.GetFirstOrDefault(x => x.EmployeeId == id);
            EmployeeEducation employeeEducation = unitOfWork.EmployeeEducation.GetFirstOrDefault(x => x.EmployeeId == id);

            var viewModel = new Tuple<Employee, EmployeeDetail, EmployeeCompanyPosition, EmployeeEducation>(employee, employeeDetail, employeeCompanyPosition, employeeEducation);
            return View(viewModel);
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
