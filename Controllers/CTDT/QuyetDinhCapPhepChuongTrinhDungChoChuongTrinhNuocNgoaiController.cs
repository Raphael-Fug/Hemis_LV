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
    public class QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiController : Controller
    {
        private readonly HemisContext _context;

        public QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiController(HemisContext context)
        {
            _context = context;
        }

        // GET: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.Include(t => t.IdChuongTrinhDaoTaoNavigation).Include(t => t.IdHinhThucDaoTaoNavigation).Include(t => t.IdLoaiQuyetDinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdHinhThucDaoTaoNavigation)
                .Include(t => t.IdLoaiQuyetDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == id);
            if (tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == null)
            {
                return NotFound();
            }

            return View(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
        }

        // GET: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao");
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao");
            ViewData["IdLoaiQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "IdLoaiQuyetDinh");
            return View();
        }

        // POST: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai,IdChuongTrinhDaoTao,IdLoaiQuyetDinh,SoQuyetDinh,NgayBanHanhQuyetDinh,IdHinhThucDaoTao")] TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdChuongTrinhDaoTao);
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdHinhThucDaoTao);
            ViewData["IdLoaiQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "IdLoaiQuyetDinh", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdLoaiQuyetDinh);
            return View(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
        }

        // GET: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.FindAsync(id);
            if (tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdChuongTrinhDaoTao);
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdHinhThucDaoTao);
            ViewData["IdLoaiQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "IdLoaiQuyetDinh", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdLoaiQuyetDinh);
            return View(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
        }

        // POST: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai,IdChuongTrinhDaoTao,IdLoaiQuyetDinh,SoQuyetDinh,NgayBanHanhQuyetDinh,IdHinhThucDaoTao")] TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai)
        {
            if (id != tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiExists(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdChuongTrinhDaoTao);
            ViewData["IdHinhThucDaoTao"] = new SelectList(_context.DmHinhThucDaoTaos, "IdHinhThucDaoTao", "IdHinhThucDaoTao", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdHinhThucDaoTao);
            ViewData["IdLoaiQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "IdLoaiQuyetDinh", tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdLoaiQuyetDinh);
            return View(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
        }

        // GET: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdHinhThucDaoTaoNavigation)
                .Include(t => t.IdLoaiQuyetDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == id);
            if (tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == null)
            {
                return NotFound();
            }

            return View(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
        }

        // POST: QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.FindAsync(id);
            if (tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai != null)
            {
                _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.Remove(tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiExists(int id)
        {
            return _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.Any(e => e.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == id);
        }
    }
}
