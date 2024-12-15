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
    // Controller quản lý quá trình công tác của cán bộ
    public class QuaTrinhCongTacCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        // Constructor nhận vào HemisContext để tương tác với cơ sở dữ liệu
        public QuaTrinhCongTacCuaCanBoController(HemisContext context)
        {
            _context = context;
        }
        #region Index và chức năng tìm kiếm
        // GET: QuaTrinhCongTacCuaCanBo
        // Phương thức hiển thị danh sách quá trình công tác, có thể tìm kiếm theo IdCanBo
        public async Task<IActionResult> Index(int? Search)
        {
            // Lấy danh sách tất cả quá trình công tác
            var name = from s in _context.TbQuaTrinhCongTacCuaCanBos select s;

            // Nếu có giá trị tìm kiếm, lọc theo IdCanBo
            if (Search.HasValue)
            {
                name = name.Where(s => s.IdCanBo == Search.Value);
            }

            // Trả về view với danh sách đã lọc
            return View(await name.ToListAsync());
        }
        #endregion

        #region Hiển thị chi tiết
        // GET: QuaTrinhCongTacCuaCanBo/Details/5
        // Phương thức hiển thị chi tiết một quá trình công tác
        public async Task<IActionResult> Details(int? id)
        {
            // Kiểm tra nếu id là null
            if (id == null)
            {
                return NotFound();
            }

            // Tìm quá trình công tác theo id
            var tbQuaTrinhCongTacCuaCanBo = await _context.TbQuaTrinhCongTacCuaCanBos
                .Include(t => t.IdCanBoNavigation) // Bao gồm thông tin cán bộ
                .Include(t => t.IdChucDanhGiangVienNavigation) // Bao gồm thông tin chức danh giảng viên
                .Include(t => t.IdChucVuNavigation) // Bao gồm thông tin chức vụ
                .FirstOrDefaultAsync(m => m.IdQuaTrinhCongTacCuaCanBo == id);

            // Kiểm tra nếu không tìm thấy
            if (tbQuaTrinhCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            // Trả về view với thông tin chi tiết
            return View(tbQuaTrinhCongTacCuaCanBo);
        }
        #endregion

        #region tạo form 
        // GET: QuaTrinhCongTacCuaCanBo/Create
        // Phương thức hiển thị form tạo mới quá trình công tác
        public IActionResult Create()
        {
            // Tạo danh sách lựa chọn cho IdCanBo, IdChucDanhGiangVien, IdChucVu
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien");
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu");
            return View();
        }

        // POST: QuaTrinhCongTacCuaCanBo/Create
        // Phương thức xử lý việc tạo mới quá trình công tác
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuaTrinhCongTacCuaCanBo,IdCanBo,TuThangNam,DenThangNam,IdChucVu,IdChucDanhGiangVien,DonViCongTac")] TbQuaTrinhCongTacCuaCanBo tbQuaTrinhCongTacCuaCanBo)
        {
            // Kiểm tra tính hợp lệ của model
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tbQuaTrinhCongTacCuaCanBo); // Thêm mới vào context
                    await _context.SaveChangesAsync(); // Lưu thay đổi
                    return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
                }
                catch (Exception ex)
                {
                    //ViewBag.ErrorMessage = ex.Message;
                    ViewBag.ErrorMessage = ex.Message + " Đây là lỗi người làm ra chưa tìm ra cách fix thông cảm";
                }
                //finally
                //{
                //    ViewBag.mess = "Vui lòng nhập lại";
                //}
            }

            // Nếu không hợp lệ, tạo lại danh sách lựa chọn
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbQuaTrinhCongTacCuaCanBo.IdCanBo);
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien", tbQuaTrinhCongTacCuaCanBo.IdChucDanhGiangVien);
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbQuaTrinhCongTacCuaCanBo.IdChucVu);
            return View(tbQuaTrinhCongTacCuaCanBo); // Trả về view với thông tin đã nhập
        }
        #endregion

        #region Edit
        // GET: QuaTrinhCongTacCuaCanBo/Edit/5
        // Phương thức hiển thị form chỉnh sửa quá trình công tác
        public async Task<IActionResult> Edit(int? id)
        {
            // Kiểm tra nếu id là null
            if (id == null)
            {
                return NotFound();
            }

            // Tìm quá trình công tác theo id
            var tbQuaTrinhCongTacCuaCanBo = await _context.TbQuaTrinhCongTacCuaCanBos.FindAsync(id);
            if (tbQuaTrinhCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            // Tạo danh sách lựa chọn cho IdCanBo, IdChucDanhGiangVien, IdChucVu
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbQuaTrinhCongTacCuaCanBo.IdCanBo);
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien", tbQuaTrinhCongTacCuaCanBo.IdChucDanhGiangVien);
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbQuaTrinhCongTacCuaCanBo.IdChucVu);
            return View(tbQuaTrinhCongTacCuaCanBo); // Trả về view với thông tin để chỉnh sửa
        }

        // POST: QuaTrinhCongTacCuaCanBo/Edit/5
        // Phương thức xử lý việc chỉnh sửa quá trình công tác
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuaTrinhCongTacCuaCanBo,IdCanBo,TuThangNam,DenThangNam,IdChucVu,IdChucDanhGiangVien,DonViCongTac")] TbQuaTrinhCongTacCuaCanBo tbQuaTrinhCongTacCuaCanBo)
        {
            // Kiểm tra nếu id không khớp với thông tin đã chỉnh sửa
            if (id != tbQuaTrinhCongTacCuaCanBo.IdQuaTrinhCongTacCuaCanBo)
            {
                return NotFound();
            }

            // Kiểm tra tính hợp lệ của model
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbQuaTrinhCongTacCuaCanBo); // Cập nhật thông tin
                    await _context.SaveChangesAsync(); // Lưu thay đổi
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Kiểm tra nếu quá trình công tác không tồn tại
                    if (!TbQuaTrinhCongTacCuaCanBoExists(tbQuaTrinhCongTacCuaCanBo.IdQuaTrinhCongTacCuaCanBo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Ném lỗi nếu có ngoại lệ
                    }
                }
                return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
            }
            // Nếu không hợp lệ, tạo lại danh sách lựa chọn
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbQuaTrinhCongTacCuaCanBo.IdCanBo);
            ViewData["IdChucDanhGiangVien"] = new SelectList(_context.DmChucDanhGiangViens, "IdChucDanhGiangVien", "IdChucDanhGiangVien", tbQuaTrinhCongTacCuaCanBo.IdChucDanhGiangVien);
            ViewData["IdChucVu"] = new SelectList(_context.DmChucVus, "IdChucVu", "IdChucVu", tbQuaTrinhCongTacCuaCanBo.IdChucVu);
            return View(tbQuaTrinhCongTacCuaCanBo); // Trả về view với thông tin đã chỉnh sửa
        }
        #endregion

        #region xoá
        // GET: QuaTrinhCongTacCuaCanBo/Delete/5
        // Phương thức hiển thị form xác nhận xóa quá trình công tác
        public async Task<IActionResult> Delete(int? id)
        {
            // Kiểm tra nếu id là null
            if (id == null)
            {
                return NotFound();
            }

            // Tìm quá trình công tác theo id
            var tbQuaTrinhCongTacCuaCanBo = await _context.TbQuaTrinhCongTacCuaCanBos
                .Include(t => t.IdCanBoNavigation) // Bao gồm thông tin cán bộ
                .Include(t => t.IdChucDanhGiangVienNavigation) // Bao gồm thông tin chức danh giảng viên
                .Include(t => t.IdChucVuNavigation) // Bao gồm thông tin chức vụ
                .FirstOrDefaultAsync(m => m.IdQuaTrinhCongTacCuaCanBo == id);
            if (tbQuaTrinhCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            // Trả về view với thông tin để xác nhận xóa
            return View(tbQuaTrinhCongTacCuaCanBo);
        }

        // POST: QuaTrinhCongTacCuaCanBo/Delete/5
        // Phương thức xử lý việc xóa quá trình công tác
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Tìm quá trình công tác theo id
            var tbQuaTrinhCongTacCuaCanBo = await _context.TbQuaTrinhCongTacCuaCanBos.FindAsync(id);
            if (tbQuaTrinhCongTacCuaCanBo != null)
            {
                _context.TbQuaTrinhCongTacCuaCanBos.Remove(tbQuaTrinhCongTacCuaCanBo); // Xóa quá trình công tác
            }

            await _context.SaveChangesAsync(); // Lưu thay đổi
            return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
        }
        #endregion
        // Phương thức kiểm tra xem quá trình công tác có tồn tại hay không
        private bool TbQuaTrinhCongTacCuaCanBoExists(int id)
        {
            return _context.TbQuaTrinhCongTacCuaCanBos.Any(e => e.IdQuaTrinhCongTacCuaCanBo == id);
        }
    }
}
