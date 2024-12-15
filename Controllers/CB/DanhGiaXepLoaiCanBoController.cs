using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CB
{
    public class DanhGiaXepLoaiCanBoController : Controller
    {
        private readonly HemisContext _context;

        public DanhGiaXepLoaiCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: DanhGiaXepLoaiCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDanhGiaXepLoaiCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdDanhGiaNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DanhGiaXepLoaiCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhGiaXepLoaiCanBo = await _context.TbDanhGiaXepLoaiCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdDanhGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhGiaXepLoaiCanBo == id);
            if (tbDanhGiaXepLoaiCanBo == null)
            {
                return NotFound();
            }

            return View(tbDanhGiaXepLoaiCanBo);
        }

        // GET: DanhGiaXepLoaiCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdDanhGia"] = new SelectList(_context.DmDanhGiaCongChucVienChucs, "IdDanhGiaCongChucVienChuc", "IdDanhGiaCongChucVienChuc");
            return View();
        }

        // POST: DanhGiaXepLoaiCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhGiaXepLoaiCanBo,IdCanBo,IdDanhGia,NamDanhGia,NganhDuocKhenThuong")] TbDanhGiaXepLoaiCanBo tbDanhGiaXepLoaiCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDanhGiaXepLoaiCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDanhGiaXepLoaiCanBo.IdCanBo);
            ViewData["IdDanhGia"] = new SelectList(_context.DmDanhGiaCongChucVienChucs, "IdDanhGiaCongChucVienChuc", "IdDanhGiaCongChucVienChuc", tbDanhGiaXepLoaiCanBo.IdDanhGia);
            return View(tbDanhGiaXepLoaiCanBo);
        }

        // GET: DanhGiaXepLoaiCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhGiaXepLoaiCanBo = await _context.TbDanhGiaXepLoaiCanBos.FindAsync(id);
            if (tbDanhGiaXepLoaiCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDanhGiaXepLoaiCanBo.IdCanBo);
            ViewData["IdDanhGia"] = new SelectList(_context.DmDanhGiaCongChucVienChucs, "IdDanhGiaCongChucVienChuc", "IdDanhGiaCongChucVienChuc", tbDanhGiaXepLoaiCanBo.IdDanhGia);
            return View(tbDanhGiaXepLoaiCanBo);
        }

        // POST: DanhGiaXepLoaiCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhGiaXepLoaiCanBo,IdCanBo,IdDanhGia,NamDanhGia,NganhDuocKhenThuong")] TbDanhGiaXepLoaiCanBo tbDanhGiaXepLoaiCanBo)
        {
            if (id != tbDanhGiaXepLoaiCanBo.IdDanhGiaXepLoaiCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhGiaXepLoaiCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhGiaXepLoaiCanBoExists(tbDanhGiaXepLoaiCanBo.IdDanhGiaXepLoaiCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDanhGiaXepLoaiCanBo.IdCanBo);
            ViewData["IdDanhGia"] = new SelectList(_context.DmDanhGiaCongChucVienChucs, "IdDanhGiaCongChucVienChuc", "IdDanhGiaCongChucVienChuc", tbDanhGiaXepLoaiCanBo.IdDanhGia);
            return View(tbDanhGiaXepLoaiCanBo);
        }

        // GET: DanhGiaXepLoaiCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhGiaXepLoaiCanBo = await _context.TbDanhGiaXepLoaiCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdDanhGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhGiaXepLoaiCanBo == id);
            if (tbDanhGiaXepLoaiCanBo == null)
            {
                return NotFound();
            }

            return View(tbDanhGiaXepLoaiCanBo);
        }

        // POST: DanhGiaXepLoaiCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDanhGiaXepLoaiCanBo = await _context.TbDanhGiaXepLoaiCanBos.FindAsync(id);
            if (tbDanhGiaXepLoaiCanBo != null)
            {
                _context.TbDanhGiaXepLoaiCanBos.Remove(tbDanhGiaXepLoaiCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDanhGiaXepLoaiCanBoExists(int id)
        {
            return _context.TbDanhGiaXepLoaiCanBos.Any(e => e.IdDanhGiaXepLoaiCanBo == id);
        }
    }
}
