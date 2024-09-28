using DemoPerson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoPerson.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonContext _context;

        public HomeController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var persons = _context.Persons.ToList();
            return View(persons);
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", _context.Persons.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Update(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
