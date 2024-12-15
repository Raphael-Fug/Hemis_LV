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
    public class HopDongThinhGiangController : Controller
    {
        private readonly HemisContext _context;

        public HopDongThinhGiangController(HemisContext context)
        {
            _context = context;
        }

        // GET: HopDongThinhGiang
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHopDongThinhGiangs.Include(t => t.IdCanBoNavigation).Include(t => t.IdTrangThaiHopDongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: HopDongThinhGiang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHopDongThinhGiang = await _context.TbHopDongThinhGiangs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdHopDongThinhGiang == id);
            if (tbHopDongThinhGiang == null)
            {
                return NotFound();
            }

            return View(tbHopDongThinhGiang);
        }

        // GET: HopDongThinhGiang/Create
        public IActionResult Create()
        {
            //
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(t => t.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name");
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong");
            return View();
        }

        // POST: HopDongThinhGiang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHopDongThinhGiang,IdCanBo,MaHopDongThinhGiang,SoSoLaoDong,NgayCapSoLaoDong,NoiCapSoLaoDong,CoGiaTriTu,CoGiaTriDen,IdTrangThaiHopDong,TyLeThoiGianGiangDay")] TbHopDongThinhGiang tbHopDongThinhGiang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbHopDongThinhGiang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbHopDongThinhGiang.IdCanBo);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong", tbHopDongThinhGiang.IdTrangThaiHopDong);
            return View(tbHopDongThinhGiang);
        }

        // GET: HopDongThinhGiang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHopDongThinhGiang = await _context.TbHopDongThinhGiangs.FindAsync(id);
            if (tbHopDongThinhGiang == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbHopDongThinhGiang.IdCanBo);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong", tbHopDongThinhGiang.IdTrangThaiHopDong);
            return View(tbHopDongThinhGiang);
        }

        // POST: HopDongThinhGiang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHopDongThinhGiang,IdCanBo,MaHopDongThinhGiang,SoSoLaoDong,NgayCapSoLaoDong,NoiCapSoLaoDong,CoGiaTriTu,CoGiaTriDen,IdTrangThaiHopDong,TyLeThoiGianGiangDay")] TbHopDongThinhGiang tbHopDongThinhGiang)
        {
            if (id != tbHopDongThinhGiang.IdHopDongThinhGiang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHopDongThinhGiang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHopDongThinhGiangExists(tbHopDongThinhGiang.IdHopDongThinhGiang))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbHopDongThinhGiang.IdCanBo);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong", tbHopDongThinhGiang.IdTrangThaiHopDong);
            return View(tbHopDongThinhGiang);
        }

        // GET: HopDongThinhGiang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHopDongThinhGiang = await _context.TbHopDongThinhGiangs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdHopDongThinhGiang == id);
            if (tbHopDongThinhGiang == null)
            {
                return NotFound();
            }

            return View(tbHopDongThinhGiang);
        }

        // POST: HopDongThinhGiang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHopDongThinhGiang = await _context.TbHopDongThinhGiangs.FindAsync(id);
            if (tbHopDongThinhGiang != null)
            {
                _context.TbHopDongThinhGiangs.Remove(tbHopDongThinhGiang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHopDongThinhGiangExists(int id)
        {
            return _context.TbHopDongThinhGiangs.Any(e => e.IdHopDongThinhGiang == id);
        }
    }
}
