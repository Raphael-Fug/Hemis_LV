using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using System.ComponentModel.DataAnnotations;

namespace C500Hemis.Controllers.CTDT
{
    public class NgonNguGiangDayController : Controller
    {
        private readonly HemisContext _context;

        public NgonNguGiangDayController(HemisContext context)
        {
            _context = context;
        }

        // GET: NgonNguGiangDay
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNgonNguGiangDays.Include(t => t.IdChuongTrinhDaoTaoNavigation).Include(t => t.IdNgonNguNavigation).Include(t => t.IdTrinhDoNgonNguDauVaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NgonNguGiangDay/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNgonNguGiangDay = await _context.TbNgonNguGiangDays
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdNgonNguNavigation)
                .Include(t => t.IdTrinhDoNgonNguDauVaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNgonNguGiangDay == id);
            if (tbNgonNguGiangDay == null)
            {
                return NotFound();
            }

            return View(tbNgonNguGiangDay);
        }

        // GET: NgonNguGiangDay/Create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh");
            ViewData["IdNgonNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu");
            ViewData["IdTrinhDoNgonNguDauVao"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu");
            return View();
        }


        // POST: NgonNguGiangDay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNgonNguGiangDay,IdChuongTrinhDaoTao,IdNgonNgu,IdTrinhDoNgonNguDauVao")] TbNgonNguGiangDay tbNgonNguGiangDay)
        {
            //Kiểm tra dữ liệu nhập vào xem có giống dữ liệu khai báo không
            if (ModelState.IsValid)
            {
                try
                {
                    //Nhập thêm 
                    _context.Add(tbNgonNguGiangDay);
                    //Lưu tất cả vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();
                    //Chuyển hướng quay lại trang index sau khi lưu thành công
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //Nếu xảy ra lỗi sẽ hiện ra dòng thông báo
                    ModelState.AddModelError("", "Đã xảy ra lỗi khi tạo mới: " + ex.Message);
                }

            }
            else
            {
                //tạo một biến error1 sẽ chứa tất cả lỗi sai xác nhận từ ModelState
                var error1 = ModelState.Values.SelectMany(h => h.Errors);
                //Vòng lặp duyệt từng lỗi trong error1
                foreach (var error in error1)
                {
                    //Mỗi lỗi sẽ được thêm vào ModelState
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }

            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbNgonNguGiangDay.IdChuongTrinhDaoTao);
            ViewData["IdNgonNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNgonNguGiangDay.IdNgonNgu);
            ViewData["IdTrinhDoNgonNguDauVao"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNgonNguGiangDay.IdTrinhDoNgonNguDauVao);
            return View(tbNgonNguGiangDay);
        }

        // GET: NgonNguGiangDay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNgonNguGiangDay = await _context.TbNgonNguGiangDays.FindAsync(id);
            if (tbNgonNguGiangDay == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbNgonNguGiangDay.IdChuongTrinhDaoTao);
            ViewData["IdNgonNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNgonNguGiangDay.IdNgonNgu);
            ViewData["IdTrinhDoNgonNguDauVao"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNgonNguGiangDay.IdTrinhDoNgonNguDauVao);
            return View(tbNgonNguGiangDay);
        }

        // POST: NgonNguGiangDay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNgonNguGiangDay,IdChuongTrinhDaoTao,IdNgonNgu,IdTrinhDoNgonNguDauVao")] TbNgonNguGiangDay tbNgonNguGiangDay)
        {
            if (id != tbNgonNguGiangDay.IdNgonNguGiangDay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNgonNguGiangDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNgonNguGiangDayExists(tbNgonNguGiangDay.IdNgonNguGiangDay))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbNgonNguGiangDay.IdChuongTrinhDaoTao);
            ViewData["IdNgonNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNgonNguGiangDay.IdNgonNgu);
            ViewData["IdTrinhDoNgonNguDauVao"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNgonNguGiangDay.IdTrinhDoNgonNguDauVao);
            return View(tbNgonNguGiangDay);
        }

        // GET: NgonNguGiangDay/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNgonNguGiangDay = await _context.TbNgonNguGiangDays
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdNgonNguNavigation)
                .Include(t => t.IdTrinhDoNgonNguDauVaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNgonNguGiangDay == id);
            if (tbNgonNguGiangDay == null)
            {
                return NotFound();
            }

            return View(tbNgonNguGiangDay);
        }

        // POST: NgonNguGiangDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNgonNguGiangDay = await _context.TbNgonNguGiangDays.FindAsync(id);
            if (tbNgonNguGiangDay != null)
            {
                _context.TbNgonNguGiangDays.Remove(tbNgonNguGiangDay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNgonNguGiangDayExists(int id)
        {
            return _context.TbNgonNguGiangDays.Any(e => e.IdNgonNguGiangDay == id);
        }
    }
}