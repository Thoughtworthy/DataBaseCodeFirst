using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseCodeFirst.Data;
using DataBaseCodeFirst.Models;

namespace DataBaseCodeFirst.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly DataBaseCodeFirstContext _context;

        public UniversitiesController(DataBaseCodeFirstContext context)
        {
            _context = context;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
            var dataBaseCodeFirstContext = _context.University.Include(u => u.Student);
            return View(await dataBaseCodeFirstContext.ToListAsync());
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .Include(u => u.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: Universities/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email");
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Fee,StudentId")] University university)
        {
            if (ModelState.IsValid)
            {
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", university.StudentId);
            return View(university);
        }

        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", university.StudentId);
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Income,StudentId")] University university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", university.StudentId);
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .Include(u => u.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'DataBaseCodeFirstContext.University'  is null.");
            }
            var university = await _context.University.FindAsync(id);
            if (university != null)
            {
                _context.University.Remove(university);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(int id)
        {
          return (_context.University?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
