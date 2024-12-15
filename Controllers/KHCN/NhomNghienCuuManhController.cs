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
    public class NhomNghienCuuManhController : Controller
    {
        private readonly HemisContext _context;

        public NhomNghienCuuManhController(HemisContext context)
        {
            _context = context;
        }

        // GET: NhomNghienCuuManh
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var nhomNghienCuuManhs = from n in _context.TbNhomNghienCuuManhs
                                     select n;


            if (!String.IsNullOrEmpty(searchString))
            {
                nhomNghienCuuManhs = nhomNghienCuuManhs.Where(n => n.TenNhomNghienCuuManh.Contains(searchString)
                                                            || n.MaNhomNghienCuuManh.Contains(searchString));
            }
            // Lấy tổng số bản ghi 
            var totalRecords = await _context.TbNhomNghienCuuManhs.CountAsync();

            // Chuyển tổng số bản ghi đến View
            ViewData["TotalRecords"] = totalRecords;

            return View(await nhomNghienCuuManhs.ToListAsync());
        }

        // GET: NhomNghienCuuManh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhomNghienCuuManh = await _context.TbNhomNghienCuuManhs
                .FirstOrDefaultAsync(m => m.IdNhomNghienCuuManh == id);
            if (tbNhomNghienCuuManh == null)
            {
                return NotFound();
            }

            return View(tbNhomNghienCuuManh);
        }

        // GET: NhomNghienCuuManh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhomNghienCuuManh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhomNghienCuuManh,MaNhomNghienCuuManh,TenNhomNghienCuuManh,SoQuyetDinhThanhLap,ToChucBanHanhQuyetDinh,NgayQuyetDinh,CacNhiemVuNckh,TomTatKetQuaDatDuoc")] TbNhomNghienCuuManh tbNhomNghienCuuManh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNhomNghienCuuManh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbNhomNghienCuuManh);
        }

        // GET: NhomNghienCuuManh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbNhomNghienCuuManh = await _context.TbNhomNghienCuuManhs.FindAsync(id);
            if (tbNhomNghienCuuManh == null)
            {
                return NotFound();
            }
            return View(tbNhomNghienCuuManh);
        }

        // POST: NhomNghienCuuManh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhomNghienCuuManh,MaNhomNghienCuuManh,TenNhomNghienCuuManh,SoQuyetDinhThanhLap,ToChucBanHanhQuyetDinh,NgayQuyetDinh,CacNhiemVuNckh,TomTatKetQuaDatDuoc")] TbNhomNghienCuuManh tbNhomNghienCuuManh)
        {
            if (id != tbNhomNghienCuuManh.IdNhomNghienCuuManh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNhomNghienCuuManh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNhomNghienCuuManhExists(tbNhomNghienCuuManh.IdNhomNghienCuuManh))
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
            return View(tbNhomNghienCuuManh);
        }

        // GET: NhomNghienCuuManh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhomNghienCuuManh = await _context.TbNhomNghienCuuManhs
                .FirstOrDefaultAsync(m => m.IdNhomNghienCuuManh == id);
            if (tbNhomNghienCuuManh == null)
            {
                return NotFound();
            }

            return View(tbNhomNghienCuuManh);
        }

        // POST: NhomNghienCuuManh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNhomNghienCuuManh = await _context.TbNhomNghienCuuManhs.FindAsync(id);
            if (tbNhomNghienCuuManh != null)
            {
                _context.TbNhomNghienCuuManhs.Remove(tbNhomNghienCuuManh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNhomNghienCuuManhExists(int id)
        {
            return _context.TbNhomNghienCuuManhs.Any(e => e.IdNhomNghienCuuManh == id);
        }
    }
}
