using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.KHCN
{
    public class BaiBaoKhdaCongBoController : Controller
    {
        private readonly HemisContext _context;

        public BaiBaoKhdaCongBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: BaiBaoKhdaCongBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: BaiBaoKhdaCongBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiBaoKhdaCongBo = await _context.TbBaiBaoKhdaCongBos
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTapChiQuocTeNavigation)
                .Include(t => t.IdTapChiTrongNuocNavigation)
                .Include(t => t.IdXepHangQNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiBaoKhdaCongBo == id);
            if (tbBaiBaoKhdaCongBo == null)
            {
                return NotFound();
            }

            return View(tbBaiBaoKhdaCongBo);
        }

        // GET: BaiBaoKhdaCongBo/Create
        public IActionResult Create()
        {
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu");
            ViewData["IdTapChiQuocTe"] = new SelectList(_context.DmTapChiKhoaHocQuocTes, "IdTapChiKhoaHocQuocTe", "TapChiKhoaHocQuocTe");
            ViewData["IdTapChiTrongNuoc"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "TapChiTrongNuoc");
            ViewData["IdXepHangQ"] = new SelectList(_context.DmXepHangQs, "IdXepHangQ", "XepHangQ");
            return View();
        }

        // POST: BaiBaoKhdaCongBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]//HTTP
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaiBaoKhdaCongBo,IdNhiemVuKhcn,MaBaiBaoKh,TenBaiBaoKh,TenTapChi,IdTapChiTrongNuoc,IdTapChiQuocTe,IdXepHangQ,GhiChuDuongDanBaiBao,TapSo,Trang,NamCongBo")] TbBaiBaoKhdaCongBo tbBaiBaoKhdaCongBo)
        {



            if (ModelState.IsValid)
            {
                _context.Add(tbBaiBaoKhdaCongBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbBaiBaoKhdaCongBo.IdNhiemVuKhcn);
            ViewData["IdTapChiQuocTe"] = new SelectList(_context.DmTapChiKhoaHocQuocTes, "IdTapChiKhoaHocQuocTe", "TapChiKhoaHocQuocTe", tbBaiBaoKhdaCongBo.IdTapChiQuocTe);
            ViewData["IdTapChiTrongNuoc"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "TapChiTrongNuoc", tbBaiBaoKhdaCongBo.IdTapChiTrongNuoc);
            ViewData["IdXepHangQ"] = new SelectList(_context.DmXepHangQs, "IdXepHangQ", "XepHangQ", tbBaiBaoKhdaCongBo.IdXepHangQ);
            return View(tbBaiBaoKhdaCongBo);
        }

        // GET: BaiBaoKhdaCongBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiBaoKhdaCongBo = await _context.TbBaiBaoKhdaCongBos.FindAsync(id);
            if (tbBaiBaoKhdaCongBo == null)
            {
                return NotFound();
            }
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbBaiBaoKhdaCongBo.IdNhiemVuKhcn);
            ViewData["IdTapChiQuocTe"] = new SelectList(_context.DmTapChiKhoaHocQuocTes, "IdTapChiKhoaHocQuocTe", "TapChiKhoaHocQuocTe", tbBaiBaoKhdaCongBo.IdTapChiQuocTe);
            ViewData["IdTapChiTrongNuoc"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "TapChiTrongNuoc", tbBaiBaoKhdaCongBo.IdTapChiTrongNuoc);
            ViewData["IdXepHangQ"] = new SelectList(_context.DmXepHangQs, "IdXepHangQ", "XepHangQ", tbBaiBaoKhdaCongBo.IdXepHangQ);
            return View(tbBaiBaoKhdaCongBo);
        }

        // POST: BaiBaoKhdaCongBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaiBaoKhdaCongBo,IdNhiemVuKhcn,MaBaiBaoKh,TenBaiBaoKh,TenTapChi,IdTapChiTrongNuoc,IdTapChiQuocTe,IdXepHangQ,GhiChuDuongDanBaiBao,TapSo,Trang,NamCongBo")] TbBaiBaoKhdaCongBo tbBaiBaoKhdaCongBo)
        {
            if (id != tbBaiBaoKhdaCongBo.IdBaiBaoKhdaCongBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBaiBaoKhdaCongBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbBaiBaoKhdaCongBoExists(tbBaiBaoKhdaCongBo.IdBaiBaoKhdaCongBo))
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
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbBaiBaoKhdaCongBo.IdNhiemVuKhcn);
            ViewData["IdTapChiQuocTe"] = new SelectList(_context.DmTapChiKhoaHocQuocTes, "IdTapChiKhoaHocQuocTe", "TapChiKhoaHocQuocTe", tbBaiBaoKhdaCongBo.IdTapChiQuocTe);
            ViewData["IdTapChiTrongNuoc"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "TapChiTrongNuoc", tbBaiBaoKhdaCongBo.IdTapChiTrongNuoc);
            ViewData["IdXepHangQ"] = new SelectList(_context.DmXepHangQs, "IdXepHangQ", "XepHangQ", tbBaiBaoKhdaCongBo.IdXepHangQ);
            return View(tbBaiBaoKhdaCongBo);
        }

        // GET: BaiBaoKhdaCongBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiBaoKhdaCongBo = await _context.TbBaiBaoKhdaCongBos
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTapChiQuocTeNavigation)
                .Include(t => t.IdTapChiTrongNuocNavigation)
                .Include(t => t.IdXepHangQNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiBaoKhdaCongBo == id);
            if (tbBaiBaoKhdaCongBo == null)
            {
                return NotFound();
            }

            return View(tbBaiBaoKhdaCongBo);
        }

        // POST: BaiBaoKhdaCongBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbBaiBaoKhdaCongBo = await _context.TbBaiBaoKhdaCongBos.FindAsync(id);
            if (tbBaiBaoKhdaCongBo != null)
            {
                _context.TbBaiBaoKhdaCongBos.Remove(tbBaiBaoKhdaCongBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbBaiBaoKhdaCongBoExists(int id)
        {
            return _context.TbBaiBaoKhdaCongBos.Any(e => e.IdBaiBaoKhdaCongBo == id);
        }
        private bool checkexist(string check)
        {
            return _context.TbBaiBaoKhdaCongBos.Any(e => e.MaBaiBaoKh == check);

        }

    }
}