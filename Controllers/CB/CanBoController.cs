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
    public class CanBoController : Controller
    {
        private readonly HemisContext _context;

        public CanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: CanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbCanBos.Include(t => t.IdChucDanhGiangVienNavigation).Include(t => t.IdChucDanhNgheNghiepNavigation).Include(t => t.IdChucDanhNghienCuuKhoaHocNavigation).Include(t => t.IdChucVuCongTacNavigation).Include(t => t.IdHuyenNavigation).Include(t => t.IdNgachNavigation).Include(t => t.IdNguoiNavigation).Include(t => t.IdTinhNavigation).Include(t => t.IdTrangThaiLamViecNavigation).Include(t => t.IdXaNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: CanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCanBo = await _context.TbCanBos
                .Include(t => t.IdChucDanhGiangVienNavigation)
                .Include(t => t.IdChucDanhNgheNghiepNavigation)
                .Include(t => t.IdChucDanhNghienCuuKhoaHocNavigation)
                .Include(t => t.IdChucVuCongTacNavigation)
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdNgachNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdTrangThaiLamViecNavigation)
                .Include(t => t.IdXaNavigation)
                .FirstOrDefaultAsync(m => m.IdCanBo == id);
            if (tbCanBo == null)
            {
                return NotFound();
            }

            return View(tbCanBo);
        }

        // GET: CanBo/Create
        public IActionResult Create()
        {
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien");
            ViewData["IdChucDanhNgheNghiep"] = new SelectList(_context.DmChucDanhNgheNghieps, "IdChucDanhNgheNghiep", "IdChucDanhNgheNghiep");
            ViewData["IdChucDanhNghienCuuKhoaHoc"] = new SelectList(_context.DmChucDanhNckhs, "IdChucDanhNghienCuuKhoaHoc", "IdChucDanhNghienCuuKhoaHoc");
            ViewData["IdChucVuCongTac"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu");
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen");
            ViewData["IdNgach"] = new SelectList(_context.DmNgaches, "IdNgach", "IdNgach");
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi");
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh");
            ViewData["IdTrangThaiLamViec"] = new SelectList(_context.DmTrangThaiCanBos, "IdTrangThaiCanBo", "IdTrangThaiCanBo");
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa");
            return View();
        }

        // POST: CanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCanBo,IdNguoi,MaCanBo,IdChucVuCongTac,SoBaoHiemXaHoi,IdXa,IdHuyen,IdTinh,Email,DienThoai,IdTrangThaiLamViec,NgayChuyenTrangThai,SoQuyetDinhHuuNghiViec,NgayQuyetDinhHuuNghiViec,HinhThucChuyenDen,NgayKetThucTamNghi,IdChucDanhNgheNghiep,IdChucDanhGiangVien,IdChucDanhNghienCuuKhoaHoc,IdNgach,CoQuanCongTac,NgayTuyenDung,ChungChiSuPhamGiangVien,LaCongChuc,LaVienChuc,CoDayMonMacLeNin,CoDayMonSuPham,SoGiayPhepLaoDong,ThamNienCongTac,TenDoanhNghiep,NamKinhNghiemGiangDay,GiangVienDapUngTt03")] TbCanBo tbCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien", tbCanBo.IdChucDanhGiangVien);
            ViewData["IdChucDanhNgheNghiep"] = new SelectList(_context.DmChucDanhNgheNghieps, "IdChucDanhNgheNghiep", "IdChucDanhNgheNghiep", tbCanBo.IdChucDanhNgheNghiep);
            ViewData["IdChucDanhNghienCuuKhoaHoc"] = new SelectList(_context.DmChucDanhNckhs, "IdChucDanhNghienCuuKhoaHoc", "IdChucDanhNghienCuuKhoaHoc", tbCanBo.IdChucDanhNghienCuuKhoaHoc);
            ViewData["IdChucVuCongTac"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbCanBo.IdChucVuCongTac);
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen", tbCanBo.IdHuyen);
            ViewData["IdNgach"] = new SelectList(_context.DmNgaches, "IdNgach", "IdNgach", tbCanBo.IdNgach);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbCanBo.IdNguoi);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh", tbCanBo.IdTinh);
            ViewData["IdTrangThaiLamViec"] = new SelectList(_context.DmTrangThaiCanBos, "IdTrangThaiCanBo", "IdTrangThaiCanBo", tbCanBo.IdTrangThaiLamViec);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa", tbCanBo.IdXa);
            return View(tbCanBo);
        }

        // GET: CanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCanBo = await _context.TbCanBos.FindAsync(id);
            if (tbCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien", tbCanBo.IdChucDanhGiangVien);
            ViewData["IdChucDanhNgheNghiep"] = new SelectList(_context.DmChucDanhNgheNghieps, "IdChucDanhNgheNghiep", "IdChucDanhNgheNghiep", tbCanBo.IdChucDanhNgheNghiep);
            ViewData["IdChucDanhNghienCuuKhoaHoc"] = new SelectList(_context.DmChucDanhNckhs, "IdChucDanhNghienCuuKhoaHoc", "IdChucDanhNghienCuuKhoaHoc", tbCanBo.IdChucDanhNghienCuuKhoaHoc);
            ViewData["IdChucVuCongTac"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbCanBo.IdChucVuCongTac);
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen", tbCanBo.IdHuyen);
            ViewData["IdNgach"] = new SelectList(_context.DmNgaches, "IdNgach", "IdNgach", tbCanBo.IdNgach);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbCanBo.IdNguoi);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh", tbCanBo.IdTinh);
            ViewData["IdTrangThaiLamViec"] = new SelectList(_context.DmTrangThaiCanBos, "IdTrangThaiCanBo", "IdTrangThaiCanBo", tbCanBo.IdTrangThaiLamViec);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa", tbCanBo.IdXa);
            return View(tbCanBo);
        }

        // POST: CanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCanBo,IdNguoi,MaCanBo,IdChucVuCongTac,SoBaoHiemXaHoi,IdXa,IdHuyen,IdTinh,Email,DienThoai,IdTrangThaiLamViec,NgayChuyenTrangThai,SoQuyetDinhHuuNghiViec,NgayQuyetDinhHuuNghiViec,HinhThucChuyenDen,NgayKetThucTamNghi,IdChucDanhNgheNghiep,IdChucDanhGiangVien,IdChucDanhNghienCuuKhoaHoc,IdNgach,CoQuanCongTac,NgayTuyenDung,ChungChiSuPhamGiangVien,LaCongChuc,LaVienChuc,CoDayMonMacLeNin,CoDayMonSuPham,SoGiayPhepLaoDong,ThamNienCongTac,TenDoanhNghiep,NamKinhNghiemGiangDay,GiangVienDapUngTt03")] TbCanBo tbCanBo)
        {
            if (id != tbCanBo.IdCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCanBoExists(tbCanBo.IdCanBo))
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
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien", tbCanBo.IdChucDanhGiangVien);
            ViewData["IdChucDanhNgheNghiep"] = new SelectList(_context.DmChucDanhNgheNghieps, "IdChucDanhNgheNghiep", "IdChucDanhNgheNghiep", tbCanBo.IdChucDanhNgheNghiep);
            ViewData["IdChucDanhNghienCuuKhoaHoc"] = new SelectList(_context.DmChucDanhNckhs, "IdChucDanhNghienCuuKhoaHoc", "IdChucDanhNghienCuuKhoaHoc", tbCanBo.IdChucDanhNghienCuuKhoaHoc);
            ViewData["IdChucVuCongTac"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbCanBo.IdChucVuCongTac);
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "IdHuyen", tbCanBo.IdHuyen);
            ViewData["IdNgach"] = new SelectList(_context.DmNgaches, "IdNgach", "IdNgach", tbCanBo.IdNgach);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbCanBo.IdNguoi);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "IdTinh", tbCanBo.IdTinh);
            ViewData["IdTrangThaiLamViec"] = new SelectList(_context.DmTrangThaiCanBos, "IdTrangThaiCanBo", "IdTrangThaiCanBo", tbCanBo.IdTrangThaiLamViec);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "IdXa", tbCanBo.IdXa);
            return View(tbCanBo);
        }

        // GET: CanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCanBo = await _context.TbCanBos
                .Include(t => t.IdChucDanhGiangVienNavigation)
                .Include(t => t.IdChucDanhNgheNghiepNavigation)
                .Include(t => t.IdChucDanhNghienCuuKhoaHocNavigation)
                .Include(t => t.IdChucVuCongTacNavigation)
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdNgachNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdTrangThaiLamViecNavigation)
                .Include(t => t.IdXaNavigation)
                .FirstOrDefaultAsync(m => m.IdCanBo == id);
            if (tbCanBo == null)
            {
                return NotFound();
            }

            return View(tbCanBo);
        }

        // POST: CanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCanBo = await _context.TbCanBos.FindAsync(id);
            if (tbCanBo != null)
            {
                _context.TbCanBos.Remove(tbCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCanBoExists(int id)
        {
            return _context.TbCanBos.Any(e => e.IdCanBo == id);
        }
    }
}
