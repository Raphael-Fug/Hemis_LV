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
    public class KhoaHocController : Controller
    {
        // Context của cơ sở dữ liệu, dùng để tương tác với các bảng trong DB.
        private readonly HemisContext _context;

        // Constructor nhận context và gán nó vào biến thành viên.
        public KhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoaHoc
        // Phương thức này trả về danh sách tất cả các khóa học (tbKhoaHocs) từ DB.
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoaHocs.ToListAsync());
        }

        // GET: KhoaHoc/Details/5
        // Phương thức này trả về chi tiết của một khóa học theo id.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Nếu id không tồn tại, trả về NotFound.
            }

            // Tìm khóa học trong DB theo id.
            var tbKhoaHoc = await _context.TbKhoaHocs.FirstOrDefaultAsync(m => m.IdKhoaHoc == id);
            if (tbKhoaHoc == null)
            {
                return NotFound(); // Nếu không tìm thấy khóa học, trả về NotFound.
            }

            return View(tbKhoaHoc); // Trả về view chi tiết khóa học.         
        }

        // GET: KhoaHoc/Create
        // Hiển thị form tạo mới khóa học.
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoaHoc/Create
        // Phương thức này nhận dữ liệu từ form để tạo mới khóa học.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoaHoc,TuNam,DenNam")] TbKhoaHoc tbKhoaHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tbKhoaHoc); // Thêm khóa học vào context.
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào DB.
                    return RedirectToAction(nameof(Index)); // Quay lại trang Index sau khi tạo thành công.
                }
                return View(tbKhoaHoc); // Nếu có lỗi, trả về lại form với dữ liệu đã nhập.
            }
            catch (DbUpdateException dbEx)
            {
                // Lỗi liên quan đến cơ sở dữ liệu như khóa chính, khóa ngoại
                ModelState.AddModelError("", "Không thể lưu dữ liệu vào cơ sở dữ liệu: " + dbEx.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                // Lỗi chung chung khác
                return BadRequest();
            }
        }

        // GET: KhoaHoc/Edit/5
        // Hiển thị form chỉnh sửa khóa học.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Nếu id không tồn tại, trả về NotFound.
            }

            // Tìm khóa học theo id.
            var tbKhoaHoc = await _context.TbKhoaHocs.FindAsync(id);
            if (tbKhoaHoc == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về NotFound.
            }
            return View(tbKhoaHoc); // Trả về view chỉnh sửa khóa học.         
        }

        // POST: KhoaHoc/Edit/5
        // Nhận dữ liệu từ form để cập nhật khóa học.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoaHoc,TuNam,DenNam")] TbKhoaHoc tbKhoaHoc)
        {
            if (id != tbKhoaHoc.IdKhoaHoc)
            {
                return NotFound(); // Nếu id không khớp, trả về NotFound.
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoaHoc); // Cập nhật khóa học trong context.
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào DB.
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoaHocExists(tbKhoaHoc.IdKhoaHoc))
                    {
                        return NotFound(); // Nếu khóa học không tồn tại nữa, trả về NotFound.
                    }
                    else
                    {
                        throw; // Nếu có lỗi khác, ném lỗi.
                    }
                }
                return RedirectToAction(nameof(Index)); // Quay lại trang Index sau khi chỉnh sửa thành công.
            }
            return View(tbKhoaHoc); // Nếu có lỗi, trả về lại form chỉnh sửa với dữ liệu đã nhập.
        }

        // GET: KhoaHoc/Delete/5
        // Hiển thị trang xác nhận xóa khóa học.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Nếu id không tồn tại, trả về NotFound.
            }

            // Tìm khóa học theo id.
            var tbKhoaHoc = await _context.TbKhoaHocs.FirstOrDefaultAsync(m => m.IdKhoaHoc == id);
            if (tbKhoaHoc == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về NotFound.
            }

            return View(tbKhoaHoc); // Trả về view xác nhận xóa khóa học.         
        }

        // POST: KhoaHoc/Delete/5
        // Xác nhận và thực hiện xóa khóa học.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoaHoc = await _context.TbKhoaHocs.FindAsync(id);
            if (tbKhoaHoc != null)
            {
                _context.TbKhoaHocs.Remove(tbKhoaHoc); // Xóa khóa học khỏi context.
            }

            await _context.SaveChangesAsync(); // Lưu thay đổi vào DB.
            return RedirectToAction(nameof(Index)); // Quay lại trang Index sau khi xóa thành công.
        }

        // Kiểm tra khóa học có tồn tại hay không dựa vào id.
        private bool TbKhoaHocExists(int id)
        {
            return _context.TbKhoaHocs.Any(e => e.IdKhoaHoc == id);
        }
    }
}
