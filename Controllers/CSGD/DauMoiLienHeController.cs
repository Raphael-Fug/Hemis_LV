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
    public class DauMoiLienHeController : Controller
    {
        private readonly HemisContext _context;

        public DauMoiLienHeController(HemisContext context)
        {
            _context = context;
        }

        // GET: DauMoiLienHe
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            // Biến giữ thứ tự sắp xếp hiện tại
            ViewData["CurrentSort"] = sortOrder;

            // Biến giữ trạng thái sắp xếp cho các cột
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";

            // Lấy dữ liệu từ cơ sở dữ liệu
            var records = from r in _context.TbDauMoiLienHes.Include(t => t.IdLoaiDauMoiLienHeNavigation)
                          select r;

            // Tìm kiếm
            if (!String.IsNullOrEmpty(searchString))
            {
                records = records.Where(r => r.SoDienThoai.Contains(searchString)
                                           || r.Email.Contains(searchString));
            }

            // Sắp xếp
            switch (sortOrder)
            {
                case "name_desc":
                    records = records.OrderByDescending(r => r.IdLoaiDauMoiLienHeNavigation.DauMoiLienHe);
                    break;
                case "Phone":
                    records = records.OrderBy(r => r.SoDienThoai);
                    break;
                case "phone_desc":
                    records = records.OrderByDescending(r => r.SoDienThoai);
                    break;
                case "Email":
                    records = records.OrderBy(r => r.Email);
                    break;
                case "email_desc":
                    records = records.OrderByDescending(r => r.Email);
                    break;
                default:
                    records = records.OrderBy(r => r.IdLoaiDauMoiLienHeNavigation.DauMoiLienHe);
                    break;
            }

            return View(await records.ToListAsync());
        }

        // GET: DauMoiLienHe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDauMoiLienHe = await _context.TbDauMoiLienHes
                .Include(t => t.IdLoaiDauMoiLienHeNavigation)
                .FirstOrDefaultAsync(m => m.IdDauMoiLienHe == id);
            if (tbDauMoiLienHe == null)
            {
                return NotFound();
            }

            return View(tbDauMoiLienHe);
        }

        // GET: DauMoiLienHe/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "DauMoiLienHe");
            return View();
        }

        // POST: DauMoiLienHe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDauMoiLienHe,IdLoaiDauMoiLienHe,SoDienThoai,Email")] TbDauMoiLienHe tbDauMoiLienHe)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tbDauMoiLienHe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateException ex)
                {
                    // Kiểm tra nếu lỗi là do dữ liệu quá dài
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("String or binary data would be truncated"))
                    {
                        // Ghi log lỗi (tùy chọn)
                        ModelState.AddModelError(string.Empty, "Dữ liệu bạn nhập quá dài. Vui lòng mô tả ngắn gọn");
                    }
                    else if (ex.InnerException != null && ex.InnerException.Message.Contains("PRIMARY KEY constraint"))
                    {
                        // Xử lý lỗi trùng khóa chính
                        ModelState.AddModelError(string.Empty, "ID đã tồn tại");
                    }
                    else
                    {
                        // Ném lại lỗi để dễ debug các lỗi khác
                        throw;
                    }
                }
            }
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "DauMoiLienHe", tbDauMoiLienHe.IdLoaiDauMoiLienHe);
            return View(tbDauMoiLienHe);
        }



        // GET: DauMoiLienHe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDauMoiLienHe = await _context.TbDauMoiLienHes.FindAsync(id);
            if (tbDauMoiLienHe == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "DauMoiLienHe", tbDauMoiLienHe.IdLoaiDauMoiLienHe);
            return View(tbDauMoiLienHe);
        }

        // POST: DauMoiLienHe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDauMoiLienHe,IdLoaiDauMoiLienHe,SoDienThoai,Email")] TbDauMoiLienHe tbDauMoiLienHe)
        {
            if (id != tbDauMoiLienHe.IdDauMoiLienHe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDauMoiLienHe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("String or binary data would be truncated"))
                    {
                        // Ghi log lỗi (tùy chọn)
                        ModelState.AddModelError(string.Empty, "Dữ liệu bạn nhập quá dài. Vui lòng kiểm tra lại độ dài các trường dữ liệu.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "DauMoiLienHe", tbDauMoiLienHe.IdLoaiDauMoiLienHe);
            return View(tbDauMoiLienHe);
        }

        // GET: DauMoiLienHe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDauMoiLienHe = await _context.TbDauMoiLienHes
                .Include(t => t.IdLoaiDauMoiLienHeNavigation)
                .FirstOrDefaultAsync(m => m.IdDauMoiLienHe == id);
            if (tbDauMoiLienHe == null)
            {
                return NotFound();
            }

            return View(tbDauMoiLienHe);
        }

        // POST: DauMoiLienHe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDauMoiLienHe = await _context.TbDauMoiLienHes.FindAsync(id);
            if (tbDauMoiLienHe != null)
            {
                _context.TbDauMoiLienHes.Remove(tbDauMoiLienHe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDauMoiLienHeExists(int id)
        {
            return _context.TbDauMoiLienHes.Any(e => e.IdDauMoiLienHe == id);
        }
    }
}
