using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Web.Controllers
{
    public class EmployeeDetailController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeDetailController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult GetEmployeeDetailById(Guid employeeId)
        {
            try
            {
                EmployeeDetail employeeDetail = unitOfWork.EmployeeDetail.GetFirstOrDefault(x => x.EmployeeId == employeeId);
                if (employeeDetail != null)
                    return Json(employeeDetail);
                else
                {
                    EmployeeDetail ed = new EmployeeDetail();
                    ed.EmployeeId = employeeId;
                    unitOfWork.EmployeeDetail.Add(ed);
                    unitOfWork.Save();
                    return Json(ed);
                }

            }
            catch (Exception)
            {
                return Json("");
            }

        }
        public IResult Edit(EmployeeDetail employeeDetail)
        {
            EmployeeDetail original = unitOfWork.EmployeeDetail.GetFirstOrDefault(x => x.Id == employeeDetail.Id);
            original.EmployeeId = employeeDetail.EmployeeId;
            original.Address = employeeDetail.Address;
            original.City = employeeDetail.City;
            original.DateOfBirth = employeeDetail.DateOfBirth;
            original.DriverLicense = employeeDetail.DriverLicense;
            original.MaritalStatus = employeeDetail.MaritalStatus;
            original.MilitaryObligations = employeeDetail.MilitaryObligations;
            original.Gender = employeeDetail.Gender;



            unitOfWork.EmployeeDetail.Update(original);
            unitOfWork.Save();

            return Results.Ok("başarılı");
        }

    }
}
