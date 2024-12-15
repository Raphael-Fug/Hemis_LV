using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TCTS
{
    public class HoatDongTaiChinhController : Controller
    {
        private readonly HemisContext _context;

        // Constructor để khởi tạo context
        public HoatDongTaiChinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: HoatDongTaiChinh
        // Hiển thị danh sách tất cả các hoạt động tài chính
        public async Task<IActionResult> Index()
        {
            try
            {
                // Lấy danh sách hoạt động tài chính và bao gồm loại hoạt động
                var hemisContext = _context.TbHoatDongTaiChinhs.Include(t => t.IdLoaiHoatDongTaiChinhNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // GET: HoatDongTaiChinh/Details/5
        // Hiển thị chi tiết cho một hoạt động tài chính cụ thể
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound(); // Nếu id null, trả về 404
                }

                // Tìm hoạt động tài chính theo id
                var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs
                    .Include(t => t.IdLoaiHoatDongTaiChinhNavigation)
                    .FirstOrDefaultAsync(m => m.IdHoatDongTaiChinh == id);

                if (tbHoatDongTaiChinh == null)
                {
                    return NotFound(); // Nếu không tìm thấy, trả về 404
                }

                return View(tbHoatDongTaiChinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // GET: HoatDongTaiChinh/Create
        // Hiển thị trang tạo mới hoạt động tài chính
        public IActionResult Create()
        {
            try
            {
                // Tạo danh sách các loại hoạt động tài chính cho dropdown
                ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "HoatDongTaiChinh");
                return View();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // POST: HoatDongTaiChinh/Create
        // Xử lý dữ liệu khi tạo mới hoạt động tài chính
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoatDongTaiChinh,IdLoaiHoatDongTaiChinh,NamTaiChinh,KinhPhi,NoiDung")] TbHoatDongTaiChinh tbHoatDongTaiChinh)
        {
            try
            {
                // Kiểm tra tính hợp lệ của model
                if (ModelState.IsValid)
                {
                    _context.Add(tbHoatDongTaiChinh); // Thêm vào context
                    await _context.SaveChangesAsync(); // Lưu thay đổi
                    return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
                }
                // Nếu không hợp lệ, tạo lại danh sách dropdown
                ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "HoatDongTaiChinh", tbHoatDongTaiChinh.IdLoaiHoatDongTaiChinh);
                return View(tbHoatDongTaiChinh); // Trả về view với model không hợp lệ
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // GET: HoatDongTaiChinh/Edit/5
        // Hiển thị trang chỉnh sửa hoạt động tài chính
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound(); // Nếu id null, trả về 404
                }

                // Tìm hoạt động tài chính để chỉnh sửa
                var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs.FindAsync(id);
                if (tbHoatDongTaiChinh == null)
                {
                    return NotFound(); // Nếu không tìm thấy, trả về 404
                }
                // Tạo danh sách loại hoạt động tài chính cho dropdown
                ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "HoatDongTaiChinh", tbHoatDongTaiChinh.IdLoaiHoatDongTaiChinh);
                return View(tbHoatDongTaiChinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // POST: HoatDongTaiChinh/Edit/5
        // Xử lý dữ liệu khi chỉnh sửa hoạt động tài chính
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoatDongTaiChinh,IdLoaiHoatDongTaiChinh,NamTaiChinh,KinhPhi,NoiDung")] TbHoatDongTaiChinh tbHoatDongTaiChinh)
        {
            try
            {
                if (id != tbHoatDongTaiChinh.IdHoatDongTaiChinh)
                {
                    return NotFound(); // Nếu id không khớp, trả về 404
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbHoatDongTaiChinh); // Cập nhật thông tin
                        await _context.SaveChangesAsync(); // Lưu thay đổi
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        // Xử lý trường hợp đồng thời cập nhật
                        if (!TbHoatDongTaiChinhExists(tbHoatDongTaiChinh.IdHoatDongTaiChinh))
                        {
                            return NotFound(); // Nếu không tìm thấy, trả về 404
                        }
                        else
                        {
                            throw; // Ném lại lỗi khác
                        }
                    }
                    return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
                }
                // Nếu không hợp lệ, tạo lại danh sách dropdown
                ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "HoatDongTaiChinh", tbHoatDongTaiChinh.IdLoaiHoatDongTaiChinh);
                return View(tbHoatDongTaiChinh); // Trả về view với model không hợp lệ
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // GET: HoatDongTaiChinh/Delete/5
        // Hiển thị trang xác nhận xóa hoạt động tài chính
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound(); // Nếu id null, trả về 404
                }

                // Tìm hoạt động tài chính để xác nhận xóa
                var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs
                    .Include(t => t.IdLoaiHoatDongTaiChinhNavigation)
                    .FirstOrDefaultAsync(m => m.IdHoatDongTaiChinh == id);

                if (tbHoatDongTaiChinh == null)
                {
                    return NotFound(); // Nếu không tìm thấy, trả về 404
                }

                return View(tbHoatDongTaiChinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // POST: HoatDongTaiChinh/Delete/5
        // Xử lý dữ liệu khi xác nhận xóa hoạt động tài chính
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Tìm hoạt động tài chính để xóa
                var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs.FindAsync(id);
                if (tbHoatDongTaiChinh != null)
                {
                    _context.TbHoatDongTaiChinhs.Remove(tbHoatDongTaiChinh); // Xóa hoạt động tài chính
                }

                await _context.SaveChangesAsync(); // Lưu thay đổi
                return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: Trả về BadRequest nếu có lỗi
                return BadRequest();
            }
        }

        // Kiểm tra xem hoạt động tài chính có tồn tại hay không
        private bool TbHoatDongTaiChinhExists(int id)
        {
            return _context.TbHoatDongTaiChinhs.Any(e => e.IdHoatDongTaiChinh == id);
        }
    }
}

