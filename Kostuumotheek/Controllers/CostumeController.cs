using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kostuumotheek.Models;
using Kostuumotheek.Data;

namespace Kostuumotheek.Controllers
{
    public class CostumeController : Controller
    {
        private readonly KostuumotheekContext _context;

        public CostumeController(KostuumotheekContext context)
        {
            _context = context;
        }

        // GET: Costume
        public async Task<IActionResult> Index()
        {
            return View(await _context.Costumes.ToListAsync());
        }

        // GET: Costume/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costume = await _context.Costumes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (costume == null)
            {
                return NotFound();
            }

            return View(costume);
        }

        // GET: Costume/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Costume/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description")] Costume costume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costume);
        }

        // GET: Costume/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costume = await _context.Costumes.SingleOrDefaultAsync(m => m.ID == id);
            if (costume == null)
            {
                return NotFound();
            }
            return View(costume);
        }

        // POST: Costume/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description")] Costume costume)
        {
            if (id != costume.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostumeExists(costume.ID))
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
            return View(costume);
        }

        // GET: Costume/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costume = await _context.Costumes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (costume == null)
            {
                return NotFound();
            }

            return View(costume);
        }

        // POST: Costume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costume = await _context.Costumes.SingleOrDefaultAsync(m => m.ID == id);
            _context.Costumes.Remove(costume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostumeExists(int id)
        {
            return _context.Costumes.Any(e => e.ID == id);
        }
    }
}
