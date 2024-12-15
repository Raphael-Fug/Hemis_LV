using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CB
{
    public class ChucDanhKhoaHocCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public ChucDanhKhoaHocCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChucDanhKhoaHocCuaCanBo
        public IActionResult Index(string IDCB, string SapXep)
        {
            ViewBag.IdCanBo = IDCB;
            var danhSach = _context.TbChucDanhKhoaHocCuaCanBos
                .Include(item => item.IdCanBoNavigation)
                .Include(item => item.IdChucDanhKhoaHocNavigation)
                .Include(item => item.IdThamQuyenQuyetDinhNavigation)
                .Where(item => string.IsNullOrEmpty(IDCB) || item.IdCanBo.ToString() == IDCB)
                .ToList();

            var sapXepDanhSach = danhSach;

            if (SapXep == "SapXep")
            {
                sapXepDanhSach = danhSach.OrderBy(x => x.NgayQuyetDinh).ToList();
            }

            ViewBag.KqTimKiem = danhSach;
            ViewBag.KqSapXep = sapXepDanhSach;

            return View(sapXepDanhSach);
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdThamQuyenQuyetDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdChucDanhKhoaHocCuaCanBo == id);

            if (tbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc");
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "LoaiQuyetDinh");
            return View();
        }

        // POST: ChucDanhKhoaHocCuaCanBo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChucDanhKhoaHocCuaCanBo,IdCanBo,IdChucDanhKhoaHoc,IdThamQuyenQuyetDinh,SoQuyetDinh,NgayQuyetDinh")] TbChucDanhKhoaHocCuaCanBo tbChucDanhKhoaHocCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChucDanhKhoaHocCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbChucDanhKhoaHocCuaCanBo.IdCanBo);
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHoc);
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "LoaiQuyetDinh", tbChucDanhKhoaHocCuaCanBo.IdThamQuyenQuyetDinh);
            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos.FindAsync(id);
            if (tbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbChucDanhKhoaHocCuaCanBo.IdCanBo);
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHoc);
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "LoaiQuyetDinh", tbChucDanhKhoaHocCuaCanBo.IdThamQuyenQuyetDinh);
            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // POST: ChucDanhKhoaHocCuaCanBo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChucDanhKhoaHocCuaCanBo,IdCanBo,IdChucDanhKhoaHoc,IdThamQuyenQuyetDinh,SoQuyetDinh,NgayQuyetDinh")] TbChucDanhKhoaHocCuaCanBo tbChucDanhKhoaHocCuaCanBo)
        {
            if (id != tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChucDanhKhoaHocCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChucDanhKhoaHocCuaCanBoExists(tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbChucDanhKhoaHocCuaCanBo.IdCanBo);
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHoc);
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "LoaiQuyetDinh", tbChucDanhKhoaHocCuaCanBo.IdThamQuyenQuyetDinh);
            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdThamQuyenQuyetDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdChucDanhKhoaHocCuaCanBo == id);

            if (tbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // POST: ChucDanhKhoaHocCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos.FindAsync(id);
            _context.TbChucDanhKhoaHocCuaCanBos.Remove(tbChucDanhKhoaHocCuaCanBo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChucDanhKhoaHocCuaCanBoExists(int id)
        {
            return _context.TbChucDanhKhoaHocCuaCanBos.Any(e => e.IdChucDanhKhoaHocCuaCanBo == id);
        }
    }
}
