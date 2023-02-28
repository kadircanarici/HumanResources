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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "Item1")] Employee employee, [Bind(Prefix = "Item2")] EmployeeDetail employeeDetail, [Bind(Prefix = "Item3")] EmployeeCompanyPosition employeeCompanyPosition, [Bind(Prefix = "Item4")] EmployeeEducation employeeEducation)
        {

            var originalEmployee = unitOfWork.Employee.GetById(employee.Id);

            if (originalEmployee == null)
            {
                return NotFound();
            }

            //// Eğer firma pozisyon bilgileri değiştirildiyse
            //if (!employeeCompanyPosition.Equals(originalEmployee.EmployeeCompanyPositions.FirstOrDefault()))
            //{
            //    if (originalEmployee.EmployeeCompanyPositions != default)
            //    {
            //        employeeCompanyPosition.EmployeeId = employee.Id;

            //        //originalEmployee.EmployeeCompanyPositions.Add(employeeCompanyPosition);

            //        unitOfWork.EmployeeCompanyPosition.Update(employeeCompanyPosition);



            //    }



            //}

            //// Eğer çalışan detay bilgileri değiştirildiyse
            //if (!employeeDetail.Equals(originalEmployee.EmployeeDetails.FirstOrDefault()))
            //{
            //    if(originalEmployee.EmployeeDetails != default)
            //    {
            //        employeeDetail.EmployeeId = employee.Id;
            //        unitOfWork.EmployeeDetail.Update(employeeDetail);


            //    }



            //}

            //// Eğer çalışan eğitim bilgileri değiştirildiyse
            //if (!employeeEducation.Equals(originalEmployee.EmployeeEducations.FirstOrDefault()))
            //{
              
            //    if (originalEmployee.EmployeeEducations != default)
            //    {

            //        employeeEducation.EmployeeId = employee.Id;
            //        unitOfWork.EmployeeEducation.Update(employeeEducation);

            //    }


            //} 

            // Employee

            if (!employee.Equals(originalEmployee))
            {
                // Çalışan bilgilerini güncelle
               // originalEmployee.Tc = employee.Tc;
                originalEmployee.FirstName = employee.FirstName;
                originalEmployee.LastName = employee.LastName;
                originalEmployee.Phone = employee.Phone;
                originalEmployee.Email = employee.Email;
                unitOfWork.Employee.Update(originalEmployee);

               
            }

            
            unitOfWork.Save();


            return  RedirectToAction("Personal", new { id = employee.Id }); 
        }





        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditEmployeeDetail([Bind(Prefix = "Item1")] Employee employee, [Bind(Prefix = "Item2")] EmployeeDetail employeeDetail)
        {

            var original = unitOfWork.EmployeeDetail.GetFirstOrDefault(x=>x.EmployeeId == employee.Id);

            if (original == null)
            {
                return NotFound();
            }

            //// Eğer firma pozisyon bilgileri değiştirildiyse
            //if (!employeeCompanyPosition.Equals(originalEmployee.EmployeeCompanyPositions.FirstOrDefault()))
            //{
            //    if (originalEmployee.EmployeeCompanyPositions != default)
            //    {
            //        employeeCompanyPosition.EmployeeId = employee.Id;

            //        //originalEmployee.EmployeeCompanyPositions.Add(employeeCompanyPosition);

            //        unitOfWork.EmployeeCompanyPosition.Update(employeeCompanyPosition);



            //    }



            //}

            //// Eğer çalışan detay bilgileri değiştirildiyse
            //if (!employeeDetail.Equals(originalEmployee.EmployeeDetails.FirstOrDefault()))
            //{
            //    if(originalEmployee.EmployeeDetails != default)
            //    {
            //        employeeDetail.EmployeeId = employee.Id;
            //        unitOfWork.EmployeeDetail.Update(employeeDetail);


            //    }



            //}

            //// Eğer çalışan eğitim bilgileri değiştirildiyse
            //if (!employeeEducation.Equals(originalEmployee.EmployeeEducations.FirstOrDefault()))
            //{

            //    if (originalEmployee.EmployeeEducations != default)
            //    {

            //        employeeEducation.EmployeeId = employee.Id;
            //        unitOfWork.EmployeeEducation.Update(employeeEducation);

            //    }


            //} 

        


            unitOfWork.Save();


            return RedirectToAction("Personal", new { id = employee.Id });
        }


    }
}
