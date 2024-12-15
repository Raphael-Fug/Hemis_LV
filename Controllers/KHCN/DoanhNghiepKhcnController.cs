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
    public class DoanhNghiepKhcnController : Controller
    {
        private readonly HemisContext _context;

        public DoanhNghiepKhcnController(HemisContext context)
        {
            _context = context;
        }

        // GET: DoanhNghiepKhcn
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDoanhNghiepKhcns.Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DoanhNghiepKhcn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns
                .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation)
                .FirstOrDefaultAsync(m => m.IdDoanhNghiepKhcn == id);
            if (tbDoanhNghiepKhcn == null)
            {
                return NotFound();
            }

            return View(tbDoanhNghiepKhcn);
        }

        // GET: DoanhNghiepKhcn/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "IdHinhThucDoanhNghiepKhcn");
            return View();
        }

        // POST: DoanhNghiepKhcn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoanhNghiepKhcn,MaDoanhNghiep,TenDoanhNghiep,IdHinhThucDoanhNghiepKhcn,DiaDiemThanhLap,QuyMoDauTu,KinhPhiGopVonTuTaiSanTriTue,TyLeGopVonCuaCsgddh")] TbDoanhNghiepKhcn tbDoanhNghiepKhcn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDoanhNghiepKhcn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "IdHinhThucDoanhNghiepKhcn", tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn);
            return View(tbDoanhNghiepKhcn);
        }

        // GET: DoanhNghiepKhcn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns.FindAsync(id);
            if (tbDoanhNghiepKhcn == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "IdHinhThucDoanhNghiepKhcn", tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn);
            return View(tbDoanhNghiepKhcn);
        }

        // POST: DoanhNghiepKhcn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoanhNghiepKhcn,MaDoanhNghiep,TenDoanhNghiep,IdHinhThucDoanhNghiepKhcn,DiaDiemThanhLap,QuyMoDauTu,KinhPhiGopVonTuTaiSanTriTue,TyLeGopVonCuaCsgddh")] TbDoanhNghiepKhcn tbDoanhNghiepKhcn)
        {
            if (id != tbDoanhNghiepKhcn.IdDoanhNghiepKhcn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDoanhNghiepKhcn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDoanhNghiepKhcnExists(tbDoanhNghiepKhcn.IdDoanhNghiepKhcn))
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
            ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "IdHinhThucDoanhNghiepKhcn", tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn);
            return View(tbDoanhNghiepKhcn);
        }

        // GET: DoanhNghiepKhcn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns
                .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation)
                .FirstOrDefaultAsync(m => m.IdDoanhNghiepKhcn == id);
            if (tbDoanhNghiepKhcn == null)
            {
                return NotFound();
            }

            return View(tbDoanhNghiepKhcn);
        }

        // POST: DoanhNghiepKhcn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns.FindAsync(id);
            if (tbDoanhNghiepKhcn != null)
            {
                _context.TbDoanhNghiepKhcns.Remove(tbDoanhNghiepKhcn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDoanhNghiepKhcnExists(int id)
        {
            return _context.TbDoanhNghiepKhcns.Any(e => e.IdDoanhNghiepKhcn == id);
        }
    }
}
