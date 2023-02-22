using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HumanResources.Web.Controllers
{
    public class EducationProviderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EducationProviderController(IUnitOfWork unitOfWork)
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
            return Json(new { data = unitOfWork.EducationProvider.GetAll().ToList<EducationProvider>() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(EducationProvider educationProvider)
        {
            unitOfWork.EducationProvider.Add(educationProvider);
            unitOfWork.Save();
            return Json(educationProvider);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            EducationProvider educationProvider = unitOfWork.EducationProvider.GetFirstOrDefault(x => x.Id == id);
            if (educationProvider != null)
            {
                unitOfWork.EducationProvider.Remove(educationProvider);
                unitOfWork.Save();
            }
            return Json(educationProvider);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(EducationProvider educationProvider)
        {
            
                unitOfWork.EducationProvider.Update(educationProvider);
                unitOfWork.Save();
           
            return Results.Ok("basarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            return Json(unitOfWork.EducationProvider.GetById(id));
        }

    }
}
