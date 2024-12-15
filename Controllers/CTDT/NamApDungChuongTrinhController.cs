using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CTDT
{
    public class NamApDungChuongTrinhController : Controller
    {
        private readonly HemisContext _context;

        public NamApDungChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: NamApDungChuongTrinh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNamApDungChuongTrinhs.Include(t => t.IdChuongTrinhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NamApDungChuongTrinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNamApDungChuongTrinh = await _context.TbNamApDungChuongTrinhs
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNamApDungChuongTrinh == id);
            if (tbNamApDungChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbNamApDungChuongTrinh);
        }

        // GET: NamApDungChuongTrinh/Create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh");
            return View();
        }

        // POST: NamApDungChuongTrinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNamApDungChuongTrinh,IdChuongTrinhDaoTao,SoTinChiToiThieuDeTotNghiep,TongHocPhiToanKhoa,NamApDung,ChiTieuTuyenSinhHangNam")] TbNamApDungChuongTrinh tbNamApDungChuongTrinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNamApDungChuongTrinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbNamApDungChuongTrinh.IdChuongTrinhDaoTao);
            return View(tbNamApDungChuongTrinh);
        }

        // GET: NamApDungChuongTrinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNamApDungChuongTrinh = await _context.TbNamApDungChuongTrinhs.FindAsync(id);
            if (tbNamApDungChuongTrinh == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbNamApDungChuongTrinh.IdChuongTrinhDaoTao);
            return View(tbNamApDungChuongTrinh);
        }

        // POST: NamApDungChuongTrinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNamApDungChuongTrinh,IdChuongTrinhDaoTao,SoTinChiToiThieuDeTotNghiep,TongHocPhiToanKhoa,NamApDung,ChiTieuTuyenSinhHangNam")] TbNamApDungChuongTrinh tbNamApDungChuongTrinh)
        {
            if (id != tbNamApDungChuongTrinh.IdNamApDungChuongTrinh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNamApDungChuongTrinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNamApDungChuongTrinhExists(tbNamApDungChuongTrinh.IdNamApDungChuongTrinh))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbNamApDungChuongTrinh.IdChuongTrinhDaoTao);
            return View(tbNamApDungChuongTrinh);
        }

        // GET: NamApDungChuongTrinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNamApDungChuongTrinh = await _context.TbNamApDungChuongTrinhs
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNamApDungChuongTrinh == id);
            if (tbNamApDungChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbNamApDungChuongTrinh);
        }

        // POST: NamApDungChuongTrinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNamApDungChuongTrinh = await _context.TbNamApDungChuongTrinhs.FindAsync(id);
            if (tbNamApDungChuongTrinh != null)
            {
                _context.TbNamApDungChuongTrinhs.Remove(tbNamApDungChuongTrinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNamApDungChuongTrinhExists(int id)
        {
            return _context.TbNamApDungChuongTrinhs.Any(e => e.IdNamApDungChuongTrinh == id);
        }
    }
}
