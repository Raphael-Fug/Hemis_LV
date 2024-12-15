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
    public class ThongTinLinhVucDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinLinhVucDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinLinhVucDaoTao
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinLinhVucDaoTaos.Include(t => t.IdKhoiNganhNavigation).Include(t => t.IdLinhVucDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinLinhVucDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinLinhVucDaoTao = await _context.TbThongTinLinhVucDaoTaos
                .Include(t => t.IdKhoiNganhNavigation)
                .Include(t => t.IdLinhVucDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinLinhVucDaoTao == id);
            if (tbThongTinLinhVucDaoTao == null)
            {
                return NotFound();
            }

            return View(tbThongTinLinhVucDaoTao);
        }

        // GET: ThongTinLinhVucDaoTao/Create
        public IActionResult Create()
        {
            ViewData["IdKhoiNganh"] = new SelectList(_context.TbKhoiNganhDaoTaos, "IdKhoiNganhDaoTao", "IdKhoiNganhDaoTao");
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao");
            return View();
        }

        // POST: ThongTinLinhVucDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinLinhVucDaoTao,IdKhoiNganh,IdLinhVucDaoTao")] TbThongTinLinhVucDaoTao tbThongTinLinhVucDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThongTinLinhVucDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKhoiNganh"] = new SelectList(_context.TbKhoiNganhDaoTaos, "IdKhoiNganhDaoTao", "IdKhoiNganhDaoTao", tbThongTinLinhVucDaoTao.IdKhoiNganh);
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao", tbThongTinLinhVucDaoTao.IdLinhVucDaoTao);
            return View(tbThongTinLinhVucDaoTao);
        }

        // GET: ThongTinLinhVucDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinLinhVucDaoTao = await _context.TbThongTinLinhVucDaoTaos.FindAsync(id);
            if (tbThongTinLinhVucDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdKhoiNganh"] = new SelectList(_context.TbKhoiNganhDaoTaos, "IdKhoiNganhDaoTao", "IdKhoiNganhDaoTao", tbThongTinLinhVucDaoTao.IdKhoiNganh);
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao", tbThongTinLinhVucDaoTao.IdLinhVucDaoTao);
            return View(tbThongTinLinhVucDaoTao);
        }

        // POST: ThongTinLinhVucDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinLinhVucDaoTao,IdKhoiNganh,IdLinhVucDaoTao")] TbThongTinLinhVucDaoTao tbThongTinLinhVucDaoTao)
        {
            if (id != tbThongTinLinhVucDaoTao.IdThongTinLinhVucDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinLinhVucDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinLinhVucDaoTaoExists(tbThongTinLinhVucDaoTao.IdThongTinLinhVucDaoTao))
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
            ViewData["IdKhoiNganh"] = new SelectList(_context.TbKhoiNganhDaoTaos, "IdKhoiNganhDaoTao", "IdKhoiNganhDaoTao", tbThongTinLinhVucDaoTao.IdKhoiNganh);
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao", tbThongTinLinhVucDaoTao.IdLinhVucDaoTao);
            return View(tbThongTinLinhVucDaoTao);
        }

        // GET: ThongTinLinhVucDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinLinhVucDaoTao = await _context.TbThongTinLinhVucDaoTaos
                .Include(t => t.IdKhoiNganhNavigation)
                .Include(t => t.IdLinhVucDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinLinhVucDaoTao == id);
            if (tbThongTinLinhVucDaoTao == null)
            {
                return NotFound();
            }

            return View(tbThongTinLinhVucDaoTao);
        }

        // POST: ThongTinLinhVucDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinLinhVucDaoTao = await _context.TbThongTinLinhVucDaoTaos.FindAsync(id);
            if (tbThongTinLinhVucDaoTao != null)
            {
                _context.TbThongTinLinhVucDaoTaos.Remove(tbThongTinLinhVucDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinLinhVucDaoTaoExists(int id)
        {
            return _context.TbThongTinLinhVucDaoTaos.Any(e => e.IdThongTinLinhVucDaoTao == id);
        }
    }
}
