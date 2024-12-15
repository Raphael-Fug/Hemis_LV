using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TCTS
{
    public class ChiTietTaiSanDonViController : Controller
    {
        private readonly HemisContext _context;
        private readonly ILogger<ChiTietTaiSanDonViController> _logger;

        public ChiTietTaiSanDonViController(HemisContext context, ILogger<ChiTietTaiSanDonViController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: ChiTietTaiSanDonVi
        public async Task<IActionResult> Index()
        {
            var chiTietTaiSanList = await _context.TbChiTietTaiSanDonVis
                .Include(t => t.IdChuSoHuuNavigation)
                .Include(t => t.IdTaiSanDonViNavigation)
                .Include(t => t.IdTinhTrangThietBiNavigation)
                .ToListAsync();
            return View(chiTietTaiSanList);
        }

        // GET: ChiTietTaiSanDonVi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var chiTietTaiSan = await _context.TbChiTietTaiSanDonVis
                .Include(t => t.IdChuSoHuuNavigation)
                .Include(t => t.IdTaiSanDonViNavigation)
                .Include(t => t.IdTinhTrangThietBiNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTietTaiSanDonVi == id);

            if (chiTietTaiSan == null)
                return NotFound();

            return View(chiTietTaiSan);
        }

        // GET: ChiTietTaiSanDonVi/Create
        public IActionResult Create()
        {
            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "ChuSoHuu");
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi");
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "TinhTrangThietBi");
            return View();
        }

        // POST: ChiTietTaiSanDonVi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiTietTaiSanDonVi,IdTaiSanDonVi,MaTaiSan,TenTaiSan,NguyenGia,TinhTrangThietBi,ChuSoHuu")] TbChiTietTaiSanDonVi chiTietTaiSanDonVi)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(chiTietTaiSanDonVi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "Có lỗi xảy ra khi tạo tài sản.");
                    ModelState.AddModelError("Id đã tồn tại", "Có lỗi xảy ra khi lưu dữ liệu. Vui lòng thử lại.");
                }
            }
            PopulateDropdowns(chiTietTaiSanDonVi);
            return View(chiTietTaiSanDonVi);
        }

        // GET: ChiTietTaiSanDonVi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var chiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis.FindAsync(id);
            if (chiTietTaiSanDonVi == null)
                return NotFound();

            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "ChuSoHuu", chiTietTaiSanDonVi?.IdChuSoHuu);
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi", chiTietTaiSanDonVi?.IdTaiSanDonVi);
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "TinhTrangThietBi", chiTietTaiSanDonVi?.IdTinhTrangThietBi);
            return View(chiTietTaiSanDonVi);
        }

        // POST: ChiTietTaiSanDonVi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiTietTaiSanDonVi,IdTaiSanDonVi,MaTaiSan,TenTaiSan,NguyenGia,IdTinhTrangThietBi,IdChuSoHuu")] TbChiTietTaiSanDonVi chiTietTaiSanDonVi)
        {
            if (id != chiTietTaiSanDonVi.IdChiTietTaiSanDonVi)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietTaiSanDonVi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _logger.LogError(ex, "Có lỗi xảy ra khi cập nhật tài sản.");
                    if (!TbChiTietTaiSanDonViExists(chiTietTaiSanDonVi.IdChiTietTaiSanDonVi))
                        return NotFound();

                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật. Vui lòng thử lại.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Có lỗi không xác định xảy ra.");
                    ModelState.AddModelError("", "Có lỗi xảy ra. Vui lòng thử lại.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDropdowns(chiTietTaiSanDonVi);
            return View(chiTietTaiSanDonVi);
        }

        // GET: ChiTietTaiSanDonVi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var chiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis
                .Include(t => t.IdChuSoHuuNavigation)
                .Include(t => t.IdTaiSanDonViNavigation)
                .Include(t => t.IdTinhTrangThietBiNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTietTaiSanDonVi == id);

            if (chiTietTaiSanDonVi == null)
                return NotFound();

            return View(chiTietTaiSanDonVi);
        }

        // POST: ChiTietTaiSanDonVi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var chiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis.FindAsync(id);
                if (chiTietTaiSanDonVi != null)
                {
                    _context.TbChiTietTaiSanDonVis.Remove(chiTietTaiSanDonVi);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi xóa tài sản.");
                ModelState.AddModelError("", "Có lỗi xảy ra khi xóa dữ liệu. Vui lòng thử lại.");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TbChiTietTaiSanDonViExists(int id)
        {
            return _context.TbChiTietTaiSanDonVis.Any(e => e.IdChiTietTaiSanDonVi == id);
        }

        private void PopulateDropdowns(TbChiTietTaiSanDonVi chiTietTaiSanDonVi = null)
        {
            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "ChuSoHuu", chiTietTaiSanDonVi?.IdChuSoHuu);
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi", chiTietTaiSanDonVi?.IdTaiSanDonVi);
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "TinhTrangThietBi", chiTietTaiSanDonVi?.IdTinhTrangThietBi);
        }
    }
}
