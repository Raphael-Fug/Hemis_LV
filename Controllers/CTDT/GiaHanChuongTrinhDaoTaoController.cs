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
    public class GiaHanChuongTrinhDaoTaoController : Controller
    {
        // Khởi tạo biến ngữ cảnh cơ sở dữ liệu
        private readonly HemisContext _context;
        // Hàm dựng (constructor) để khởi tạo controller với ngữ cảnh cơ sở dữ liệu
        public GiaHanChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách các chương trình đào tạo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGiaHanChuongTrinhDaoTaos.Include(t => t.IdChuongTrinhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: GiaHanChuongTrinhDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //kiểm tra xem id có null hay không
            if (id == null)
            {
                return NotFound();
            }
            // Lấy thông tin chương trình đào tạo dựa trên ID từ cơ sở dữ liệu
            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaHanChuongTrinhDaoTao == id);
            // Nếu không tìm thấy chương trình, trả về trang lỗi 404
            if (tbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGiaHanChuongTrinhDaoTao);
        }

        //hiển thị form create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh");
            return View();
        }

        // POST: GiaHanChuongTrinhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGiaHanChuongTrinhDaoTao,IdChuongTrinhDaoTao,SoQuyetDinhGiaHan,NgayBanHanhVanBanGiaHan,GiaHanLanThu")] TbGiaHanChuongTrinhDaoTao tbGiaHanChuongTrinhDaoTao)
        {
            // Kiểm tra nếu dữ liệu hợp lệ
            if (ModelState.IsValid)
            {
                try
                {

                    if (tbGiaHanChuongTrinhDaoTao.GiaHanLanThu <= 0)
                    {
                        ModelState.AddModelError("GiaHanLanThu", "Vui lòng nhập số dương");
                    }
                    //thêm đối tượng vào context
                    _context.Add(tbGiaHanChuongTrinhDaoTao);
                    //lưu thay đổi
                    await _context.SaveChangesAsync();
                    //chuyển hướng về index sau khi lưu thành công
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //bắt lỗi khi lưu dữ liệu. Mỗi lỗi sẽ được thêm vào modelstate
                    ModelState.AddModelError("", "Đã có lỗi xảy ra. Vui lòng thử lại");
                }
            }
            
            //tạo lại Selectlist cho view trong trường hợp dữ liệu không hợp lệ
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbGiaHanChuongTrinhDaoTao.IdChuongTrinhDaoTao);
            //quay lại create
            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // GET: GiaHanChuongTrinhDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos.FindAsync(id);
            if (tbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbGiaHanChuongTrinhDaoTao.IdChuongTrinhDaoTao);
            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // POST: GiaHanChuongTrinhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGiaHanChuongTrinhDaoTao,IdChuongTrinhDaoTao,SoQuyetDinhGiaHan,NgayBanHanhVanBanGiaHan,GiaHanLanThu")] TbGiaHanChuongTrinhDaoTao tbGiaHanChuongTrinhDaoTao)
        {
            if (id != tbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiaHanChuongTrinhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiaHanChuongTrinhDaoTaoExists(tbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "TenChuongTrinh", tbGiaHanChuongTrinhDaoTao.IdChuongTrinhDaoTao);
            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // GET: GiaHanChuongTrinhDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaHanChuongTrinhDaoTao == id);
            if (tbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // POST: GiaHanChuongTrinhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos.FindAsync(id);
            if (tbGiaHanChuongTrinhDaoTao != null)
            {
                _context.TbGiaHanChuongTrinhDaoTaos.Remove(tbGiaHanChuongTrinhDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiaHanChuongTrinhDaoTaoExists(int id)
        {
            return _context.TbGiaHanChuongTrinhDaoTaos.Any(e => e.IdGiaHanChuongTrinhDaoTao == id);
        }
    }
}
