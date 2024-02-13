using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Controllers.Data;
using Sample.Models;
using Sample.Models.Domain;
using System.Reflection.Metadata.Ecma335;
namespace Sample.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DBContextClass dBContextClass;

        public EmployeeController(DBContextClass dBContextClass)
        {
            this.dBContextClass = dBContextClass;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await dBContextClass.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest) 
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department

            };
            await dBContextClass.Employees.AddAsync(employee);
            await dBContextClass.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var employee = await dBContextClass.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeViewModel model)
        {
            var employee = await dBContextClass.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;

                //await dBContextClass.Employees.AddAsync(employee);
                await dBContextClass.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = dBContextClass.Employees.FindAsync(model.Id);
           
            if(employee != null)
            {
                dBContextClass.Employees.Remove(await employee);
                await dBContextClass.SaveChangesAsync();
                return RedirectToAction("Index");
            }  
            return RedirectToAction("Index");
        }
    }
}
