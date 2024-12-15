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
    public class TbGvduocCuDiDaoTaosController : Controller
    {
        private readonly HemisContext _context;

        public TbGvduocCuDiDaoTaosController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbGvduocCuDiDaoTaos
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGvduocCuDiDaoTaos.Include(t => t.IdCanBoNavigation).Include(t => t.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation).Include(t => t.IdNguonKinhPhiCuaGvNavigation).Include(t => t.IdQuocGiaDenNavigation).Include(t => t.IdTinhTrangGvduocCuDiDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbGvduocCuDiDaoTaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation)
                .Include(t => t.IdNguonKinhPhiCuaGvNavigation)
                .Include(t => t.IdQuocGiaDenNavigation)
                .Include(t => t.IdTinhTrangGvduocCuDiDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGvduocCuDiDaoTao == id);
            if (tbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGvduocCuDiDaoTao);
        }
        // Tao trang moi de hien thi cac chuc nang nguoi dung nhap vao
        // GET: TbGvduocCuDiDaoTaos/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "HinhThucThamGiaGvduocCuDiDaoTao");
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "NguonKinhPhiCuaGvduocCuDiDaoTao");
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc");
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "TinhTrangGiangVienDuocCuDiDaoTao");
            return View();
        }
        // Kiem tra tinh hop le cua du lieu dau vao roi them ban ghi vao csdl
        // POST: TbGvduocCuDiDaoTaos/Create 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: TbGvduocCuDiDaoTaos/Create
        // POST: TbGvduocCuDiDaoTaos/Create
        // POST: TbGvduocCuDiDaoTaos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGvduocCuDiDaoTao,IdCanBo,IdHinhThucThamGiaGvduocCuDiDaoTao,IdQuocGiaDen,TenCoSoGiaoDucThamGiaOnn,ThoiGianBatDau,ThoiGianKetThuc,IdTinhTrangGvduocCuDiDaoTao,IdNguonKinhPhiCuaGv")] TbGvduocCuDiDaoTao tbGvduocCuDiDaoTao)
        {
            //Đoạn này kiểm tra xem các dữ liệu mà người dùng gửi lên có hợp lệ hay không. Nếu không hợp lệ, mã sẽ không thực hiện các bước tiếp theo.
            if (ModelState.IsValid)
            {
                // Kiểm tra trùng lặp IdCanBo trước khi thêm vào context
                //Ở đây, mã kiểm tra xem IdCanBo đã tồn tại trong cơ sở dữ liệu hay chưa. Nếu đã tồn tại, một lỗi sẽ được thêm vào ModelState.
                bool isDuplicateIdCanBo = await _context.TbGvduocCuDiDaoTaos.AnyAsync(x => x.IdCanBo == tbGvduocCuDiDaoTao.IdCanBo);
                if (isDuplicateIdCanBo)
                {
                    //Nếu isDuplicateIdCanBo là true, một thông báo lỗi sẽ được thêm vào ModelState, thông báo cho người dùng rằng IdCanBo đã tồn tại.
                    ModelState.AddModelError("IdCanBo", "Giáo viên với IdCanBo này đã tồn tại. Vui lòng chọn một IdCanBo khác.");

                    // Đưa dữ liệu cần thiết vào ViewData trước khi quay lại View
                    ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGvduocCuDiDaoTao.IdCanBo);
                    ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "HinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
                    ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "NguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
                    ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbGvduocCuDiDaoTao.IdQuocGiaDen);
                    ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "TinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);

                    // Quay lại View với thông báo lỗi
                    return View(tbGvduocCuDiDaoTao);
                }

                try
                {
                    //Trong khối try, mã sẽ thêm đối tượng vào cơ sở dữ liệu và lưu thay đổi. Nếu thành công, nó sẽ chuyển hướng người dùng đến phương thức Index.
                    //Nếu có lỗi trong quá trình lưu một ngoại lệ DbUpdateException sẽ được ném ra. Trong khối catch, mã sẽ thêm một thông báo lỗi vào ModelState, thông báo cho người dùng về sự cố đã xảy ra khi lưu dữ liệu.
                    _context.Add(tbGvduocCuDiDaoTao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Đã xảy ra lỗi khi lưu. Vui lòng kiểm tra lại dữ liệu và thử lại.");
                }
            }

            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGvduocCuDiDaoTao.IdCanBo);
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "HinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "NguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbGvduocCuDiDaoTao.IdQuocGiaDen);
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "TinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);

            return View(tbGvduocCuDiDaoTao);
        }

        // GET: TbGvduocCuDiDaoTaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos.FindAsync(id);
            if (tbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGvduocCuDiDaoTao.IdCanBo);
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "HinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "NguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbGvduocCuDiDaoTao.IdQuocGiaDen);
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "TinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);
            return View(tbGvduocCuDiDaoTao);
        }

        // POST: TbGvduocCuDiDaoTaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGvduocCuDiDaoTao,IdCanBo,IdHinhThucThamGiaGvduocCuDiDaoTao,IdQuocGiaDen,TenCoSoGiaoDucThamGiaOnn,ThoiGianBatDau,ThoiGianKetThuc,IdTinhTrangGvduocCuDiDaoTao,IdNguonKinhPhiCuaGv")] TbGvduocCuDiDaoTao tbGvduocCuDiDaoTao)
        { // Kiểm tra xem ID có hợp lệ không
            if (id != tbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao)
            {
                return NotFound();
            }
            // Kiểm tra tính hợp lệ của mô hình
            if (ModelState.IsValid)
            {
                try
                {
                    // Cập nhật mô hình
                    _context.Update(tbGvduocCuDiDaoTao);
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                    return RedirectToAction(nameof(Index)); // Quay lại trang danh sách
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý trường hợp có lỗi cập nhật
                    if (!TbGvduocCuDiDaoTaoExists(tbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    // Bắt lỗi cập nhật cơ sở dữ liệu
                    ModelState.AddModelError("", "Không thể lưu thay đổi. Vui lòng kiểm tra dữ liệu nhập vào.");
                    return View(tbGvduocCuDiDaoTao); // Quay lại view với thông báo lỗi
                }
                return RedirectToAction(nameof(Index));
            }
        
        
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdNguoi", tbGvduocCuDiDaoTao.IdCanBo);
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "HinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "NguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbGvduocCuDiDaoTao.IdQuocGiaDen);
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "TinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);
            return View(tbGvduocCuDiDaoTao);
        }
        // lay thong tin cua ban ghi can xoa
        // GET: TbGvduocCuDiDaoTaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation)
                .Include(t => t.IdNguonKinhPhiCuaGvNavigation)
                .Include(t => t.IdQuocGiaDenNavigation)
                .Include(t => t.IdTinhTrangGvduocCuDiDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGvduocCuDiDaoTao == id);
            if (tbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGvduocCuDiDaoTao);
        }
        // xoa ban ghi khoi csdl khi xac nhan
        // POST: TbGvduocCuDiDaoTaos/Delete/5
        // su dung [HttpPost, ActionName("Delete")] de goi DeleteConfirmed tranh xoa ngau nhien
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos.FindAsync(id);
            if (tbGvduocCuDiDaoTao != null)
            {
                _context.TbGvduocCuDiDaoTaos.Remove(tbGvduocCuDiDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGvduocCuDiDaoTaoExists(int id)
        {
            return _context.TbGvduocCuDiDaoTaos.Any(e => e.IdGvduocCuDiDaoTao == id);
        }
    }
}

