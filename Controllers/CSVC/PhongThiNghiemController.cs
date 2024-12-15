using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSVC
{
    public class PhongThiNghiemController : Controller
    {
        private readonly HemisContext _context;

        public PhongThiNghiemController(HemisContext context)
        {
            _context = context;
        }

        // GET: PhongThiNghiem
        public async Task<IActionResult> Index()
        {

            var hemisContext = _context.TbPhongThiNghiems.Include(t => t.IdCongTrinhCsvcNavigation).Include(t => t.IdLinhVucNavigation).Include(t => t.IdLoaiPhongThiNghiemNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: PhongThiNghiem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongThiNghiem = await _context.TbPhongThiNghiems
                .Include(t => t.IdCongTrinhCsvcNavigation)
                .Include(t => t.IdLinhVucNavigation)
                .Include(t => t.IdLoaiPhongThiNghiemNavigation)
                .FirstOrDefaultAsync(m => m.IdPhongThiNghiem == id);
            if (tbPhongThiNghiem == null)
            {
                return NotFound();
            }

            return View(tbPhongThiNghiem);
        }

        // GET: PhongThiNghiem/Create
        public IActionResult Create()
        {
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat");
            ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu");
            ViewData["IdLoaiPhongThiNghiem"] = new SelectList(_context.DmLoaiPhongThiNghiems, "IdLoaiPhongThiNghiem", "LoaiPhongThiNghiem");
            return View();
        }

        // POST: PhongThiNghiem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhongThiNghiem,IdCongTrinhCsvc,IdLoaiPhongThiNghiem,IdLinhVuc,MucDoDapUngNhuCauNckh,NamDuaVaoSuDung")] TbPhongThiNghiem tbPhongThiNghiem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tbPhongThiNghiem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbPhongThiNghiem.IdCongTrinhCsvc);
                ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbPhongThiNghiem.IdLinhVuc);
                ViewData["IdLoaiPhongThiNghiem"] = new SelectList(_context.DmLoaiPhongThiNghiems, "IdLoaiPhongThiNghiem", "IdLoaiPhongThiNghiem", tbPhongThiNghiem.IdLoaiPhongThiNghiem);
                return View(tbPhongThiNghiem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Đã xảy ra lỗi khi nhập STT. Vui lòng thử lại." }); ;
            }
        }

        // GET: PhongThiNghiem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongThiNghiem = await _context.TbPhongThiNghiems.FindAsync(id);
            if (tbPhongThiNghiem == null)
            {
                return NotFound();
            }
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbPhongThiNghiem.IdCongTrinhCsvc);
            ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbPhongThiNghiem.IdLinhVuc);
            ViewData["IdLoaiPhongThiNghiem"] = new SelectList(_context.DmLoaiPhongThiNghiems, "IdLoaiPhongThiNghiem", "LoaiPhongThiNghiem", tbPhongThiNghiem.IdLoaiPhongThiNghiem);
            return View(tbPhongThiNghiem);
        }

        // POST: PhongThiNghiem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhongThiNghiem,IdCongTrinhCsvc,IdLoaiPhongThiNghiem,IdLinhVuc,MucDoDapUngNhuCauNckh,NamDuaVaoSuDung")] TbPhongThiNghiem tbPhongThiNghiem)
        {
            if (id != tbPhongThiNghiem.IdPhongThiNghiem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPhongThiNghiem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPhongThiNghiemExists(tbPhongThiNghiem.IdPhongThiNghiem))
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
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbPhongThiNghiem.IdCongTrinhCsvc);
            ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbPhongThiNghiem.IdLinhVuc);
            ViewData["IdLoaiPhongThiNghiem"] = new SelectList(_context.DmLoaiPhongThiNghiems, "IdLoaiPhongThiNghiem", "IdLoaiPhongThiNghiem", tbPhongThiNghiem.IdLoaiPhongThiNghiem);
            return View(tbPhongThiNghiem);
        }

        // GET: PhongThiNghiem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongThiNghiem = await _context.TbPhongThiNghiems
                .Include(t => t.IdCongTrinhCsvcNavigation)
                .Include(t => t.IdLinhVucNavigation)
                .Include(t => t.IdLoaiPhongThiNghiemNavigation)
                .FirstOrDefaultAsync(m => m.IdPhongThiNghiem == id);
            if (tbPhongThiNghiem == null)
            {
                return NotFound();
            }

            return View(tbPhongThiNghiem);
        }

        // POST: PhongThiNghiem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPhongThiNghiem = await _context.TbPhongThiNghiems.FindAsync(id);
            if (tbPhongThiNghiem != null)
            {
                _context.TbPhongThiNghiems.Remove(tbPhongThiNghiem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPhongThiNghiemExists(int id)
        {
            return _context.TbPhongThiNghiems.Any(e => e.IdPhongThiNghiem == id);
        }
    }
}
