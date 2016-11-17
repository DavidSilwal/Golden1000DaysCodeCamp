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
    public class MothersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MothersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Mothers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mothers.ToListAsync());
        }

        // GET: Mothers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mother = await _context.Mothers.SingleOrDefaultAsync(m => m.MotherID == id);
            if (mother == null)
            {
                return NotFound();
            }

            return View(mother);
        }

        // GET: Mothers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mothers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotherID,Age,FName,LName,PhoneNo")] Mother mother)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mother);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mother);
        }

        // GET: Mothers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mother = await _context.Mothers.SingleOrDefaultAsync(m => m.MotherID == id);
            if (mother == null)
            {
                return NotFound();
            }
            return View(mother);
        }

        // POST: Mothers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotherID,Age,FName,LName,PhoneNo")] Mother mother)
        {
            if (id != mother.MotherID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mother);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotherExists(mother.MotherID))
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
            return View(mother);
        }

        // GET: Mothers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mother = await _context.Mothers.SingleOrDefaultAsync(m => m.MotherID == id);
            if (mother == null)
            {
                return NotFound();
            }

            return View(mother);
        }

        // POST: Mothers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mother = await _context.Mothers.SingleOrDefaultAsync(m => m.MotherID == id);
            _context.Mothers.Remove(mother);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MotherExists(int id)
        {
            return _context.Mothers.Any(e => e.MotherID == id);
        }
    }
}
