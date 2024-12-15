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
    public class KhoiNganhDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public KhoiNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoiNganhDaoTao
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoiNganhDaoTaos.ToListAsync());
        }

        // GET: KhoiNganhDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoiNganhDaoTao = await _context.TbKhoiNganhDaoTaos
                .FirstOrDefaultAsync(m => m.IdKhoiNganhDaoTao == id);
            if (tbKhoiNganhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbKhoiNganhDaoTao);
        }

        // GET: KhoiNganhDaoTao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoiNganhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoiNganhDaoTao,KhoiNganhDaoTao")] TbKhoiNganhDaoTao tbKhoiNganhDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhoiNganhDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKhoiNganhDaoTao);
        }

        // GET: KhoiNganhDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoiNganhDaoTao = await _context.TbKhoiNganhDaoTaos.FindAsync(id);
            if (tbKhoiNganhDaoTao == null)
            {
                return NotFound();
            }
            return View(tbKhoiNganhDaoTao);
        }

        // POST: KhoiNganhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoiNganhDaoTao,KhoiNganhDaoTao")] TbKhoiNganhDaoTao tbKhoiNganhDaoTao)
        {
            if (id != tbKhoiNganhDaoTao.IdKhoiNganhDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoiNganhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoiNganhDaoTaoExists(tbKhoiNganhDaoTao.IdKhoiNganhDaoTao))
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
            return View(tbKhoiNganhDaoTao);
        }

        // GET: KhoiNganhDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoiNganhDaoTao = await _context.TbKhoiNganhDaoTaos
                .FirstOrDefaultAsync(m => m.IdKhoiNganhDaoTao == id);
            if (tbKhoiNganhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbKhoiNganhDaoTao);
        }

        // POST: KhoiNganhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoiNganhDaoTao = await _context.TbKhoiNganhDaoTaos.FindAsync(id);
            if (tbKhoiNganhDaoTao != null)
            {
                _context.TbKhoiNganhDaoTaos.Remove(tbKhoiNganhDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoiNganhDaoTaoExists(int id)
        {
            return _context.TbKhoiNganhDaoTaos.Any(e => e.IdKhoiNganhDaoTao == id);
        }
    }
}
