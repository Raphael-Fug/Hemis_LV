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
    public class HopDongController : Controller
    {
        private readonly HemisContext _context;

        public HopDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: HopDong
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHopDongs.Include(t => t.IdCanBoNavigation).Include(t => t.IdLoaiHopDongNavigation).Include(t => t.IdTinhTrangHopDongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: HopDong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHopDong = await _context.TbHopDongs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiHopDongNavigation)
                .Include(t => t.IdTinhTrangHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdHopDong == id);
            if (tbHopDong == null)
            {
                return NotFound();
            }

            return View(tbHopDong);
        }

        // GET: HopDong/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdLoaiHopDong"] = new SelectList(_context.DmLoaiHopDongs, "IdLoaiHopDong", "IdLoaiHopDong");
            ViewData["IdTinhTrangHopDong"] = new SelectList(_context.DmTinhTrangHopDongs, "IdTinhTrangHopDong", "IdTinhTrangHopDong");
            return View();
        }

        // POST: HopDong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHopDong,IdCanBo,SoHopDong,IdLoaiHopDong,SoQuyetDinh,NgayQuyetDinh,CoGiaTriTu,CoGiaTriDen,IdTinhTrangHopDong,LamViecToanThoiGian")] TbHopDong tbHopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbHopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbHopDong.IdCanBo);
            ViewData["IdLoaiHopDong"] = new SelectList(_context.DmLoaiHopDongs, "IdLoaiHopDong", "IdLoaiHopDong", tbHopDong.IdLoaiHopDong);
            ViewData["IdTinhTrangHopDong"] = new SelectList(_context.DmTinhTrangHopDongs, "IdTinhTrangHopDong", "IdTinhTrangHopDong", tbHopDong.IdTinhTrangHopDong);
            return View(tbHopDong);
        }

        // GET: HopDong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHopDong = await _context.TbHopDongs.FindAsync(id);
            if (tbHopDong == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbHopDong.IdCanBo);
            ViewData["IdLoaiHopDong"] = new SelectList(_context.DmLoaiHopDongs, "IdLoaiHopDong", "IdLoaiHopDong", tbHopDong.IdLoaiHopDong);
            ViewData["IdTinhTrangHopDong"] = new SelectList(_context.DmTinhTrangHopDongs, "IdTinhTrangHopDong", "IdTinhTrangHopDong", tbHopDong.IdTinhTrangHopDong);
            return View(tbHopDong);
        }

        // POST: HopDong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHopDong,IdCanBo,SoHopDong,IdLoaiHopDong,SoQuyetDinh,NgayQuyetDinh,CoGiaTriTu,CoGiaTriDen,IdTinhTrangHopDong,LamViecToanThoiGian")] TbHopDong tbHopDong)
        {
            if (id != tbHopDong.IdHopDong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHopDongExists(tbHopDong.IdHopDong))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbHopDong.IdCanBo);
            ViewData["IdLoaiHopDong"] = new SelectList(_context.DmLoaiHopDongs, "IdLoaiHopDong", "IdLoaiHopDong", tbHopDong.IdLoaiHopDong);
            ViewData["IdTinhTrangHopDong"] = new SelectList(_context.DmTinhTrangHopDongs, "IdTinhTrangHopDong", "IdTinhTrangHopDong", tbHopDong.IdTinhTrangHopDong);
            return View(tbHopDong);
        }

        // GET: HopDong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHopDong = await _context.TbHopDongs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiHopDongNavigation)
                .Include(t => t.IdTinhTrangHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdHopDong == id);
            if (tbHopDong == null)
            {
                return NotFound();
            }

            return View(tbHopDong);
        }

        // POST: HopDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHopDong = await _context.TbHopDongs.FindAsync(id);
            if (tbHopDong != null)
            {
                _context.TbHopDongs.Remove(tbHopDong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHopDongExists(int id)
        {
            return _context.TbHopDongs.Any(e => e.IdHopDong == id);
        }
    }
}
