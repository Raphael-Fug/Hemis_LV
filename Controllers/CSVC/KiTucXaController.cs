using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSVC
{
    //Dương Minh Vũ
    public class KiTucXaController : Controller
    {
        private readonly HemisContext _context;

        public KiTucXaController(HemisContext context)
        {
            _context = context;
        }

        // GET: KiTucXa
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbKiTucXas.Include(t => t.IdHinhThucSoHuuNavigation).Include(t => t.IdTinhTrangCsvcNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: KiTucXa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKiTucXa = await _context.TbKiTucXas
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdTinhTrangCsvcNavigation)
                .FirstOrDefaultAsync(m => m.IdKiTucXa == id);
            if (tbKiTucXa == null)
            {
                return NotFound();
            }

            return View(tbKiTucXa);
        }

        // GET: KiTucXa/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu");
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "TinhTrangCoSoVatChat");
            return View();
        }

        // POST: KiTucXa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKiTucXa,MaKyTucxa,IdHinhThucSoHuu,TongChoO,TongDienTich,IdTinhTrangCsvc,SoPhong,NamDuaVaoSuDung")] TbKiTucXa tbKiTucXa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKiTucXa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbKiTucXa.IdHinhThucSoHuu);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbKiTucXa.IdTinhTrangCsvc);
            return View(tbKiTucXa);
        }

        // GET: KiTucXa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKiTucXa = await _context.TbKiTucXas.FindAsync(id);
            if (tbKiTucXa == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu", tbKiTucXa.IdHinhThucSoHuu);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "TinhTrangCoSoVatChat", tbKiTucXa.IdTinhTrangCsvc);
            return View(tbKiTucXa);
        }

        // POST: KiTucXa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKiTucXa,MaKyTucxa,IdHinhThucSoHuu,TongChoO,TongDienTich,IdTinhTrangCsvc,SoPhong,NamDuaVaoSuDung")] TbKiTucXa tbKiTucXa)
        {
            if (id != tbKiTucXa.IdKiTucXa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKiTucXa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKiTucXaExists(tbKiTucXa.IdKiTucXa))
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
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbKiTucXa.IdHinhThucSoHuu);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbKiTucXa.IdTinhTrangCsvc);
            return View(tbKiTucXa);
        }

        // GET: KiTucXa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKiTucXa = await _context.TbKiTucXas
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdTinhTrangCsvcNavigation)
                .FirstOrDefaultAsync(m => m.IdKiTucXa == id);
            if (tbKiTucXa == null)
            {
                return NotFound();
            }

            return View(tbKiTucXa);
        }

        // POST: KiTucXa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKiTucXa = await _context.TbKiTucXas.FindAsync(id);
            if (tbKiTucXa != null)
            {
                _context.TbKiTucXas.Remove(tbKiTucXa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKiTucXaExists(int id)
        {
            return _context.TbKiTucXas.Any(e => e.IdKiTucXa == id);
        }
    }
}
