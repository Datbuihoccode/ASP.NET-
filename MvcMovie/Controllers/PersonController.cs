using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Data;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    { 
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person p)
        {
            await _context.AddAsync(p);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}