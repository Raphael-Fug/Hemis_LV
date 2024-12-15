using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSGD
{
    public class ToChucKiemDinhController : Controller
    {
        private readonly HemisContext _context;

        public ToChucKiemDinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: ToChucKiemDinh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbToChucKiemDinhs.Include(t => t.IdKetQuaNavigation).Include(t => t.IdToChucKiemDinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ToChucKiemDinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucKiemDinh = await _context.TbToChucKiemDinhs
                .Include(t => t.IdKetQuaNavigation)
                .Include(t => t.IdToChucKiemDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdToChucKiemDinhCsdg == id);
            if (tbToChucKiemDinh == null)
            {
                return NotFound();
            }

            return View(tbToChucKiemDinh);
        }

        // GET: ToChucKiemDinh/Create
        public IActionResult Create()
        {
            ViewData["IdKetQua"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh");
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh");
            return View();
        }

        // POST: ToChucKiemDinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdToChucKiemDinhCsdg,IdToChucKiemDinh,IdKetQua,SoQuyetDinhKiemDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbToChucKiemDinh tbToChucKiemDinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbToChucKiemDinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKetQua"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbToChucKiemDinh.IdKetQua);
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh", tbToChucKiemDinh.IdToChucKiemDinh);
            return View(tbToChucKiemDinh);
        }

        // GET: ToChucKiemDinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucKiemDinh = await _context.TbToChucKiemDinhs.FindAsync(id);
            if (tbToChucKiemDinh == null)
            {
                return NotFound();
            }
            ViewData["IdKetQua"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbToChucKiemDinh.IdKetQua);
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh", tbToChucKiemDinh.IdToChucKiemDinh);
            return View(tbToChucKiemDinh);
        }

        // POST: ToChucKiemDinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdToChucKiemDinhCsdg,IdToChucKiemDinh,IdKetQua,SoQuyetDinhKiemDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbToChucKiemDinh tbToChucKiemDinh)
        {
            if (id != tbToChucKiemDinh.IdToChucKiemDinhCsdg)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbToChucKiemDinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbToChucKiemDinhExists(tbToChucKiemDinh.IdToChucKiemDinhCsdg))
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
            ViewData["IdKetQua"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbToChucKiemDinh.IdKetQua);
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh", tbToChucKiemDinh.IdToChucKiemDinh);
            return View(tbToChucKiemDinh);
        }

        // GET: ToChucKiemDinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucKiemDinh = await _context.TbToChucKiemDinhs
                .Include(t => t.IdKetQuaNavigation)
                .Include(t => t.IdToChucKiemDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdToChucKiemDinhCsdg == id);
            if (tbToChucKiemDinh == null)
            {
                return NotFound();
            }

            return View(tbToChucKiemDinh);
        }

        // POST: ToChucKiemDinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbToChucKiemDinh = await _context.TbToChucKiemDinhs.FindAsync(id);
            if (tbToChucKiemDinh != null)
            {
                _context.TbToChucKiemDinhs.Remove(tbToChucKiemDinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbToChucKiemDinhExists(int id)
        {
            return _context.TbToChucKiemDinhs.Any(e => e.IdToChucKiemDinhCsdg == id);
        }
    }
}
