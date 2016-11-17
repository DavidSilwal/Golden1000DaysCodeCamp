using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class CheckupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckupsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Checkups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Checkups.ToListAsync());
        }

        // GET: Checkups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkups = await _context.Checkups.SingleOrDefaultAsync(m => m.CheckupsID == id);
            if (checkups == null)
            {
                return NotFound();
            }

            return View(checkups);
        }

        // GET: Checkups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checkups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckupsID,Name,Patients,Period")] Checkups checkups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkups);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(checkups);
        }

        // GET: Checkups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkups = await _context.Checkups.SingleOrDefaultAsync(m => m.CheckupsID == id);
            if (checkups == null)
            {
                return NotFound();
            }
            return View(checkups);
        }

        // POST: Checkups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckupsID,Name,Patients,Period")] Checkups checkups)
        {
            if (id != checkups.CheckupsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckupsExists(checkups.CheckupsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(checkups);
        }

        // GET: Checkups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkups = await _context.Checkups.SingleOrDefaultAsync(m => m.CheckupsID == id);
            if (checkups == null)
            {
                return NotFound();
            }

            return View(checkups);
        }

        // POST: Checkups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkups = await _context.Checkups.SingleOrDefaultAsync(m => m.CheckupsID == id);
            _context.Checkups.Remove(checkups);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CheckupsExists(int id)
        {
            return _context.Checkups.Any(e => e.CheckupsID == id);
        }
    }
}
