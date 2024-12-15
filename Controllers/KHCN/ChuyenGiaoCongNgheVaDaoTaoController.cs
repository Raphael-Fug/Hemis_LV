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
    public class ChuyenGiaoCongNgheVaDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public ChuyenGiaoCongNgheVaDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChuyenGiaoCongNgheVaDaoTao
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbChuyenGiaoCongNgheVaDaoTaos.Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation).Include(t => t.IdLinhVucNghienCuuNavigation).Include(t => t.IdNganhKinhTeNavigation).Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTrangThaiHopDongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ChuyenGiaoCongNgheVaDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos
                .Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNganhKinhTeNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdChuyenGiaoCongNgheVaDaoTao == id);
            if (tbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // GET: ChuyenGiaoCongNgheVaDaoTao/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "IdHinhThucChuyenGiaoCongNghe");
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu");
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "IdNganhKinhTe");
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn");
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong");
            return View();
        }

        // POST: ChuyenGiaoCongNgheVaDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChuyenGiaoCongNgheVaDaoTao,IdNhiemVuKhcn,MaSoHopDong,Ten,TongChiPhiThucHien,TongThoiGianThucHien,IdHinhThucChuyenGiaoCongNghe,PhuongThucChuyenGiaoCongNghe,ChuSoHuu,DonViChuTri,DonViPhoiHop,DonViNhanChuyenGiao,TomTat,TenDuAn,GiaTriHopDong,IdNganhKinhTe,IdTrangThaiHopDong,SoNguoiDuocDaoTaoChuyenGiaoCn,IdLinhVucNghienCuu")] TbChuyenGiaoCongNgheVaDaoTao tbChuyenGiaoCongNgheVaDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChuyenGiaoCongNgheVaDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "IdHinhThucChuyenGiaoCongNghe", tbChuyenGiaoCongNgheVaDaoTao.IdHinhThucChuyenGiaoCongNghe);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbChuyenGiaoCongNgheVaDaoTao.IdLinhVucNghienCuu);
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "IdNganhKinhTe", tbChuyenGiaoCongNgheVaDaoTao.IdNganhKinhTe);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbChuyenGiaoCongNgheVaDaoTao.IdNhiemVuKhcn);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong", tbChuyenGiaoCongNgheVaDaoTao.IdTrangThaiHopDong);
            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // GET: ChuyenGiaoCongNgheVaDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);
            if (tbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "IdHinhThucChuyenGiaoCongNghe", tbChuyenGiaoCongNgheVaDaoTao.IdHinhThucChuyenGiaoCongNghe);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbChuyenGiaoCongNgheVaDaoTao.IdLinhVucNghienCuu);
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "IdNganhKinhTe", tbChuyenGiaoCongNgheVaDaoTao.IdNganhKinhTe);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbChuyenGiaoCongNgheVaDaoTao.IdNhiemVuKhcn);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong", tbChuyenGiaoCongNgheVaDaoTao.IdTrangThaiHopDong);
            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // POST: ChuyenGiaoCongNgheVaDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChuyenGiaoCongNgheVaDaoTao,IdNhiemVuKhcn,MaSoHopDong,Ten,TongChiPhiThucHien,TongThoiGianThucHien,IdHinhThucChuyenGiaoCongNghe,PhuongThucChuyenGiaoCongNghe,ChuSoHuu,DonViChuTri,DonViPhoiHop,DonViNhanChuyenGiao,TomTat,TenDuAn,GiaTriHopDong,IdNganhKinhTe,IdTrangThaiHopDong,SoNguoiDuocDaoTaoChuyenGiaoCn,IdLinhVucNghienCuu")] TbChuyenGiaoCongNgheVaDaoTao tbChuyenGiaoCongNgheVaDaoTao)
        {
            if (id != tbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChuyenGiaoCongNgheVaDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChuyenGiaoCongNgheVaDaoTaoExists(tbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao))
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
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "IdHinhThucChuyenGiaoCongNghe", tbChuyenGiaoCongNgheVaDaoTao.IdHinhThucChuyenGiaoCongNghe);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbChuyenGiaoCongNgheVaDaoTao.IdLinhVucNghienCuu);
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "IdNganhKinhTe", tbChuyenGiaoCongNgheVaDaoTao.IdNganhKinhTe);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbChuyenGiaoCongNgheVaDaoTao.IdNhiemVuKhcn);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "IdTrangThaiHopDong", tbChuyenGiaoCongNgheVaDaoTao.IdTrangThaiHopDong);
            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // GET: ChuyenGiaoCongNgheVaDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos
                .Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNganhKinhTeNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdChuyenGiaoCongNgheVaDaoTao == id);
            if (tbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // POST: ChuyenGiaoCongNgheVaDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);
            if (tbChuyenGiaoCongNgheVaDaoTao != null)
            {
                _context.TbChuyenGiaoCongNgheVaDaoTaos.Remove(tbChuyenGiaoCongNgheVaDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChuyenGiaoCongNgheVaDaoTaoExists(int id)
        {
            return _context.TbChuyenGiaoCongNgheVaDaoTaos.Any(e => e.IdChuyenGiaoCongNgheVaDaoTao == id);
        }
    }
}
