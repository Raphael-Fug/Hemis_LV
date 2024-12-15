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
    public class DonViThinhGiangCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public DonViThinhGiangCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: DonViThinhGiangCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDonViThinhGiangCuaCanBos.Include(t => t.IdCanBoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DonViThinhGiangCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViThinhGiangCuaCanBo = await _context.TbDonViThinhGiangCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .FirstOrDefaultAsync(m => m.IdDonViThinhGiangCuaCanBo == id);
            if (tbDonViThinhGiangCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbDonViThinhGiangCuaCanBo);
        }

        // GET: DonViThinhGiangCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            return View();
        }

        // POST: DonViThinhGiangCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDonViThinhGiangCuaCanBo,IdCanBo,DonViThinhGiang,SoHopDongThinhGiang,ThoiGianBatDau,ThoiGianKetThuc,ThamNienGiangDay")] TbDonViThinhGiangCuaCanBo tbDonViThinhGiangCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDonViThinhGiangCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDonViThinhGiangCuaCanBo.IdCanBo);
            return View(tbDonViThinhGiangCuaCanBo);
        }

        // GET: DonViThinhGiangCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViThinhGiangCuaCanBo = await _context.TbDonViThinhGiangCuaCanBos.FindAsync(id);
            if (tbDonViThinhGiangCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDonViThinhGiangCuaCanBo.IdCanBo);
            return View(tbDonViThinhGiangCuaCanBo);
        }

        // POST: DonViThinhGiangCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonViThinhGiangCuaCanBo,IdCanBo,DonViThinhGiang,SoHopDongThinhGiang,ThoiGianBatDau,ThoiGianKetThuc,ThamNienGiangDay")] TbDonViThinhGiangCuaCanBo tbDonViThinhGiangCuaCanBo)
        {
            if (id != tbDonViThinhGiangCuaCanBo.IdDonViThinhGiangCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDonViThinhGiangCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDonViThinhGiangCuaCanBoExists(tbDonViThinhGiangCuaCanBo.IdDonViThinhGiangCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDonViThinhGiangCuaCanBo.IdCanBo);
            return View(tbDonViThinhGiangCuaCanBo);
        }

        // GET: DonViThinhGiangCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViThinhGiangCuaCanBo = await _context.TbDonViThinhGiangCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .FirstOrDefaultAsync(m => m.IdDonViThinhGiangCuaCanBo == id);
            if (tbDonViThinhGiangCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbDonViThinhGiangCuaCanBo);
        }

        // POST: DonViThinhGiangCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDonViThinhGiangCuaCanBo = await _context.TbDonViThinhGiangCuaCanBos.FindAsync(id);
            if (tbDonViThinhGiangCuaCanBo != null)
            {
                _context.TbDonViThinhGiangCuaCanBos.Remove(tbDonViThinhGiangCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDonViThinhGiangCuaCanBoExists(int id)
        {
            return _context.TbDonViThinhGiangCuaCanBos.Any(e => e.IdDonViThinhGiangCuaCanBo == id);
        }
    }
}
