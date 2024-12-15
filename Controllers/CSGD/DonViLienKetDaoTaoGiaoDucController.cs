using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSGD
{
    public class DonViLienKetDaoTaoGiaoDucController : Controller
    {
        private readonly HemisContext _context;

        public DonViLienKetDaoTaoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: DonViLienKetDaoTaoGiaoDuc
        // GET: DonViLienKetDaoTaoGiaoDuc
        // GET: DonViLienKetDaoTaoGiaoDuc
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                ViewData["CurrentFilter"] = searchString;
                // Lấy tất cả các dữ liệu từ Biến hemisContext (là nơi lưu trữ tất cả các bản ghi liên kết đào tạo giáo dục)
                var hemisContext = _context.TbDonViLienKetDaoTaoGiaoDucs
                                          //Đây là cách để lấy dữ liệu chi tiết từ bảng khác thông qua khóa ngoại.
                                          .Include(t => t.IdCoSoGiaoDucNavigation)
                                          .Include(t => t.IdLoaiLienKetNavigation)
                                          .AsQueryable(); // Chuyển về IQueryable để có thể thêm các điều kiện Where sau đó

                // Nếu có từ khóa tìm kiếm, lọc kết quả
                if (!string.IsNullOrEmpty(searchString))
                {
                    // Kiểm tra xem searchString có thể là số nguyên hay không (ktra IdCoSoGiaoDuc)
                    if (int.TryParse(searchString, out int idCoSoGiaoDuc))
                    {
                        // Sử dụng phép so sánh trực tiếp cho số nguyên
                        hemisContext = hemisContext.Where(d => d.IdCoSoGiaoDuc == idCoSoGiaoDuc);
                    }
                    else
                    {
                        // Nếu không phải số, tìm kiếm theo các cột khác (chuỗi)
                        //where Nó giúp chỉ lấy những bản ghi nào thỏa mãn điều kiện được chỉ định.
                        hemisContext = hemisContext.Where(d => d.DiaChi.Contains(searchString)
                                                            || d.DienThoai.Contains(searchString)
                                                            || d.IdLoaiLienKetNavigation.LoaiLienKet.Contains(searchString));
                    }
                }

                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // GET: DonViLienKetDaoTaoGiaoDuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs
                    .Include(t => t.IdCoSoGiaoDucNavigation)
                    .Include(t => t.IdLoaiLienKetNavigation)
                    .FirstOrDefaultAsync(m => m.IdDonViLienKetDaoTaoGiaoDuc == id);
                if (tbDonViLienKetDaoTaoGiaoDuc == null)
                {
                    return NotFound();
                }

                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "TenDonVi");
                ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "LoaiLienKet");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: DonViLienKetDaoTaoGiaoDuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDonViLienKetDaoTaoGiaoDuc,IdCoSoGiaoDuc,DiaChi,DienThoai,IdLoaiLienKet")] TbDonViLienKetDaoTaoGiaoDuc tbDonViLienKetDaoTaoGiaoDuc)
        {
            try
            {
                if (TbDonViLienKetDaoTaoGiaoDucExists(tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc)) ModelState.AddModelError("IdDonViLienKetDaoTaoGiaoDuc", "Đã tồn tại Id này!");
                if (ModelState.IsValid)
                {
                    _context.Add(tbDonViLienKetDaoTaoGiaoDuc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "TenDonVi", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
                ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "LoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs.FindAsync(id);
                if (tbDonViLienKetDaoTaoGiaoDuc == null)
                {
                    return NotFound();
                }
                ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "TenDonVi", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
                ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "LoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: DonViLienKetDaoTaoGiaoDuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonViLienKetDaoTaoGiaoDuc,IdCoSoGiaoDuc,DiaChi,DienThoai,IdLoaiLienKet")] TbDonViLienKetDaoTaoGiaoDuc tbDonViLienKetDaoTaoGiaoDuc)
        {
            try
            {
                if (id != tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbDonViLienKetDaoTaoGiaoDuc);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbDonViLienKetDaoTaoGiaoDucExists(tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc))
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
                ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "TenDonVi", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
                ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "LoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs
                    .Include(t => t.IdCoSoGiaoDucNavigation)
                    .Include(t => t.IdLoaiLienKetNavigation)
                    .FirstOrDefaultAsync(m => m.IdDonViLienKetDaoTaoGiaoDuc == id);
                if (tbDonViLienKetDaoTaoGiaoDuc == null)
                {
                    return NotFound();
                }

                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: DonViLienKetDaoTaoGiaoDuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs.FindAsync(id);
                if (tbDonViLienKetDaoTaoGiaoDuc != null)
                {
                    _context.TbDonViLienKetDaoTaoGiaoDucs.Remove(tbDonViLienKetDaoTaoGiaoDuc);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool TbDonViLienKetDaoTaoGiaoDucExists(int id)
        {
            return _context.TbDonViLienKetDaoTaoGiaoDucs.Any(e => e.IdDonViLienKetDaoTaoGiaoDuc == id);
        }
    }
}
