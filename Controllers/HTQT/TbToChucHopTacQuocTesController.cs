using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.HTQT
{
    public class TbToChucHopTacQuocTesController : Controller
    {
        private readonly HemisContext _context;

        public TbToChucHopTacQuocTesController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbToChucHopTacQuocTes
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbToChucHopTacQuocTes.Include(t => t.IdQuocGiaNavigation);
            var totalRecords = await hemisContext.CountAsync(); // Đếm tổng số bản ghi
            ViewBag.TotalRecords = totalRecords;

            return View(await hemisContext.ToListAsync());
        }


        // GET: TbToChucHopTacQuocTes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucHopTacQuocTe = await _context.TbToChucHopTacQuocTes
                .Include(t => t.IdQuocGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdToChucHopTacQuocTe == id);
            if (tbToChucHopTacQuocTe == null)
            {
                return NotFound();
            }

            return View(tbToChucHopTacQuocTe);
        }

        // GET: TbToChucHopTacQuocTes/Create
        public IActionResult Create()
        {
            ViewData["IdQuocGia"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc");  //: kHÓA nGOẠI

            ViewData["IdHinhThucHopTac"] = new SelectList(_context.DmHinhThucHopTacs, "IdHinhThucHopTac", "HinhThucHopTac"); // Adjust the fields as necessary
            return View();
        }

        // POST: TbToChucHopTacQuocTes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdToChucHopTacQuocTe,MaHopTac,TenToChuc,IdQuocGia,NoiDung,ThoiGianKyKet,KetQuaHopTac,LoaiToChuc")] TbToChucHopTacQuocTe tbToChucHopTacQuocTe)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tbToChucHopTacQuocTe);                                       // Try catch: Bắt lỗi trùng ID
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "ID này đã tồn tại rồi. Bạn vui lòng nhập ID khác  ");
                }

            }
            else
            {
                var error1 = ModelState.Values.SelectMany(h => h.Errors);
                foreach (var error in error1)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }
            ViewData["IdQuocGia"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbToChucHopTacQuocTe.IdQuocGia);



            ViewData["IdHinhThucHopTac"] = new SelectList(_context.DmHinhThucHopTacs, "IdHinhThucHopTac", "HinhThucHopTac");
            return View(tbToChucHopTacQuocTe);
        }

        // GET: TbToChucHopTacQuocTes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucHopTacQuocTe = await _context.TbToChucHopTacQuocTes.FindAsync(id);
            if (tbToChucHopTacQuocTe == null)
            {
                return NotFound();
            }
            ViewData["IdQuocGia"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbToChucHopTacQuocTe.IdQuocGia);
            return View(tbToChucHopTacQuocTe);
        }

        // POST: TbToChucHopTacQuocTes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdToChucHopTacQuocTe,MaHopTac,TenToChuc,IdQuocGia,NoiDung,ThoiGianKyKet,KetQuaHopTac,LoaiToChuc")] TbToChucHopTacQuocTe tbToChucHopTacQuocTe)
        {
            if (id != tbToChucHopTacQuocTe.IdToChucHopTacQuocTe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbToChucHopTacQuocTe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbToChucHopTacQuocTeExists(tbToChucHopTacQuocTe.IdToChucHopTacQuocTe))
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
            ViewData["IdQuocGia"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbToChucHopTacQuocTe.IdQuocGia);
            return View(tbToChucHopTacQuocTe);
        }

        // GET: TbToChucHopTacQuocTes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbToChucHopTacQuocTe = await _context.TbToChucHopTacQuocTes
                .Include(t => t.IdQuocGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdToChucHopTacQuocTe == id);
            if (tbToChucHopTacQuocTe == null)
            {
                return NotFound();
            }

            return View(tbToChucHopTacQuocTe);
        }

        // POST: TbToChucHopTacQuocTes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbToChucHopTacQuocTe = await _context.TbToChucHopTacQuocTes.FindAsync(id);
            if (tbToChucHopTacQuocTe != null)
            {
                _context.TbToChucHopTacQuocTes.Remove(tbToChucHopTacQuocTe);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool TbToChucHopTacQuocTeExists(int id)
        {
            return _context.TbToChucHopTacQuocTes.Any(e => e.IdToChucHopTacQuocTe == id);
        }
    }
}
