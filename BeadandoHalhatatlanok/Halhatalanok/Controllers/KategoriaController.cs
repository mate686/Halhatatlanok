using Halhatatlanok.Data;
using Halhatatlanok.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Halhatatlanok.Controllers
{
    public class KategoriaController : Controller
    {
        private readonly HalhatatlanContext _context;

        public KategoriaController(HalhatatlanContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string? nev, int page = 1, string sort = "nev", string dir = "asc")
        {
            var kategotiak = _context.Kategoriak.AsQueryable();
           
            if (!string.IsNullOrEmpty(nev))
            {
                kategotiak = kategotiak
                .Where(p => p.Nev!.ToLower().Contains(nev.ToLower()));
                ViewData["AktualisNev"] = nev;
            }
            kategotiak = (sort, dir) switch
            {

                ("nev", "asc") => kategotiak.OrderBy(p => p.Nev),

                ("nev", "desc") => kategotiak.OrderByDescending(p => p.Nev),
      
            };


            ViewData["CurrentSort"] = sort;

            ViewData["CurrentDir"] = dir;

            int pageSize = 10; // ennyi elem egy oldalon


            int totalCount = await kategotiak.CountAsync();

            var items = await kategotiak
            //.OrderBy(p => p.Nev) // ⚠️ lapozásnál KÖTELEZŐ rendezni
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();


            ViewData["CurrentPage"] = page;

            ViewData["TotalPages"] = (int)Math.Ceiling(totalCount / (double)pageSize);

            ViewData["TotalCount"] = totalCount;


            return View(items);
        }




        // GET: Kategoria/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoriak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategoria == null)
            {
                return NotFound();
            }

            return View(kategoria);
        }

        // GET: Kategoria/Create
        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nev")] Kategoriak kategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoria);
        }

        // GET: Kategoria/Edit/5
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoriak.FindAsync(id);
            if (kategoria == null)
            {
                return NotFound();
            }
            return View(kategoria);
        }

        // POST: Kategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nev")] Kategoriak kategoria)
        {
            if (id != kategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaExists(kategoria.Id))
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
            return View(kategoria);
        }

        // GET: Kategoria/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoriak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategoria == null)
            {
                return NotFound();
            }

            return View(kategoria);
        }

        // POST: Kategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoria = await _context.Kategoriak.FindAsync(id);
            if (kategoria != null)
            {
                _context.Kategoriak.Remove(kategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriaExists(int id)
        {
            return _context.Kategoriak.Any(e => e.Id == id);
        }
    }
}
