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
    public class CheckupsDonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckupsDonesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CheckupsDones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CheckupsDone.Include(c => c.Mother);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CheckupsDones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkupsDone = await _context.CheckupsDone.SingleOrDefaultAsync(m => m.CheckupsDoneID == id);
            if (checkupsDone == null)
            {
                return NotFound();
            }

            return View(checkupsDone);
        }

        // GET: CheckupsDones/Create
        public IActionResult Create()
        {
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID");
            return View();
        }

        // POST: CheckupsDones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckupsDoneID,MotherID,Patients")] CheckupsDone checkupsDone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkupsDone);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", checkupsDone.MotherID);
            return View(checkupsDone);
        }

        // GET: CheckupsDones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkupsDone = await _context.CheckupsDone.SingleOrDefaultAsync(m => m.CheckupsDoneID == id);
            if (checkupsDone == null)
            {
                return NotFound();
            }
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", checkupsDone.MotherID);
            return View(checkupsDone);
        }

        // POST: CheckupsDones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckupsDoneID,MotherID,Patients")] CheckupsDone checkupsDone)
        {
            if (id != checkupsDone.CheckupsDoneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkupsDone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckupsDoneExists(checkupsDone.CheckupsDoneID))
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
            ViewData["MotherID"] = new SelectList(_context.Mothers, "MotherID", "MotherID", checkupsDone.MotherID);
            return View(checkupsDone);
        }

        // GET: CheckupsDones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkupsDone = await _context.CheckupsDone.SingleOrDefaultAsync(m => m.CheckupsDoneID == id);
            if (checkupsDone == null)
            {
                return NotFound();
            }

            return View(checkupsDone);
        }

        // POST: CheckupsDones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkupsDone = await _context.CheckupsDone.SingleOrDefaultAsync(m => m.CheckupsDoneID == id);
            _context.CheckupsDone.Remove(checkupsDone);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CheckupsDoneExists(int id)
        {
            return _context.CheckupsDone.Any(e => e.CheckupsDoneID == id);
        }
    }
}
