using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangolfModels;
using BangolfData;

namespace BangolfWeb.Controllers
{
    public class ArenasController : Controller
    {
        private readonly BangolfWebContext _context;

        public ArenasController(BangolfWebContext context)
        {
            _context = context;
        }

        // GET: Arenas
        public async Task<IActionResult> Index()
        {
              return _context.Arena != null ? 
                          View(await _context.Arena.ToListAsync()) :
                          Problem("Entity set 'BangolfWebContext.Arena'  is null.");
        }

        // GET: Arenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arena == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arena == null)
            {
                return NotFound();
            }

            return View(arena);
        }

        // GET: Arenas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arenas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Par,Id")] Arena arena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arena);
        }

        // GET: Arenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arena == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena.FindAsync(id);
            if (arena == null)
            {
                return NotFound();
            }
            return View(arena);
        }

        // POST: Arenas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Par,Id")] Arena arena)
        {
            if (id != arena.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArenaExists(arena.Id))
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
            return View(arena);
        }

        // GET: Arenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arena == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arena == null)
            {
                return NotFound();
            }

            return View(arena);
        }

        // POST: Arenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arena == null)
            {
                return Problem("Entity set 'BangolfWebContext.Arena'  is null.");
            }
            var arena = await _context.Arena.FindAsync(id);
            if (arena != null)
            {
                _context.Arena.Remove(arena);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArenaExists(int id)
        {
          return (_context.Arena?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
