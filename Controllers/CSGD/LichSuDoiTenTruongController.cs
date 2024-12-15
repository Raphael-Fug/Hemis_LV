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
    public class LichSuDoiTenTruongController : Controller
    {
        private readonly HemisContext _context;

        public LichSuDoiTenTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: LichSuDoiTenTruong
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbLichSuDoiTenTruongs.ToListAsync());
        }

        // GET: LichSuDoiTenTruong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLichSuDoiTenTruong = await _context.TbLichSuDoiTenTruongs
                .FirstOrDefaultAsync(m => m.IdLichSuDoiTenTruong == id);
            if (tbLichSuDoiTenTruong == null)
            {
                return NotFound();
            }

            return View(tbLichSuDoiTenTruong);
        }

        // GET: LichSuDoiTenTruong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LichSuDoiTenTruong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLichSuDoiTenTruong,TenTruongCu,TenTruongCuTiengAnh,SoQuyetDinhDoiTen,NgayKyQuyetDinhDoiTen")] TbLichSuDoiTenTruong tbLichSuDoiTenTruong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLichSuDoiTenTruong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbLichSuDoiTenTruong);
        }

        // GET: LichSuDoiTenTruong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLichSuDoiTenTruong = await _context.TbLichSuDoiTenTruongs.FindAsync(id);
            if (tbLichSuDoiTenTruong == null)
            {
                return NotFound();
            }
            return View(tbLichSuDoiTenTruong);
        }

        // POST: LichSuDoiTenTruong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLichSuDoiTenTruong,TenTruongCu,TenTruongCuTiengAnh,SoQuyetDinhDoiTen,NgayKyQuyetDinhDoiTen")] TbLichSuDoiTenTruong tbLichSuDoiTenTruong)
        {
            if (id != tbLichSuDoiTenTruong.IdLichSuDoiTenTruong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLichSuDoiTenTruong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLichSuDoiTenTruongExists(tbLichSuDoiTenTruong.IdLichSuDoiTenTruong))
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
            return View(tbLichSuDoiTenTruong);
        }

        // GET: LichSuDoiTenTruong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLichSuDoiTenTruong = await _context.TbLichSuDoiTenTruongs
                .FirstOrDefaultAsync(m => m.IdLichSuDoiTenTruong == id);
            if (tbLichSuDoiTenTruong == null)
            {
                return NotFound();
            }

            return View(tbLichSuDoiTenTruong);
        }

        // POST: LichSuDoiTenTruong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLichSuDoiTenTruong = await _context.TbLichSuDoiTenTruongs.FindAsync(id);
            if (tbLichSuDoiTenTruong != null)
            {
                _context.TbLichSuDoiTenTruongs.Remove(tbLichSuDoiTenTruong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLichSuDoiTenTruongExists(int id)
        {
            return _context.TbLichSuDoiTenTruongs.Any(e => e.IdLichSuDoiTenTruong == id);
        }
    }
}
