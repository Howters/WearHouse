using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WearHouse.Database;
using WearHouse.Models;

namespace WearHouse.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly WearHouseContext _context;

        public CategoryController(WearHouseContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
              return _context.Category != null ? 
                          View(await _context.Category.ToListAsync()) :
                          Problem("Entity set 'WearHouseContext.Category'  is null.");
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string CategoryNameEdit)
        {
            // Update the category directly with the provided ID and CategoryNameEdit
            var category = new Category
            {
                Id = id,
                CategoryName = CategoryNameEdit
            };

            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }





        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Console.WriteLine("Received id for deltetete: " + id);

            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine("Received id fordidid deletion: " + id);
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound(); // Handle the case where the category with the specified ID doesn't exist
            }

            _context.Remove(category); // Remove the category from the context
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction(nameof(Index)); // Redirect to the index page or any other appropriate page
        }





        private bool CategoryExists(int id)
        {
          return (_context.Category?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
