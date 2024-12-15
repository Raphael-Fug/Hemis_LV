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
    public class PhuCapController : Controller
    {
        private readonly HemisContext _context;

        public PhuCapController(HemisContext context)
        {
            _context = context;
        }

        // GET: PhuCap
        public async Task<IActionResult> Index(int? Search)
        {

            IQueryable<TbPhuCap> query = _context.TbPhuCaps

                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation);

            if (Search.HasValue)
            {
                query = query.Where(s => s.IdCanBo == Search.Value);
            }

            // Trả về view với danh sách đã lọc
            var result = await query.ToListAsync();
            //Sau khi áp dụng điều kiện lọc (nếu có), đoạn mã này sẽ thực hiện truy vấn và lấy danh sách các bản ghi thỏa mãn điều kiện.
            return View(result);
        }

        // GET: PhuCap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhuCap = await _context.TbPhuCaps
                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation)
                .FirstOrDefaultAsync(m => m.IdPhuCap == id);
            if (tbPhuCap == null)
            {
                return NotFound();
            }

            return View(tbPhuCap);
        }

        // GET: PhuCap/Create
        public IActionResult Create()
        {

            //tạo dropdow
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "BacLuong");
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "MaCanBo");
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "HeSoLuong");
            return View();
        }

        // POST: PhuCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhuCap,IdCanBo,PhuCapThuHutNghe,PhuCapThamNien,PhuCapUuDaiNghe,PhuCapChucVu,PhuCapDocHai,PhuCapKhac,IdBacLuong,PhanTramVuotKhung,IdHeSoLuong,NgayThangNamHuongLuong")] TbPhuCap tbPhuCap)
        {

            // Kiểm tra xem ID đã tồn tại hay chưa
            if (_context.TbPhuCaps.Any(p => p.IdPhuCap == tbPhuCap.IdPhuCap))
            {
                ModelState.AddModelError("IdPhuCap", "ID đã tồn tại. Vui lòng chọn ID khác.");
                ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "BacLuong");
                ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "MaCanBo");
                ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "HeSoLuong");
                return View(tbPhuCap);
            }

            if (ModelState.IsValid)
            {
                _context.Add(tbPhuCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "BacLuong");
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "MaCanBo");
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "HeSoLuong");
            return View(tbPhuCap);
        }
        // GET: PhuCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhuCap = await _context.TbPhuCaps.FindAsync(id);
            if (tbPhuCap == null)
            {
                return NotFound();
            }
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "BacLuong");
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "MaCanBo");
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "HeSoLuong");
            return View(tbPhuCap);
        }

        // POST: PhuCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhuCap,IdCanBo,PhuCapThuHutNghe,PhuCapThamNien,PhuCapUuDaiNghe,PhuCapChucVu,PhuCapDocHai,PhuCapKhac,IdBacLuong,PhanTramVuotKhung,IdHeSoLuong,NgayThangNamHuongLuong")] TbPhuCap tbPhuCap)
        {
            if (id != tbPhuCap.IdPhuCap)
            {
                return NotFound();
            }

            // Kiểm tra xem ID đã tồn tại hay chưa (trừ ID hiện tại)
            if (_context.TbPhuCaps.Any(p => p.IdPhuCap == tbPhuCap.IdPhuCap && p.IdPhuCap != id))
            {
                ModelState.AddModelError("IdPhuCap", "ID đã tồn tại. Vui lòng chọn ID khác.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPhuCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPhuCapExists(tbPhuCap.IdPhuCap))
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

            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "BacLuong");
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "MaCanBo");
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "HeSoLuong");
            return View(tbPhuCap);
        }

        // GET: PhuCap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhuCap = await _context.TbPhuCaps
                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation)
                .FirstOrDefaultAsync(m => m.IdPhuCap == id);
            if (tbPhuCap == null)
            {
                return NotFound();
            }

            return View(tbPhuCap);
        }

        // POST: PhuCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPhuCap = await _context.TbPhuCaps.FindAsync(id);
            if (tbPhuCap != null)
            {
                _context.TbPhuCaps.Remove(tbPhuCap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPhuCapExists(int id)
        {
            return _context.TbPhuCaps.Any(e => e.IdPhuCap == id);
        }
    }
}