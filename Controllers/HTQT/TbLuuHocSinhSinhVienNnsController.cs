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
    public class TbLuuHocSinhSinhVienNnsController : Controller
    {
        private readonly HemisContext _context;

        public TbLuuHocSinhSinhVienNnsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbLuuHocSinhSinhVienNns
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbLuuHocSinhSinhVienNns.Include(t => t.IdLoaiLuuHocSinhNavigation).Include(t => t.IdNguonKinhPhiLuuHocSinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbLuuHocSinhSinhVienNns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLuuHocSinhSinhVienNn = await _context.TbLuuHocSinhSinhVienNns
                .Include(t => t.IdLoaiLuuHocSinhNavigation)
                .Include(t => t.IdNguonKinhPhiLuuHocSinhNavigation)
                .FirstOrDefaultAsync(m => m.IdLuuHocSinhSinhVienNn == id);
            if (tbLuuHocSinhSinhVienNn == null)
            {
                return NotFound();
            }

            return View(tbLuuHocSinhSinhVienNn);
        }

        // GET: TbLuuHocSinhSinhVienNns/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiLuuHocSinh"] = new SelectList(_context.DmLoaiLuuHocSinhs, "IdLoaiLuuHocSinh", "IdLoaiLuuHocSinh");
            ViewData["IdNguonKinhPhiLuuHocSinh"] = new SelectList(_context.DmNguonKinhPhiChoLuuHocSinhs, "IdNguonKinhPhiChoLuuHocSinh", "IdNguonKinhPhiChoLuuHocSinh");
            return View();
        }

        // POST: TbLuuHocSinhSinhVienNns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLuuHocSinhSinhVienNn,IdNguoiHoc,IdNguonKinhPhiLuuHocSinh,IdLoaiLuuHocSinh")] TbLuuHocSinhSinhVienNn tbLuuHocSinhSinhVienNn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLuuHocSinhSinhVienNn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiLuuHocSinh"] = new SelectList(_context.DmLoaiLuuHocSinhs, "IdLoaiLuuHocSinh", "IdLoaiLuuHocSinh", tbLuuHocSinhSinhVienNn.IdLoaiLuuHocSinh);
            ViewData["IdNguonKinhPhiLuuHocSinh"] = new SelectList(_context.DmNguonKinhPhiChoLuuHocSinhs, "IdNguonKinhPhiChoLuuHocSinh", "IdNguonKinhPhiChoLuuHocSinh", tbLuuHocSinhSinhVienNn.IdNguonKinhPhiLuuHocSinh);
            return View(tbLuuHocSinhSinhVienNn);
        }

        // GET: TbLuuHocSinhSinhVienNns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLuuHocSinhSinhVienNn = await _context.TbLuuHocSinhSinhVienNns.FindAsync(id);
            if (tbLuuHocSinhSinhVienNn == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiLuuHocSinh"] = new SelectList(_context.DmLoaiLuuHocSinhs, "IdLoaiLuuHocSinh", "IdLoaiLuuHocSinh", tbLuuHocSinhSinhVienNn.IdLoaiLuuHocSinh);
            ViewData["IdNguonKinhPhiLuuHocSinh"] = new SelectList(_context.DmNguonKinhPhiChoLuuHocSinhs, "IdNguonKinhPhiChoLuuHocSinh", "IdNguonKinhPhiChoLuuHocSinh", tbLuuHocSinhSinhVienNn.IdNguonKinhPhiLuuHocSinh);
            return View(tbLuuHocSinhSinhVienNn);
        }

        // POST: TbLuuHocSinhSinhVienNns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLuuHocSinhSinhVienNn,IdNguoiHoc,IdNguonKinhPhiLuuHocSinh,IdLoaiLuuHocSinh")] TbLuuHocSinhSinhVienNn tbLuuHocSinhSinhVienNn)
        {
            if (id != tbLuuHocSinhSinhVienNn.IdLuuHocSinhSinhVienNn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLuuHocSinhSinhVienNn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLuuHocSinhSinhVienNnExists(tbLuuHocSinhSinhVienNn.IdLuuHocSinhSinhVienNn))
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
            ViewData["IdLoaiLuuHocSinh"] = new SelectList(_context.DmLoaiLuuHocSinhs, "IdLoaiLuuHocSinh", "IdLoaiLuuHocSinh", tbLuuHocSinhSinhVienNn.IdLoaiLuuHocSinh);
            ViewData["IdNguonKinhPhiLuuHocSinh"] = new SelectList(_context.DmNguonKinhPhiChoLuuHocSinhs, "IdNguonKinhPhiChoLuuHocSinh", "IdNguonKinhPhiChoLuuHocSinh", tbLuuHocSinhSinhVienNn.IdNguonKinhPhiLuuHocSinh);
            return View(tbLuuHocSinhSinhVienNn);
        }

        // GET: TbLuuHocSinhSinhVienNns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLuuHocSinhSinhVienNn = await _context.TbLuuHocSinhSinhVienNns
                .Include(t => t.IdLoaiLuuHocSinhNavigation)
                .Include(t => t.IdNguonKinhPhiLuuHocSinhNavigation)
                .FirstOrDefaultAsync(m => m.IdLuuHocSinhSinhVienNn == id);
            if (tbLuuHocSinhSinhVienNn == null)
            {
                return NotFound();
            }

            return View(tbLuuHocSinhSinhVienNn);
        }

        // POST: TbLuuHocSinhSinhVienNns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLuuHocSinhSinhVienNn = await _context.TbLuuHocSinhSinhVienNns.FindAsync(id);
            if (tbLuuHocSinhSinhVienNn != null)
            {
                _context.TbLuuHocSinhSinhVienNns.Remove(tbLuuHocSinhSinhVienNn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLuuHocSinhSinhVienNnExists(int id)
        {
            return _context.TbLuuHocSinhSinhVienNns.Any(e => e.IdLuuHocSinhSinhVienNn == id);
        }
    }
}
