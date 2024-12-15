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
    public class NganhGiangDayCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public NganhGiangDayCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: NganhGiangDayCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNganhGiangDayCuaCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdNganhNavigation).Include(t => t.IdTrinhDoDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NganhGiangDayCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNganhGiangDayCuaCanBo = await _context.TbNganhGiangDayCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdNganhNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNganhGiangDayCuaCanBo == id);
            if (tbNganhGiangDayCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbNganhGiangDayCuaCanBo);
        }

        // GET: NganhGiangDayCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdNganh"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao");
            return View();
        }

        // POST: NganhGiangDayCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNganhGiangDayCuaCanBo,IdCanBo,IdTrinhDoDaoTao,IdNganh,LaNganhChinh,DonViThinhGiang")] TbNganhGiangDayCuaCanBo tbNganhGiangDayCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNganhGiangDayCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbNganhGiangDayCuaCanBo.IdCanBo);
            ViewData["IdNganh"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNganhGiangDayCuaCanBo.IdNganh);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbNganhGiangDayCuaCanBo.IdTrinhDoDaoTao);
            return View(tbNganhGiangDayCuaCanBo);
        }

        // GET: NganhGiangDayCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNganhGiangDayCuaCanBo = await _context.TbNganhGiangDayCuaCanBos.FindAsync(id);
            if (tbNganhGiangDayCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbNganhGiangDayCuaCanBo.IdCanBo);
            ViewData["IdNganh"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNganhGiangDayCuaCanBo.IdNganh);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbNganhGiangDayCuaCanBo.IdTrinhDoDaoTao);
            return View(tbNganhGiangDayCuaCanBo);
        }

        // POST: NganhGiangDayCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNganhGiangDayCuaCanBo,IdCanBo,IdTrinhDoDaoTao,IdNganh,LaNganhChinh,DonViThinhGiang")] TbNganhGiangDayCuaCanBo tbNganhGiangDayCuaCanBo)
        {
            if (id != tbNganhGiangDayCuaCanBo.IdNganhGiangDayCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNganhGiangDayCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNganhGiangDayCuaCanBoExists(tbNganhGiangDayCuaCanBo.IdNganhGiangDayCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbNganhGiangDayCuaCanBo.IdCanBo);
            ViewData["IdNganh"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNganhGiangDayCuaCanBo.IdNganh);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbNganhGiangDayCuaCanBo.IdTrinhDoDaoTao);
            return View(tbNganhGiangDayCuaCanBo);
        }

        // GET: NganhGiangDayCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNganhGiangDayCuaCanBo = await _context.TbNganhGiangDayCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdNganhNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNganhGiangDayCuaCanBo == id);
            if (tbNganhGiangDayCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbNganhGiangDayCuaCanBo);
        }

        // POST: NganhGiangDayCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNganhGiangDayCuaCanBo = await _context.TbNganhGiangDayCuaCanBos.FindAsync(id);
            if (tbNganhGiangDayCuaCanBo != null)
            {
                _context.TbNganhGiangDayCuaCanBos.Remove(tbNganhGiangDayCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNganhGiangDayCuaCanBoExists(int id)
        {
            return _context.TbNganhGiangDayCuaCanBos.Any(e => e.IdNganhGiangDayCuaCanBo == id);
        }
    }
}
