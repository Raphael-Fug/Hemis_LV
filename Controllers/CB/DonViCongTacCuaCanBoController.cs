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
    public class DonViCongTacCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public DonViCongTacCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: DonViCongTacCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDonViCongTacCuaCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdChucVuNavigation).Include(t => t.IdHinhThucBoNhiemNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DonViCongTacCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViCongTacCuaCanBo = await _context.TbDonViCongTacCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdChucVuNavigation)
                .Include(t => t.IdHinhThucBoNhiemNavigation)
                .FirstOrDefaultAsync(m => m.IdDvct == id);
            if (tbDonViCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbDonViCongTacCuaCanBo);
        }

        // GET: DonViCongTacCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu");
            ViewData["IdHinhThucBoNhiem"] = new SelectList(_context.DmHinhThucBoNhiems, "IdHinhThucBoNhiem", "IdHinhThucBoNhiem");
            return View();
        }

        // POST: DonViCongTacCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDvct,IdCanBo,MaPhongBanDonVi,IdChucVu,IdHinhThucBoNhiem,SoQuyetDinh,NgayQuyetDinh,LaDonViChinh,LaDonViGiangDay,ThoiGianCoHieuLuc,ThoiGianHetHieuLuc")] TbDonViCongTacCuaCanBo tbDonViCongTacCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDonViCongTacCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDonViCongTacCuaCanBo.IdCanBo);
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbDonViCongTacCuaCanBo.IdChucVu);
            ViewData["IdHinhThucBoNhiem"] = new SelectList(_context.DmHinhThucBoNhiems, "IdHinhThucBoNhiem", "IdHinhThucBoNhiem", tbDonViCongTacCuaCanBo.IdHinhThucBoNhiem);
            return View(tbDonViCongTacCuaCanBo);
        }

        // GET: DonViCongTacCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViCongTacCuaCanBo = await _context.TbDonViCongTacCuaCanBos.FindAsync(id);
            if (tbDonViCongTacCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDonViCongTacCuaCanBo.IdCanBo);
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbDonViCongTacCuaCanBo.IdChucVu);
            ViewData["IdHinhThucBoNhiem"] = new SelectList(_context.DmHinhThucBoNhiems, "IdHinhThucBoNhiem", "IdHinhThucBoNhiem", tbDonViCongTacCuaCanBo.IdHinhThucBoNhiem);
            return View(tbDonViCongTacCuaCanBo);
        }

        // POST: DonViCongTacCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDvct,IdCanBo,MaPhongBanDonVi,IdChucVu,IdHinhThucBoNhiem,SoQuyetDinh,NgayQuyetDinh,LaDonViChinh,LaDonViGiangDay,ThoiGianCoHieuLuc,ThoiGianHetHieuLuc")] TbDonViCongTacCuaCanBo tbDonViCongTacCuaCanBo)
        {
            if (id != tbDonViCongTacCuaCanBo.IdDvct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDonViCongTacCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDonViCongTacCuaCanBoExists(tbDonViCongTacCuaCanBo.IdDvct))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDonViCongTacCuaCanBo.IdCanBo);
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbDonViCongTacCuaCanBo.IdChucVu);
            ViewData["IdHinhThucBoNhiem"] = new SelectList(_context.DmHinhThucBoNhiems, "IdHinhThucBoNhiem", "IdHinhThucBoNhiem", tbDonViCongTacCuaCanBo.IdHinhThucBoNhiem);
            return View(tbDonViCongTacCuaCanBo);
        }

        // GET: DonViCongTacCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViCongTacCuaCanBo = await _context.TbDonViCongTacCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdChucVuNavigation)
                .Include(t => t.IdHinhThucBoNhiemNavigation)
                .FirstOrDefaultAsync(m => m.IdDvct == id);
            if (tbDonViCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbDonViCongTacCuaCanBo);
        }

        // POST: DonViCongTacCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDonViCongTacCuaCanBo = await _context.TbDonViCongTacCuaCanBos.FindAsync(id);
            if (tbDonViCongTacCuaCanBo != null)
            {
                _context.TbDonViCongTacCuaCanBos.Remove(tbDonViCongTacCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDonViCongTacCuaCanBoExists(int id)
        {
            return _context.TbDonViCongTacCuaCanBos.Any(e => e.IdDvct == id);
        }
    }
}
