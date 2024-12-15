using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.Models.DM;

namespace C500Hemis.Controllers.HTQT
{
    public class DmHinhThucHopTacsController : Controller
    {
        private readonly HemisContext _context;

        public DmHinhThucHopTacsController(HemisContext context)
        {
            _context = context;
        }

        // GET: DmHinhThucHopTacs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DmHinhThucHopTacs.ToListAsync());
        }

        // GET: DmHinhThucHopTacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dmHinhThucHopTac = await _context.DmHinhThucHopTacs
                .FirstOrDefaultAsync(m => m.IdHinhThucHopTac == id);
            if (dmHinhThucHopTac == null)
            {
                return NotFound();
            }

            return View(dmHinhThucHopTac);
        }

        // GET: DmHinhThucHopTacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DmHinhThucHopTacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHinhThucHopTac,HinhThucHopTac")] DmHinhThucHopTac dmHinhThucHopTac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dmHinhThucHopTac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dmHinhThucHopTac);
        }

        // GET: DmHinhThucHopTacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dmHinhThucHopTac = await _context.DmHinhThucHopTacs.FindAsync(id);
            if (dmHinhThucHopTac == null)
            {
                return NotFound();
            }
            return View(dmHinhThucHopTac);
        }

        // POST: DmHinhThucHopTacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHinhThucHopTac,HinhThucHopTac")] DmHinhThucHopTac dmHinhThucHopTac)
        {
            if (id != dmHinhThucHopTac.IdHinhThucHopTac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dmHinhThucHopTac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DmHinhThucHopTacExists(dmHinhThucHopTac.IdHinhThucHopTac))
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
            return View(dmHinhThucHopTac);
        }

        // GET: DmHinhThucHopTacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dmHinhThucHopTac = await _context.DmHinhThucHopTacs
                .FirstOrDefaultAsync(m => m.IdHinhThucHopTac == id);
            if (dmHinhThucHopTac == null)
            {
                return NotFound();
            }

            return View(dmHinhThucHopTac);
        }

        // POST: DmHinhThucHopTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dmHinhThucHopTac = await _context.DmHinhThucHopTacs.FindAsync(id);
            if (dmHinhThucHopTac != null)
            {
                _context.DmHinhThucHopTacs.Remove(dmHinhThucHopTac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DmHinhThucHopTacExists(int id)
        {
            return _context.DmHinhThucHopTacs.Any(e => e.IdHinhThucHopTac == id);
        }
    }
}
