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
    public class ThietBiPtnThtren500TrController : Controller
    {
        private readonly HemisContext _context;

        public ThietBiPtnThtren500TrController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThietBiPtnThtren500Tr
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThietBiPtnThtren500Trs.Include(t => t.IdCongTrinhCsvcNavigation).Include(t => t.IdQuocGiaXuatXuNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThietBiPtnThtren500Tr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThietBiPtnThtren500Tr = await _context.TbThietBiPtnThtren500Trs
                .Include(t => t.IdCongTrinhCsvcNavigation)
                .Include(t => t.IdQuocGiaXuatXuNavigation)
                .FirstOrDefaultAsync(m => m.IdThietBiPtnTh == id);
            if (tbThietBiPtnThtren500Tr == null)
            {
                return NotFound();
            }

            return View(tbThietBiPtnThtren500Tr);
        }

        // GET: ThietBiPtnThtren500Tr/Create
        public IActionResult Create()
        {
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat");
            ViewData["IdQuocGiaXuatXu"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich");
            return View();
        }

        // POST: ThietBiPtnThtren500Tr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThietBiPtnTh,MaThietBi,IdCongTrinhCsvc,TenThietBi,NamSanXuat,IdQuocGiaXuatXu,HangSanXuat,SoLuongThietBiCungLoai,NamDuaVaoSuDung")] TbThietBiPtnThtren500Tr tbThietBiPtnThtren500Tr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThietBiPtnThtren500Tr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbThietBiPtnThtren500Tr.IdCongTrinhCsvc);
            ViewData["IdQuocGiaXuatXu"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbThietBiPtnThtren500Tr.IdQuocGiaXuatXu);
            return View(tbThietBiPtnThtren500Tr);
        }

        // GET: ThietBiPtnThtren500Tr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThietBiPtnThtren500Tr = await _context.TbThietBiPtnThtren500Trs.FindAsync(id);
            if (tbThietBiPtnThtren500Tr == null)
            {
                return NotFound();
            }
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbThietBiPtnThtren500Tr.IdCongTrinhCsvc);
            ViewData["IdQuocGiaXuatXu"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbThietBiPtnThtren500Tr.IdQuocGiaXuatXu);
            return View(tbThietBiPtnThtren500Tr);
        }

        // POST: ThietBiPtnThtren500Tr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThietBiPtnTh,MaThietBi,IdCongTrinhCsvc,TenThietBi,NamSanXuat,IdQuocGiaXuatXu,HangSanXuat,SoLuongThietBiCungLoai,NamDuaVaoSuDung")] TbThietBiPtnThtren500Tr tbThietBiPtnThtren500Tr)
        {
            if (id != tbThietBiPtnThtren500Tr.IdThietBiPtnTh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThietBiPtnThtren500Tr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThietBiPtnThtren500TrExists(tbThietBiPtnThtren500Tr.IdThietBiPtnTh))
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
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbThietBiPtnThtren500Tr.IdCongTrinhCsvc);
            ViewData["IdQuocGiaXuatXu"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbThietBiPtnThtren500Tr.IdQuocGiaXuatXu);
            return View(tbThietBiPtnThtren500Tr);
        }

        // GET: ThietBiPtnThtren500Tr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThietBiPtnThtren500Tr = await _context.TbThietBiPtnThtren500Trs
                .Include(t => t.IdCongTrinhCsvcNavigation)
                .Include(t => t.IdQuocGiaXuatXuNavigation)
                .FirstOrDefaultAsync(m => m.IdThietBiPtnTh == id);
            if (tbThietBiPtnThtren500Tr == null)
            {
                return NotFound();
            }

            return View(tbThietBiPtnThtren500Tr);
        }

        // POST: ThietBiPtnThtren500Tr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThietBiPtnThtren500Tr = await _context.TbThietBiPtnThtren500Trs.FindAsync(id);
            if (tbThietBiPtnThtren500Tr != null)
            {
                _context.TbThietBiPtnThtren500Trs.Remove(tbThietBiPtnThtren500Tr);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThietBiPtnThtren500TrExists(int id)
        {
            return _context.TbThietBiPtnThtren500Trs.Any(e => e.IdThietBiPtnTh == id);
        }
    }
}
