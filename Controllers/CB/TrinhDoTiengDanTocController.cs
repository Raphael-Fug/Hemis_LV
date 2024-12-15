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
    public class TrinhDoTiengDanTocController : Controller
    {
        private readonly HemisContext _context;

        public TrinhDoTiengDanTocController(HemisContext context)
        {
            _context = context;
        }

        // GET: TrinhDoTiengDanToc
        public async Task<IActionResult> Index(int? Search)
        {
            // Lấy danh sách tất cả quá trình công tác
            var id = from s in _context.TbTrinhDoTiengDanTocs select s;

            // Nếu có giá trị tìm kiếm, lọc theo IdCanBo
            if (Search.HasValue)
            {
                id = id.Where(s => s.IdCanBo == Search.Value);
            }

            // Trả về view với danh sách đã lọc
            return View(await id.ToListAsync());
        }

        // GET: TrinhDoTiengDanToc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTrinhDoTiengDanToc = await _context.TbTrinhDoTiengDanTocs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdKhungNangLucNgoaiNguNavigation)
                .Include(t => t.IdTiengDanTocNavigation)
                .FirstOrDefaultAsync(m => m.IdTrinhDoTiengDanToc == id);
            if (tbTrinhDoTiengDanToc == null)
            {
                return NotFound();
            }

            return View(tbTrinhDoTiengDanToc);
        }

        // GET: TrinhDoTiengDanToc/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdKhungNangLucNgoaiNgu"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu");
            ViewData["IdTiengDanToc"] = new SelectList(_context.DmTiengDanTocs, "IdTiengDanToc", "IdTiengDanToc");
            return View();
        }

        // POST: TrinhDoTiengDanToc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTrinhDoTiengDanToc,IdCanBo,IdTiengDanToc,IdKhungNangLucNgoaiNgu")] TbTrinhDoTiengDanToc tbTrinhDoTiengDanToc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTrinhDoTiengDanToc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbTrinhDoTiengDanToc.IdCanBo);
            ViewData["IdKhungNangLucNgoaiNgu"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu", tbTrinhDoTiengDanToc.IdKhungNangLucNgoaiNgu);
            ViewData["IdTiengDanToc"] = new SelectList(_context.DmTiengDanTocs, "IdTiengDanToc", "IdTiengDanToc", tbTrinhDoTiengDanToc.IdTiengDanToc);
            return View(tbTrinhDoTiengDanToc);
        }

        // GET: TrinhDoTiengDanToc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTrinhDoTiengDanToc = await _context.TbTrinhDoTiengDanTocs.FindAsync(id);
            if (tbTrinhDoTiengDanToc == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbTrinhDoTiengDanToc.IdCanBo);
            ViewData["IdKhungNangLucNgoaiNgu"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu", tbTrinhDoTiengDanToc.IdKhungNangLucNgoaiNgu);
            ViewData["IdTiengDanToc"] = new SelectList(_context.DmTiengDanTocs, "IdTiengDanToc", "IdTiengDanToc", tbTrinhDoTiengDanToc.IdTiengDanToc);
            return View(tbTrinhDoTiengDanToc);
        }

        // POST: TrinhDoTiengDanToc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTrinhDoTiengDanToc,IdCanBo,IdTiengDanToc,IdKhungNangLucNgoaiNgu")] TbTrinhDoTiengDanToc tbTrinhDoTiengDanToc)
        {
            if (id != tbTrinhDoTiengDanToc.IdTrinhDoTiengDanToc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTrinhDoTiengDanToc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTrinhDoTiengDanTocExists(tbTrinhDoTiengDanToc.IdTrinhDoTiengDanToc))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbTrinhDoTiengDanToc.IdCanBo);
            ViewData["IdKhungNangLucNgoaiNgu"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu", tbTrinhDoTiengDanToc.IdKhungNangLucNgoaiNgu);
            ViewData["IdTiengDanToc"] = new SelectList(_context.DmTiengDanTocs, "IdTiengDanToc", "IdTiengDanToc", tbTrinhDoTiengDanToc.IdTiengDanToc);
            return View(tbTrinhDoTiengDanToc);
        }

        // GET: TrinhDoTiengDanToc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTrinhDoTiengDanToc = await _context.TbTrinhDoTiengDanTocs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdKhungNangLucNgoaiNguNavigation)
                .Include(t => t.IdTiengDanTocNavigation)
                .FirstOrDefaultAsync(m => m.IdTrinhDoTiengDanToc == id);
            if (tbTrinhDoTiengDanToc == null)
            {
                return NotFound();
            }

            return View(tbTrinhDoTiengDanToc);
        }

        // POST: TrinhDoTiengDanToc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTrinhDoTiengDanToc = await _context.TbTrinhDoTiengDanTocs.FindAsync(id);
            if (tbTrinhDoTiengDanToc != null)
            {
                _context.TbTrinhDoTiengDanTocs.Remove(tbTrinhDoTiengDanToc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTrinhDoTiengDanTocExists(int id)
        {
            return _context.TbTrinhDoTiengDanTocs.Any(e => e.IdTrinhDoTiengDanToc == id);
        }
    }
}
