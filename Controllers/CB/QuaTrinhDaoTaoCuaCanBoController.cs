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
    public class QuaTrinhDaoTaoCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public QuaTrinhDaoTaoCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: QuaTrinhDaoTaoCuaCanBo
        public async Task<IActionResult> Index(int? Search)
        {
            // Lấy danh sách tất cả quá trình công tác
            var id = from s in _context.TbQuaTrinhDaoTaoCuaCanBos select s;

            // Nếu có giá trị tìm kiếm, lọc theo IdCanBo
            if (Search.HasValue)
            {
                id = id.Where(s => s.IdCanBo == Search.Value);
            }

            // Trả về view với danh sách đã lọc
            return View(await id.ToListAsync());
        }

        // GET: QuaTrinhDaoTaoCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbQuaTrinhDaoTaoCuaCanBo = await _context.TbQuaTrinhDaoTaoCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdQuocGiaDaoTaoNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdQuaTrinhDaoTaoCuaCanBo == id);
            if (tbQuaTrinhDaoTaoCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbQuaTrinhDaoTaoCuaCanBo);
        }

        // GET: QuaTrinhDaoTaoCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            ViewData["IdQuocGiaDaoTao"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich");
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao");
            return View();
        }

        // POST: QuaTrinhDaoTaoCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuaTrinhDaoTaoCuaCanBo,IdCanBo,IdTrinhDoDaoTao,IdQuocGiaDaoTao,CoSoDaoTao,ThoiGianBatDau,ThoiGianKetThuc,IdNganhDaoTao,NamTotNghiep,IdLoaiHinhDaoTao")] TbQuaTrinhDaoTaoCuaCanBo tbQuaTrinhDaoTaoCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbQuaTrinhDaoTaoCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbQuaTrinhDaoTaoCuaCanBo.IdCanBo);
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdNganhDaoTao);
            ViewData["IdQuocGiaDaoTao"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbQuaTrinhDaoTaoCuaCanBo.IdQuocGiaDaoTao);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdTrinhDoDaoTao);
            return View(tbQuaTrinhDaoTaoCuaCanBo);
        }

        // GET: QuaTrinhDaoTaoCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbQuaTrinhDaoTaoCuaCanBo = await _context.TbQuaTrinhDaoTaoCuaCanBos.FindAsync(id);
            if (tbQuaTrinhDaoTaoCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbQuaTrinhDaoTaoCuaCanBo.IdCanBo);
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdNganhDaoTao);
            ViewData["IdQuocGiaDaoTao"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbQuaTrinhDaoTaoCuaCanBo.IdQuocGiaDaoTao);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdTrinhDoDaoTao);
            return View(tbQuaTrinhDaoTaoCuaCanBo);
        }

        // POST: QuaTrinhDaoTaoCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuaTrinhDaoTaoCuaCanBo,IdCanBo,IdTrinhDoDaoTao,IdQuocGiaDaoTao,CoSoDaoTao,ThoiGianBatDau,ThoiGianKetThuc,IdNganhDaoTao,NamTotNghiep,IdLoaiHinhDaoTao")] TbQuaTrinhDaoTaoCuaCanBo tbQuaTrinhDaoTaoCuaCanBo)
        {
            if (id != tbQuaTrinhDaoTaoCuaCanBo.IdQuaTrinhDaoTaoCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbQuaTrinhDaoTaoCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbQuaTrinhDaoTaoCuaCanBoExists(tbQuaTrinhDaoTaoCuaCanBo.IdQuaTrinhDaoTaoCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbQuaTrinhDaoTaoCuaCanBo.IdCanBo);
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdNganhDaoTao);
            ViewData["IdQuocGiaDaoTao"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbQuaTrinhDaoTaoCuaCanBo.IdQuocGiaDaoTao);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbQuaTrinhDaoTaoCuaCanBo.IdTrinhDoDaoTao);
            return View(tbQuaTrinhDaoTaoCuaCanBo);
        }

        // GET: QuaTrinhDaoTaoCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbQuaTrinhDaoTaoCuaCanBo = await _context.TbQuaTrinhDaoTaoCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdQuocGiaDaoTaoNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdQuaTrinhDaoTaoCuaCanBo == id);
            if (tbQuaTrinhDaoTaoCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbQuaTrinhDaoTaoCuaCanBo);
        }

        // POST: QuaTrinhDaoTaoCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbQuaTrinhDaoTaoCuaCanBo = await _context.TbQuaTrinhDaoTaoCuaCanBos.FindAsync(id);
            if (tbQuaTrinhDaoTaoCuaCanBo != null)
            {
                _context.TbQuaTrinhDaoTaoCuaCanBos.Remove(tbQuaTrinhDaoTaoCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbQuaTrinhDaoTaoCuaCanBoExists(int id)
        {
            return _context.TbQuaTrinhDaoTaoCuaCanBos.Any(e => e.IdQuaTrinhDaoTaoCuaCanBo == id);
        }
    }
}
