using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CB
{
    public class DoiTuongChinhSachCanBoController : Controller
    {
        private readonly HemisContext _context;

        public DoiTuongChinhSachCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: DoiTuongChinhSachCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDoiTuongChinhSachCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdDoiTuongChinhSachNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DoiTuongChinhSachCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTuongChinhSachCanBo = await _context.TbDoiTuongChinhSachCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdDoiTuongChinhSachNavigation)
                .FirstOrDefaultAsync(m => m.IdDoiTuongChinhSachCanBo == id);
            if (tbDoiTuongChinhSachCanBo == null)
            {
                return NotFound();
            }

            return View(tbDoiTuongChinhSachCanBo);
        }

        // GET: DoiTuongChinhSachCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdDoiTuongChinhSach"] = new SelectList(_context.DmDoiTuongChinhSaches, "IdDoiTuongChinhSach", "IdDoiTuongChinhSach");
            return View();
        }

        // POST: DoiTuongChinhSachCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoiTuongChinhSachCanBo,IdCanBo,IdDoiTuongChinhSach,TuNgay,DenNgay")] TbDoiTuongChinhSachCanBo tbDoiTuongChinhSachCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDoiTuongChinhSachCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDoiTuongChinhSachCanBo.IdCanBo);
            ViewData["IdDoiTuongChinhSach"] = new SelectList(_context.DmDoiTuongChinhSaches, "IdDoiTuongChinhSach", "IdDoiTuongChinhSach", tbDoiTuongChinhSachCanBo.IdDoiTuongChinhSach);
            return View(tbDoiTuongChinhSachCanBo);
        }

        // GET: DoiTuongChinhSachCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTuongChinhSachCanBo = await _context.TbDoiTuongChinhSachCanBos.FindAsync(id);
            if (tbDoiTuongChinhSachCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDoiTuongChinhSachCanBo.IdCanBo);
            ViewData["IdDoiTuongChinhSach"] = new SelectList(_context.DmDoiTuongChinhSaches, "IdDoiTuongChinhSach", "IdDoiTuongChinhSach", tbDoiTuongChinhSachCanBo.IdDoiTuongChinhSach);
            return View(tbDoiTuongChinhSachCanBo);
        }

        // POST: DoiTuongChinhSachCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoiTuongChinhSachCanBo,IdCanBo,IdDoiTuongChinhSach,TuNgay,DenNgay")] TbDoiTuongChinhSachCanBo tbDoiTuongChinhSachCanBo)
        {
            if (id != tbDoiTuongChinhSachCanBo.IdDoiTuongChinhSachCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDoiTuongChinhSachCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDoiTuongChinhSachCanBoExists(tbDoiTuongChinhSachCanBo.IdDoiTuongChinhSachCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDoiTuongChinhSachCanBo.IdCanBo);
            ViewData["IdDoiTuongChinhSach"] = new SelectList(_context.DmDoiTuongChinhSaches, "IdDoiTuongChinhSach", "IdDoiTuongChinhSach", tbDoiTuongChinhSachCanBo.IdDoiTuongChinhSach);
            return View(tbDoiTuongChinhSachCanBo);
        }

        // GET: DoiTuongChinhSachCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTuongChinhSachCanBo = await _context.TbDoiTuongChinhSachCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdDoiTuongChinhSachNavigation)
                .FirstOrDefaultAsync(m => m.IdDoiTuongChinhSachCanBo == id);
            if (tbDoiTuongChinhSachCanBo == null)
            {
                return NotFound();
            }

            return View(tbDoiTuongChinhSachCanBo);
        }

        // POST: DoiTuongChinhSachCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDoiTuongChinhSachCanBo = await _context.TbDoiTuongChinhSachCanBos.FindAsync(id);
            if (tbDoiTuongChinhSachCanBo != null)
            {
                _context.TbDoiTuongChinhSachCanBos.Remove(tbDoiTuongChinhSachCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDoiTuongChinhSachCanBoExists(int id)
        {
            return _context.TbDoiTuongChinhSachCanBos.Any(e => e.IdDoiTuongChinhSachCanBo == id);
        }
    }
}
