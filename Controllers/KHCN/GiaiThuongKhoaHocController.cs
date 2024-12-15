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
    public class GiaiThuongKhoaHocController : Controller
    {
        private readonly HemisContext _context;

        public GiaiThuongKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: GiaiThuongKhoaHoc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGiaiThuongKhoaHocs.Include(t => t.IdLoaiGiaiThuongNavigation).Include(t => t.IdMucGiaiThuongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: GiaiThuongKhoaHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaiThuongKhoaHoc = await _context.TbGiaiThuongKhoaHocs
                .Include(t => t.IdLoaiGiaiThuongNavigation)
                .Include(t => t.IdMucGiaiThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaiThuongKhoaHoc == id);
            if (tbGiaiThuongKhoaHoc == null)
            {
                return NotFound();
            }

            return View(tbGiaiThuongKhoaHoc);
        }

        // GET: GiaiThuongKhoaHoc/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiGiaiThuong"] = new SelectList(_context.DmLoaiGiaiThuongKhcns, "IdLoaiGiaiThuongKhcn", "IdLoaiGiaiThuongKhcn");
            ViewData["IdMucGiaiThuong"] = new SelectList(_context.DmMucGiaiThuongs, "IdMucGiaiThuong", "IdMucGiaiThuong");
            return View();
        }

        // POST: GiaiThuongKhoaHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGiaiThuongKhoaHoc,MaGiaiThuong,IdLoaiGiaiThuong,CoQuanToChucGiaiThuong,TenDeTaiDuocTraoGiai,TenDonViDuocTraoGiai,IdMucGiaiThuong,QuyetDinhCapBangKhen,CoQuanBanHanhQuyetDinh")] TbGiaiThuongKhoaHoc tbGiaiThuongKhoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGiaiThuongKhoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiGiaiThuong"] = new SelectList(_context.DmLoaiGiaiThuongKhcns, "IdLoaiGiaiThuongKhcn", "IdLoaiGiaiThuongKhcn", tbGiaiThuongKhoaHoc.IdLoaiGiaiThuong);
            ViewData["IdMucGiaiThuong"] = new SelectList(_context.DmMucGiaiThuongs, "IdMucGiaiThuong", "IdMucGiaiThuong", tbGiaiThuongKhoaHoc.IdMucGiaiThuong);
            return View(tbGiaiThuongKhoaHoc);
        }

        // GET: GiaiThuongKhoaHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaiThuongKhoaHoc = await _context.TbGiaiThuongKhoaHocs.FindAsync(id);
            if (tbGiaiThuongKhoaHoc == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiGiaiThuong"] = new SelectList(_context.DmLoaiGiaiThuongKhcns, "IdLoaiGiaiThuongKhcn", "IdLoaiGiaiThuongKhcn", tbGiaiThuongKhoaHoc.IdLoaiGiaiThuong);
            ViewData["IdMucGiaiThuong"] = new SelectList(_context.DmMucGiaiThuongs, "IdMucGiaiThuong", "IdMucGiaiThuong", tbGiaiThuongKhoaHoc.IdMucGiaiThuong);
            return View(tbGiaiThuongKhoaHoc);
        }

        // POST: GiaiThuongKhoaHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGiaiThuongKhoaHoc,MaGiaiThuong,IdLoaiGiaiThuong,CoQuanToChucGiaiThuong,TenDeTaiDuocTraoGiai,TenDonViDuocTraoGiai,IdMucGiaiThuong,QuyetDinhCapBangKhen,CoQuanBanHanhQuyetDinh")] TbGiaiThuongKhoaHoc tbGiaiThuongKhoaHoc)
        {
            if (id != tbGiaiThuongKhoaHoc.IdGiaiThuongKhoaHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiaiThuongKhoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiaiThuongKhoaHocExists(tbGiaiThuongKhoaHoc.IdGiaiThuongKhoaHoc))
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
            ViewData["IdLoaiGiaiThuong"] = new SelectList(_context.DmLoaiGiaiThuongKhcns, "IdLoaiGiaiThuongKhcn", "IdLoaiGiaiThuongKhcn", tbGiaiThuongKhoaHoc.IdLoaiGiaiThuong);
            ViewData["IdMucGiaiThuong"] = new SelectList(_context.DmMucGiaiThuongs, "IdMucGiaiThuong", "IdMucGiaiThuong", tbGiaiThuongKhoaHoc.IdMucGiaiThuong);
            return View(tbGiaiThuongKhoaHoc);
        }

        // GET: GiaiThuongKhoaHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaiThuongKhoaHoc = await _context.TbGiaiThuongKhoaHocs
                .Include(t => t.IdLoaiGiaiThuongNavigation)
                .Include(t => t.IdMucGiaiThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaiThuongKhoaHoc == id);
            if (tbGiaiThuongKhoaHoc == null)
            {
                return NotFound();
            }

            return View(tbGiaiThuongKhoaHoc);
        }

        // POST: GiaiThuongKhoaHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGiaiThuongKhoaHoc = await _context.TbGiaiThuongKhoaHocs.FindAsync(id);
            if (tbGiaiThuongKhoaHoc != null)
            {
                _context.TbGiaiThuongKhoaHocs.Remove(tbGiaiThuongKhoaHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiaiThuongKhoaHocExists(int id)
        {
            return _context.TbGiaiThuongKhoaHocs.Any(e => e.IdGiaiThuongKhoaHoc == id);
        }
    }
}
