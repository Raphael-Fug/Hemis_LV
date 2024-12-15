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
    public class KyLuatCanBoController : Controller
    {
        private readonly HemisContext _context;

        public KyLuatCanBoController(HemisContext context)
        {
            _context = context;
        }
        // Toàn bộ action mặc định không xuất lổi chỉ trả về BadRequest
        // GET: KyLuatCanBo
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbKyLuatCanBos.Include(t => t.IdCanBoNavigation).ThenInclude(human => human.IdNguoiNavigation).Include(t => t.IdCapQuyetDinhNavigation).Include(t => t.IdLoaiKyLuatNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: KyLuatCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbKyLuatCanBo = await _context.TbKyLuatCanBos
                    .Include(t => t.IdCanBoNavigation)
                    .ThenInclude(human => human.IdNguoiNavigation)
                    .Include(t => t.IdCapQuyetDinhNavigation)
                    .Include(t => t.IdLoaiKyLuatNavigation)
                    .FirstOrDefaultAsync(m => m.IdKyLuatCanBo == id);
                if (tbKyLuatCanBo == null)
                {
                    return NotFound();
                }

                return View(tbKyLuatCanBo);
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Hàm khởi tạo thông tin kỷ luật cán bộ
        /// phutn_8.10.2024
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            try
            {
                //Lấy danh sách cán bộ truyền cho selectbox cán bộ bên view
                ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(t => t.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name");

                //Lấy danh sách cấp quyết định, hiện thị cụ thể cấp quyết định
                ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong");

                //Lấy danh sách các loại kỷ luật, hiện thị cụ thể tên loại kỷ luật
                //8.10.2024: bổ sung theo góp ý của thầy Phú
                ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "LoaiKyLuat");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: KyLuatCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKyLuatCanBo,IdCanBo,IdLoaiKyLuat,LyDo,IdCapQuyetDinh,NgayThangNamQuyetDinh,SoQuyetDinh,NamBiKyLuat")] TbKyLuatCanBo tbKyLuatCanBo)
        {
            try
            {
                
                //Nếu đã tồn tại thì thêm Error cho IdKyLuatCanBo
                if (await existId(tbKyLuatCanBo.IdKyLuatCanBo)) ModelState.AddModelError("IdKyLuatCanBo", "Đã tồn tại Id này!");
                if (ModelState.IsValid)
                {
                    //Thêm đối tượng vào context
                    _context.Add(tbKyLuatCanBo);
                    // Lưu vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();
                    // Nếu thành công sẽ trở về trang index
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbKyLuatCanBo.IdCanBo);
                ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbKyLuatCanBo.IdCapQuyetDinh);
                ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "LoaiKyLuat", tbKyLuatCanBo.IdLoaiKyLuat);
                return View(tbKyLuatCanBo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Khởi tạo sưa thông tin kỷ luật
        /// </summary>
        /// <param name="id"> là id định danh của Kỷ luật cán bộ trong cơ sở dữ liệu </param>
        /// <returns>View khởi tạo kỷ luật cán bộ</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbKyLuatCanBo = await _context.TbKyLuatCanBos.FindAsync(id);
                if (tbKyLuatCanBo == null)
                {
                    return NotFound();
                }
                ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbKyLuatCanBo.IdCanBo);
                ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbKyLuatCanBo.IdCapQuyetDinh);
                ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "LoaiKyLuat", tbKyLuatCanBo.IdLoaiKyLuat);
                return View(tbKyLuatCanBo);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST: KyLuatCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKyLuatCanBo,IdCanBo,IdLoaiKyLuat,LyDo,IdCapQuyetDinh,NgayThangNamQuyetDinh,SoQuyetDinh,NamBiKyLuat")] TbKyLuatCanBo tbKyLuatCanBo)
        {
            try
            {
                if (id != tbKyLuatCanBo.IdKyLuatCanBo)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbKyLuatCanBo);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!(await existId(tbKyLuatCanBo.IdKyLuatCanBo)))
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
                ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbKyLuatCanBo.IdCanBo);
                ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "CapKhenThuong", tbKyLuatCanBo.IdCapQuyetDinh);
                ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "LoaiKyLuat", tbKyLuatCanBo.IdLoaiKyLuat);
                return View(tbKyLuatCanBo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: KyLuatCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbKyLuatCanBo = await _context.TbKyLuatCanBos
                    .Include(t => t.IdCanBoNavigation)
                    .ThenInclude(h => h.IdNguoiNavigation)
                    .Include(t => t.IdCapQuyetDinhNavigation)
                    .Include(t => t.IdLoaiKyLuatNavigation)
                    .FirstOrDefaultAsync(m => m.IdKyLuatCanBo == id);
                if (tbKyLuatCanBo == null)
                {
                    return NotFound();
                }

                return View(tbKyLuatCanBo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: KyLuatCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbKyLuatCanBo = await _context.TbKyLuatCanBos.FindAsync(id);
                if (tbKyLuatCanBo != null)
                {
                    _context.TbKyLuatCanBos.Remove(tbKyLuatCanBo);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        private async Task<bool> existId(int id)
        {
            //Kiểm tra đã tồn tại trong TbKyLuatCanBo chua
            TbKyLuatCanBo? cr = (await _context.TbKyLuatCanBos.SingleOrDefaultAsync(e => e.IdKyLuatCanBo == id));
            if (cr == null) return false;
            return true;
        }
    }
}
