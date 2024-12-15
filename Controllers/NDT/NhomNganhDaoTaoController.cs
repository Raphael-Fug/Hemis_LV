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
    public class NhomNganhDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public NhomNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: NhomNganhDaoTao
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNhomNganhDaoTaos.Include(t => t.IdLinhVucDaoTaoNavigation).Include(t => t.IdNganhDaoTaoNavigation).Include(t => t.IdNhomNganhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NhomNganhDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhomNganhDaoTao = await _context.TbNhomNganhDaoTaos
                .Include(t => t.IdLinhVucDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdNhomNganhNavigation)
                .FirstOrDefaultAsync(m => m.IdNhomNganhDaoTao == id);
            if (tbNhomNganhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbNhomNganhDaoTao);
        }

        // GET: NhomNganhDaoTao/Create
        public IActionResult Create()
        {
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            ViewData["IdNhomNganh"] = new SelectList(_context.DmNhomNganhs, "IdNhomNganh", "IdNhomNganh");
            return View();
        }

        // POST: NhomNganhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhomNganhDaoTao,IdLinhVucDaoTao,IdNganhDaoTao,IdNhomNganh")] TbNhomNganhDaoTao tbNhomNganhDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNhomNganhDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao", tbNhomNganhDaoTao.IdLinhVucDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNhomNganhDaoTao.IdNganhDaoTao);
            ViewData["IdNhomNganh"] = new SelectList(_context.DmNhomNganhs, "IdNhomNganh", "IdNhomNganh", tbNhomNganhDaoTao.IdNhomNganh);
            return View(tbNhomNganhDaoTao);
        }

        // GET: NhomNganhDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhomNganhDaoTao = await _context.TbNhomNganhDaoTaos.FindAsync(id);
            if (tbNhomNganhDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao", tbNhomNganhDaoTao.IdLinhVucDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNhomNganhDaoTao.IdNganhDaoTao);
            ViewData["IdNhomNganh"] = new SelectList(_context.DmNhomNganhs, "IdNhomNganh", "IdNhomNganh", tbNhomNganhDaoTao.IdNhomNganh);
            return View(tbNhomNganhDaoTao);
        }

        // POST: NhomNganhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhomNganhDaoTao,IdLinhVucDaoTao,IdNganhDaoTao,IdNhomNganh")] TbNhomNganhDaoTao tbNhomNganhDaoTao)
        {
            if (id != tbNhomNganhDaoTao.IdNhomNganhDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNhomNganhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNhomNganhDaoTaoExists(tbNhomNganhDaoTao.IdNhomNganhDaoTao))
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
            ViewData["IdLinhVucDaoTao"] = new SelectList(_context.DmLinhVucDaoTaos, "IdLinhVucDaoTao", "IdLinhVucDaoTao", tbNhomNganhDaoTao.IdLinhVucDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNhomNganhDaoTao.IdNganhDaoTao);
            ViewData["IdNhomNganh"] = new SelectList(_context.DmNhomNganhs, "IdNhomNganh", "IdNhomNganh", tbNhomNganhDaoTao.IdNhomNganh);
            return View(tbNhomNganhDaoTao);
        }

        // GET: NhomNganhDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhomNganhDaoTao = await _context.TbNhomNganhDaoTaos
                .Include(t => t.IdLinhVucDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdNhomNganhNavigation)
                .FirstOrDefaultAsync(m => m.IdNhomNganhDaoTao == id);
            if (tbNhomNganhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbNhomNganhDaoTao);
        }

        // POST: NhomNganhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNhomNganhDaoTao = await _context.TbNhomNganhDaoTaos.FindAsync(id);
            if (tbNhomNganhDaoTao != null)
            {
                _context.TbNhomNganhDaoTaos.Remove(tbNhomNganhDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNhomNganhDaoTaoExists(int id)
        {
            return _context.TbNhomNganhDaoTaos.Any(e => e.IdNhomNganhDaoTao == id);
        }
    }
}
