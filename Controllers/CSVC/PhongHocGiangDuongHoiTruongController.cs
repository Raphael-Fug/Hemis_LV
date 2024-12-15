using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSVC
{
    public class PhongHocGiangDuongHoiTruongController : Controller
    {
        private readonly HemisContext _context;

        public PhongHocGiangDuongHoiTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: PhongHocGiangDuongHoiTruong
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbPhongHocGiangDuongHoiTruongs.Include(t => t.IdHinhThucSoHuuNavigation).Include(t => t.IdLoaiDeAnNavigation).Include(t => t.IdLoaiPhongHocNavigation).Include(t => t.IdPhanLoaiCsvcNavigation).Include(t => t.IdTinhTrangCoSoVatChatNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: PhongHocGiangDuongHoiTruong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongHocGiangDuongHoiTruong = await _context.TbPhongHocGiangDuongHoiTruongs
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdLoaiDeAnNavigation)
                .Include(t => t.IdLoaiPhongHocNavigation)
                .Include(t => t.IdPhanLoaiCsvcNavigation)
                .Include(t => t.IdTinhTrangCoSoVatChatNavigation)
                .FirstOrDefaultAsync(m => m.IdPhongHocGiangDuongHoiTruong == id);
            if (tbPhongHocGiangDuongHoiTruong == null)
            {
                return NotFound();
            }

            return View(tbPhongHocGiangDuongHoiTruong);
        }

        // GET: PhongHocGiangDuongHoiTruong/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu");
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh");
            ViewData["IdLoaiPhongHoc"] = new SelectList(_context.DmLoaiPhongHocs, "IdLoaiPhongHoc", "IdLoaiPhongHoc");
            ViewData["IdPhanLoaiCsvc"] = new SelectList(_context.DmPhanLoaiCsvcs, "IdPhanLoaiCsvc", "IdPhanLoaiCsvc");
            ViewData["IdTinhTrangCoSoVatChat"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat");
            return View();
        }

        // POST: PhongHocGiangDuongHoiTruong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhongHocGiangDuongHoiTruong,MaPhongHocGiangDuongHoiTruong,TenPhongHocGiangDuongHoiTruong,DienTich,IdHinhThucSoHuu,QuyMoChoNgoi,IdTinhTrangCoSoVatChat,IdPhanLoaiCsvc,IdLoaiPhongHoc,IdLoaiDeAn,NamDuaVaoSuDung")] TbPhongHocGiangDuongHoiTruong tbPhongHocGiangDuongHoiTruong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbPhongHocGiangDuongHoiTruong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbPhongHocGiangDuongHoiTruong.IdHinhThucSoHuu);
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh", tbPhongHocGiangDuongHoiTruong.IdLoaiDeAn);
            ViewData["IdLoaiPhongHoc"] = new SelectList(_context.DmLoaiPhongHocs, "IdLoaiPhongHoc", "IdLoaiPhongHoc", tbPhongHocGiangDuongHoiTruong.IdLoaiPhongHoc);
            ViewData["IdPhanLoaiCsvc"] = new SelectList(_context.DmPhanLoaiCsvcs, "IdPhanLoaiCsvc", "IdPhanLoaiCsvc", tbPhongHocGiangDuongHoiTruong.IdPhanLoaiCsvc);
            ViewData["IdTinhTrangCoSoVatChat"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbPhongHocGiangDuongHoiTruong.IdTinhTrangCoSoVatChat);
            return View(tbPhongHocGiangDuongHoiTruong);
        }

        // GET: PhongHocGiangDuongHoiTruong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongHocGiangDuongHoiTruong = await _context.TbPhongHocGiangDuongHoiTruongs.FindAsync(id);
            if (tbPhongHocGiangDuongHoiTruong == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbPhongHocGiangDuongHoiTruong.IdHinhThucSoHuu);
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh", tbPhongHocGiangDuongHoiTruong.IdLoaiDeAn);
            ViewData["IdLoaiPhongHoc"] = new SelectList(_context.DmLoaiPhongHocs, "IdLoaiPhongHoc", "IdLoaiPhongHoc", tbPhongHocGiangDuongHoiTruong.IdLoaiPhongHoc);
            ViewData["IdPhanLoaiCsvc"] = new SelectList(_context.DmPhanLoaiCsvcs, "IdPhanLoaiCsvc", "IdPhanLoaiCsvc", tbPhongHocGiangDuongHoiTruong.IdPhanLoaiCsvc);
            ViewData["IdTinhTrangCoSoVatChat"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbPhongHocGiangDuongHoiTruong.IdTinhTrangCoSoVatChat);
            return View(tbPhongHocGiangDuongHoiTruong);
        }

        // POST: PhongHocGiangDuongHoiTruong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhongHocGiangDuongHoiTruong,MaPhongHocGiangDuongHoiTruong,TenPhongHocGiangDuongHoiTruong,DienTich,IdHinhThucSoHuu,QuyMoChoNgoi,IdTinhTrangCoSoVatChat,IdPhanLoaiCsvc,IdLoaiPhongHoc,IdLoaiDeAn,NamDuaVaoSuDung")] TbPhongHocGiangDuongHoiTruong tbPhongHocGiangDuongHoiTruong)
        {
            if (id != tbPhongHocGiangDuongHoiTruong.IdPhongHocGiangDuongHoiTruong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPhongHocGiangDuongHoiTruong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPhongHocGiangDuongHoiTruongExists(tbPhongHocGiangDuongHoiTruong.IdPhongHocGiangDuongHoiTruong))
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
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbPhongHocGiangDuongHoiTruong.IdHinhThucSoHuu);
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh", tbPhongHocGiangDuongHoiTruong.IdLoaiDeAn);
            ViewData["IdLoaiPhongHoc"] = new SelectList(_context.DmLoaiPhongHocs, "IdLoaiPhongHoc", "IdLoaiPhongHoc", tbPhongHocGiangDuongHoiTruong.IdLoaiPhongHoc);
            ViewData["IdPhanLoaiCsvc"] = new SelectList(_context.DmPhanLoaiCsvcs, "IdPhanLoaiCsvc", "IdPhanLoaiCsvc", tbPhongHocGiangDuongHoiTruong.IdPhanLoaiCsvc);
            ViewData["IdTinhTrangCoSoVatChat"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbPhongHocGiangDuongHoiTruong.IdTinhTrangCoSoVatChat);
            return View(tbPhongHocGiangDuongHoiTruong);
        }

        // GET: PhongHocGiangDuongHoiTruong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongHocGiangDuongHoiTruong = await _context.TbPhongHocGiangDuongHoiTruongs
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdLoaiDeAnNavigation)
                .Include(t => t.IdLoaiPhongHocNavigation)
                .Include(t => t.IdPhanLoaiCsvcNavigation)
                .Include(t => t.IdTinhTrangCoSoVatChatNavigation)
                .FirstOrDefaultAsync(m => m.IdPhongHocGiangDuongHoiTruong == id);
            if (tbPhongHocGiangDuongHoiTruong == null)
            {
                return NotFound();
            }

            return View(tbPhongHocGiangDuongHoiTruong);
        }

        // POST: PhongHocGiangDuongHoiTruong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPhongHocGiangDuongHoiTruong = await _context.TbPhongHocGiangDuongHoiTruongs.FindAsync(id);
            if (tbPhongHocGiangDuongHoiTruong != null)
            {
                _context.TbPhongHocGiangDuongHoiTruongs.Remove(tbPhongHocGiangDuongHoiTruong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPhongHocGiangDuongHoiTruongExists(int id)
        {
            return _context.TbPhongHocGiangDuongHoiTruongs.Any(e => e.IdPhongHocGiangDuongHoiTruong == id);
        }
    }
}
