using DataAccessLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModel;
using System.Linq;

namespace Personnel_Accounting.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(uint? birthYear, string? education, double? salary)
        {
            var Employee = _unitOfWork.Employees.GetAll(e =>
            e.BirthYear == (birthYear ?? e.BirthYear) &&
            e.Education == (education ?? e.Education) &&
            e.Salary == (salary ?? e.Salary),
                includeProperties: "Department,Supervisor").ToList();
            return View(Employee);
        }

        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new EmployeeVM
            {
                DepartmentList = _unitOfWork.Departments
                .GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }),
                Employee = new Employee(),
                EmployeeList = _unitOfWork.Employees
                    .GetAll(e => e.Id != id)
                    .GroupBy(e => e.DepartmentId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => new SelectListItem
                        {
                            Text = $"{e.LastName} {e.FirstName}",
                            Value = e.Id.ToString()
                        })
                    )
            };

            if (id == null || id == 0)
            {
                //Create
                return View(employeeVM);
            }
            else
            {
                //Update
                employeeVM.Employee = _unitOfWork.Employees.Get(p => p.Id == id);
                return View(employeeVM);

            }
        }

        [HttpPost]
        public IActionResult Upsert(EmployeeVM employeeVM)
        {
            if (employeeVM.Employee.Id == 0)
            {
                _unitOfWork.Employees.Add(employeeVM.Employee);
            }
            else
            {
                _unitOfWork.Employees.UpDate(employeeVM.Employee);
            }

            _unitOfWork.Save();

            TempData["success"] = "Emloyee created/updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeDb = _unitOfWork.Employees.Get(c => c.Id == id);
            if (employeeDb == null)
            {
                return NotFound();
            }

            return View(employeeDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Employee? employeeDb = _unitOfWork.Employees.Get(c => c.Id == id);

            if (employeeDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Employees.Remove(employeeDb);
            _unitOfWork.Save();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");
        }
    }
}