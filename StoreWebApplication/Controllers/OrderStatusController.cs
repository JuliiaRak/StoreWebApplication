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
    public class OrderStatusController : Controller
    {
        private readonly OnlineShopContext _context;

        public OrderStatusController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: OrderStatus
        public async Task<IActionResult> Index()
        {
            var onlineShopContext = _context.OrderStatuses.Include(o => o.Order);
            return View(await onlineShopContext.ToListAsync());
        }

        // GET: OrderStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderStatus = await _context.OrderStatuses
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderStatusId == id);
            if (orderStatus == null)
            {
                return NotFound();
            }

            return View(orderStatus);
        }

        // GET: OrderStatus/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: OrderStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderStatusId,OrderStatus1,OrderId")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderStatus.OrderId);
            return View(orderStatus);
        }

        // GET: OrderStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderStatus = await _context.OrderStatuses.FindAsync(id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderStatus.OrderId);
            return View(orderStatus);
        }

        // POST: OrderStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderStatusId,OrderStatus1,OrderId")] OrderStatus orderStatus)
        {
            if (id != orderStatus.OrderStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderStatusExists(orderStatus.OrderStatusId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderStatus.OrderId);
            return View(orderStatus);
        }

        // GET: OrderStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderStatus = await _context.OrderStatuses
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderStatusId == id);
            if (orderStatus == null)
            {
                return NotFound();
            }

            return View(orderStatus);
        }

        // POST: OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderStatus = await _context.OrderStatuses.FindAsync(id);
            _context.OrderStatuses.Remove(orderStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderStatusExists(int id)
        {
            return _context.OrderStatuses.Any(e => e.OrderStatusId == id);
        }
    }
}
