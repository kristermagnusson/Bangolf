using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangolfModels;
using BangolfData;
using AutoMapper;
using BangolfWeb.Models;

namespace BangolfWeb.Controllers
{
    public class PlayersController : Controller
    {
        private readonly BangolfWebContext _context;
        private readonly IMapper mapper;

        public PlayersController(BangolfWebContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            //return _context.Player != null ? 
            //            View(await _context.Player.ToListAsync()) :
            //            Problem("Entity set 'BangolfWebContext.Player'  is null.");
            var viewModel = await mapper.ProjectTo<PlayerIndexViewModel>
            (_context.Player).ToListAsync();
            return View(viewModel);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            //var player = await _context.Player
            //    .FirstOrDefaultAsync(m => m.Id == id);
var player=await mapper.ProjectTo<PlayerDetailsViewModel>(_context.Player)
                .FirstOrDefaultAsync(s=>s.Id==id);


            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var player = mapper.Map<Player>(viewModel);

                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            //  var player = await _context.Player.FindAsync(id);
            var player = await mapper.ProjectTo<PlayerEditViewModel>(_context.Player)
                        .FirstOrDefaultAsync(s => s.Id == id);

            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PlayerEditViewModel viewModel
            )
        {
            if (id !=viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var player = await _context.Player.FirstOrDefaultAsync(s => s.Id == id);
                    mapper.Map(viewModel, player);
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(viewModel.Id))
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
            return View(viewModel);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Player == null)
            {
                return Problem("Entity set 'BangolfWebContext.Player'  is null.");
            }
            var player = await _context.Player.FindAsync(id);
            if (player != null)
            {
                _context.Player.Remove(player);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
          return (_context.Player?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
