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
    public class VanBanTuChuController : Controller
    {
        private readonly HemisContext _context;

        public VanBanTuChuController(HemisContext context)
        {
            _context = context;
        }

        // GET: VanBanTuChu
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbVanBanTuChus.ToListAsync());
        }

        // GET: VanBanTuChu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanBanTuChu = await _context.TbVanBanTuChus
                .FirstOrDefaultAsync(m => m.IdVanBanTuChu == id);
            if (tbVanBanTuChu == null)
            {
                return NotFound();
            }

            return View(tbVanBanTuChu);
        }

        // GET: VanBanTuChu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VanBanTuChu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVanBanTuChu,LoaiVanBan,NoiDungVanBan,QuyetDinhBanHanh,CoQuanQuyetDinhBanHanh")] TbVanBanTuChu tbVanBanTuChu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tbVanBanTuChu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tbVanBanTuChu);
            }
            catch (DbUpdateException dbEx)
            {
                // Lỗi liên quan đến cơ sở dữ liệu như khóa chính, khóa ngoại
                ModelState.AddModelError("", "Không thể lưu dữ liệu vào cơ sở dữ liệu: " + dbEx.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                // Lỗi chung chung khác
                return BadRequest();
            }

        }

        // GET: VanBanTuChu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanBanTuChu = await _context.TbVanBanTuChus.FindAsync(id);
            if (tbVanBanTuChu == null)
            {
                return NotFound();
            }
            return View(tbVanBanTuChu);
        }

        // POST: VanBanTuChu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVanBanTuChu,LoaiVanBan,NoiDungVanBan,QuyetDinhBanHanh,CoQuanQuyetDinhBanHanh")] TbVanBanTuChu tbVanBanTuChu)
        {
            if (id != tbVanBanTuChu.IdVanBanTuChu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbVanBanTuChu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbVanBanTuChuExists(tbVanBanTuChu.IdVanBanTuChu))
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
            return View(tbVanBanTuChu);
        }

        // GET: VanBanTuChu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanBanTuChu = await _context.TbVanBanTuChus
                .FirstOrDefaultAsync(m => m.IdVanBanTuChu == id);
            if (tbVanBanTuChu == null)
            {
                return NotFound();
            }

            return View(tbVanBanTuChu);
        }

        // POST: VanBanTuChu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbVanBanTuChu = await _context.TbVanBanTuChus.FindAsync(id);
            if (tbVanBanTuChu != null)
            {
                _context.TbVanBanTuChus.Remove(tbVanBanTuChu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbVanBanTuChuExists(int id)
        {
            return _context.TbVanBanTuChus.Any(e => e.IdVanBanTuChu == id);
        }
    }
}
