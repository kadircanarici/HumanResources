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
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.Employee.GetAll().ToList() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            employee.Phone.Replace("-", string.Empty);
            unitOfWork.Employee.Add(employee);
            unitOfWork.Save();
            return Json(employee);

        }


        public IActionResult Personal()
        {
            return View();

        }
        public IActionResult GetEmployeeById(Guid employeeId)
        {
            try
            {
                return Json( unitOfWork.Employee.GetFirstOrDefault(x => x.Id == employeeId));
                
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }
        public IResult Edit(Employee employee)
        {
            Employee original = unitOfWork.Employee.GetFirstOrDefault(x => x.Id == employee.Id);

            original.FirstName = employee.FirstName;
            original.LastName = employee.LastName;
            original.Phone = employee.Phone;
            original.Email = employee.Email;



            unitOfWork.Employee.Update(original);
            unitOfWork.Save();

            return Results.Ok("başarılı");
        }


    }
}
