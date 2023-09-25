using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext context;

        public EmployeeController()
        {
            context = new AppDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var employees = context.Employees.Include(e=>e.office).ToList();
            return View(employees);
        }
        public IActionResult Details(int?id)
        {
            var emp=context.Employees.Include(e=>e.office).SingleOrDefault(x => x.Id == id);
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveCreate(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }
        public IActionResult Edit(int?id)
        {
            var Emp=context.Employees.SingleOrDefault(x => x.Id == id);
            return View(Emp);
        }
        public IActionResult SaveEdit(Employee employee)
        {
            var oldEmp=context.Employees.SingleOrDefault(e=>e.Id== employee.Id);
            oldEmp.Name= employee.Name;
            oldEmp.Address= employee.Address;
            oldEmp.Salary = employee.Salary;
            oldEmp.Age = employee.Age;
            oldEmp.Email = employee.Email;
            oldEmp.Password= employee.Password;
            oldEmp.Office_id = employee.Office_id;
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }
        public IActionResult Delete(int? id)
        {
            var Emp= context.Employees.SingleOrDefault(e => e.Id ==id);
            context.Employees.Remove(Emp);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));

        }
    }
}
