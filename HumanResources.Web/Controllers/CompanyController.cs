using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class CompanyController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
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
            return Json(new { data = unitOfWork.Company.GetAll().ToList<Company>() });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Company company)
        {
            unitOfWork.Company.Add(company);
            unitOfWork.Save();
            return Json(company);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Company company = unitOfWork.Company.GetFirstOrDefault(x => x.Id == id);
            if (company != null)
            {
                unitOfWork.Company.Remove(company);
                unitOfWork.Save();
            }
            return Json(company);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(Company company)
        {

            unitOfWork.Company.Update(company);
            unitOfWork.Save();

            return Results.Ok("basarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            return Json(unitOfWork.Company.GetById(id));
        }

    }
}
