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
    public class LoaiHinhDaoTaoKhacDuocChoPhepMoNganhController : Controller
    {
        private readonly HemisContext _context;

        public LoaiHinhDaoTaoKhacDuocChoPhepMoNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.Include(t => t.IdLoaiHinhDaoTaoNavigation).Include(t => t.IdNganhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == id);
            if (tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == null)
            {
                return NotFound();
            }

            return View(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
        }

        // GET: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            return View();
        }

        // POST: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh,IdNganhDaoTao,IdLoaiHinhDaoTao,SoQuyetDinhChoPhep,NgayBanHanhQuyetDinhChoPhep")] TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdNganhDaoTao);
            return View(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
        }

        // GET: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.FindAsync(id);
            if (tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdNganhDaoTao);
            return View(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
        }

        // POST: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh,IdNganhDaoTao,IdLoaiHinhDaoTao,SoQuyetDinhChoPhep,NgayBanHanhQuyetDinhChoPhep")] TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh)
        {
            if (id != tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhExists(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh))
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
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdNganhDaoTao);
            return View(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
        }

        // GET: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == id);
            if (tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == null)
            {
                return NotFound();
            }

            return View(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
        }

        // POST: LoaiHinhDaoTaoKhacDuocChoPhepMoNganh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.FindAsync(id);
            if (tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh != null)
            {
                _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.Remove(tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhExists(int id)
        {
            return _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.Any(e => e.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == id);
        }
    }
}
