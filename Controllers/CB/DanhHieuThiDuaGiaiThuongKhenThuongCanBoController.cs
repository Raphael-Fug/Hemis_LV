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
   
        public class DanhHieuThiDuaGiaiThuongKhenThuongCanBoController : Controller
        {
            private readonly HemisContext _context;

            public DanhHieuThiDuaGiaiThuongKhenThuongCanBoController(HemisContext context)
            {
                _context = context;
            }

            // GET: DanhHieuThiDuaGiaiThuongKhenThuongCanBo
            //public async Task<IActionResult> Index()
            //{
            //    var hemisContext = _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdCapKhenThuongNavigation).Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation).Include(t => t.IdPhuongThucKhenThuongNavigation).Include(t => t.IdThiDuaGiaiThuongKhenThuongNavigation);
            //    return View(await hemisContext.ToListAsync());
            //}
            public IActionResult Index(string IDCB, string SapXep)
            {
                ViewBag.IdCanBo = IDCB;
                HemisContext db = new HemisContext();
                var kq = db.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.ToList();
                var danhSach = db.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos
                    .Include(item => item.IdCanBoNavigation)
                    .Include(item => item.IdCapKhenThuongNavigation)
                    .Include(item => item.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                    .Include(item => item.IdPhuongThucKhenThuongNavigation)
                    .Include(item => item.IdThiDuaGiaiThuongKhenThuongNavigation)
                    .Where(item => string.IsNullOrEmpty(IDCB) || item.IdCanBo.ToString() == IDCB)
                    .ToList();

                var sapXepDanhSach = danhSach;

                if (SapXep == "SapXep")
                {
                    sapXepDanhSach = danhSach.OrderBy(x => x.NamKhenThuong).ToList();
                }

                ViewBag.KqTimKiem = danhSach;
                ViewBag.KqSapXep = sapXepDanhSach;

                return View(sapXepDanhSach);
            }

        public IActionResult Delete(int id)
        {
            var cb = _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Find(id);
            if (cb == null)
            {
                return NotFound();
            }
            return View(cb);
        }
        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdCapKhenThuongNavigation)
                .Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdPhuongThucKhenThuongNavigation)
                .Include(t => t.IdThiDuaGiaiThuongKhenThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo == id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo == null)
            {
                return NotFound();
            }

            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong");
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong");
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong");
            ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong");
            return View();
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo,IdCanBo,LoaiDanhHieuThiDuaGiaiThuongKhenThuong,ThiDuaGiaiThuongKhenThuong,SoQuyetDinh,PhuongThucKhenThuong,NamKhenThuong,CapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdCanBo);
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdCapKhenThuong);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdPhuongThucKhenThuong);
            ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdThiDuaGiaiThuongKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.FindAsync(id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdCanBo);
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdCapKhenThuong);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdPhuongThucKhenThuong);
            ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdThiDuaGiaiThuongKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo,IdCanBo,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdThiDuaGiaiThuongKhenThuong,SoQuyetDinh,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo)
        {
            if (id != tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhHieuThiDuaGiaiThuongKhenThuongCanBoExists(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdCanBo);
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdCapKhenThuong);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdPhuongThucKhenThuong);
            ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdThiDuaGiaiThuongKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        }

        //// GET: DanhHieuThiDuaGiaiThuongKhenThuongCanBo/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos
        //        .Include(t => t.IdCanBoNavigation)
        //        .Include(t => t.IdCapKhenThuongNavigation)
        //        .Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
        //        .Include(t => t.IdPhuongThucKhenThuongNavigation)
        //        .Include(t => t.IdThiDuaGiaiThuongKhenThuongNavigation)
        //        .FirstOrDefaultAsync(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo == id);
        //    if (tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.FindAsync(id);
        //    if (tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo != null)
        //    {
        //        _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Remove(tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tkb = _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Find(id);
            if (tkb != null)
            {
                _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Remove(tkb);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        private bool TbDanhHieuThiDuaGiaiThuongKhenThuongCanBoExists(int id)
        {
            return _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo == id);
        }
       

    }
}