using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace HumanResources.Web.Controllers
{
    public class FieldOfStudyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public FieldOfStudyController(IUnitOfWork unitOfWork)
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
            return Json(new { data = unitOfWork.FieldOfStudy.GetAll().ToList<FieldOfStudy>() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(FieldOfStudy fieldOfStudy)
        {
            unitOfWork.FieldOfStudy.Add(fieldOfStudy);
            unitOfWork.Save();
            return Json(fieldOfStudy);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            FieldOfStudy fieldOfStudy = unitOfWork.FieldOfStudy.GetFirstOrDefault(x => x.Id == id);
            if (fieldOfStudy != null)
            {
                unitOfWork.FieldOfStudy.Remove(fieldOfStudy);
                unitOfWork.Save();
            }
            return Json(fieldOfStudy);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(FieldOfStudy fieldOfStudy)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FieldOfStudy.Update(fieldOfStudy);
                unitOfWork.Save();
            }
            return Results.Ok("basarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            return Json(unitOfWork.FieldOfStudy.GetById(id));
        }

    }
}
