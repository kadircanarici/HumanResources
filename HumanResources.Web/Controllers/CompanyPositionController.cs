using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class CompanyPositionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyPositionController(IUnitOfWork unitOfWork)
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
            var res= Json(new { data = unitOfWork.CompanyPosition.GetAll().ToList<CompanyPosition>()
           });
            return res;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllByCompany(Guid companyId)
        {
            return Json(new { data = unitOfWork.CompanyPosition.GetAll().Where(x => x.CompanyId == companyId).ToList<CompanyPosition>() });
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Add(CompanyPosition companyPosition)
        {
            unitOfWork.CompanyPosition.Add(companyPosition);
            unitOfWork.Save();

            return Json(companyPosition);
        }


        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            CompanyPosition found =unitOfWork.CompanyPosition.GetFirstOrDefault(x => x.Id == id);
            if (found!=null)
            {
                unitOfWork.CompanyPosition.Remove(found);
                unitOfWork.Save();

            }
            return Json(found);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            CompanyPosition found =unitOfWork.CompanyPosition.GetById(id);
            return Json(found);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IResult Edit(CompanyPosition companyPosition)
        {
            CompanyPosition found = unitOfWork.CompanyPosition.GetById(companyPosition.Id);
            found.Name = companyPosition.Name;
            found.CompanyId = companyPosition.CompanyId;

            unitOfWork.CompanyPosition.Update(found);
            unitOfWork.Save();

            return Results.Ok("done");

        }
       
       
    }
}
