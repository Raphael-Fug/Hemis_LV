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
    public class PhongThucHanhController : Controller
    {
        private readonly HemisContext _context;

        public PhongThucHanhController(HemisContext context)
        {
            _context = context;
        }

        // GET: PhongThucHanh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbPhongThucHanhs.Include(t => t.IdCongTrinhCsvcNavigation).Include(t => t.IdLinhVucNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: PhongThucHanh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongThucHanh = await _context.TbPhongThucHanhs
                .Include(t => t.IdCongTrinhCsvcNavigation)
                .Include(t => t.IdLinhVucNavigation)
                .FirstOrDefaultAsync(m => m.IdPhongThucHanh == id);
            if (tbPhongThucHanh == null)
            {
                return NotFound();
            }

            return View(tbPhongThucHanh);
        }

        // GET: PhongThucHanh/Create
        public IActionResult Create()
        {
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat");
            ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu");
            return View();
        }

        // POST: PhongThucHanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhongThucHanh,IdCongTrinhCsvc,IdLinhVuc,MucDoDapUngNhuCauNckh,NamDuaVaoSuDung")] TbPhongThucHanh tbPhongThucHanh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tbPhongThucHanh);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbPhongThucHanh.IdCongTrinhCsvc);
                ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbPhongThucHanh.IdLinhVuc);
                return View(tbPhongThucHanh);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Đã xảy ra lỗi khi nhập STT. Vui lòng thử lại." }); ;
            }
        }

        // GET: PhongThucHanh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongThucHanh = await _context.TbPhongThucHanhs.FindAsync(id);
            if (tbPhongThucHanh == null)
            {
                return NotFound();
            }
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbPhongThucHanh.IdCongTrinhCsvc);
            ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbPhongThucHanh.IdLinhVuc);
            return View(tbPhongThucHanh);
        }

        // POST: PhongThucHanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhongThucHanh,IdCongTrinhCsvc,IdLinhVuc,MucDoDapUngNhuCauNckh,NamDuaVaoSuDung")] TbPhongThucHanh tbPhongThucHanh)
        {
            if (id != tbPhongThucHanh.IdPhongThucHanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPhongThucHanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPhongThucHanhExists(tbPhongThucHanh.IdPhongThucHanh))
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
            ViewData["IdCongTrinhCsvc"] = new SelectList(_context.TbCongTrinhCoSoVatChats, "IdCongTrinhCoSoVatChat", "IdCongTrinhCoSoVatChat", tbPhongThucHanh.IdCongTrinhCsvc);
            ViewData["IdLinhVuc"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbPhongThucHanh.IdLinhVuc);
            return View(tbPhongThucHanh);
        }

        // GET: PhongThucHanh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhongThucHanh = await _context.TbPhongThucHanhs
                .Include(t => t.IdCongTrinhCsvcNavigation)
                .Include(t => t.IdLinhVucNavigation)
                .FirstOrDefaultAsync(m => m.IdPhongThucHanh == id);
            if (tbPhongThucHanh == null)
            {
                return NotFound();
            }

            return View(tbPhongThucHanh);
        }

        // POST: PhongThucHanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPhongThucHanh = await _context.TbPhongThucHanhs.FindAsync(id);
            if (tbPhongThucHanh != null)
            {
                _context.TbPhongThucHanhs.Remove(tbPhongThucHanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPhongThucHanhExists(int id)
        {
            return _context.TbPhongThucHanhs.Any(e => e.IdPhongThucHanh == id);
        }
    }
}
