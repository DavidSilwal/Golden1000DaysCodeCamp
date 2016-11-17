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
    public class MotherExaminationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotherExaminationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MotherExaminations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Examination.Include(m => m.Mother);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MotherExaminations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherExamination = await _context.Examination.SingleOrDefaultAsync(m => m.ExaminationID == id);
            if (motherExamination == null)
            {
                return NotFound();
            }

            return View(motherExamination);
        }

        // GET: MotherExaminations/Create
        public IActionResult Create()
        {
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID");
            return View();
        }

        // POST: MotherExaminations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExaminationID,Advice,BloodPressure,Complication,HBTest,Height,Medication,MotherID,Weight")] MotherExamination motherExamination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motherExamination);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", motherExamination.MotherID);
            return View(motherExamination);
        }

        // GET: MotherExaminations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherExamination = await _context.Examination.SingleOrDefaultAsync(m => m.ExaminationID == id);
            if (motherExamination == null)
            {
                return NotFound();
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", motherExamination.MotherID);
            return View(motherExamination);
        }

        // POST: MotherExaminations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExaminationID,Advice,BloodPressure,Complication,HBTest,Height,Medication,MotherID,Weight")] MotherExamination motherExamination)
        {
            if (id != motherExamination.ExaminationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motherExamination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotherExaminationExists(motherExamination.ExaminationID))
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
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", motherExamination.MotherID);
            return View(motherExamination);
        }

        // GET: MotherExaminations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherExamination = await _context.Examination.SingleOrDefaultAsync(m => m.ExaminationID == id);
            if (motherExamination == null)
            {
                return NotFound();
            }

            return View(motherExamination);
        }

        // POST: MotherExaminations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motherExamination = await _context.Examination.SingleOrDefaultAsync(m => m.ExaminationID == id);
            _context.Examination.Remove(motherExamination);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MotherExaminationExists(int id)
        {
            return _context.Examination.Any(e => e.ExaminationID == id);
        }
    }
}
