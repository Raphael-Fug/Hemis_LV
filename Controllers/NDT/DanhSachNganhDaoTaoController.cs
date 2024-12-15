using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.NDT
{
    public class DanhSachNganhDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public DanhSachNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: DanhSachNganhDaoTao
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDanhSachNganhDaoTaos.Include(t => t.HinhThucDaoTaoTheoChuyenNguNavigation).Include(t => t.IdNganhDaoTaoNavigation).Include(t => t.IdQuyetDinhTuChuNavigation).Include(t => t.IdTrangThaiDaoTaoNavigation).Include(t => t.IdTuChuMoNganhNavigation).Include(t => t.NganhDaoTaoLienKetNuocNgoaiNavigation).Include(t => t.UuTienDaoTaoNhanLucDuLichCnttNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DanhSachNganhDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhSachNganhDaoTao = await _context.TbDanhSachNganhDaoTaos
                .Include(t => t.HinhThucDaoTaoTheoChuyenNguNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdQuyetDinhTuChuNavigation)
                .Include(t => t.IdTrangThaiDaoTaoNavigation)
                .Include(t => t.IdTuChuMoNganhNavigation)
                .Include(t => t.NganhDaoTaoLienKetNuocNgoaiNavigation)
                .Include(t => t.UuTienDaoTaoNhanLucDuLichCnttNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhSachNganhDaoTao == id);
            if (tbDanhSachNganhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbDanhSachNganhDaoTao);
        }

        // GET: DanhSachNganhDaoTao/Create
        public IActionResult Create()
        {
            ViewData["HinhThucDaoTaoTheoChuyenNgu"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            ViewData["IdQuyetDinhTuChu"] = new SelectList(_context.DmQuyetDinhTuChus, "IdQuyetDinhTuChu", "IdQuyetDinhTuChu");
            ViewData["IdTrangThaiDaoTao"] = new SelectList(_context.DmTrangThaiDaoTaos, "IdTrangThaiDaoTao", "IdTrangThaiDaoTao");
            ViewData["IdTuChuMoNganh"] = new SelectList(_context.DmTuChuMoNganhs, "IdTuChuMoNganh", "IdTuChuMoNganh");
            ViewData["NganhDaoTaoLienKetNuocNgoai"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon");
            ViewData["UuTienDaoTaoNhanLucDuLichCntt"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon");
            return View();
        }

        // POST: DanhSachNganhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhSachNganhDaoTao,IdNganhDaoTao,SoQuyetDinhChoPhepMoNganh,NgayBanHanhVanBanQuyetDinhMoNganh,MaNganhMoLanDau,TenNganhMoLanDau,CoQuanBanHanh,NguoiKy,SoQuyetDinhChoPhepDoiTenNganh,NgayBanHanhVanBanQuyetDinhDoiTenNganh,HinhThucDaoTaoTheoChuyenNgu,NamBatDauDaoTao,IdQuyetDinhTuChu,IdTuChuMoNganh,SoNamDaoTaoThSts,NamTuyenSinhVaDaoTaoGanNhat,TongSoNamDaoTaoCuaNganh,UuTienDaoTaoNhanLucDuLichCntt,NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCntt,SoQuyetDinhDaoTaoTuXa,NgayQuyetDinhDaoTaoTuXa,NamBatDauDaoTaoTuXa,NganhDaoTaoLienKetNuocNgoai,IdTrangThaiDaoTao")] TbDanhSachNganhDaoTao tbDanhSachNganhDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDanhSachNganhDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HinhThucDaoTaoTheoChuyenNgu"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.HinhThucDaoTaoTheoChuyenNgu);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbDanhSachNganhDaoTao.IdNganhDaoTao);
            ViewData["IdQuyetDinhTuChu"] = new SelectList(_context.DmQuyetDinhTuChus, "IdQuyetDinhTuChu", "IdQuyetDinhTuChu", tbDanhSachNganhDaoTao.IdQuyetDinhTuChu);
            ViewData["IdTrangThaiDaoTao"] = new SelectList(_context.DmTrangThaiDaoTaos, "IdTrangThaiDaoTao", "IdTrangThaiDaoTao", tbDanhSachNganhDaoTao.IdTrangThaiDaoTao);
            ViewData["IdTuChuMoNganh"] = new SelectList(_context.DmTuChuMoNganhs, "IdTuChuMoNganh", "IdTuChuMoNganh", tbDanhSachNganhDaoTao.IdTuChuMoNganh);
            ViewData["NganhDaoTaoLienKetNuocNgoai"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.NganhDaoTaoLienKetNuocNgoai);
            ViewData["UuTienDaoTaoNhanLucDuLichCntt"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.UuTienDaoTaoNhanLucDuLichCntt);
            return View(tbDanhSachNganhDaoTao);
        }

        // GET: DanhSachNganhDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhSachNganhDaoTao = await _context.TbDanhSachNganhDaoTaos.FindAsync(id);
            if (tbDanhSachNganhDaoTao == null)
            {
                return NotFound();
            }
            ViewData["HinhThucDaoTaoTheoChuyenNgu"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.HinhThucDaoTaoTheoChuyenNgu);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbDanhSachNganhDaoTao.IdNganhDaoTao);
            ViewData["IdQuyetDinhTuChu"] = new SelectList(_context.DmQuyetDinhTuChus, "IdQuyetDinhTuChu", "IdQuyetDinhTuChu", tbDanhSachNganhDaoTao.IdQuyetDinhTuChu);
            ViewData["IdTrangThaiDaoTao"] = new SelectList(_context.DmTrangThaiDaoTaos, "IdTrangThaiDaoTao", "IdTrangThaiDaoTao", tbDanhSachNganhDaoTao.IdTrangThaiDaoTao);
            ViewData["IdTuChuMoNganh"] = new SelectList(_context.DmTuChuMoNganhs, "IdTuChuMoNganh", "IdTuChuMoNganh", tbDanhSachNganhDaoTao.IdTuChuMoNganh);
            ViewData["NganhDaoTaoLienKetNuocNgoai"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.NganhDaoTaoLienKetNuocNgoai);
            ViewData["UuTienDaoTaoNhanLucDuLichCntt"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.UuTienDaoTaoNhanLucDuLichCntt);
            return View(tbDanhSachNganhDaoTao);
        }

        // POST: DanhSachNganhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhSachNganhDaoTao,IdNganhDaoTao,SoQuyetDinhChoPhepMoNganh,NgayBanHanhVanBanQuyetDinhMoNganh,MaNganhMoLanDau,TenNganhMoLanDau,CoQuanBanHanh,NguoiKy,SoQuyetDinhChoPhepDoiTenNganh,NgayBanHanhVanBanQuyetDinhDoiTenNganh,HinhThucDaoTaoTheoChuyenNgu,NamBatDauDaoTao,IdQuyetDinhTuChu,IdTuChuMoNganh,SoNamDaoTaoThSts,NamTuyenSinhVaDaoTaoGanNhat,TongSoNamDaoTaoCuaNganh,UuTienDaoTaoNhanLucDuLichCntt,NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCntt,SoQuyetDinhDaoTaoTuXa,NgayQuyetDinhDaoTaoTuXa,NamBatDauDaoTaoTuXa,NganhDaoTaoLienKetNuocNgoai,IdTrangThaiDaoTao")] TbDanhSachNganhDaoTao tbDanhSachNganhDaoTao)
        {
            if (id != tbDanhSachNganhDaoTao.IdDanhSachNganhDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhSachNganhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhSachNganhDaoTaoExists(tbDanhSachNganhDaoTao.IdDanhSachNganhDaoTao))
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
            ViewData["HinhThucDaoTaoTheoChuyenNgu"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.HinhThucDaoTaoTheoChuyenNgu);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbDanhSachNganhDaoTao.IdNganhDaoTao);
            ViewData["IdQuyetDinhTuChu"] = new SelectList(_context.DmQuyetDinhTuChus, "IdQuyetDinhTuChu", "IdQuyetDinhTuChu", tbDanhSachNganhDaoTao.IdQuyetDinhTuChu);
            ViewData["IdTrangThaiDaoTao"] = new SelectList(_context.DmTrangThaiDaoTaos, "IdTrangThaiDaoTao", "IdTrangThaiDaoTao", tbDanhSachNganhDaoTao.IdTrangThaiDaoTao);
            ViewData["IdTuChuMoNganh"] = new SelectList(_context.DmTuChuMoNganhs, "IdTuChuMoNganh", "IdTuChuMoNganh", tbDanhSachNganhDaoTao.IdTuChuMoNganh);
            ViewData["NganhDaoTaoLienKetNuocNgoai"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.NganhDaoTaoLienKetNuocNgoai);
            ViewData["UuTienDaoTaoNhanLucDuLichCntt"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbDanhSachNganhDaoTao.UuTienDaoTaoNhanLucDuLichCntt);
            return View(tbDanhSachNganhDaoTao);
        }

        // GET: DanhSachNganhDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhSachNganhDaoTao = await _context.TbDanhSachNganhDaoTaos
                .Include(t => t.HinhThucDaoTaoTheoChuyenNguNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdQuyetDinhTuChuNavigation)
                .Include(t => t.IdTrangThaiDaoTaoNavigation)
                .Include(t => t.IdTuChuMoNganhNavigation)
                .Include(t => t.NganhDaoTaoLienKetNuocNgoaiNavigation)
                .Include(t => t.UuTienDaoTaoNhanLucDuLichCnttNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhSachNganhDaoTao == id);
            if (tbDanhSachNganhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbDanhSachNganhDaoTao);
        }

        // POST: DanhSachNganhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDanhSachNganhDaoTao = await _context.TbDanhSachNganhDaoTaos.FindAsync(id);
            if (tbDanhSachNganhDaoTao != null)
            {
                _context.TbDanhSachNganhDaoTaos.Remove(tbDanhSachNganhDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDanhSachNganhDaoTaoExists(int id)
        {
            return _context.TbDanhSachNganhDaoTaos.Any(e => e.IdDanhSachNganhDaoTao == id);
        }
    }
}
