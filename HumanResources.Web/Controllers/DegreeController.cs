using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class DegreeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DegreeController(IUnitOfWork unitOfWork)
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
            return Json(new { data = unitOfWork.Degree.GetAll().ToList<Degree>() });
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Add(Degree degree)
        {
            unitOfWork.Degree.Add(degree);
            unitOfWork.Save();
            return Json(degree);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Degree degree = unitOfWork.Degree.GetFirstOrDefault(x => x.Id == id);
            if(degree !=null)
            {
                unitOfWork.Degree.Remove(degree);
                unitOfWork.Save();
            }
            return Json(degree);
        }


        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IResult Edit(Degree degree)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Degree.Update(degree);
                unitOfWork.Save();
            }
            return Results.Ok("basarılı");
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            return Json(unitOfWork.Degree.GetById(id));
        }
    }
}
