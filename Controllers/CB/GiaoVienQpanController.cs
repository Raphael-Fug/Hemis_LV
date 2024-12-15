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
    public class GiaoVienQpanController : Controller
    {
        private readonly HemisContext _context;

        public GiaoVienQpanController(HemisContext context)
        {
            _context = context;
        }

        // GET: GiaoVienQpan
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGiaoVienQpans.Include(t => t.IdCanBoNavigation).Include(t => t.IdLoaiGiangVienQpNavigation).Include(t => t.IdQuanHamNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: GiaoVienQpan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaoVienQpan = await _context.TbGiaoVienQpans
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiGiangVienQpNavigation)
                .Include(t => t.IdQuanHamNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaoVienQpan == id);
            if (tbGiaoVienQpan == null)
            {
                return NotFound();
            }

            return View(tbGiaoVienQpan);
        }

        // GET: GiaoVienQpan/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdLoaiGiangVienQp"] = new SelectList(_context.DmLoaiGiangVienQuocPhongs, "IdLoaiGiangVienQuocPhong", "IdLoaiGiangVienQuocPhong");  //trường đầu tiên là value
            ViewData["IdQuanHam"] = new SelectList(_context.DmQuanHams, "IdQuanHam", "IdQuanHam");
            return View();
        }

        // POST: GiaoVienQpan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGiaoVienQpan,IdCanBo,NamBatDauBietPhai,SoNamBietPhai,IdLoaiGiangVienQp,DaoTaoGdqpan,IdQuanHam,SoTruongCongTac")] TbGiaoVienQpan tbGiaoVienQpan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGiaoVienQpan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGiaoVienQpan.IdCanBo);
            ViewData["IdLoaiGiangVienQp"] = new SelectList(_context.DmLoaiGiangVienQuocPhongs, "IdLoaiGiangVienQuocPhong", "IdLoaiGiangVienQuocPhong", tbGiaoVienQpan.IdLoaiGiangVienQp);
            ViewData["IdQuanHam"] = new SelectList(_context.DmQuanHams, "IdQuanHam", "IdQuanHam", tbGiaoVienQpan.IdQuanHam);
            return View(tbGiaoVienQpan);
        }

        // GET: GiaoVienQpan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaoVienQpan = await _context.TbGiaoVienQpans.FindAsync(id);
            if (tbGiaoVienQpan == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGiaoVienQpan.IdCanBo);
            ViewData["IdLoaiGiangVienQp"] = new SelectList(_context.DmLoaiGiangVienQuocPhongs, "IdLoaiGiangVienQuocPhong", "IdLoaiGiangVienQuocPhong", tbGiaoVienQpan.IdLoaiGiangVienQp);
            ViewData["IdQuanHam"] = new SelectList(_context.DmQuanHams, "IdQuanHam", "IdQuanHam", tbGiaoVienQpan.IdQuanHam);
            return View(tbGiaoVienQpan);
        }

        // POST: GiaoVienQpan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGiaoVienQpan,IdCanBo,NamBatDauBietPhai,SoNamBietPhai,IdLoaiGiangVienQp,DaoTaoGdqpan,IdQuanHam,SoTruongCongTac")] TbGiaoVienQpan tbGiaoVienQpan)
        {
            if (id != tbGiaoVienQpan.IdGiaoVienQpan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiaoVienQpan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiaoVienQpanExists(tbGiaoVienQpan.IdGiaoVienQpan))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGiaoVienQpan.IdCanBo);
            ViewData["IdLoaiGiangVienQp"] = new SelectList(_context.DmLoaiGiangVienQuocPhongs, "IdLoaiGiangVienQuocPhong", "IdLoaiGiangVienQuocPhong", tbGiaoVienQpan.IdLoaiGiangVienQp);
            ViewData["IdQuanHam"] = new SelectList(_context.DmQuanHams, "IdQuanHam", "IdQuanHam", tbGiaoVienQpan.IdQuanHam);
            return View(tbGiaoVienQpan);
        }

        // GET: GiaoVienQpan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaoVienQpan = await _context.TbGiaoVienQpans
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiGiangVienQpNavigation)
                .Include(t => t.IdQuanHamNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaoVienQpan == id);
            if (tbGiaoVienQpan == null)
            {
                return NotFound();
            }

            return View(tbGiaoVienQpan);
        }

        // POST: GiaoVienQpan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGiaoVienQpan = await _context.TbGiaoVienQpans.FindAsync(id);
            if (tbGiaoVienQpan != null)
            {
                _context.TbGiaoVienQpans.Remove(tbGiaoVienQpan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiaoVienQpanExists(int id)
        {
            return _context.TbGiaoVienQpans.Any(e => e.IdGiaoVienQpan == id);
        }
    }
}