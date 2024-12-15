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
    public class KhoanTrichLapQuyController : Controller
    {
        private readonly HemisContext _context;

        public KhoanTrichLapQuyController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoanTrichLapQuy
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoanTrichLapQuies.ToListAsync());
        }

        // GET: KhoanTrichLapQuy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies
                .FirstOrDefaultAsync(m => m.IdKhoanTrichLapQuy == id);
            if (tbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            return View(tbKhoanTrichLapQuy);
        }

        // GET: KhoanTrichLapQuy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoanTrichLapQuy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoanTrichLapQuy,MaKhoanTrichLapQuy,TenKhoanTrichLapQuy,NamTaiChinh,SoTien")] TbKhoanTrichLapQuy tbKhoanTrichLapQuy)
        {
            // Kiểm tra xem ModelState có hợp lệ không
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem MaKhoanTrichLapQuy có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanTrichLapQuy.MaKhoanTrichLapQuy))
                    {
                        ModelState.AddModelError("MaKhoanTrichLapQuy", "Mã Khoản Trích Lập Quỹ không được để trống.");
                    }

                    // Kiểm tra trùng lặp MaKhoanTrichLapQuy trong cơ sở dữ liệu
                    if (await _context.TbKhoanTrichLapQuies.AnyAsync(x => x.MaKhoanTrichLapQuy == tbKhoanTrichLapQuy.MaKhoanTrichLapQuy))
                    {
                        throw new Exception("Mã Khoản Trích Lập Quỹ đã tồn tại.");
                    }

                    // Kiểm tra xem TenKhoanTrichLapQuy có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanTrichLapQuy.TenKhoanTrichLapQuy))
                    {
                        ModelState.AddModelError("TenKhoanTrichLapQuy", "Tên Khoản Trích Lập Quỹ không được để trống.");
                    }

                    // Kiểm tra NamTaiChinh là số dương, có 4 chữ số và nhỏ hơn hoặc bằng 2024
                    if (!int.TryParse(tbKhoanTrichLapQuy.NamTaiChinh, out int namTaiChinh) || namTaiChinh <= 0 || tbKhoanTrichLapQuy.NamTaiChinh.Length != 4 || namTaiChinh > 2024)
                    {
                        ModelState.AddModelError("NamTaiChinh", "Năm Tài Chính phải là một số dương gồm 4 chữ số và nhỏ hơn hoặc bằng 2024.");
                    }

                    // Kiểm tra SoTien phải lớn hơn 0
                    if (tbKhoanTrichLapQuy.SoTien <= 0)
                    {
                        ModelState.AddModelError("SoTien", "Số Tiền phải lớn hơn 0.");
                    }

                    // Kiểm tra trùng lặp TenKhoanTrichLapQuy
                    var existsTenKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies
                        .AnyAsync(x => x.TenKhoanTrichLapQuy == tbKhoanTrichLapQuy.TenKhoanTrichLapQuy);
                    if (existsTenKhoanTrichLapQuy)
                    {
                        ModelState.AddModelError("TenKhoanTrichLapQuy", "Tên Khoản Trích Lập Quỹ đã tồn tại.");
                    }

                    // Nếu dữ liệu có lỗi thì trả về form để người dùng chỉnh sửa
                    if (!ModelState.IsValid)
                    {
                        return View(tbKhoanTrichLapQuy);
                    }

                    // Thêm đối tượng vào DbContext
                    _context.Add(tbKhoanTrichLapQuy);

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
            return View(tbKhoanTrichLapQuy);
        }

        // GET: KhoanTrichLapQuy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies.FindAsync(id);
            if (tbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }
            return View(tbKhoanTrichLapQuy);
        }

        // POST: KhoanTrichLapQuy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoanTrichLapQuy,MaKhoanTrichLapQuy,TenKhoanTrichLapQuy,NamTaiChinh,SoTien")] TbKhoanTrichLapQuy tbKhoanTrichLapQuy)
        {
            if (id != tbKhoanTrichLapQuy.IdKhoanTrichLapQuy)
            {
                return NotFound();
            }

            // Kiểm tra nếu dữ liệu hợp lệ
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem MaKhoanTrichLapQuy có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanTrichLapQuy.MaKhoanTrichLapQuy))
                    {
                        ModelState.AddModelError("MaKhoanTrichLapQuy", "Mã Trích Lập Quỹ không được để trống.");
                    }

                    // Kiểm tra xem TenKhoanTrichLapQuy có null hay không
                    if (string.IsNullOrWhiteSpace(tbKhoanTrichLapQuy.TenKhoanTrichLapQuy))
                    {
                        ModelState.AddModelError("TenKhoanTrichLapQuy", "Tên Khoản Trích Lập Quỹ không được để trống.");
                    }

                    // Kiểm tra NamTaiChinh là số dương, có 4 chữ số và nhỏ hơn hoặc bằng 2024
                    if (!int.TryParse(tbKhoanTrichLapQuy.NamTaiChinh, out int namTaiChinh) || namTaiChinh <= 0 || tbKhoanTrichLapQuy.NamTaiChinh.Length != 4 || namTaiChinh > 2024)
                    {
                        ModelState.AddModelError("NamTaiChinh", "Năm Tài Chính phải là một số dương gồm 4 chữ số và nhỏ hơn hoặc bằng 2024.");
                    }

                    // Kiểm tra SoTien phải lớn hơn 0
                    if (tbKhoanTrichLapQuy.SoTien <= 0)
                    {
                        ModelState.AddModelError("SoTien", "Số Tiền phải lớn hơn 0.");
                    }
                    
                    // Nếu có lỗi thì trả về view để người dùng chỉnh sửa
                    if (!ModelState.IsValid)
                    {
                        return View(tbKhoanTrichLapQuy);
                    }

                    // Cập nhật đối tượng trong DbContext
                    _context.Update(tbKhoanTrichLapQuy);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();

                    // Chuyển hướng về trang danh sách
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý nếu có xung đột cập nhật trong cơ sở dữ liệu
                    if (!TbKhoanTrichLapQuyExists(tbKhoanTrichLapQuy.IdKhoanTrichLapQuy))
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
            return View(tbKhoanTrichLapQuy);
        }

        // GET: KhoanTrichLapQuy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies
                .FirstOrDefaultAsync(m => m.IdKhoanTrichLapQuy == id);
            if (tbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            return View(tbKhoanTrichLapQuy);
        }

        // POST: KhoanTrichLapQuy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies.FindAsync(id);
            if (tbKhoanTrichLapQuy != null)
            {
                _context.TbKhoanTrichLapQuies.Remove(tbKhoanTrichLapQuy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoanTrichLapQuyExists(int id)
        {
            return _context.TbKhoanTrichLapQuies.Any(e => e.IdKhoanTrichLapQuy == id);
        }
    }
}
