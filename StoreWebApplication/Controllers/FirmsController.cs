﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreWebApplication;

namespace StoreWebApplication.Controllers
{
    public class FirmsController : Controller
    {
        private readonly OnlineShopContext _context;

        public FirmsController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: Firms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Firms.ToListAsync());
        }

        // GET: Firms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firms
                .FirstOrDefaultAsync(m => m.FirmId == id);
            if (firm == null)
            {
                return NotFound();
            }

            //return View(firm);
            return RedirectToAction("Index", "Products", new { property = "Firm", id = firm.FirmId, name = firm.Name });
        }

        // GET: Firms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Firms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirmId,Name,YearOfFondation,Owner,Capital")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firm);
        }

        // GET: Firms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firms.FindAsync(id);
            if (firm == null)
            {
                return NotFound();
            }
            return View(firm);
        }

        // POST: Firms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirmId,Name,YearOfFondation,Owner,Capital")] Firm firm)
        {
            if (id != firm.FirmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmExists(firm.FirmId))
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
            return View(firm);
        }

        // GET: Firms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firms
                .FirstOrDefaultAsync(m => m.FirmId == id);
            if (firm == null)
            {
                return NotFound();
            }

            return View(firm);
        }

        // POST: Firms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firm = await _context.Firms.FindAsync(id);
            _context.Firms.Remove(firm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirmExists(int id)
        {
            return _context.Firms.Any(e => e.FirmId == id);
        }
    }
}
