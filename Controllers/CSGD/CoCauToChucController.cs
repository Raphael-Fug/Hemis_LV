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
    public class CoCauToChucController : Controller
    {
        private readonly HemisContext _context;

        public CoCauToChucController(HemisContext context)
        {
            _context = context;
        }

        //CoCauToChuc
        // Trang hiển thị danh sách cơ cấu tổ chức
        public async Task<IActionResult> Index()
        {
            // Lấy dữ liệu từ cơ sở dữ liệu, bao gồm thông tin loại phòng ban và trạng thái
            var hemisContext = _context.TbCoCauToChucs.Include(t => t.IdLoaiPhongBanNavigation).Include(t => t.IdTrangThaiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        //  CoCauToChuc/Details/5
        // Trang hiển thị chi tiết của một cơ cấu tổ chức
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Tìm cơ cấu tổ chức dựa trên id và bao gồm thông tin loại phòng ban và trạng thái
            var tbCoCauToChuc = await _context.TbCoCauToChucs
                .Include(t => t.IdLoaiPhongBanNavigation)
                .Include(t => t.IdTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.IdCoCauToChuc == id);
            if (tbCoCauToChuc == null)
            {
                return NotFound();
            }

            return View(tbCoCauToChuc);
        }

        // GET: CoCauToChuc/Create
        // Trang tạo mới cơ cấu tổ chức
        public IActionResult Create()
        {
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "LoaiPhongBan");
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "TrangThaiCoSoGd");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCoCauToChuc,MaPhongBanDonVi,IdLoaiPhongBan,MaPhongBanDonViCha,TenPhongBanDonVi,SoQuyetDinhThanhLap,NgayRaQuyetDinh,IdTrangThai")] TbCoCauToChuc tbCoCauToChuc)
        {
            try
            {
                // kiểm tra nếu IdCoCauToChuc có tồn tại
                
                // Nếu dữ liệu hợp lệ , lưu vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    _context.Add(tbCoCauToChuc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "LoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
                ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "TrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
                return View(tbCoCauToChuc);
            }
            catch (DbUpdateException dbEx)
            {
                // lỗi liên quan đến cơ sở dữ liệu như khóa chính, khóa ngoại, trùng id
             
                ModelState.AddModelError("", "Không thể lưu dữ liệu vào cơ sở dữ liệu do trùng id: " + dbEx.Message);
                return View(tbCoCauToChuc);
            }
            catch (Exception ex)
            {
                // xử lý lỗi nếu xảy ra ngoại lệ
                return BadRequest();

            }
        }
        // chi tiết cơ cấu tổ chức
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoCauToChuc = await _context.TbCoCauToChucs.FindAsync(id);
            if (tbCoCauToChuc == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "LoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "TrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
            return View(tbCoCauToChuc);
        }

        // chi tiết cơ cấu chi tiết
        // Để bảo vệ khỏi các cuộc tấn công overposting, hãy chỉ bật các thuộc tính bạn muốn bind.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCoCauToChuc,MaPhongBanDonVi,IdLoaiPhongBan,MaPhongBanDonViCha,TenPhongBanDonVi,SoQuyetDinhThanhLap,NgayRaQuyetDinh,IdTrangThai")] TbCoCauToChuc tbCoCauToChuc)
        {
            if (id != tbCoCauToChuc.IdCoCauToChuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCoCauToChuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCoCauToChucExists(tbCoCauToChuc.IdCoCauToChuc))
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
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "LoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "TrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
            return View(tbCoCauToChuc);
        }

        // trang xóa cơ cấu tổi chức
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoCauToChuc = await _context.TbCoCauToChucs
                .Include(t => t.IdLoaiPhongBanNavigation)
                .Include(t => t.IdTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.IdCoCauToChuc == id);
            if (tbCoCauToChuc == null)
            {
                return NotFound();
            }

            return View(tbCoCauToChuc);
        }

        // xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCoCauToChuc = await _context.TbCoCauToChucs.FindAsync(id);
            if (tbCoCauToChuc != null)
            {
                _context.TbCoCauToChucs.Remove(tbCoCauToChuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCoCauToChucExists(int id)
        {
            return _context.TbCoCauToChucs.Any(e => e.IdCoCauToChuc == id);
        }
    }
}
