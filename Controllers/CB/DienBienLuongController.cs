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
    public class DienBienLuongController : Controller
    {
        private readonly HemisContext _context;

        public DienBienLuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: DienBienLuong
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDienBienLuongs.Include(t => t.IdBacLuongNavigation).Include(t => t.IdCanBoNavigation).Include(t => t.IdHeSoLuongNavigation).Include(t => t.IdTrinhDoDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DienBienLuong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDienBienLuong = await _context.TbDienBienLuongs
                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdDienBienLuong == id);
            if (tbDienBienLuong == null)
            {
                return NotFound();
            }

            return View(tbDienBienLuong);
        }

        // GET: DienBienLuong/Create
        public IActionResult Create()
        {
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong");
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong");
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao");
            return View();
        }

        // POST: DienBienLuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDienBienLuong,IdCanBo,IdTrinhDoDaoTao,NgayThangNam,IdBacLuong,IdHeSoLuong")] TbDienBienLuong tbDienBienLuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDienBienLuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong", tbDienBienLuong.IdBacLuong);
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDienBienLuong.IdCanBo);
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong", tbDienBienLuong.IdHeSoLuong);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbDienBienLuong.IdTrinhDoDaoTao);
            return View(tbDienBienLuong);
        }

        // GET: DienBienLuong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDienBienLuong = await _context.TbDienBienLuongs.FindAsync(id);
            if (tbDienBienLuong == null)
            {
                return NotFound();
            }
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong", tbDienBienLuong.IdBacLuong);
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDienBienLuong.IdCanBo);
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong", tbDienBienLuong.IdHeSoLuong);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbDienBienLuong.IdTrinhDoDaoTao);
            return View(tbDienBienLuong);
        }

        // POST: DienBienLuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDienBienLuong,IdCanBo,IdTrinhDoDaoTao,NgayThangNam,IdBacLuong,IdHeSoLuong")] TbDienBienLuong tbDienBienLuong)
        {
            if (id != tbDienBienLuong.IdDienBienLuong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDienBienLuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDienBienLuongExists(tbDienBienLuong.IdDienBienLuong))
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
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong", tbDienBienLuong.IdBacLuong);
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDienBienLuong.IdCanBo);
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong", tbDienBienLuong.IdHeSoLuong);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbDienBienLuong.IdTrinhDoDaoTao);
            return View(tbDienBienLuong);
        }

        // GET: DienBienLuong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDienBienLuong = await _context.TbDienBienLuongs
                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdDienBienLuong == id);
            if (tbDienBienLuong == null)
            {
                return NotFound();
            }

            return View(tbDienBienLuong);
        }

        // POST: DienBienLuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDienBienLuong = await _context.TbDienBienLuongs.FindAsync(id);
            if (tbDienBienLuong != null)
            {
                _context.TbDienBienLuongs.Remove(tbDienBienLuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDienBienLuongExists(int id)
        {
            return _context.TbDienBienLuongs.Any(e => e.IdDienBienLuong == id);
        }
    }
}
