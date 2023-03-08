using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class EmployeeEducationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeEducationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetEducationByEmployeeId(Guid employeeId)
        {
            try
            {
                EmployeeEducation ee = unitOfWork.EmployeeEducation.GetFirstOrDefault(x => x.EmployeeId == employeeId);
                if (ee != null)
                    return Json(ee);
                else
                {
                    EmployeeEducation newEe = new EmployeeEducation();
                    newEe.EmployeeId = employeeId;
                    unitOfWork.EmployeeEducation.Add(newEe);
                    unitOfWork.Save();
                    return Json(newEe);
                }
            }
            catch (Exception)
            {
                return Json("");
            }
        }
        public IResult Edit(EmployeeEducation ee)
        {
            EmployeeEducation original = unitOfWork.EmployeeEducation.GetFirstOrDefault(x => x.Id == ee.Id);
            original.EmployeeId = ee.EmployeeId;
            original.DegreeId = ee.DegreeId;
            original.EducationProviderId = ee.EducationProviderId;
            original.FieldOfStudyId = ee.FieldOfStudyId;
            original.GraduationDate = ee.GraduationDate;

            unitOfWork.EmployeeEducation.Update(original);
            unitOfWork.Save();

            return Results.Ok("başarılı");
        }
    }
}
