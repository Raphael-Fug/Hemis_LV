using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.HTQT
{
    public class TbThanhPhanThamGiaDoanCongTacsController : Controller
    {
        private readonly HemisContext _context;

        public TbThanhPhanThamGiaDoanCongTacsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThanhPhanThamGiaDoanCongTacs.Include(t => t.IdCanBoNavigation).ThenInclude(h => h.IdNguoiNavigation).Include(t => t.IdDoanCongTacNavigation).Include(t => t.IdVaiTroThamGiaNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdDoanCongTacNavigation)
                .Include(t => t.IdVaiTroThamGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdThanhPhanThamGiaDoanCongTac == id);
            if (tbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }

            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name");
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "TenDoanCongTac");
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "VaiTroThamGia");
            return View();
        }

        // POST: TbThanhPhanThamGiaDoanCongTacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThanhPhanThamGiaDoanCongTac,IdDoanCongTac,IdCanBo,IdVaiTroThamGia")] TbThanhPhanThamGiaDoanCongTac tbThanhPhanThamGiaDoanCongTac)
        {
            try
            {
                // Kiểm tra xem ID thành phần tham gia có bị trùng không
                if (TbThanhPhanThamGiaDoanCongTacExists(tbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac))
                {
                    ModelState.AddModelError("IdThanhPhanThamGiaDoanCongTac", "ID vừa nhập đã tồn tại, vui lòng nhập một ID khác.");
                }

                // Kiểm tra ID cán bộ có null không
                if (tbThanhPhanThamGiaDoanCongTac.IdCanBo == 0)
                {
                    ModelState.AddModelError("IdCanBo", "Mã cán bộ không được để trống.");
                }

                // Kiểm tra ID đoàn công tác có null không
                if (tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac == 0)
                {
                    ModelState.AddModelError("IdDoanCongTac", "Mã đoàn công tác không được để trống.");
                }

                // Kiểm tra ID vai trò tham gia có null không
                if (tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia == 0)
                {
                    ModelState.AddModelError("IdVaiTroThamGia", "Vai trò tham gia không được để trống.");
                }
                if (ModelState.IsValid)
                {
                    _context.Add(tbThanhPhanThamGiaDoanCongTac);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbThanhPhanThamGiaDoanCongTac.IdCanBo);
                ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "TenDoanCongTac", tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac);
                ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "VaiTroThamGia", tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia);
                return View(tbThanhPhanThamGiaDoanCongTac);
            }
            catch (Exception loi)
            {
                return BadRequest();
            }
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs.FindAsync(id);
            if (tbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbThanhPhanThamGiaDoanCongTac.IdCanBo);
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "TenDoanCongTac", tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac);
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "VaiTroThamGia", tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia);
            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // POST: TbThanhPhanThamGiaDoanCongTacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThanhPhanThamGiaDoanCongTac,IdDoanCongTac,IdCanBo,IdVaiTroThamGia")] TbThanhPhanThamGiaDoanCongTac tbThanhPhanThamGiaDoanCongTac)
        {
            if (id != tbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThanhPhanThamGiaDoanCongTac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThanhPhanThamGiaDoanCongTacExists(tbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbThanhPhanThamGiaDoanCongTac.IdCanBo);
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "TenDoanCongTac", tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac);
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "VaiTroThamGia", tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia);
            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdDoanCongTacNavigation)
                .Include(t => t.IdVaiTroThamGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdThanhPhanThamGiaDoanCongTac == id);
            if (tbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }

            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // POST: TbThanhPhanThamGiaDoanCongTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs.FindAsync(id);
            if (tbThanhPhanThamGiaDoanCongTac != null)
            {
                _context.TbThanhPhanThamGiaDoanCongTacs.Remove(tbThanhPhanThamGiaDoanCongTac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThanhPhanThamGiaDoanCongTacExists(int id)
        {
            return _context.TbThanhPhanThamGiaDoanCongTacs.Any(e => e.IdThanhPhanThamGiaDoanCongTac == id);
        }
    }
}
