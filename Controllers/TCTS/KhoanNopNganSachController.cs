using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using System.ComponentModel.DataAnnotations;

namespace C500Hemis.Controllers.TCTS
{
    public class KhoanNopNganSachController : Controller
    {
        // Khởi tạo biến ngữ cảnh cơ sở dữ liệu  
        private readonly HemisContext _context;

        // Hàm dựng (constructor) để khởi tạo controller với ngữ cảnh cơ sở dữ liệu
        public KhoanNopNganSachController(HemisContext context)
        {
            _context = context;
        }

        // Phương thức GET: KhoanNopNganSach - Hiển thị danh sách các khoản nộp ngân sách
        public async Task<IActionResult> Index()
        {
            // Trả về view với danh sách các khoản nộp từ cơ sở dữ liệu
            return View(await _context.TbKhoanNopNganSaches.ToListAsync());
        }

        // Phương thức GET: KhoanNopNganSach/Details/5 - Hiển thị chi tiết khoản nộp ngân sách dựa trên ID
        public async Task<IActionResult> Details(int? id)
        {
            // Kiểm tra ID có null hay không
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin khoản nộp dựa trên ID từ cơ sở dữ liệu
            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches
                .FirstOrDefaultAsync(m => m.IdKhoanNopNganSach == id);

            // Nếu không tìm thấy khoản nộp, trả về trang lỗi 404
            if (tbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            // Trả về view với chi tiết của khoản nộp
            return View(tbKhoanNopNganSach);
        }

        // Phương thức GET: KhoanNopNganSach/Create - Hiển thị form tạo mới khoản nộp ngân sách
        public IActionResult Create()
        {
            // Trả về view hiển thị form tạo mới
            return View();
        }

        // Phương thức POST: KhoanNopNganSach/Create - Xử lý việc tạo mới khoản nộp ngân sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoanNopNganSach,MaKhoanNop,TenKhoanNopNganSach,SoTien,NamTaiChinh")] TbKhoanNopNganSach tbKhoanNopNganSach)
        {
            // Kiểm tra nếu dữ liệu hợp lệ
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem MaKhoanNop có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanNopNganSach.MaKhoanNop))
                    {
                        ModelState.AddModelError("MaKhoanNop", "Mã Khoản Nộp không được để trống.");
                    }

                    // Kiểm tra trùng lặp MaKhoanNop trong cơ sở dữ liệu
                    if (await _context.TbKhoanNopNganSaches.AnyAsync(x => x.MaKhoanNop == tbKhoanNopNganSach.MaKhoanNop))
                    {
                        throw new Exception("Mã Khoản Nộp đã tồn tại.");
                    }

                    // Kiểm tra xem TenKhoanNopNganSach có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanNopNganSach.TenKhoanNopNganSach))
                    {
                        ModelState.AddModelError("TenKhoanNopNganSach", "Tên Khoản Nộp Ngân Sách không được để trống.");
                    }

                    // Kiểm tra SoTien phải lớn hơn 0
                    if (tbKhoanNopNganSach.SoTien <= 0)
                    {
                        ModelState.AddModelError("SoTien", "Số Tiền phải lớn hơn 0.");
                    }
                    // Kiểm tra NamTaiChinh là số dương, có 4 chữ số và nhỏ hơn hoặc bằng 2024
                    if (!int.TryParse(tbKhoanNopNganSach.NamTaiChinh, out int namTaiChinh) || namTaiChinh <= 0 || tbKhoanNopNganSach.NamTaiChinh.Length != 4 || namTaiChinh > 2024)
                    {
                        ModelState.AddModelError("NamTaiChinh", "Năm Tài Chính phải là một số dương gồm 4 chữ số và nhỏ hơn hoặc bằng 2024.");
                    }


                    // Kiểm tra trùng lặp TenKhoanNopNganSach
                    var existsTenKhoanNopNganSach = await _context.TbKhoanNopNganSaches
                        .AnyAsync(x => x.TenKhoanNopNganSach == tbKhoanNopNganSach.TenKhoanNopNganSach);
                    if (existsTenKhoanNopNganSach)
                    {
                        ModelState.AddModelError("TenKhoanNopNganSach", "Tên Khoản Nộp Ngân Sách đã tồn tại.");
                    }

                    // Nếu dữ liệu có lỗi thì trả về form để người dùng chỉnh sửa
                    if (!ModelState.IsValid)
                    {
                        return View(tbKhoanNopNganSach);
                    }

                    // Thêm đối tượng vào DbContext
                    _context.Add(tbKhoanNopNganSach);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();

                    // Chuyển hướng về trang danh sách
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu có ngoại lệ và thông báo lỗi
                    ModelState.AddModelError("", "Đã có lỗi xảy ra: " + ex.Message);
                }
            }

            // Trả về view với dữ liệu để hiển thị lại form nếu có lỗi
            return View(tbKhoanNopNganSach);
        }

        // Phương thức GET: KhoanNopNganSach/Edit/5 - Hiển thị form chỉnh sửa khoản nộp ngân sách dựa trên ID
        public async Task<IActionResult> Edit(int? id)
        {
            // Kiểm tra nếu ID null thì trả về lỗi
            if (id == null)
            {
                return NotFound();
            }

            // Lấy dữ liệu khoản nộp dựa trên ID
            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches.FindAsync(id);

            // Kiểm tra nếu không tìm thấy thì trả về lỗi
            if (tbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            // Trả về view với dữ liệu khoản nộp cần chỉnh sửa
            return View(tbKhoanNopNganSach);
        }

        // Phương thức POST: KhoanNopNganSach/Edit/5 - Xử lý chỉnh sửa khoản nộp ngân sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoanNopNganSach,MaKhoanNop,TenKhoanNopNganSach,SoTien,NamTaiChinh")] TbKhoanNopNganSach tbKhoanNopNganSach)
        {
            // Kiểm tra nếu ID không khớp thì trả về lỗi
            if (id != tbKhoanNopNganSach.IdKhoanNopNganSach)
            {
                return NotFound();
            }

            // Kiểm tra nếu dữ liệu hợp lệ
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem MaKhoanNop có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanNopNganSach.MaKhoanNop))
                    {
                        ModelState.AddModelError("MaKhoanNop", "Mã Khoản Nộp không được để trống.");
                    }


                    // Kiểm tra xem TenKhoanNopNganSach có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanNopNganSach.TenKhoanNopNganSach))
                    {
                        ModelState.AddModelError("TenKhoanNopNganSach", "Tên Khoản Nộp Ngân Sách không được để trống.");
                    }

                    // Kiểm tra SoTien phải lớn hơn 0
                    if (tbKhoanNopNganSach.SoTien <= 0)
                    {
                        ModelState.AddModelError("SoTien", "Số Tiền phải lớn hơn 0.");
                    }
                    // Kiểm tra NamTaiChinh là số dương, có 4 chữ số và nhỏ hơn hoặc bằng 2024
                    if (!int.TryParse(tbKhoanNopNganSach.NamTaiChinh, out int namTaiChinh) || namTaiChinh <= 0 || tbKhoanNopNganSach.NamTaiChinh.Length != 4 || namTaiChinh > 2024)
                    {
                        ModelState.AddModelError("NamTaiChinh", "Năm Tài Chính phải là một số dương gồm 4 chữ số và nhỏ hơn hoặc bằng 2024.");
                    }




                    // Nếu có lỗi thì trả về view để người dùng chỉnh sửa
                    if (!ModelState.IsValid)
                    {
                        return View(tbKhoanNopNganSach);
                    }

                    // Cập nhật đối tượng trong DbContext
                    _context.Update(tbKhoanNopNganSach);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();

                    // Chuyển hướng về trang danh sách
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý nếu có xung đột cập nhật trong cơ sở dữ liệu
                    if (!TbKhoanNopNganSachExists(tbKhoanNopNganSach.IdKhoanNopNganSach))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Có sự xung đột trong việc cập nhật dữ liệu.");
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu có ngoại lệ và thông báo lỗi
                    ModelState.AddModelError("", "Một lỗi xảy ra: " + ex.Message);
                }
            }

            // Trả về view với dữ liệu để hiển thị lại form nếu có lỗi
            return View(tbKhoanNopNganSach);
        }

        // Phương thức GET: KhoanNopNganSach/Delete/5 - Hiển thị trang xác nhận xóa khoản nộp ngân sách
        public async Task<IActionResult> Delete(int? id)
        {
            // Kiểm tra nếu ID null thì trả về lỗi
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin khoản nộp dựa trên ID
            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches
                .FirstOrDefaultAsync(m => m.IdKhoanNopNganSach == id);

            // Nếu không tìm thấy thì trả về lỗi
            if (tbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            // Trả về view xác nhận xóa
            return View(tbKhoanNopNganSach);
        }

        // Phương thức POST: KhoanNopNganSach/Delete/5 - Xử lý xóa khoản nộp ngân sách
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Lấy thông tin khoản nộp cần xóa từ cơ sở dữ liệu
            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches.FindAsync(id);

            // Nếu tìm thấy, thực hiện xóa
            if (tbKhoanNopNganSach != null)
            {
                _context.TbKhoanNopNganSaches.Remove(tbKhoanNopNganSach);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Chuyển hướng về trang danh sách
            return RedirectToAction(nameof(Index));
        }

        // Phương thức kiểm tra khoản nộp có tồn tại trong cơ sở dữ liệu hay không dựa trên ID
        private bool TbKhoanNopNganSachExists(int id)
        {
            return _context.TbKhoanNopNganSaches.Any(e => e.IdKhoanNopNganSach == id);
        }
    }
}