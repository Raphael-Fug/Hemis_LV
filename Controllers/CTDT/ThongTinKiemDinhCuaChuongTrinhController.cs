using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CTDT
{
    public class ThongTinKiemDinhCuaChuongTrinhController : Controller
    {
        private readonly HemisContext _context;

        // Constructor: Inject HemisContext để tương tác với cơ sở dữ liệu
        public ThongTinKiemDinhCuaChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh
        public async Task<IActionResult> Index()
        {
            try
            {
                // Tải dữ liệu từ bảng TbThongTinKiemDinhCuaChuongTrinhs và các bảng liên quan
                var hemisContext = _context.TbThongTinKiemDinhCuaChuongTrinhs
                    .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                    .Include(t => t.IdKetQuaKiemDinhNavigation)
                    .Include(t => t.IdToChucKiemDinhNavigation);

                // Trả về view và hiển thị dữ liệu
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                // Kiểm tra nếu id là null
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm thông tin kiểm định theo id và tải các bảng liên quan
                var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs
                    .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                    .Include(t => t.IdKetQuaKiemDinhNavigation)
                    .Include(t => t.IdToChucKiemDinhNavigation)
                    .FirstOrDefaultAsync(m => m.IdThongTinKiemDinhCuaChuongTrinh == id);

                // Kiểm tra nếu không tìm thấy kết quả
                if (tbThongTinKiemDinhCuaChuongTrinh == null)
                {
                    return NotFound();
                }

                // Trả về view với chi tiết của thông tin kiểm định
                return View(tbThongTinKiemDinhCuaChuongTrinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Create
        public IActionResult Create()
        {
            try
            {
                // Tạo danh sách các SelectList cho các trường dropdown
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh");
                ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "KetQuaKiemDinh");
                ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "ToChucKiemDinh");
                return View();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinKiemDinhCuaChuongTrinh,IdChuongTrinhDaoTao,IdToChucKiemDinh,IdKetQuaKiemDinh,SoQuyetDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbThongTinKiemDinhCuaChuongTrinh tbThongTinKiemDinhCuaChuongTrinh)
        {
            try
            {
                // Kiểm tra nếu IdThongTinKiemDinh đã tồn tại
                //if (TbThongTinKiemDinhCuaChuongTrinhExists(tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh))
                //    ModelState.AddModelError("IdThongTinKiemDinhCuaChuongTrinh", "Đã tồn tại Id này!");

                // Nếu dữ liệu hợp lệ, lưu vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    _context.Add(tbThongTinKiemDinhCuaChuongTrinh);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                // Nếu có lỗi, hiển thị lại form với thông báo lỗi
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
                ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "KetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
                ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "ToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
                return View(tbThongTinKiemDinhCuaChuongTrinh);
            }
            catch (DbUpdateException dbEx)
            {
                // Lỗi liên quan đến cơ sở dữ liệu như khóa chính, khóa ngoại
                ModelState.AddModelError("", "Không thể lưu dữ liệu vào cơ sở dữ liệu: " + dbEx.Message);
                return View(tbThongTinKiemDinhCuaChuongTrinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                // Kiểm tra nếu id là null
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm thông tin kiểm định theo id
                var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);
                if (tbThongTinKiemDinhCuaChuongTrinh == null)
                {
                    return NotFound();
                }

                // Tạo SelectList để hiển thị trong form chỉnh sửa
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
                ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "KetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
                ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "ToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
                return View(tbThongTinKiemDinhCuaChuongTrinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinKiemDinhCuaChuongTrinh,IdChuongTrinhDaoTao,IdToChucKiemDinh,IdKetQuaKiemDinh,SoQuyetDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbThongTinKiemDinhCuaChuongTrinh tbThongTinKiemDinhCuaChuongTrinh)
        {
            try
            {
                // Kiểm tra nếu id không khớp
                if (id != tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh)
                {
                    return NotFound();
                }

                // Kiểm tra dữ liệu hợp lệ và cập nhật
                if (ModelState.IsValid)
                {
                    try
                    {
                        // Cập nhật thông tin kiểm định
                        _context.Update(tbThongTinKiemDinhCuaChuongTrinh);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        // Xử lý lỗi nếu dữ liệu đã bị thay đổi từ nguồn khác
                        if (!TbThongTinKiemDinhCuaChuongTrinhExists(tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh))
                        {
                            return NotFound();
                        }
                        else
                        {
                            // Ném lỗi nếu không xử lý được
                            throw;
                        }
                    }
                    // Điều hướng trở về trang Index sau khi cập nhật thành công
                    return RedirectToAction(nameof(Index));
                }

                // Nếu dữ liệu không hợp lệ, hiển thị lại form với thông báo lỗi
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
                ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "KetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
                ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "ToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
                return View(tbThongTinKiemDinhCuaChuongTrinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                // Kiểm tra nếu id là null
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm thông tin kiểm định theo id và tải các bảng liên quan
                var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs
                    .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                    .Include(t => t.IdKetQuaKiemDinhNavigation)
                    .Include(t => t.IdToChucKiemDinhNavigation)
                    .FirstOrDefaultAsync(m => m.IdThongTinKiemDinhCuaChuongTrinh == id);

                // Kiểm tra nếu không tìm thấy kết quả
                if (tbThongTinKiemDinhCuaChuongTrinh == null)
                {
                    return NotFound();
                }

                // Trả về view với chi tiết để xác nhận xóa
                return View(tbThongTinKiemDinhCuaChuongTrinh);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Tìm thông tin kiểm định theo id
                var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);

                // Nếu tìm thấy, xóa bản ghi
                if (tbThongTinKiemDinhCuaChuongTrinh != null)
                {
                    _context.TbThongTinKiemDinhCuaChuongTrinhs.Remove(tbThongTinKiemDinhCuaChuongTrinh);
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                // Điều hướng trở về trang Index sau khi xóa thành công
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();
            }
        }

        // Phương thức kiểm tra sự tồn tại của ThongTinKiemDinh dựa trên id
        private bool TbThongTinKiemDinhCuaChuongTrinhExists(int id)
        {
            // Trả về true nếu IdThongTinKiemDinhCuaChuongTrinh tồn tại, ngược lại false
            return _context.TbThongTinKiemDinhCuaChuongTrinhs.Any(e => e.IdThongTinKiemDinhCuaChuongTrinh == id);
        }
    }
}
