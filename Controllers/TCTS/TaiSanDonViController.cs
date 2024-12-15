using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TCTS
{
    public class TaiSanDonViController : Controller
    {
        private readonly HemisContext _context;

        public TaiSanDonViController(HemisContext context)
        {
            _context = context;
        }

        // GET: TaiSanDonVi
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbTaiSanDonVis.ToListAsync());
        }

        // GET: TaiSanDonVi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTaiSanDonVi = await _context.TbTaiSanDonVis
                .FirstOrDefaultAsync(m => m.IdTaiSanDonVi == id);
            if (tbTaiSanDonVi == null)
            {
                return NotFound();
            }

            return View(tbTaiSanDonVi);
        }

        // GET: TaiSanDonVi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaiSanDonVi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTaiSanDonVi,MaLoaiTaiSan,TenLoaiTaiSan,MoTa,NamTaiChinh")] TbTaiSanDonVi tbTaiSanDonVi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTaiSanDonVi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTaiSanDonVi);
        }

        // GET: TaiSanDonVi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTaiSanDonVi = await _context.TbTaiSanDonVis.FindAsync(id);
            if (tbTaiSanDonVi == null)
            {
                return NotFound();
            }
            return View(tbTaiSanDonVi);
        }

        // POST: TaiSanDonVi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaiSanDonVi,MaLoaiTaiSan,TenLoaiTaiSan,MoTa,NamTaiChinh")] TbTaiSanDonVi tbTaiSanDonVi)
        {
            if (id != tbTaiSanDonVi.IdTaiSanDonVi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTaiSanDonVi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTaiSanDonViExists(tbTaiSanDonVi.IdTaiSanDonVi))
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
            return View(tbTaiSanDonVi);
        }

        // GET: TaiSanDonVi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTaiSanDonVi = await _context.TbTaiSanDonVis
                .FirstOrDefaultAsync(m => m.IdTaiSanDonVi == id);
            if (tbTaiSanDonVi == null)
            {
                return NotFound();
            }

            return View(tbTaiSanDonVi);
        }

        // POST: TaiSanDonVi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTaiSanDonVi = await _context.TbTaiSanDonVis.FindAsync(id);
            if (tbTaiSanDonVi != null)
            {
                _context.TbTaiSanDonVis.Remove(tbTaiSanDonVi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTaiSanDonViExists(int id)
        {
            return _context.TbTaiSanDonVis.Any(e => e.IdTaiSanDonVi == id);
        }
    }
}
