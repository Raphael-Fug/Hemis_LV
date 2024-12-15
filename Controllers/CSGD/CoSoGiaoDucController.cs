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
    public class CoSoGiaoDucController : Controller
    {
        private readonly HemisContext _context;

        public CoSoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: CoSoGiaoDuc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbCoSoGiaoDucs.Include(t => t.HoatDongKhongLoiNhuanNavigation).Include(t => t.IdCoQuanChuQuanNavigation).Include(t => t.IdHinhThucThanhLapNavigation).Include(t => t.IdHuyenNavigation).Include(t => t.IdLoaiHinhCoSoDaoTaoNavigation).Include(t => t.IdLoaiHinhTruongNavigation).Include(t => t.IdPhanLoaiCoSoNavigation).Include(t => t.IdTinhNavigation).Include(t => t.IdXaNavigation).Include(t => t.TuChuGiaoDucQpanNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: CoSoGiaoDuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoSoGiaoDuc = await _context.TbCoSoGiaoDucs
                .Include(t => t.HoatDongKhongLoiNhuanNavigation)
                .Include(t => t.IdCoQuanChuQuanNavigation)
                .Include(t => t.IdHinhThucThanhLapNavigation)
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdLoaiHinhCoSoDaoTaoNavigation)
                .Include(t => t.IdLoaiHinhTruongNavigation)
                .Include(t => t.IdPhanLoaiCoSoNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdXaNavigation)
                .Include(t => t.TuChuGiaoDucQpanNavigation)
                .FirstOrDefaultAsync(m => m.IdCoSoGiaoDuc == id);
            if (tbCoSoGiaoDuc == null)
            {
                return NotFound();
            }

            return View(tbCoSoGiaoDuc);
        }

        // GET: CoSoGiaoDuc/Create
        public IActionResult Create()
        {
            ViewData["HoatDongKhongLoiNhuan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon");
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan");
            ViewData["IdHinhThucThanhLap"] = new SelectList(_context.DmHinhThucThanhLaps, "IdHinhThucThanhLap", "IdHinhThucThanhLap");
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen");
            ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(_context.DmLoaiHinhCoSoDaoTaos, "IdLoaiHinhCoSoDaoTao", "IdLoaiHinhCoSoDaoTao");
            ViewData["IdLoaiHinhTruong"] = new SelectList(_context.DmLoaiHinhTruongs, "IdLoaiHinhTruong", "IdLoaiHinhTruong");
            ViewData["IdPhanLoaiCoSo"] = new SelectList(_context.DmPhanLoaiCoSos, "IdPhanLoaiCoSo", "IdPhanLoaiCoSo");
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh");
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa");
            ViewData["TuChuGiaoDucQpan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon");
            return View();
        }

        // POST: CoSoGiaoDuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCoSoGiaoDuc,MaDonVi,TenDonVi,TenTiengAnh,IdHinhThucThanhLap,IdLoaiHinhTruong,SoQuyetDinhChuyenDoiLoaiHinh,NgayKyQuyetDinhChuyenDoiLoaiHinh,TenDaiHocTrucThuoc,SoDienThoai,Fax,Email,DiaChiWebsite,IdCoQuanChuQuan,SoQuyetDinhThanhLap,NgayKyQuyetDinhThanhLap,DiaChi,IdTinh,IdHuyen,IdXa,HoatDongKhongLoiNhuan,SoQuyetDinhCapPhepHoatDong,NgayDuocCapPhepHoatDong,IdLoaiHinhCoSoDaoTao,SoGiaoVienGdtc,IdPhanLoaiCoSo,TuChuGiaoDucQpan,SoQuyetDinhGiaoTuChu,DaoTaoSvgdqpan1nam,SoQuyetDinhBanHanhQuyCheTaiChinh,NgayKyQuyetDinhBanHanhQuyCheTaiChinh")] TbCoSoGiaoDuc tbCoSoGiaoDuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCoSoGiaoDuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoatDongKhongLoiNhuan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCoSoGiaoDuc.HoatDongKhongLoiNhuan);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbCoSoGiaoDuc.IdCoQuanChuQuan);
            ViewData["IdHinhThucThanhLap"] = new SelectList(_context.DmHinhThucThanhLaps, "IdHinhThucThanhLap", "IdHinhThucThanhLap", tbCoSoGiaoDuc.IdHinhThucThanhLap);
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen", tbCoSoGiaoDuc.IdHuyen);
            ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(_context.DmLoaiHinhCoSoDaoTaos, "IdLoaiHinhCoSoDaoTao", "IdLoaiHinhCoSoDaoTao", tbCoSoGiaoDuc.IdLoaiHinhCoSoDaoTao);
            ViewData["IdLoaiHinhTruong"] = new SelectList(_context.DmLoaiHinhTruongs, "IdLoaiHinhTruong", "IdLoaiHinhTruong", tbCoSoGiaoDuc.IdLoaiHinhTruong);
            ViewData["IdPhanLoaiCoSo"] = new SelectList(_context.DmPhanLoaiCoSos, "IdPhanLoaiCoSo", "IdPhanLoaiCoSo", tbCoSoGiaoDuc.IdPhanLoaiCoSo);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh", tbCoSoGiaoDuc.IdTinh);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa", tbCoSoGiaoDuc.IdXa);
            ViewData["TuChuGiaoDucQpan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCoSoGiaoDuc.TuChuGiaoDucQpan);
            return View(tbCoSoGiaoDuc);
        }

        // GET: CoSoGiaoDuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoSoGiaoDuc = await _context.TbCoSoGiaoDucs.FindAsync(id);
            if (tbCoSoGiaoDuc == null)
            {
                return NotFound();
            }
            ViewData["HoatDongKhongLoiNhuan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCoSoGiaoDuc.HoatDongKhongLoiNhuan);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbCoSoGiaoDuc.IdCoQuanChuQuan);
            ViewData["IdHinhThucThanhLap"] = new SelectList(_context.DmHinhThucThanhLaps, "IdHinhThucThanhLap", "IdHinhThucThanhLap", tbCoSoGiaoDuc.IdHinhThucThanhLap);
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen", tbCoSoGiaoDuc.IdHuyen);
            ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(_context.DmLoaiHinhCoSoDaoTaos, "IdLoaiHinhCoSoDaoTao", "IdLoaiHinhCoSoDaoTao", tbCoSoGiaoDuc.IdLoaiHinhCoSoDaoTao);
            ViewData["IdLoaiHinhTruong"] = new SelectList(_context.DmLoaiHinhTruongs, "IdLoaiHinhTruong", "IdLoaiHinhTruong", tbCoSoGiaoDuc.IdLoaiHinhTruong);
            ViewData["IdPhanLoaiCoSo"] = new SelectList(_context.DmPhanLoaiCoSos, "IdPhanLoaiCoSo", "IdPhanLoaiCoSo", tbCoSoGiaoDuc.IdPhanLoaiCoSo);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh", tbCoSoGiaoDuc.IdTinh);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa", tbCoSoGiaoDuc.IdXa);
            ViewData["TuChuGiaoDucQpan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCoSoGiaoDuc.TuChuGiaoDucQpan);
            return View(tbCoSoGiaoDuc);
        }

        // POST: CoSoGiaoDuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCoSoGiaoDuc,MaDonVi,TenDonVi,TenTiengAnh,IdHinhThucThanhLap,IdLoaiHinhTruong,SoQuyetDinhChuyenDoiLoaiHinh,NgayKyQuyetDinhChuyenDoiLoaiHinh,TenDaiHocTrucThuoc,SoDienThoai,Fax,Email,DiaChiWebsite,IdCoQuanChuQuan,SoQuyetDinhThanhLap,NgayKyQuyetDinhThanhLap,DiaChi,IdTinh,IdHuyen,IdXa,HoatDongKhongLoiNhuan,SoQuyetDinhCapPhepHoatDong,NgayDuocCapPhepHoatDong,IdLoaiHinhCoSoDaoTao,SoGiaoVienGdtc,IdPhanLoaiCoSo,TuChuGiaoDucQpan,SoQuyetDinhGiaoTuChu,DaoTaoSvgdqpan1nam,SoQuyetDinhBanHanhQuyCheTaiChinh,NgayKyQuyetDinhBanHanhQuyCheTaiChinh")] TbCoSoGiaoDuc tbCoSoGiaoDuc)
        {
            if (id != tbCoSoGiaoDuc.IdCoSoGiaoDuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCoSoGiaoDuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCoSoGiaoDucExists(tbCoSoGiaoDuc.IdCoSoGiaoDuc))
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
            ViewData["HoatDongKhongLoiNhuan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCoSoGiaoDuc.HoatDongKhongLoiNhuan);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbCoSoGiaoDuc.IdCoQuanChuQuan);
            ViewData["IdHinhThucThanhLap"] = new SelectList(_context.DmHinhThucThanhLaps, "IdHinhThucThanhLap", "IdHinhThucThanhLap", tbCoSoGiaoDuc.IdHinhThucThanhLap);
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen", tbCoSoGiaoDuc.IdHuyen);
            ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(_context.DmLoaiHinhCoSoDaoTaos, "IdLoaiHinhCoSoDaoTao", "IdLoaiHinhCoSoDaoTao", tbCoSoGiaoDuc.IdLoaiHinhCoSoDaoTao);
            ViewData["IdLoaiHinhTruong"] = new SelectList(_context.DmLoaiHinhTruongs, "IdLoaiHinhTruong", "IdLoaiHinhTruong", tbCoSoGiaoDuc.IdLoaiHinhTruong);
            ViewData["IdPhanLoaiCoSo"] = new SelectList(_context.DmPhanLoaiCoSos, "IdPhanLoaiCoSo", "IdPhanLoaiCoSo", tbCoSoGiaoDuc.IdPhanLoaiCoSo);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh", tbCoSoGiaoDuc.IdTinh);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa", tbCoSoGiaoDuc.IdXa);
            ViewData["TuChuGiaoDucQpan"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCoSoGiaoDuc.TuChuGiaoDucQpan);
            return View(tbCoSoGiaoDuc);
        }

        // GET: CoSoGiaoDuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoSoGiaoDuc = await _context.TbCoSoGiaoDucs
                .Include(t => t.HoatDongKhongLoiNhuanNavigation)
                .Include(t => t.IdCoQuanChuQuanNavigation)
                .Include(t => t.IdHinhThucThanhLapNavigation)
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdLoaiHinhCoSoDaoTaoNavigation)
                .Include(t => t.IdLoaiHinhTruongNavigation)
                .Include(t => t.IdPhanLoaiCoSoNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdXaNavigation)
                .Include(t => t.TuChuGiaoDucQpanNavigation)
                .FirstOrDefaultAsync(m => m.IdCoSoGiaoDuc == id);
            if (tbCoSoGiaoDuc == null)
            {
                return NotFound();
            }

            return View(tbCoSoGiaoDuc);
        }

        // POST: CoSoGiaoDuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCoSoGiaoDuc = await _context.TbCoSoGiaoDucs.FindAsync(id);
            if (tbCoSoGiaoDuc != null)
            {
                _context.TbCoSoGiaoDucs.Remove(tbCoSoGiaoDuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCoSoGiaoDucExists(int id)
        {
            return _context.TbCoSoGiaoDucs.Any(e => e.IdCoSoGiaoDuc == id);
        }
    }
}
