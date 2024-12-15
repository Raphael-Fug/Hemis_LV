using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TS
{
    public class TbChiTieuTuyenSinhTheoNganhsController : Controller
    {
        private readonly HemisContext _context;

        public TbChiTieuTuyenSinhTheoNganhsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbChiTieuTuyenSinhTheoNganhs
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbChiTieuTuyenSinhTheoNganhs.Include(t => t.IdLoaiHinhDaoTaoNavigation).Include(t => t.IdNganhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbChiTieuTuyenSinhTheoNganhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTieuTuyenSinhTheoNganh = await _context.TbChiTieuTuyenSinhTheoNganhs
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTieuTuyenSinhTheoNganh == id);
            if (tbChiTieuTuyenSinhTheoNganh == null)
            {
                return NotFound();
            }

            return View(tbChiTieuTuyenSinhTheoNganh);
        }

        // GET: TbChiTieuTuyenSinhTheoNganhs/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            return View();
        }

        // POST: TbChiTieuTuyenSinhTheoNganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiTieuTuyenSinhTheoNganh,IdLoaiHinhDaoTao,IdNganhDaoTao,Nam,ChiTieu")] TbChiTieuTuyenSinhTheoNganh tbChiTieuTuyenSinhTheoNganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChiTieuTuyenSinhTheoNganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbChiTieuTuyenSinhTheoNganh.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbChiTieuTuyenSinhTheoNganh.IdNganhDaoTao);
            return View(tbChiTieuTuyenSinhTheoNganh);
        }

        // GET: TbChiTieuTuyenSinhTheoNganhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTieuTuyenSinhTheoNganh = await _context.TbChiTieuTuyenSinhTheoNganhs.FindAsync(id);
            if (tbChiTieuTuyenSinhTheoNganh == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbChiTieuTuyenSinhTheoNganh.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbChiTieuTuyenSinhTheoNganh.IdNganhDaoTao);
            return View(tbChiTieuTuyenSinhTheoNganh);
        }

        // POST: TbChiTieuTuyenSinhTheoNganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiTieuTuyenSinhTheoNganh,IdLoaiHinhDaoTao,IdNganhDaoTao,Nam,ChiTieu")] TbChiTieuTuyenSinhTheoNganh tbChiTieuTuyenSinhTheoNganh)
        {
            if (id != tbChiTieuTuyenSinhTheoNganh.IdChiTieuTuyenSinhTheoNganh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChiTieuTuyenSinhTheoNganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChiTieuTuyenSinhTheoNganhExists(tbChiTieuTuyenSinhTheoNganh.IdChiTieuTuyenSinhTheoNganh))
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
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbChiTieuTuyenSinhTheoNganh.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbChiTieuTuyenSinhTheoNganh.IdNganhDaoTao);
            return View(tbChiTieuTuyenSinhTheoNganh);
        }

        // GET: TbChiTieuTuyenSinhTheoNganhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTieuTuyenSinhTheoNganh = await _context.TbChiTieuTuyenSinhTheoNganhs
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTieuTuyenSinhTheoNganh == id);
            if (tbChiTieuTuyenSinhTheoNganh == null)
            {
                return NotFound();
            }

            return View(tbChiTieuTuyenSinhTheoNganh);
        }

        // POST: TbChiTieuTuyenSinhTheoNganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChiTieuTuyenSinhTheoNganh = await _context.TbChiTieuTuyenSinhTheoNganhs.FindAsync(id);
            if (tbChiTieuTuyenSinhTheoNganh != null)
            {
                _context.TbChiTieuTuyenSinhTheoNganhs.Remove(tbChiTieuTuyenSinhTheoNganh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChiTieuTuyenSinhTheoNganhExists(int id)
        {
            return _context.TbChiTieuTuyenSinhTheoNganhs.Any(e => e.IdChiTieuTuyenSinhTheoNganh == id);
        }
    }
}
