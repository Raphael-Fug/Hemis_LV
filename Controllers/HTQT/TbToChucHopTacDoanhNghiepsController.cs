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
    public class TbToChucHopTacDoanhNghiepsController : Controller
    {
        private readonly HemisContext _context;

        public TbToChucHopTacDoanhNghiepsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbToChucHopTacDoanhNghieps
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbToChucHopTacDoanhNghieps.Include(t => t.IdLoaiDeAnNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbToChucHopTacDoanhNghieps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucHopTacDoanhNghiep = await _context.TbToChucHopTacDoanhNghieps
                .Include(t => t.IdLoaiDeAnNavigation)
                .FirstOrDefaultAsync(m => m.IdToChucHopTacDoanhNghiep == id);
            if (tbToChucHopTacDoanhNghiep == null)
            {
                return NotFound();
            }

            return View(tbToChucHopTacDoanhNghiep);
        }

        // GET: TbToChucHopTacDoanhNghieps/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh");
            return View();
        }

        // POST: TbToChucHopTacDoanhNghieps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdToChucHopTacDoanhNghiep,MaToChucHopTacDoanhNghiep,TenToChucHopTacDoanhNghiep,NoiDungHopTac,NgayKyKet,KetQuaHopTac,IdLoaiDeAn,GiaTriGiaoDichCuaThiTruong")] TbToChucHopTacDoanhNghiep tbToChucHopTacDoanhNghiep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbToChucHopTacDoanhNghiep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh", tbToChucHopTacDoanhNghiep.IdLoaiDeAn);
            return View(tbToChucHopTacDoanhNghiep);
        }

        // GET: TbToChucHopTacDoanhNghieps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucHopTacDoanhNghiep = await _context.TbToChucHopTacDoanhNghieps.FindAsync(id);
            if (tbToChucHopTacDoanhNghiep == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh", tbToChucHopTacDoanhNghiep.IdLoaiDeAn);
            return View(tbToChucHopTacDoanhNghiep);
        }

        // POST: TbToChucHopTacDoanhNghieps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdToChucHopTacDoanhNghiep,MaToChucHopTacDoanhNghiep,TenToChucHopTacDoanhNghiep,NoiDungHopTac,NgayKyKet,KetQuaHopTac,IdLoaiDeAn,GiaTriGiaoDichCuaThiTruong")] TbToChucHopTacDoanhNghiep tbToChucHopTacDoanhNghiep)
        {
            if (id != tbToChucHopTacDoanhNghiep.IdToChucHopTacDoanhNghiep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbToChucHopTacDoanhNghiep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbToChucHopTacDoanhNghiepExists(tbToChucHopTacDoanhNghiep.IdToChucHopTacDoanhNghiep))
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
            ViewData["IdLoaiDeAn"] = new SelectList(_context.DmLoaiDeAnChuongTrinhs, "IdLoaiDeAnChuongTrinh", "IdLoaiDeAnChuongTrinh", tbToChucHopTacDoanhNghiep.IdLoaiDeAn);
            return View(tbToChucHopTacDoanhNghiep);
        }

        // GET: TbToChucHopTacDoanhNghieps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucHopTacDoanhNghiep = await _context.TbToChucHopTacDoanhNghieps
                .Include(t => t.IdLoaiDeAnNavigation)
                .FirstOrDefaultAsync(m => m.IdToChucHopTacDoanhNghiep == id);
            if (tbToChucHopTacDoanhNghiep == null)
            {
                return NotFound();
            }

            return View(tbToChucHopTacDoanhNghiep);
        }

        // POST: TbToChucHopTacDoanhNghieps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbToChucHopTacDoanhNghiep = await _context.TbToChucHopTacDoanhNghieps.FindAsync(id);
            if (tbToChucHopTacDoanhNghiep != null)
            {
                _context.TbToChucHopTacDoanhNghieps.Remove(tbToChucHopTacDoanhNghiep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbToChucHopTacDoanhNghiepExists(int id)
        {
            return _context.TbToChucHopTacDoanhNghieps.Any(e => e.IdToChucHopTacDoanhNghiep == id);
        }
    }
}
