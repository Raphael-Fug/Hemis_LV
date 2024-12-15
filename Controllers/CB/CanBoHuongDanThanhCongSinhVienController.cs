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
    public class CanBoHuongDanThanhCongSinhVienController : Controller
    {
        private readonly HemisContext _context;

        public CanBoHuongDanThanhCongSinhVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: CanBoHuongDanThanhCongSinhVien
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbCanBoHuongDanThanhCongSinhViens.Include(t => t.IdCanBoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: CanBoHuongDanThanhCongSinhVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCanBoHuongDanThanhCongSinhVien = await _context.TbCanBoHuongDanThanhCongSinhViens
                .Include(t => t.IdCanBoNavigation)
                .FirstOrDefaultAsync(m => m.IdCanBoHuongDanThanhCongSinhVien == id);
            if (tbCanBoHuongDanThanhCongSinhVien == null)
            {
                return NotFound();
            }

            return View(tbCanBoHuongDanThanhCongSinhVien);
        }

        // GET: CanBoHuongDanThanhCongSinhVien/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            return View();
        }

        // POST: CanBoHuongDanThanhCongSinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCanBoHuongDanThanhCongSinhVien,IdCanBo,IdSinhVien,TrachNhiemHuongDan,ThoiGianBatDau,ThoiGianKetThuc")] TbCanBoHuongDanThanhCongSinhVien tbCanBoHuongDanThanhCongSinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCanBoHuongDanThanhCongSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbCanBoHuongDanThanhCongSinhVien.IdCanBo);
            return View(tbCanBoHuongDanThanhCongSinhVien);
        }

        // GET: CanBoHuongDanThanhCongSinhVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCanBoHuongDanThanhCongSinhVien = await _context.TbCanBoHuongDanThanhCongSinhViens.FindAsync(id);
            if (tbCanBoHuongDanThanhCongSinhVien == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbCanBoHuongDanThanhCongSinhVien.IdCanBo);
            return View(tbCanBoHuongDanThanhCongSinhVien);
        }

        // POST: CanBoHuongDanThanhCongSinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCanBoHuongDanThanhCongSinhVien,IdCanBo,IdSinhVien,TrachNhiemHuongDan,ThoiGianBatDau,ThoiGianKetThuc")] TbCanBoHuongDanThanhCongSinhVien tbCanBoHuongDanThanhCongSinhVien)
        {
            if (id != tbCanBoHuongDanThanhCongSinhVien.IdCanBoHuongDanThanhCongSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCanBoHuongDanThanhCongSinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCanBoHuongDanThanhCongSinhVienExists(tbCanBoHuongDanThanhCongSinhVien.IdCanBoHuongDanThanhCongSinhVien))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbCanBoHuongDanThanhCongSinhVien.IdCanBo);
            return View(tbCanBoHuongDanThanhCongSinhVien);
        }

        // GET: CanBoHuongDanThanhCongSinhVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCanBoHuongDanThanhCongSinhVien = await _context.TbCanBoHuongDanThanhCongSinhViens
                .Include(t => t.IdCanBoNavigation)
                .FirstOrDefaultAsync(m => m.IdCanBoHuongDanThanhCongSinhVien == id);
            if (tbCanBoHuongDanThanhCongSinhVien == null)
            {
                return NotFound();
            }

            return View(tbCanBoHuongDanThanhCongSinhVien);
        }

        // POST: CanBoHuongDanThanhCongSinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCanBoHuongDanThanhCongSinhVien = await _context.TbCanBoHuongDanThanhCongSinhViens.FindAsync(id);
            if (tbCanBoHuongDanThanhCongSinhVien != null)
            {
                _context.TbCanBoHuongDanThanhCongSinhViens.Remove(tbCanBoHuongDanThanhCongSinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCanBoHuongDanThanhCongSinhVienExists(int id)
        {
            return _context.TbCanBoHuongDanThanhCongSinhViens.Any(e => e.IdCanBoHuongDanThanhCongSinhVien == id);
        }
    }
}
