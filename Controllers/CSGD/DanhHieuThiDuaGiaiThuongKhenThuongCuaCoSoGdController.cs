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
    public class DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdController : Controller
    {
        private readonly HemisContext _context;

        public DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdController(HemisContext context)
        {
            _context = context;
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.Include(t => t.IdCapKhenThuongNavigation).Include(t => t.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdNavigation).Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation).Include(t => t.IdPhuongThucKhenThuongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds
                .Include(t => t.IdCapKhenThuongNavigation)
                .Include(t => t.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdNavigation)
                .Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdPhuongThucKhenThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == null)
            {
                return NotFound();
            }

            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Create
        public IActionResult Create()
        {
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong");
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong");
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong");
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong");
            return View();
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Create/-strong/-heart:>:o:-((:-h // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdDanhHieuThiDuaGiaiThuongKhenThuong,SoQuyetDinhKhenThuong,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Thêm đối tượng vào context
                    _context.Add(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);

                    // Lưu thay đổi
                    await _context.SaveChangesAsync();

                    // Chuyển hướng về trang Index sau khi lưu thành công
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu xảy ra khi lưu dữ liệu
                    Console.WriteLine(ex.Message);  // Bạn có thể log lỗi ra file log hoặc hiển thị ra giao diện
                    ModelState.AddModelError("", "Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng thử lại.");
                }
            }
            else
            {
                // In ra lỗi của ModelState nếu không hợp lệ
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            // Tạo lại các SelectList cho View trong trường hợp dữ liệu không hợp lệ
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdCapKhenThuong);
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdPhuongThucKhenThuong);
            // Quay lại view Create với dữ liệu hiện tại
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
        }
        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.FindAsync(id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == null)
            {
                return NotFound();
            }
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdCapKhenThuong);
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdPhuongThucKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdDanhHieuThiDuaGiaiThuongKhenThuong,SoQuyetDinhKhenThuong,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
        {
            if (id != tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdExists(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd))
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
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdCapKhenThuong);
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdPhuongThucKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
        }
        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds
                .Include(t => t.IdCapKhenThuongNavigation)
                .Include(t => t.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdNavigation)
                .Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdPhuongThucKhenThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == null)
            {
                return NotFound();
            }

            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.FindAsync(id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd != null)
            {
                _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.Remove(tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdExists(int id)
        {
            return _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == id);
        }
    }
}