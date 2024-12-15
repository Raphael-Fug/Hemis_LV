using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using System.Text;
using System.IO;

namespace C500Hemis.Controllers.HTQT
{
    public class TbHoiThaoHoiNghisController : Controller
    {
        private readonly HemisContext _context;

        public TbHoiThaoHoiNghisController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbHoiThaoHoiNghis
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHoiThaoHoiNghis.Include(t => t.IdNguonKinhPhiHoiThaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbHoiThaoHoiNghis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis
                .Include(t => t.IdNguonKinhPhiHoiThaoNavigation)
                .FirstOrDefaultAsync(m => m.IdHoiThaoHoiNghi == id);
            if (tbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            return View(tbHoiThaoHoiNghi);
        }

        // GET: TbHoiThaoHoiNghis/Create
        public IActionResult Create()
        {
            //chạy chương trình nếu xuất hiện một ngoại lệ sẽ dừng lại và hiển thị lỗi badrequest
            try
            {
                ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // POST: TbHoiThaoHoiNghis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoiThaoHoiNghi,MaHoiThaoHoiNghi,TenHoiThaoHoiNghi,CoQuanCoThamQuyenCapPhep,MucTieu,NoiDung,SoLuongDaiBieuThamDu,SoLuongDaiBieuQuocTeThamDu,ThoiGianToChuc,DiaDiemToChuc,IdNguonKinhPhiHoiThao,DonViChuTri")] TbHoiThaoHoiNghi tbHoiThaoHoiNghi)
        {
            try
            {
                //nếu nhập id trùng sẽ bắt nhập lại
                if (TbHoiThaoHoiNghiExists(tbHoiThaoHoiNghi.IdHoiThaoHoiNghi)) ModelState.AddModelError("IdHoiThaoHoiNghi", "ID vừa nhập đã tồn tại, vui lòng nhập một ID khác");

                // Kiểm tra Sl đại biểu phải lớn hơn 0
                if (tbHoiThaoHoiNghi.SoLuongDaiBieuThamDu <= 0)
                {
                    ModelState.AddModelError("SoLuongDaiBieuThamDu", "Số lượng đại biểu phải lớn hơn 0.");
                }
                // Kiểm tra Sl đại biểu quốc tế phải lớn hơn 0
                if (tbHoiThaoHoiNghi.SoLuongDaiBieuQuocTeThamDu <= 0)
                {
                    ModelState.AddModelError("SoLuongDaiBieuQuocTeThamDu", "Số lượng đại biểu quốc tế phải lớn hơn 0.");
                }
                // Kiểm tra xem mã HTHN có null hay không
                if (string.IsNullOrWhiteSpace(tbHoiThaoHoiNghi.MaHoiThaoHoiNghi))
                {
                    ModelState.AddModelError("MaHoiThaoHoiNghi", "Tên hội thảo/hội nghị không được để trống.");
                }
                // Kiểm tra xem Tên HTHN có null hay không
                if (string.IsNullOrWhiteSpace(tbHoiThaoHoiNghi.TenHoiThaoHoiNghi))
                {
                    ModelState.AddModelError("TenHoiThaoHoiNghi", "Tên hội thảo/hội nghị không được để trống.");
                }
                //chạy chương trình nếu xuất hiện một ngoại lệ sẽ dừng lại và hiển thị lỗi badrequest
                if (ModelState.IsValid)
                {
                    _context.Add(tbHoiThaoHoiNghi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi", tbHoiThaoHoiNghi.IdNguonKinhPhiHoiThao);
                return View(tbHoiThaoHoiNghi);
            }
            catch (Exception Ex)
            {
                return BadRequest();
            }
        }

        // GET: TbHoiThaoHoiNghis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis.FindAsync(id);
            if (tbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }
            ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi", tbHoiThaoHoiNghi.IdNguonKinhPhiHoiThao);
            return View(tbHoiThaoHoiNghi);
        }

        // POST: TbHoiThaoHoiNghis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoiThaoHoiNghi,MaHoiThaoHoiNghi,TenHoiThaoHoiNghi,CoQuanCoThamQuyenCapPhep,MucTieu,NoiDung,SoLuongDaiBieuThamDu,SoLuongDaiBieuQuocTeThamDu,ThoiGianToChuc,DiaDiemToChuc,IdNguonKinhPhiHoiThao,DonViChuTri")] TbHoiThaoHoiNghi tbHoiThaoHoiNghi)
        {
            // Kiểm tra Sl đại biểu phải lớn hơn 0
            if (tbHoiThaoHoiNghi.SoLuongDaiBieuThamDu <= 0)
            {
                ModelState.AddModelError("SoLuongDaiBieuThamDu", "Số lượng đại biểu phải lớn hơn 0");
            }
            // Kiểm tra Sl đại biểu quốc tế phải lớn hơn 0
            if (tbHoiThaoHoiNghi.SoLuongDaiBieuQuocTeThamDu <= 0)
            {
                ModelState.AddModelError("SoLuongDaiBieuQuocTeThamDu", "Số lượng đại biểu quốc tế phải lớn hơn 0");
            }
            // Kiểm tra xem mã HTHN có null hay không
            if (string.IsNullOrWhiteSpace(tbHoiThaoHoiNghi.MaHoiThaoHoiNghi))
            {
                ModelState.AddModelError("MaHoiThaoHoiNghi", "Tên hội thảo/hội nghị không được để trống.");
            }
            // Kiểm tra xem Tên HTHN có null hay không
            if (string.IsNullOrWhiteSpace(tbHoiThaoHoiNghi.TenHoiThaoHoiNghi))
            {
                ModelState.AddModelError("TenHoiThaoHoiNghi", "Tên hội thảo/hội nghị không được để trống.");
            }
            if (id != tbHoiThaoHoiNghi.IdHoiThaoHoiNghi)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHoiThaoHoiNghi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHoiThaoHoiNghiExists(tbHoiThaoHoiNghi.IdHoiThaoHoiNghi))
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
            ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi", tbHoiThaoHoiNghi.IdNguonKinhPhiHoiThao);
            return View(tbHoiThaoHoiNghi);
        }

        // GET: TbHoiThaoHoiNghis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis
                .Include(t => t.IdNguonKinhPhiHoiThaoNavigation)
                .FirstOrDefaultAsync(m => m.IdHoiThaoHoiNghi == id);
            if (tbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            return View(tbHoiThaoHoiNghi);
        }

        // POST: TbHoiThaoHoiNghis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis.FindAsync(id);
            if (tbHoiThaoHoiNghi != null)
            {
                _context.TbHoiThaoHoiNghis.Remove(tbHoiThaoHoiNghi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHoiThaoHoiNghiExists(int id)
        {
            return _context.TbHoiThaoHoiNghis.Any(e => e.IdHoiThaoHoiNghi == id);
        }


    }
}
