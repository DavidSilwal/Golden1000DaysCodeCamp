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
    public class PregnanciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PregnanciesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Pregnancies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pregnancy.Include(p => p.Mother);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pregnancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregnancy = await _context.Pregnancy.SingleOrDefaultAsync(m => m.PregnancyID == id);
            if (pregnancy == null)
            {
                return NotFound();
            }

            return View(pregnancy);
        }

        // GET: Pregnancies/Create
        public IActionResult Create()
        {
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID");
            return View();
        }

        // POST: Pregnancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PregnancyID,LMD,MotherID,PregNo")] Pregnancy pregnancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pregnancy);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", pregnancy.MotherID);
            return View(pregnancy);
        }

        // GET: Pregnancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregnancy = await _context.Pregnancy.SingleOrDefaultAsync(m => m.PregnancyID == id);
            if (pregnancy == null)
            {
                return NotFound();
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", pregnancy.MotherID);
            return View(pregnancy);
        }

        // POST: Pregnancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PregnancyID,LMD,MotherID,PregNo")] Pregnancy pregnancy)
        {
            if (id != pregnancy.PregnancyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregnancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PregnancyExists(pregnancy.PregnancyID))
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
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", pregnancy.MotherID);
            return View(pregnancy);
        }

        // GET: Pregnancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregnancy = await _context.Pregnancy.SingleOrDefaultAsync(m => m.PregnancyID == id);
            if (pregnancy == null)
            {
                return NotFound();
            }

            return View(pregnancy);
        }

        // POST: Pregnancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pregnancy = await _context.Pregnancy.SingleOrDefaultAsync(m => m.PregnancyID == id);
            _context.Pregnancy.Remove(pregnancy);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PregnancyExists(int id)
        {
            return _context.Pregnancy.Any(e => e.PregnancyID == id);
        }
    }
}
