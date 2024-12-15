using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.KHCN
{
    public class HoatDongBaoVeMoiTruongController : Controller
    {
        private readonly HemisContext _context;


        public HoatDongBaoVeMoiTruongController(HemisContext context)
        {
            _context = context;
        }

        // Toàn bộ action mặc định không xuất lổi chỉ trả về BadRequest
        // GET: HoatDongBaoVeMoiTruong

        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbHoatDongBaoVeMoiTruongs
                    .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                    .Include(t => t.IdCoQuanChuQuanNavigation)
                    .Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation)
                    .Include(t => t.IdNguonKinhPhiNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation)
                    .Include(t => t.IdTinhTrangNhiemVuNavigation);
                var records = hemisContext.ToList(); // Lấy danh sách bản ghi
                ViewBag.RecordCount = records.Count; // Đếm số bản ghi trong phần try của index
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //chức năng tìm kiếm
        [HttpGet("index-search")]
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                // Lấy toàn bộ dữ liệu từ bảng
                var query = _context.TbHoatDongBaoVeMoiTruongs
                    .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                    .Include(t => t.IdCoQuanChuQuanNavigation)
                    .Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation)
                    .Include(t => t.IdNguonKinhPhiNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation)
                    .Include(t => t.IdTinhTrangNhiemVuNavigation)
                    .AsQueryable(); // Chuyển đổi thành IQueryable để có thể lọc dữ liệu

                // Nếu có tham số tìm kiếm, lọc dữ liệu theo từ khóa
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(t => t.TenNhiemVuBvmt.Contains(searchString) ||
                                             t.CoQuanChuTri.Contains(searchString) ||
                                             t.TongKinhPhiCuaNhiemVu.ToString().Contains(searchString));
                }

                ViewData["CurrentFilter"] = searchString; // Truyền lại từ khóa tìm kiếm cho View
                return View(await query.ToListAsync()); // Trả về kết quả sau khi lọc
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // GET: HoatDongBaoVeMoiTruong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs
                    .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                    .Include(t => t.IdCoQuanChuQuanNavigation)
                    .Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation)
                    .Include(t => t.IdNguonKinhPhiNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation)
                    .Include(t => t.IdTinhTrangNhiemVuNavigation)
                    .FirstOrDefaultAsync(m => m.IdHoatDongBaoVeMoiTruong == id);
                if (tbHoatDongBaoVeMoiTruong == null)
                {
                    return NotFound();
                }

                return View(tbHoatDongBaoVeMoiTruong);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: HoatDongBaoVeMoiTruong/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "PhanCapNhiemVu");
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "CoQuanChuQuan");
                ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "LoaiNhiemVuBaoVeMoiTruong");
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi");
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "MaNhiemVu");
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "TinhTrangNhiemVu");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: HoatDongBaoVeMoiTruong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoatDongBaoVeMoiTruong,IdNhiemVuKhcn,TenNhiemVuBvmt,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,IdLoaiNhiemVuBaoVeMoiTruong,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,DonViThucHienLuuTruSanPham,IdTinhTrangNhiemVu")] TbHoatDongBaoVeMoiTruong tbHoatDongBaoVeMoiTruong)
        {
            try
            {
                // Kiểm tra nếu ThoiGianBatDau >= ThoiGianKetThuc thì thêm lỗi vào ModelState
                if (tbHoatDongBaoVeMoiTruong.ThoiGianBatDau >= tbHoatDongBaoVeMoiTruong.ThoiGianKetThuc)
                {
                    ModelState.AddModelError("ThoiGianKetThuc", "Thời gian bắt đầu phải trước thời gian kết thúc.");
                }
                //Nếu đã tồn tại thì thêm Error cho IdHoatDongBaoVeMoiTruong
                if (await existId(tbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong)) ModelState.AddModelError("IdHoatDongBaoVeMoiTruong", "Đã tồn tại Id này!");
                if (ModelState.IsValid)
                {
                    //Thêm đối tượng vào context
                    _context.Add(tbHoatDongBaoVeMoiTruong);
                    // Lưu vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();
                    // Nếu thành công sẽ trở về trang index
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbHoatDongBaoVeMoiTruong.IdCapQuanLyNhiemVu);
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbHoatDongBaoVeMoiTruong.IdCoQuanChuQuan);
                ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong", tbHoatDongBaoVeMoiTruong.IdLoaiNhiemVuBaoVeMoiTruong);
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoatDongBaoVeMoiTruong.IdNguonKinhPhi);
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbHoatDongBaoVeMoiTruong.IdNhiemVuKhcn);
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbHoatDongBaoVeMoiTruong.IdTinhTrangNhiemVu);
                return View(tbHoatDongBaoVeMoiTruong);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: HoatDongBaoVeMoiTruong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs.FindAsync(id);
                if (tbHoatDongBaoVeMoiTruong == null)
                {
                    return NotFound();
                }
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbHoatDongBaoVeMoiTruong.IdCapQuanLyNhiemVu);
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbHoatDongBaoVeMoiTruong.IdCoQuanChuQuan);
                ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong", tbHoatDongBaoVeMoiTruong.IdLoaiNhiemVuBaoVeMoiTruong);
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoatDongBaoVeMoiTruong.IdNguonKinhPhi);
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbHoatDongBaoVeMoiTruong.IdNhiemVuKhcn);
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbHoatDongBaoVeMoiTruong.IdTinhTrangNhiemVu);
                return View(tbHoatDongBaoVeMoiTruong);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: HoatDongBaoVeMoiTruong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoatDongBaoVeMoiTruong,IdNhiemVuKhcn,TenNhiemVuBvmt,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,IdLoaiNhiemVuBaoVeMoiTruong,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,DonViThucHienLuuTruSanPham,IdTinhTrangNhiemVu")] TbHoatDongBaoVeMoiTruong tbHoatDongBaoVeMoiTruong)
        {
            try
            {
                if (id != tbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong)
                {
                    return NotFound();
                }

                // Kiểm tra nếu ThoiGianBatDau >= ThoiGianKetThuc thì thêm lỗi vào ModelState
                if (tbHoatDongBaoVeMoiTruong.ThoiGianBatDau >= tbHoatDongBaoVeMoiTruong.ThoiGianKetThuc)
                {
                    ModelState.AddModelError("ThoiGianKetThuc", "Thời gian bắt đầu phải trước thời gian kết thúc.");
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbHoatDongBaoVeMoiTruong);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!(await existId(tbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong)))
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
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbHoatDongBaoVeMoiTruong.IdCapQuanLyNhiemVu);
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbHoatDongBaoVeMoiTruong.IdCoQuanChuQuan);
                ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong", tbHoatDongBaoVeMoiTruong.IdLoaiNhiemVuBaoVeMoiTruong);
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoatDongBaoVeMoiTruong.IdNguonKinhPhi);
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbHoatDongBaoVeMoiTruong.IdNhiemVuKhcn);
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbHoatDongBaoVeMoiTruong.IdTinhTrangNhiemVu);
                return View(tbHoatDongBaoVeMoiTruong);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: HoatDongBaoVeMoiTruong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs
                    .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                    .Include(t => t.IdCoQuanChuQuanNavigation)
                    .Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation)
                    .Include(t => t.IdNguonKinhPhiNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation)
                    .Include(t => t.IdTinhTrangNhiemVuNavigation)
                    .FirstOrDefaultAsync(m => m.IdHoatDongBaoVeMoiTruong == id);
                if (tbHoatDongBaoVeMoiTruong == null)
                {
                    return NotFound();
                }

                return View(tbHoatDongBaoVeMoiTruong);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: HoatDongBaoVeMoiTruong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs.FindAsync(id);
                if (tbHoatDongBaoVeMoiTruong != null)
                {
                    _context.TbHoatDongBaoVeMoiTruongs.Remove(tbHoatDongBaoVeMoiTruong);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private async Task<bool> existId(int id)
        {
            //Kiểm tra đã tồn tại trong TbHoatDongBaoVeMoiTruong chua
            TbHoatDongBaoVeMoiTruong? cr = (await _context.TbHoatDongBaoVeMoiTruongs.SingleOrDefaultAsync(e => e.IdHoatDongBaoVeMoiTruong == id));
            if (cr == null) return false;
            return true;
        }

    }
}
