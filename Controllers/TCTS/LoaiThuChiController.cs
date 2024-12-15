using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace C500Hemis.Controllers.TCTS
{
    // Controller để xử lý các thao tác liên quan đến thực thể "LoaiThuChi"
    public class LoaiThuChiController : Controller
    {
        // Context cơ sở dữ liệu để truy cập vào cơ sở dữ liệu
        private readonly HemisContext _context;

        // Constructor để khởi tạo context cơ sở dữ liệu
        public LoaiThuChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: LoaiThuChi
        // Lấy và hiển thị danh sách các mục "LoaiThuChi"
        public async Task<IActionResult> Index()
        {
            try
            {
                // Lấy danh sách "LoaiThuChi" kèm theo dữ liệu liên quan "IdPhanLoaiThuChi"
                var hemisContext = _context.TbLoaiThuChis.Include(t => t.IdPhanLoaiThuChiNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // GET: LoaiThuChi/Details/5
        // Lấy và hiển thị chi tiết của một mục "LoaiThuChi" cụ thể theo ID
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                // Kiểm tra nếu ID được cung cấp là null
                if (id == null)
                {
                    return NotFound(); // Trả về 404 nếu ID không được cung cấp
                }

                // Lấy mục "LoaiThuChi" cụ thể với dữ liệu liên quan
                var tbLoaiThuChi = await _context.TbLoaiThuChis
                    .Include(t => t.IdPhanLoaiThuChiNavigation)
                    .FirstOrDefaultAsync(m => m.IdLoaiThuChi == id);

                // Kiểm tra xem mục có tồn tại không
                if (tbLoaiThuChi == null)
                {
                    return NotFound(); // Trả về 404 nếu mục không tồn tại
                }

                return View(tbLoaiThuChi); // Trả về view chi tiết
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // GET: LoaiThuChi/Create
        // Hiển thị form để tạo một mục "LoaiThuChi" mới
        public IActionResult Create()
        {
            try
            {
                // Điền danh sách dropdown để chọn "IdPhanLoaiThuChi"
                ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "PhanLoaiThuChi");
                return View(); // Trả về view tạo mới
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // POST: LoaiThuChi/Create
        // Xử lý việc gửi form để tạo một mục "LoaiThuChi" mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiThuChi,MaLoaiThuChi,IdPhanLoaiThuChi,TenLoaiThuChi,MoTa")] TbLoaiThuChi tbLoaiThuChi)
        {
            // Xác thực trạng thái mô hình để bảo vệ chống lại các tấn công overposting
            try
            {
                if (ModelState.IsValid) // Kiểm tra xem dữ liệu gửi lên có hợp lệ không
                {
                    _context.Add(tbLoaiThuChi); // Thêm mục mới vào context
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                    return RedirectToAction(nameof(Index)); // Chuyển hướng về trang chỉ mục
                }

                // Điền lại danh sách dropdown trong trường hợp xác thực thất bại
                ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "PhanLoaiThuChi", tbLoaiThuChi.IdPhanLoaiThuChi);
                return View(tbLoaiThuChi); // Trả về view tạo mới với dữ liệu đã nhập
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // GET: LoaiThuChi/Edit/5
        // Hiển thị form để chỉnh sửa một mục "LoaiThuChi" đã tồn tại
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                // Kiểm tra nếu ID được cung cấp là null
                if (id == null)
                {
                    return NotFound(); // Trả về 404 nếu ID không được cung cấp
                }

                // Lấy mục "LoaiThuChi" cụ thể
                var tbLoaiThuChi = await _context.TbLoaiThuChis.FindAsync(id);
                if (tbLoaiThuChi == null)
                {
                    return NotFound(); // Trả về 404 nếu mục không tồn tại
                }

                // Điền danh sách dropdown để chọn "IdPhanLoaiThuChi"
                ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "PhanLoaiThuChi", tbLoaiThuChi.IdPhanLoaiThuChi);
                return View(tbLoaiThuChi); // Trả về view chỉnh sửa
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // POST: LoaiThuChi/Edit/5
        // Xử lý việc gửi form để cập nhật một mục "LoaiThuChi" đã tồn tại
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiThuChi,MaLoaiThuChi,IdPhanLoaiThuChi,TenLoaiThuChi,MoTa")] TbLoaiThuChi tbLoaiThuChi)
        {
            try
            {
                // Kiểm tra nếu ID trong URL không khớp với ID trong mô hình
                if (id != tbLoaiThuChi.IdLoaiThuChi)
                {
                    return NotFound(); // Trả về 404 nếu ID không khớp
                }

                if (ModelState.IsValid) // Kiểm tra xem dữ liệu gửi lên có hợp lệ không
                {
                    try
                    {
                        _context.Update(tbLoaiThuChi); // Cập nhật mục trong context
                        await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        // Xử lý các ngoại lệ liên quan đến đồng thời
                        if (!TbLoaiThuChiExists(tbLoaiThuChi.IdLoaiThuChi))
                        {
                            return NotFound(); // Trả về 404 nếu mục không tồn tại
                        }
                        else
                        {
                            throw; // Ném lại ngoại lệ nếu mục tồn tại
                        }
                    }
                    return RedirectToAction(nameof(Index)); // Chuyển hướng về trang chỉ mục
                }

                // Điền lại danh sách dropdown trong trường hợp xác thực thất bại
                ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "PhanLoaiThuChi", tbLoaiThuChi.IdPhanLoaiThuChi);
                return View(tbLoaiThuChi); // Trả về view chỉnh sửa với dữ liệu đã nhập
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // GET: LoaiThuChi/Delete/5
        // Hiển thị trang xác nhận xóa cho một mục "LoaiThuChi" đã tồn tại
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                // Kiểm tra nếu ID được cung cấp là null
                if (id == null)
                {
                    return NotFound(); // Trả về 404 nếu ID không được cung cấp
                }

                // Lấy mục "LoaiThuChi" cụ thể với dữ liệu liên quan
                var tbLoaiThuChi = await _context.TbLoaiThuChis
                    .Include(t => t.IdPhanLoaiThuChiNavigation)
                    .FirstOrDefaultAsync(m => m.IdLoaiThuChi == id);
                if (tbLoaiThuChi == null)
                {
                    return NotFound(); // Trả về 404 nếu mục không tồn tại
                }

                return View(tbLoaiThuChi); // Trả về view xác nhận xóa
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // POST: LoaiThuChi/Delete/5
        // Xử lý việc gửi form để xóa một mục "LoaiThuChi" đã tồn tại
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Lấy mục "LoaiThuChi" cụ thể
                var tbLoaiThuChi = await _context.TbLoaiThuChis.FindAsync(id);
                if (tbLoaiThuChi != null)
                {
                    _context.TbLoaiThuChis.Remove(tbLoaiThuChi); // Xóa mục khỏi context
                }

                await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction(nameof(Index)); // Chuyển hướng về trang chỉ mục
            }
            catch (Exception ex)
            {
                // Trả về trạng thái bad request nếu có lỗi xảy ra
                return BadRequest();
            }
        }

        // Phương thức trợ giúp để kiểm tra xem một mục "LoaiThuChi" có tồn tại theo ID không
        private bool TbLoaiThuChiExists(int id)
        {
            return _context.TbLoaiThuChis.Any(e => e.IdLoaiThuChi == id); // Trả về true nếu mục tồn tại, ngược lại false
        }
    }
}
