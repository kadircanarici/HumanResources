using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HumanResources.Web.Controllers
{
    public class EmployeeCompanyPositionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeCompanyPositionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult GetCompanyPositionByEmployeeId(Guid employeeId)
        {
            try
            {
                EmployeeCompanyPosition ecp = unitOfWork.EmployeeCompanyPosition.GetFirstOrDefault(x => x.EmployeeId == employeeId);
                if (ecp != null)
                    return Json(ecp);
                else
                {
                    EmployeeCompanyPosition newEcp = new EmployeeCompanyPosition();
                    newEcp.EmployeeId = employeeId;
                    unitOfWork.EmployeeCompanyPosition.Add(newEcp);
                    unitOfWork.Save();
                    return Json(newEcp);
                }

            }
            catch (Exception)
            {
                return Json("");
            }

        }
        public IResult Edit(EmployeeCompanyPosition ecp)
        {
            EmployeeCompanyPosition original = unitOfWork.EmployeeCompanyPosition.GetFirstOrDefault(x => x.Id == ecp.Id);
            original.EmployeeId = ecp.EmployeeId;
            original.PositionId = ecp.PositionId;
            original.HireDate =ecp.HireDate;
            original.TerminationDate= ecp.TerminationDate;
            
          


            unitOfWork.EmployeeCompanyPosition.Update(original);
            unitOfWork.Save();

            return Results.Ok("başarılı");
        }

    }
}
