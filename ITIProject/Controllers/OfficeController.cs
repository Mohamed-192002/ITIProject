using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly AppDbContext context;

        public OfficeController()
        {
            context = new AppDbContext();
        }
        public IActionResult GetAll()
        {
            var offices = context.Offices.Include(e=>e.employees).ToList();
            return View(offices);
        }
        public IActionResult Details(int? id)
        {
            var office = context.Offices.Include(e => e.employees).SingleOrDefault(x => x.Id == id);
            return View(office);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveCreate(Office office)
        {
            context.Offices.Add(office);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }
        public IActionResult Edit(int? id)
        {
            var office = context.Offices.SingleOrDefault(x => x.Id == id);
            return View(office);
        }
        public IActionResult SaveEdit(Office office)
        {
            var oldoffice = context.Offices.SingleOrDefault(e => e.Id == office.Id);
            oldoffice.Name = office.Name;
            oldoffice.Location = office.Location;
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }
        public IActionResult Delete(int? id)
        {
            var office = context.Offices.SingleOrDefault(e => e.Id == id);
            context.Offices.Remove(office);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));

        }
    }
}
