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
    }
}
