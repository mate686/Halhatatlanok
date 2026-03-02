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
    public class TagController : Controller
    {
        private readonly HalhatatlanContext _context;

        public TagController(HalhatatlanContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string? ev,string? nev,int page = 1, string sort = "nev", string dir = "asc")
        {
            var tagok = _context.Tagok.AsQueryable();

            if (!string.IsNullOrEmpty(ev))
            {
                tagok = tagok
                .Where(p => p.Ev!.ToString().Contains(ev.ToLower()));
                ViewData["AktualisEv"] = ev;
            }

            if (!string.IsNullOrEmpty(nev))
            {
                tagok = tagok
                .Where(p => p.Nev!.ToLower().Contains(nev.ToLower()));
                ViewData["AktualisNev"] = nev;
            }
            tagok = (sort, dir) switch
            {

                ("nev", "asc") => tagok.OrderBy(p => p.Nev),

                ("nev", "desc") => tagok.OrderByDescending(p => p.Nev),

                ("ev", "asc") => tagok.OrderBy(p => p.Ev),

                ("ev", "desc") => tagok.OrderByDescending(p => p.Ev),

                //("kategoria", "asc") => tagok.OrderBy(p => p.Kategoria),

                //("kategoria", "desc") => tagok.OrderByDescending(p => p.Kategoria),

            };


            ViewData["CurrentSort"] = sort;

            ViewData["CurrentDir"] = dir;

            int pageSize = 10; // ennyi elem egy oldalon


            int totalCount = await tagok.CountAsync();

            var items = await tagok
            //.OrderBy(p => p.Nev) 
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();


            ViewData["CurrentPage"] = page;

            ViewData["TotalPages"] = (int)Math.Ceiling(totalCount / (double)pageSize);

            ViewData["TotalCount"] = totalCount;


            return View(items);
        }

        // GET: Tag/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tagok
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Tag/Create
        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ev,Nev")] Tagok tag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: Tag/Edit/5
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tagok.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        // POST: Tag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ev,Nev")] Tagok tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.Id))
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
            return View(tag);
        }

        // GET: Tag/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tagok
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _context.Tagok.FindAsync(id);
            if (tag != null)
            {
                _context.Tagok.Remove(tag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return _context.Tagok.Any(e => e.Id == id);
        }
    }
}
