using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.HTQT
{
    public class TbThongTinHopTacsController : Controller
    {
        private readonly HemisContext _context;

        public TbThongTinHopTacsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbThongTinHopTac
        public async Task<IActionResult> Index(string searchTerm)
        {
            // Lấy danh sách thông tin hợp tác
            IQueryable<TbThongTinHopTac> query = _context.TbThongTinHopTacs
                .Include(t => t.IdToChucHopTacNavigation)
                .Include(t => t.IdHinhThucHopTacNavigation);

            // Nếu có giá trị tìm kiếm, lọc theo các trường thông tin
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r =>
                    r.IdThongTinHopTac.ToString().Contains(searchTerm)); // Tìm theo Id tổ chức hợp tác quốc tế                 
                /*r.TenThoaThuan.Contains(searchTerm) || // Tìm theo Tên thỏa thuận
                r.ThongTinLienHeDoiTac.Contains(searchTerm) || // Tìm theo Thông tin liên hệ đối tác
                r.MucTieu.Contains(searchTerm) || // Tìm theo Mục tiêu
                r.DonViTrienKhai.Contains(searchTerm) || // Tìm theo Đơn vị triển khai
                r.SanPhamChinh.Contains(searchTerm)); // Tìm theo Sản phẩm chính*/
            }

            // Trả về view với danh sách đã lọc
            var result = await query.ToListAsync();
            return View(result);

        }

        // GET: TbThongTinHopTacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHopTac = await _context.TbThongTinHopTacs
                .Include(t => t.IdHinhThucHopTacNavigation)
                .Include(t => t.IdToChucHopTacNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinHopTac == id);
            if (tbThongTinHopTac == null)
            {
                return NotFound();
            }

            return View(tbThongTinHopTac);
        }

        // GET: TbThongTinHopTacs/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucHopTac"] = new SelectList(_context.DmHinhThucHopTacs, "IdHinhThucHopTac", "IdHinhThucHopTac");
            ViewData["IdToChucHopTac"] = new SelectList(_context.TbToChucHopTacQuocTes, "IdToChucHopTacQuocTe", "IdToChucHopTacQuocTe");
            return View();
        }

        // POST: TbThongTinHopTacs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinHopTac,IdToChucHopTac,ThoiGianHopTacTu,ThoiGianHopTacDen,TenThoaThuan,ThongTinLienHeDoiTac,MucTieu,DonViTrienKhai,IdHinhThucHopTac,SanPhamChinh")] TbThongTinHopTac tbThongTinHopTac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra nếu IdThongTinHopTac đã tồn tại trong bảng
                    if (await _context.TbThongTinHopTacs.AnyAsync(t => t.IdThongTinHopTac == tbThongTinHopTac.IdThongTinHopTac))
                    {
                        // Nếu có bản ghi trùng lặp, thêm thông báo lỗi vào ModelState
                        ModelState.AddModelError("IdThongTinHopTac", "Đã trùng ID vui lòng nhập Id khác.");
                    }
                    else
                    {
                        // Kiểm tra nếu IdToChucHopTac đã tồn tại trong bảng TbToChucHopTacQuocTe
                        var existingToChuc = await _context.TbToChucHopTacQuocTes
                                              .FirstOrDefaultAsync(t => t.IdToChucHopTacQuocTe == tbThongTinHopTac.IdToChucHopTac);

                        // Nếu không tồn tại, thêm tổ chức mới vào TbToChucHopTacQuocTe
                        if (existingToChuc == null)
                        {
                            var newToChuc = new TbToChucHopTacQuocTe
                            {
                                IdToChucHopTacQuocTe = (int)tbThongTinHopTac.IdToChucHopTac,
                            };
                            _context.TbToChucHopTacQuocTes.Add(newToChuc);
                            await _context.SaveChangesAsync();
                        }

                        // Sau đó thêm dữ liệu vào bảng TbThongTinHopTac
                        _context.Add(tbThongTinHopTac);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateException ex)
                {
                    // Xử lý ngoại lệ liên quan đến việc cập nhật cơ sở dữ liệu
                    ModelState.AddModelError("", "Không thể thêm bản ghi vào cơ sở dữ liệu. Vui lòng thử lại.");
                    // Log the exception if needed (e.g., using a logging framework)
                }
            }

            // Nếu có lỗi, hiển thị lại form với thông tin lỗi
            ViewData["IdHinhThucHopTac"] = new SelectList(_context.DmHinhThucHopTacs, "IdHinhThucHopTac", "IdHinhThucHopTac", tbThongTinHopTac.IdHinhThucHopTac);
            ViewData["IdToChucHopTac"] = new SelectList(_context.TbToChucHopTacQuocTes, "IdToChucHopTacQuocTe", "IdToChucHopTacQuocTe", tbThongTinHopTac.IdToChucHopTac);
            return View(tbThongTinHopTac);
        }


        // GET: TbThongTinHopTacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHopTac = await _context.TbThongTinHopTacs.FindAsync(id);
            if (tbThongTinHopTac == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucHopTac"] = new SelectList(_context.DmHinhThucHopTacs, "IdHinhThucHopTac", "IdHinhThucHopTac", tbThongTinHopTac.IdHinhThucHopTac);
            ViewData["IdToChucHopTac"] = new SelectList(_context.TbToChucHopTacQuocTes, "IdToChucHopTacQuocTe", "IdToChucHopTacQuocTe", tbThongTinHopTac.IdToChucHopTac);
            return View(tbThongTinHopTac);
        }


        // POST: TbThongTinHopTacs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinHopTac,IdToChucHopTac,ThoiGianHopTacTu,ThoiGianHopTacDen,TenThoaThuan,ThongTinLienHeDoiTac,MucTieu,DonViTrienKhai,IdHinhThucHopTac,SanPhamChinh")] TbThongTinHopTac tbThongTinHopTac)
        {
            if (id != tbThongTinHopTac.IdThongTinHopTac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinHopTac);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinHopTacExists(tbThongTinHopTac.IdThongTinHopTac))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // If there's a validation error, return to Edit view instead of Create view
            ViewData["IdHinhThucHopTac"] = new SelectList(_context.DmHinhThucHopTacs, "IdHinhThucHopTac", "IdHinhThucHopTac", tbThongTinHopTac.IdHinhThucHopTac);
            ViewData["IdToChucHopTac"] = new SelectList(_context.TbToChucHopTacQuocTes, "IdToChucHopTacQuocTe", "IdToChucHopTacQuocTe", tbThongTinHopTac.IdToChucHopTac);
            return View(tbThongTinHopTac);
        }

        // GET: TbThongTinHopTacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHopTac = await _context.TbThongTinHopTacs
                .Include(t => t.IdHinhThucHopTacNavigation)
                .Include(t => t.IdToChucHopTacNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinHopTac == id);
            if (tbThongTinHopTac == null)
            {
                return NotFound();
            }

            return View(tbThongTinHopTac);
        }

        // POST: TbThongTinHopTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinHopTac = await _context.TbThongTinHopTacs.FindAsync(id);
            if (tbThongTinHopTac != null)
            {
                _context.TbThongTinHopTacs.Remove(tbThongTinHopTac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinHopTacExists(int id)
        {
            return _context.TbThongTinHopTacs.Any(e => e.IdThongTinHopTac == id);
        }
    }
}