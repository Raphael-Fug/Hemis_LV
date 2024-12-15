using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
//PHẠM XUÂN LONG LÀM VÀ COMMIT..
namespace C500Hemis.Controllers.HTQT
{
    public class TbDeAnDuAnChuongTrinhsController : Controller
    {
        private readonly HemisContext _context;

        public TbDeAnDuAnChuongTrinhsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbDeAnDuAnChuongTrinhs
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbDeAnDuAnChuongTrinhs.Include(t => t.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: TbDeAnDuAnChuongTrinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs
                    .Include(t => t.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation)
                    .FirstOrDefaultAsync(m => m.IdDeAnDuAnChuongTrinh == id);
                if (tbDeAnDuAnChuongTrinh == null)
                {
                    return NotFound();
                }

                return View(tbDeAnDuAnChuongTrinh);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: TbDeAnDuAnChuongTrinhs/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "NguonKinhPhiChoDeAn");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: TbDeAnDuAnChuongTrinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDeAnDuAnChuongTrinh,MaDeAnDuAnChuongTrinh,TenDeAnDuAnChuongTrinh,NoiDungTomTat,MucTieu,ThoiGianHopTacTu,ThoiGianHopTacDen,TongKinhPhi,IdNguonKinhPhiDeAnDuAnChuongTrinh")] TbDeAnDuAnChuongTrinh tbDeAnDuAnChuongTrinh)
        {
            try
            {
                //kiểm tra id đã tồn tại
                if (TbDeAnDuAnChuongTrinhExists(tbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh)) ModelState.AddModelError("IdDeAnDuAnChuongTrinh", "ID đã tồn tại");


                if (ModelState.IsValid)
                {
                    _context.Add(tbDeAnDuAnChuongTrinh);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "NguonKinhPhiChoDeAn", tbDeAnDuAnChuongTrinh.IdNguonKinhPhiDeAnDuAnChuongTrinh);
                return View(tbDeAnDuAnChuongTrinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: TbDeAnDuAnChuongTrinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs.FindAsync(id);
                if (tbDeAnDuAnChuongTrinh == null)
                {
                    return NotFound();
                }
                ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "NguonKinhPhiChoDeAn", tbDeAnDuAnChuongTrinh.IdNguonKinhPhiDeAnDuAnChuongTrinh);
                return View(tbDeAnDuAnChuongTrinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: TbDeAnDuAnChuongTrinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDeAnDuAnChuongTrinh,MaDeAnDuAnChuongTrinh,TenDeAnDuAnChuongTrinh,NoiDungTomTat,MucTieu,ThoiGianHopTacTu,ThoiGianHopTacDen,TongKinhPhi,IdNguonKinhPhiDeAnDuAnChuongTrinh")] TbDeAnDuAnChuongTrinh tbDeAnDuAnChuongTrinh)
        {
            //khối lệnh trong try là khối lệnh cần bắt lỗi khi khối lệnh đó có lỗi sẽ chuyển vào catch 
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbDeAnDuAnChuongTrinh);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbDeAnDuAnChuongTrinhExists(tbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh))
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
                ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "NguonKinhPhiChoDeAn", tbDeAnDuAnChuongTrinh.IdNguonKinhPhiDeAnDuAnChuongTrinh);
                return View(tbDeAnDuAnChuongTrinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: TbDeAnDuAnChuongTrinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs
                    .Include(t => t.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation)
                    .FirstOrDefaultAsync(m => m.IdDeAnDuAnChuongTrinh == id);
                if (tbDeAnDuAnChuongTrinh == null)
                {
                    return NotFound();
                }

                return View(tbDeAnDuAnChuongTrinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: TbDeAnDuAnChuongTrinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs.FindAsync(id);
                if (tbDeAnDuAnChuongTrinh != null)
                {
                    _context.TbDeAnDuAnChuongTrinhs.Remove(tbDeAnDuAnChuongTrinh);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool TbDeAnDuAnChuongTrinhExists(int id)
        {
            return _context.TbDeAnDuAnChuongTrinhs.Any(e => e.IdDeAnDuAnChuongTrinh == id);
        }
    }
}
