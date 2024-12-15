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
    public class LinhVucNghienCuuCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public LinhVucNghienCuuCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: LinhVucNghienCuuCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbLinhVucNghienCuuCuaCanBos.Include(t => t.IdCanBoNavigation).ThenInclude(human => human.IdNguoiNavigation).Include(t => t.IdLinhVucNghienCuuNavigation);
            return View(await hemisContext.ToListAsync());
        }
      
        // GET: LinhVucNghienCuuCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .FirstOrDefaultAsync(m => m.IdLinhVucNghienCuuCuaCanBo == id);
            if (tbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }
            ViewBag.Hoten = _context.TbNguois.FirstOrDefault(p => p.IdNguoi == tbLinhVucNghienCuuCuaCanBo.IdCanBoNavigation.IdNguoi).Ho;
            return View(tbLinhVucNghienCuuCuaCanBo);
        }


        /// <summary>
        /// Hàm khởi tạo dữ liệu lĩnh vực nghiên cứu của cán bộ 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            //Lấy danh sách cán bộ truyền cho selectbox cán bộ bên view
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(t => t.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name");

            //Lấy danh sách linh vực nghiên cứu, hiện thị cụ thể lĩnh vực nghiên cứu
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu");
            return View();
        }
        // POST: LinhVucNghienCuuCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLinhVucNghienCuuCuaCanBo,IdCanBo,IdLinhVucNghienCuu,LaLinhVucNghienCuuChuyenSau,SoNamNghienCuu")] TbLinhVucNghienCuuCuaCanBo tbLinhVucNghienCuuCuaCanBo)
        {
            // Kiểm tra dữ liệu có chuẩn không
            // Đối sánh với lớp tbLinhVucNghienCuuCuaCanBo
            if (ModelState.IsValid)
            {
                //Thêm đối tượng vào context
                _context.Add(tbLinhVucNghienCuuCuaCanBo);
                //Lưu vào CSDL
                await _context.SaveChangesAsync();
                // Nếu thành công quay về index
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbLinhVucNghienCuuCuaCanBo.IdCanBo);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuu);
            return View(tbLinhVucNghienCuuCuaCanBo);
        }
            
        /// <summary>
        /// Khởi tạo thông tin sửa dữ liệu nghiên cứu của cán bộ
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Views tạo</returns>
        // GET: LinhVucNghienCuuCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos.FindAsync(id);
            if (tbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbLinhVucNghienCuuCuaCanBo.IdCanBo);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuu);
            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // POST: LinhVucNghienCuuCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLinhVucNghienCuuCuaCanBo,IdCanBo,IdLinhVucNghienCuu,LaLinhVucNghienCuuChuyenSau,SoNamNghienCuu")] TbLinhVucNghienCuuCuaCanBo tbLinhVucNghienCuuCuaCanBo)
        {
            if (id != tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLinhVucNghienCuuCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLinhVucNghienCuuCuaCanBoExists(tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos.Include(h => h.IdNguoiNavigation), "IdCanBo", "IdNguoiNavigation.name", tbLinhVucNghienCuuCuaCanBo.IdCanBo);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuu);
            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // GET: LinhVucNghienCuuCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(t => t.IdNguoiNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .FirstOrDefaultAsync(m => m.IdLinhVucNghienCuuCuaCanBo == id);
            if (tbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // POST: LinhVucNghienCuuCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos.FindAsync(id);
            if (tbLinhVucNghienCuuCuaCanBo != null)
            {
                _context.TbLinhVucNghienCuuCuaCanBos.Remove(tbLinhVucNghienCuuCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLinhVucNghienCuuCuaCanBoExists(int id)
        {
            return _context.TbLinhVucNghienCuuCuaCanBos.Any(e => e.IdLinhVucNghienCuuCuaCanBo == id);
        }
    }
}
