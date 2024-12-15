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
    public class GiangVienNnController : Controller
    {
        private readonly HemisContext _context;

        public GiangVienNnController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbGiangVienNns
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGiangVienNns.Include(t => t.IdCanBoNavigation).ThenInclude(human => human.IdNguoiNavigation).Include(t => t.IdNoiDungHoatDongTaiVietNamNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbGiangVienNns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiangVienNn = await _context.TbGiangVienNns
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdNoiDungHoatDongTaiVietNamNavigation)
                .FirstOrDefaultAsync(m => m.IdGvnn == id);
            if (tbGiangVienNn == null)
            {
                return NotFound();
            }

            return View(tbGiangVienNn);
        }

        // GET: TbGiangVienNns/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(human => human.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name");
            ViewData["IdNoiDungHoatDongTaiVietNam"] = new SelectList(_context.DmNoiDungHoatDongTaiVietNams, "IdNoiDungHoatDongTaiVietNam", "NoiDungHoatDongTaiVietNam");
            return View();
        }

        // POST: TbGiangVienNns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGvnn,IdCanBo,CoQuanChuQuanOnuocNgoai,IdNoiDungHoatDongTaiVietNam")] TbGiangVienNn tbGiangVienNn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGiangVienNn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(human => human.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbGiangVienNn.IdCanBo);
            ViewData["IdNoiDungHoatDongTaiVietNam"] = new SelectList(_context.DmNoiDungHoatDongTaiVietNams, "IdNoiDungHoatDongTaiVietNam", "NoiDungHoatDongTaiVietNam", tbGiangVienNn.IdNoiDungHoatDongTaiVietNam);
            return View(tbGiangVienNn);
        }

        // GET: TbGiangVienNns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiangVienNn = await _context.TbGiangVienNns.FindAsync(id);
            if (tbGiangVienNn == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(human => human.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbGiangVienNn.IdCanBo);
            ViewData["IdNoiDungHoatDongTaiVietNam"] = new SelectList(_context.DmNoiDungHoatDongTaiVietNams, "IdNoiDungHoatDongTaiVietNam", "NoiDungHoatDongTaiVietNam", tbGiangVienNn.IdNoiDungHoatDongTaiVietNam);
            return View(tbGiangVienNn);
        }

        // POST: TbGiangVienNns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGvnn,IdCanBo,CoQuanChuQuanOnuocNgoai,IdNoiDungHoatDongTaiVietNam")] TbGiangVienNn tbGiangVienNn)
        {
            if (id != tbGiangVienNn.IdGvnn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiangVienNn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiangVienNnExists(tbGiangVienNn.IdGvnn))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdNguoiNavigation.name", tbGiangVienNn.IdCanBo);
            ViewData["IdNoiDungHoatDongTaiVietNam"] = new SelectList(_context.DmNoiDungHoatDongTaiVietNams, "IdNoiDungHoatDongTaiVietNam", "NoiDungHoatDongTaiVietNam", tbGiangVienNn.IdNoiDungHoatDongTaiVietNam);
            return View(tbGiangVienNn);
        }

        // GET: TbGiangVienNns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiangVienNn = await _context.TbGiangVienNns
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdNoiDungHoatDongTaiVietNamNavigation)
                .FirstOrDefaultAsync(m => m.IdGvnn == id);
            if (tbGiangVienNn == null)
            {
                return NotFound();
            }

            return View(tbGiangVienNn);
        }

        // POST: TbGiangVienNns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGiangVienNn = await _context.TbGiangVienNns.FindAsync(id);
            if (tbGiangVienNn != null)
            {
                _context.TbGiangVienNns.Remove(tbGiangVienNn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiangVienNnExists(int id)
        {
            return _context.TbGiangVienNns.Any(e => e.IdGvnn == id);
        }
    }
}
