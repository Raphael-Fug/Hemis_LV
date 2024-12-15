using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.NDT
{
    public class HinhThucDaoTaoCuaNganhController : Controller
    {
        private readonly HemisContext _context;

        public HinhThucDaoTaoCuaNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: HinhThucDaoTaoCuaNganh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHinhThucDaoTaoCuaNganhs.Include(t => t.IdHinhThucDaoTaoNavigation).Include(t => t.IdNganhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: HinhThucDaoTaoCuaNganh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHinhThucDaoTaoCuaNganh = await _context.TbHinhThucDaoTaoCuaNganhs
                .Include(t => t.IdHinhThucDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdHinhThucDaoTaoCuaNganh == id);
            if (tbHinhThucDaoTaoCuaNganh == null)
            {
                return NotFound();
            }

            return View(tbHinhThucDaoTaoCuaNganh);
        }

        // GET: HinhThucDaoTaoCuaNganh/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            return View();
        }

        // POST: HinhThucDaoTaoCuaNganh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHinhThucDaoTaoCuaNganh,IdNganhDaoTao,IdHinhThucDaoTao,SoNamDaoTao")] TbHinhThucDaoTaoCuaNganh tbHinhThucDaoTaoCuaNganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbHinhThucDaoTaoCuaNganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao", tbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbHinhThucDaoTaoCuaNganh.IdNganhDaoTao);
            return View(tbHinhThucDaoTaoCuaNganh);
        }

        // GET: HinhThucDaoTaoCuaNganh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHinhThucDaoTaoCuaNganh = await _context.TbHinhThucDaoTaoCuaNganhs.FindAsync(id);
            if (tbHinhThucDaoTaoCuaNganh == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao", tbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbHinhThucDaoTaoCuaNganh.IdNganhDaoTao);
            return View(tbHinhThucDaoTaoCuaNganh);
        }

        // POST: HinhThucDaoTaoCuaNganh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHinhThucDaoTaoCuaNganh,IdNganhDaoTao,IdHinhThucDaoTao,SoNamDaoTao")] TbHinhThucDaoTaoCuaNganh tbHinhThucDaoTaoCuaNganh)
        {
            if (id != tbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTaoCuaNganh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHinhThucDaoTaoCuaNganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHinhThucDaoTaoCuaNganhExists(tbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTaoCuaNganh))
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
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao", tbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbHinhThucDaoTaoCuaNganh.IdNganhDaoTao);
            return View(tbHinhThucDaoTaoCuaNganh);
        }

        // GET: HinhThucDaoTaoCuaNganh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHinhThucDaoTaoCuaNganh = await _context.TbHinhThucDaoTaoCuaNganhs
                .Include(t => t.IdHinhThucDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdHinhThucDaoTaoCuaNganh == id);
            if (tbHinhThucDaoTaoCuaNganh == null)
            {
                return NotFound();
            }

            return View(tbHinhThucDaoTaoCuaNganh);
        }

        // POST: HinhThucDaoTaoCuaNganh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHinhThucDaoTaoCuaNganh = await _context.TbHinhThucDaoTaoCuaNganhs.FindAsync(id);
            if (tbHinhThucDaoTaoCuaNganh != null)
            {
                _context.TbHinhThucDaoTaoCuaNganhs.Remove(tbHinhThucDaoTaoCuaNganh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHinhThucDaoTaoCuaNganhExists(int id)
        {
            return _context.TbHinhThucDaoTaoCuaNganhs.Any(e => e.IdHinhThucDaoTaoCuaNganh == id);
        }
    }
}
