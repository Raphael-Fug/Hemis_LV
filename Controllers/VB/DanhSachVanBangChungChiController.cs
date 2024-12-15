using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.VB
{
    //Bùi VĂN ĐẠT
    public class DanhSachVanBangChungChiController : Controller
    {
        private readonly HemisContext _context;

        public DanhSachVanBangChungChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: DanhSachVanBangChungChi
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDanhSachVanBangChungChis.Include(t => t.IdHocVienNavigation).ThenInclude(human => human.IdNguoiNavigation).Include(t => t.IdLoaiTotNghiepNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DanhSachVanBangChungChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhSachVanBangChungChi = await _context.TbDanhSachVanBangChungChis
                .Include(t => t.IdHocVienNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdLoaiTotNghiepNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhSachVanBangChungChi == id);
            if (tbDanhSachVanBangChungChi == null)
            {
                return NotFound();
            }

            return View(tbDanhSachVanBangChungChi);
        }

        // GET: DanhSachVanBangChungChi/Create
        public IActionResult Create()
        {
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(t => t.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name");
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "LoaiTotNghiep");
            return View();
        }

        // POST: DanhSachVanBangChungChi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhSachVanBangChungChi,IdHocVien,TenVanBang,IdChuongTrinhDaoTao,TenDonViBangCap,NgayCap,NamTotNghiep,IdLoaiTotNghiep,SoQuyetDinhCongNhanTotNghiep,NgayQuyetDinhCongNhanTotNghiep,SoHieuVanBang,SoVaoSoGocCapVanBang,SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan,NgayBaoVe,LinkFileScan")] TbDanhSachVanBangChungChi tbDanhSachVanBangChungChi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDanhSachVanBangChungChi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbDanhSachVanBangChungChi.IdHocVien);
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "IdLoaiTotNghiep", tbDanhSachVanBangChungChi.IdLoaiTotNghiep);
            return View(tbDanhSachVanBangChungChi);
        }

        // GET: DanhSachVanBangChungChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhSachVanBangChungChi = await _context.TbDanhSachVanBangChungChis.FindAsync(id);
            if (tbDanhSachVanBangChungChi == null)
            {
                return NotFound();
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(t => t.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbDanhSachVanBangChungChi.IdHocVien);
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "LoaiTotNghiep", tbDanhSachVanBangChungChi.IdLoaiTotNghiep);
            return View(tbDanhSachVanBangChungChi);
        }

        // POST: DanhSachVanBangChungChi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhSachVanBangChungChi,IdHocVien,TenVanBang,IdChuongTrinhDaoTao,TenDonViBangCap,NgayCap,NamTotNghiep,IdLoaiTotNghiep,SoQuyetDinhCongNhanTotNghiep,NgayQuyetDinhCongNhanTotNghiep,SoHieuVanBang,SoVaoSoGocCapVanBang,SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan,NgayBaoVe,LinkFileScan")] TbDanhSachVanBangChungChi tbDanhSachVanBangChungChi)
        {
            if (id != tbDanhSachVanBangChungChi.IdDanhSachVanBangChungChi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhSachVanBangChungChi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhSachVanBangChungChiExists(tbDanhSachVanBangChungChi.IdDanhSachVanBangChungChi))
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
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbDanhSachVanBangChungChi.IdHocVien);
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "IdLoaiTotNghiep", tbDanhSachVanBangChungChi.IdLoaiTotNghiep);
            return View(tbDanhSachVanBangChungChi);
        }

        // GET: DanhSachVanBangChungChi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhSachVanBangChungChi = await _context.TbDanhSachVanBangChungChis
                .Include(t => t.IdHocVienNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdLoaiTotNghiepNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhSachVanBangChungChi == id);
            if (tbDanhSachVanBangChungChi == null)
            {
                return NotFound();
            }

            return View(tbDanhSachVanBangChungChi);
        }

        // POST: DanhSachVanBangChungChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDanhSachVanBangChungChi = await _context.TbDanhSachVanBangChungChis.FindAsync(id);
            if (tbDanhSachVanBangChungChi != null)
            {
                _context.TbDanhSachVanBangChungChis.Remove(tbDanhSachVanBangChungChi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDanhSachVanBangChungChiExists(int id)
        {
            return _context.TbDanhSachVanBangChungChis.Any(e => e.IdDanhSachVanBangChungChi == id);
        }
    }
}
