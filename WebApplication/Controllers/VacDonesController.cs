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
    public class VacDonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacDonesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: VacDones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VacDone.Include(v => v.Mother);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VacDones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacDone = await _context.VacDone.SingleOrDefaultAsync(m => m.VacDoneID == id);
            if (vacDone == null)
            {
                return NotFound();
            }

            return View(vacDone);
        }

        // GET: VacDones/Create
        public IActionResult Create()
        {
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID");
            return View();
        }

        // POST: VacDones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacDoneID,MotherID")] VacDone vacDone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacDone);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", vacDone.MotherID);
            return View(vacDone);
        }

        // GET: VacDones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacDone = await _context.VacDone.SingleOrDefaultAsync(m => m.VacDoneID == id);
            if (vacDone == null)
            {
                return NotFound();
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", vacDone.MotherID);
            return View(vacDone);
        }

        // POST: VacDones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacDoneID,MotherID")] VacDone vacDone)
        {
            if (id != vacDone.VacDoneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacDone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacDoneExists(vacDone.VacDoneID))
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
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", vacDone.MotherID);
            return View(vacDone);
        }

        // GET: VacDones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacDone = await _context.VacDone.SingleOrDefaultAsync(m => m.VacDoneID == id);
            if (vacDone == null)
            {
                return NotFound();
            }

            return View(vacDone);
        }

        // POST: VacDones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacDone = await _context.VacDone.SingleOrDefaultAsync(m => m.VacDoneID == id);
            _context.VacDone.Remove(vacDone);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VacDoneExists(int id)
        {
            return _context.VacDone.Any(e => e.VacDoneID == id);
        }
    }
}
