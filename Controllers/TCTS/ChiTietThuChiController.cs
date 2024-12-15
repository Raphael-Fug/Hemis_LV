using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TCTS
{
    public class ChiTietThuChiController : Controller
    {
        private readonly HemisContext _context;

        public ChiTietThuChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChiTietThuChi
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbChiTietThuChis.Include(t => t.IdLoaiThuChiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ChiTietThuChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTietThuChi = await _context.TbChiTietThuChis
                .Include(t => t.IdLoaiThuChiNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTietThuChi == id);
            if (tbChiTietThuChi == null)
            {
                return NotFound();
            }

            return View(tbChiTietThuChi);
        }

        // GET: ChiTietThuChi/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiThuChi"] = new SelectList(_context.TbLoaiThuChis, "IdLoaiThuChi", "IdLoaiThuChi");
            return View();
        }

        // POST: ChiTietThuChi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiTietThuChi,IdLoaiThuChi,TenKhoanThuChi,NamTaiChinh,SoTien")] TbChiTietThuChi tbChiTietThuChi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChiTietThuChi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiThuChi"] = new SelectList(_context.TbLoaiThuChis, "IdLoaiThuChi", "IdLoaiThuChi", tbChiTietThuChi.IdLoaiThuChi);
            return View(tbChiTietThuChi);
        }

        // GET: ChiTietThuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTietThuChi = await _context.TbChiTietThuChis.FindAsync(id);
            if (tbChiTietThuChi == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiThuChi"] = new SelectList(_context.TbLoaiThuChis, "IdLoaiThuChi", "IdLoaiThuChi", tbChiTietThuChi.IdLoaiThuChi);
            return View(tbChiTietThuChi);
        }

        // POST: ChiTietThuChi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiTietThuChi,IdLoaiThuChi,TenKhoanThuChi,NamTaiChinh,SoTien")] TbChiTietThuChi tbChiTietThuChi)
        {
            if (id != tbChiTietThuChi.IdChiTietThuChi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChiTietThuChi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChiTietThuChiExists(tbChiTietThuChi.IdChiTietThuChi))
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
            ViewData["IdLoaiThuChi"] = new SelectList(_context.TbLoaiThuChis, "IdLoaiThuChi", "IdLoaiThuChi", tbChiTietThuChi.IdLoaiThuChi);
            return View(tbChiTietThuChi);
        }

        // GET: ChiTietThuChi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTietThuChi = await _context.TbChiTietThuChis
                .Include(t => t.IdLoaiThuChiNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTietThuChi == id);
            if (tbChiTietThuChi == null)
            {
                return NotFound();
            }

            return View(tbChiTietThuChi);
        }

        // POST: ChiTietThuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChiTietThuChi = await _context.TbChiTietThuChis.FindAsync(id);
            if (tbChiTietThuChi != null)
            {
                _context.TbChiTietThuChis.Remove(tbChiTietThuChi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChiTietThuChiExists(int id)
        {
            return _context.TbChiTietThuChis.Any(e => e.IdChiTietThuChi == id);
        }
    }
}
