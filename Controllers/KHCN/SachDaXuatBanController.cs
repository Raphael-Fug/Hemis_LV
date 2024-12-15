using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.KHCN
{
    public class SachDaXuatBanController : Controller
    {
        private readonly HemisContext _context;

        public SachDaXuatBanController(HemisContext context)
        {
            _context = context;
        }

        // GET: SachDaXuatBan
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbSachDaXuatBans.Include(t => t.IdDangTaiLieuNavigation).Include(t => t.IdLoaiSachTapChiNavigation).Include(t => t.IdNhiemVuKhcnNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: SachDaXuatBan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSachDaXuatBan = await _context.TbSachDaXuatBans
                .Include(t => t.IdDangTaiLieuNavigation)
                .Include(t => t.IdLoaiSachTapChiNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .FirstOrDefaultAsync(m => m.IdSachDaXuatBan == id);
            if (tbSachDaXuatBan == null)
            {
                return NotFound();
            }

            return View(tbSachDaXuatBan);
        }

        // GET: SachDaXuatBan/Create
        public IActionResult Create()
        {
            ViewData["IdDangTaiLieu"] = new SelectList(_context.DmDangTaiLieus, "IdDangTaiLieu", "IdDangTaiLieu");
            ViewData["IdLoaiSachTapChi"] = new SelectList(_context.DmLoaiSachTapChis, "IdLoaiSachTapChi", "IdLoaiSachTapChi");
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn");
            return View();
        }

        // POST: SachDaXuatBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSachDaXuatBan,IdNhiemVuKhcn,MaSach,TenSach,IdLoaiSachTapChi,MaChuanIsbn,SoTrang,Nxb,NamXuatBan,NamViet,IdDangTaiLieu")] TbSachDaXuatBan tbSachDaXuatBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSachDaXuatBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDangTaiLieu"] = new SelectList(_context.DmDangTaiLieus, "IdDangTaiLieu", "IdDangTaiLieu", tbSachDaXuatBan.IdDangTaiLieu);
            ViewData["IdLoaiSachTapChi"] = new SelectList(_context.DmLoaiSachTapChis, "IdLoaiSachTapChi", "IdLoaiSachTapChi", tbSachDaXuatBan.IdLoaiSachTapChi);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbSachDaXuatBan.IdNhiemVuKhcn);
            return View(tbSachDaXuatBan);
        }

        // GET: SachDaXuatBan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSachDaXuatBan = await _context.TbSachDaXuatBans.FindAsync(id);
            if (tbSachDaXuatBan == null)
            {
                return NotFound();
            }
            ViewData["IdDangTaiLieu"] = new SelectList(_context.DmDangTaiLieus, "IdDangTaiLieu", "IdDangTaiLieu", tbSachDaXuatBan.IdDangTaiLieu);
            ViewData["IdLoaiSachTapChi"] = new SelectList(_context.DmLoaiSachTapChis, "IdLoaiSachTapChi", "IdLoaiSachTapChi", tbSachDaXuatBan.IdLoaiSachTapChi);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbSachDaXuatBan.IdNhiemVuKhcn);
            return View(tbSachDaXuatBan);
        }

        // POST: SachDaXuatBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSachDaXuatBan,IdNhiemVuKhcn,MaSach,TenSach,IdLoaiSachTapChi,MaChuanIsbn,SoTrang,Nxb,NamXuatBan,NamViet,IdDangTaiLieu")] TbSachDaXuatBan tbSachDaXuatBan)
        {
            if (id != tbSachDaXuatBan.IdSachDaXuatBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSachDaXuatBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSachDaXuatBanExists(tbSachDaXuatBan.IdSachDaXuatBan))
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
            ViewData["IdDangTaiLieu"] = new SelectList(_context.DmDangTaiLieus, "IdDangTaiLieu", "IdDangTaiLieu", tbSachDaXuatBan.IdDangTaiLieu);
            ViewData["IdLoaiSachTapChi"] = new SelectList(_context.DmLoaiSachTapChis, "IdLoaiSachTapChi", "IdLoaiSachTapChi", tbSachDaXuatBan.IdLoaiSachTapChi);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbSachDaXuatBan.IdNhiemVuKhcn);
            return View(tbSachDaXuatBan);
        }

        // GET: SachDaXuatBan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSachDaXuatBan = await _context.TbSachDaXuatBans
                .Include(t => t.IdDangTaiLieuNavigation)
                .Include(t => t.IdLoaiSachTapChiNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .FirstOrDefaultAsync(m => m.IdSachDaXuatBan == id);
            if (tbSachDaXuatBan == null)
            {
                return NotFound();
            }

            return View(tbSachDaXuatBan);
        }

        // POST: SachDaXuatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSachDaXuatBan = await _context.TbSachDaXuatBans.FindAsync(id);
            if (tbSachDaXuatBan != null)
            {
                _context.TbSachDaXuatBans.Remove(tbSachDaXuatBan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSachDaXuatBanExists(int id)
        {
            return _context.TbSachDaXuatBans.Any(e => e.IdSachDaXuatBan == id);
        }
    }
}
