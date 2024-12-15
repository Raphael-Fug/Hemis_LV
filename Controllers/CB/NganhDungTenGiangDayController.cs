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
    public class NganhDungTenGiangDayController : Controller
    {
        private readonly HemisContext _context; //Kiem tra thong tin dau vao

        public NganhDungTenGiangDayController(HemisContext context)
        {
            _context = context;
        }

        // GET: NganhDungTenGiangDay
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNganhDungTenGiangDays.Include(t => t.IdCanBoNavigation).Include(t => t.IdNganhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NganhDungTenGiangDay/Details/5
        public async Task<IActionResult> Details(int? id) //Xem chi tiet thong tin 
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNganhDungTenGiangDay = await _context.TbNganhDungTenGiangDays
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNganhDungTenGiangDay == id);
            if (tbNganhDungTenGiangDay == null)
            {
                return NotFound();
            }

            return View(tbNganhDungTenGiangDay);
        }

        // GET: NganhDungTenGiangDay/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            return View();
        }

        // POST: NganhDungTenGiangDay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNganhDungTenGiangDay,IdCanBo,IdNganhDaoTao,TrongSo,TenCanBo,TenNganhGiangDay,NgayBatDau,NgayKetThuc")] TbNganhDungTenGiangDay tbNganhDungTenGiangDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNganhDungTenGiangDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbNganhDungTenGiangDay.IdCanBo);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNganhDungTenGiangDay.IdNganhDaoTao);
            return View(tbNganhDungTenGiangDay);
        }

        // GET: NganhDungTenGiangDay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNganhDungTenGiangDay = await _context.TbNganhDungTenGiangDays.FindAsync(id);
            if (tbNganhDungTenGiangDay == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbNganhDungTenGiangDay.IdCanBo);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNganhDungTenGiangDay.IdNganhDaoTao);
            return View(tbNganhDungTenGiangDay);
        }

        // POST: NganhDungTenGiangDay/Edit/5
        // To protect from overposting attack
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNganhDungTenGiangDay,IdCanBo,IdNganhDaoTao,TrongSo,TenCanBo,TenNganhGiangDay,NgayBatDau,NgayKetThuc")] TbNganhDungTenGiangDay tbNganhDungTenGiangDay)
        {
            if (id != tbNganhDungTenGiangDay.IdNganhDungTenGiangDay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNganhDungTenGiangDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNganhDungTenGiangDayExists(tbNganhDungTenGiangDay.IdNganhDungTenGiangDay))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbNganhDungTenGiangDay.IdCanBo);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNganhDungTenGiangDay.IdNganhDaoTao);
            return View(tbNganhDungTenGiangDay);
        }

        // GET: NganhDungTenGiangDay/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNganhDungTenGiangDay = await _context.TbNganhDungTenGiangDays
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdNganhDungTenGiangDay == id);
            if (tbNganhDungTenGiangDay == null)
            {
                return NotFound();
            }

            return View(tbNganhDungTenGiangDay);
        }

        // POST: NganhDungTenGiangDay/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNganhDungTenGiangDay = await _context.TbNganhDungTenGiangDays.FindAsync(id);
            if (tbNganhDungTenGiangDay != null)
            {
                _context.TbNganhDungTenGiangDays.Remove(tbNganhDungTenGiangDay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNganhDungTenGiangDayExists(int id)
        {
            return _context.TbNganhDungTenGiangDays.Any(e => e.IdNganhDungTenGiangDay == id);
        }
    }
}
