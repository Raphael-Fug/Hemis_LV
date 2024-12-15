using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.KHCN
{
    //Các thao tác thực hiện trong Controller:
    //1. Thêm phần báo lỗi nếu như trùng id 
    //2. Hiển thị giá trị các danh mục 
    //3. Thêm Error Message cho các trường bắt buộc nhập
    //4. Thêm các khối lệnh try, catch để xử lí ngoại lệ 
    public class NhiemVuKhcnController : Controller
    {
        private readonly HemisContext _context;

        public NhiemVuKhcnController(HemisContext context)
        {
            _context = context;
        }

        // GET: NhiemVuKhcn
        // Thu thập các dữ liệu cần thiết của table TbNhiemVuKhcn để trả về hiển thị trên trang index
        public async Task<IActionResult> Index()
        {
            try //Bắt lỗi chương trình trong try nếu có 
            {
                var hemisContext = _context.TbNhiemVuKhcns.Include(t => t.IdCapQuanLyNhiemVuNavigation).Include(t => t.IdCoQuanChuQuanNavigation).Include(t => t.IdLinhVucNghienCuuNavigation).Include(t => t.IdNguonKinhPhiNavigation).Include(t => t.IdPhanLoaiNhiemVuNavigation).Include(t => t.IdTinhTrangNhiemVuNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request 400
                return BadRequest();
            }
        }

        // GET: NhiemVuKhcn/Details/5
        // Thu thập thông tin chi tiết của Hồ sơ nhiệm vụ KHCN với Id cụ thể để trả về hiện thị ở Details
        public async Task<IActionResult> Details(int? id)
        {
            try
            //Bắt lỗi chương trình trong try nếu có 
            {
                if (id == null)
                {
                    return NotFound();
                }
                //Tìm Hồ sơ nhiệm vụ cần trả về
                //Include là tìm các model cần thiết cho model TbNhiemVuKhcn 

                var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns
                    .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                    .Include(t => t.IdCoQuanChuQuanNavigation)
                    .Include(t => t.IdLinhVucNghienCuuNavigation)
                    .Include(t => t.IdNguonKinhPhiNavigation)
                    .Include(t => t.IdPhanLoaiNhiemVuNavigation)
                    .Include(t => t.IdTinhTrangNhiemVuNavigation)
                    .FirstOrDefaultAsync(m => m.IdNhiemVuKhcn == id);
                if (tbNhiemVuKhcn == null)
                {
                    return NotFound();
                }

                return View(tbNhiemVuKhcn);
            }
            // trả về HTTP Bad request HTTP 400
            catch (Exception bat_loi)
            {
                return BadRequest();
            }
        }
        //=============================================================TẠO MỚI=====================================================================================
        // GET: NhiemVuKhcn/Create 
        //Thực hiện tạo mới hồ sơ nhiệm vụ KHCN 
        public IActionResult Create()
        {
            try
            //Bắt lỗi chương trình trong try nếu có 
            {
                //SelectList phục vụ cho việc nhập dữ liệu cho các ForeignKey
                //Mô hình selectlist(List<model>, ValueField, TextField)
                //ValueField, TextField đều là tên attribute của model
                //ValueField là tên attribute cần người dùng nhập dữ liệu để lấy dữ liệu
                //TextField là tên attribute muốn hiển thị cho client
                //Vd model DmPhanCapNhiemVus thì ValueField là IdPhanCapNhiemVu tương đương DmPhanCapNhiemVus.IdPhanCapNhiemVu 
                //Sửa đổi 24/10/2024 
                //Thay đổi để nhả kết quả Phân cấp nhiệm vụ chứ không phải nhả ID thay IDPhanCapNhiemVu => PhanCapNhiemVu
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "PhanCapNhiemVu");
                //Thay đổi để nhả kết quả Cơ quan chủ quản chứ không phải nhả ID thay IDCoQuanChuQuan => CoQuanChuQuan
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "CoQuanChuQuan");
                //Thay đổi để nhả kết quả Lĩnh vực nghiên cứu chứ không phải nhả ID thay IdLinhVucNghienCuu => LinhVucNghienCuu
                ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu");
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdNguonKinhPhis => NguonKinhPhis
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi");
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdLoaiNhiemVu => LoaiNhiemVu
                ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "LoaiNhiemVu");
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdTinhTrangNhiemVu => TinhTrangNhiemVu
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "TinhTrangNhiemVu");
                return View();
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request HTTP 400
                return BadRequest();
            }
        }

        // POST: NhiemVuKhcn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhiemVuKhcn,MaNhiemVu,TenNhiemVu,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,NguoiChuTri,IdPhanLoaiNhiemVu,ThuocNhiemVu,IdLinhVucNghienCuu,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,IdTinhTrangNhiemVu")] TbNhiemVuKhcn tbNhiemVuKhcn)
        {
            /*
            //========= Báo lỗi nếu nhập trùng với IdNhiemVuKhcn (Số thứ tự của hồ sơ) đã tồn tại==================
            if (TbNhiemVuKhcnExists(tbNhiemVuKhcn.IdNhiemVuKhcn)) ModelState.AddModelError("IdNhiemVuKhcn", "Số thứ tự hồ sơ này đã tồn tại. Vui lòng nhập lại!");
            //========= Báo lỗi nếu không nhập một số trường bắt buộc phải nhập  ============================
            if (tbNhiemVuKhcn.IdNhiemVuKhcn == null) ModelState.AddModelError("IdNhiemVuKhcn", "Bạn bắt buộc phải nhập Mã quản lí nhiệm vụ Khoa học công nghệ!");
            if (tbNhiemVuKhcn.MaNhiemVu == null) ModelState.AddModelError("MaNhiemVu", "Bạn bắt buộc phải nhập Mã nhiệm vụ Khoa học công nghệ!");
            if (tbNhiemVuKhcn.TenNhiemVu == null) ModelState.AddModelError("TenNhiemVu", "Bạn bắt buộc phải nhập Tên nhiệm vụ Khoa học công nghệ!");
            if (tbNhiemVuKhcn.IdCapQuanLyNhiemVu == null) ModelState.AddModelError("IdCapQuanLyNhiemVu", "Bạn bắt buộc phải nhập Cấp quản lí nhiệm vụ Khoa học công nghệ!");
            if (tbNhiemVuKhcn.IdPhanLoaiNhiemVu == null) ModelState.AddModelError("IdPhanLoaiNhiemVu", "Bạn bắt buộc phải chọn Phân loại nhiệm vụ từ danh sách!");
            if (tbNhiemVuKhcn.ThoiGianBatDau == null) ModelState.AddModelError("ThoiGianBatDau", "Bạn bắt buộc phải nhập Thời gian bắt đầu của nhiệm vụ Khoa học công nghệ!");
            
            */

            try
            {
                //Áp dụng throw và hiển thị ra theo BadRequest(bat_loi.Message);
                //throw new Exception("Lỗi rồi bạn ơi! Mã quản lí nhiệm vụ bạn vừa nhập đã tồn tại!!!Nhập lại nhé!");
                if (ModelState.IsValid)
                {
                    //Thêm đối tượng vào context 
                    _context.Add(tbNhiemVuKhcn);
                    //Lưu vào cơ sở dữ liệu 
                    await _context.SaveChangesAsync();
                    //Nếu thành công thì trở về trang Index 
                    return RedirectToAction(nameof(Index));
                }
                //Thay đổi để nhả kết quả Phân cấp nhiệm vụ chứ không phải nhả ID thay IDPhanCapNhiemVu => PhanCapNhiemVu
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "PhanCapNhiemVu", tbNhiemVuKhcn.IdCapQuanLyNhiemVu);
                //Thay đổi để nhả kết quả Cơ quan chủ quản chứ không phải nhả ID thay IDCoQuanChuQuan => CoQuanChuQuan
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "CoQuanChuQuan", tbNhiemVuKhcn.IdCoQuanChuQuan);
                //Thay đổi để nhả kết quả Lĩnh vực nghiên cứu chứ không phải nhả ID thay IdLinhVucNghienCuu => LinhVucNghienCuu
                ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbNhiemVuKhcn.IdLinhVucNghienCuu);
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdNguonKinhPhis => NguonKinhPhis
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi", tbNhiemVuKhcn.IdNguonKinhPhi);
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdTinhTrangNhiemVu => TinhTrangNhiemVu
                ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "LoaiNhiemVu", tbNhiemVuKhcn.IdPhanLoaiNhiemVu);
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdTinhTrangNhiemVu => TinhTrangNhiemVu
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "TinhTrangNhiemVu", tbNhiemVuKhcn.IdTinhTrangNhiemVu);
                return View(tbNhiemVuKhcn);
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request 400
                return BadRequest(bat_loi);     
              //Trả về thông báo hiển thị 
              //  return BadRequest(bat_loi.Message);
            }

        }

        //===================================================Cập nhật===================================================================================
        // GET: NhiemVuKhcn/Edit/5 
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                //Tìm model Hồ sơ nhiệm vụ KHCN khớp với Id được cung cấp
                var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns.FindAsync(id);
                if (tbNhiemVuKhcn == null)
                {
                    return NotFound();
                }
                //Sửa đổi 11/10/2024 
                //Thay đổi để nhả kết quả Phân cấp nhiệm vụ chứ không phải nhả ID thay IDPhanCapNhiemVu => PhanCapNhiemVu
                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "PhanCapNhiemVu", tbNhiemVuKhcn.IdCapQuanLyNhiemVu);
                //Thay đổi để nhả kết quả Cơ quan chủ quản chứ không phải nhả ID thay IDCoQuanChuQuan => CoQuanChuQuan
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "CoQuanChuQuan", tbNhiemVuKhcn.IdCoQuanChuQuan);
                //Thay đổi để nhả kết quả Lĩnh vực nghiên cứu chứ không phải nhả ID thay IdLinhVucNghienCuu => LinhVucNghienCuu
                ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbNhiemVuKhcn.IdLinhVucNghienCuu);
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdNguonKinhPhis => NguonKinhPhis
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi", tbNhiemVuKhcn.IdNguonKinhPhi);
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdLoaiNhiemVu => LoaiNhiemVu
                ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "LoaiNhiemVu", tbNhiemVuKhcn.IdPhanLoaiNhiemVu);
                //Thay đổi để nhả kết quả Nguồn kinh phí chứ không phải nhả ID thay IdTinhTrangNhiemVu => TinhTrangNhiemVu
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "TinhTrangNhiemVu", tbNhiemVuKhcn.IdTinhTrangNhiemVu);
                return View(tbNhiemVuKhcn);
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request HTTP 400
                return BadRequest();
            }

        }

        // POST: NhiemVuKhcn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhiemVuKhcn,MaNhiemVu,TenNhiemVu,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,NguoiChuTri,IdPhanLoaiNhiemVu,ThuocNhiemVu,IdLinhVucNghienCuu,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,IdTinhTrangNhiemVu")] TbNhiemVuKhcn tbNhiemVuKhcn)
        {
            try
            {
                if (id != tbNhiemVuKhcn.IdNhiemVuKhcn)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    //Bắt lỗi chương trình trong try nếu có 
                    {
                        _context.Update(tbNhiemVuKhcn);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbNhiemVuKhcnExists(tbNhiemVuKhcn.IdNhiemVuKhcn))
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

                ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "PhanCapNhiemVu", tbNhiemVuKhcn.IdCapQuanLyNhiemVu);
                ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "CoQuanChuQuan", tbNhiemVuKhcn.IdCoQuanChuQuan);
                ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbNhiemVuKhcn.IdLinhVucNghienCuu);
                ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "NguonKinhPhi", tbNhiemVuKhcn.IdNguonKinhPhi);
                ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "LoaiNhiemVu", tbNhiemVuKhcn.IdPhanLoaiNhiemVu);
                ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "TinhTrangNhiemVu", tbNhiemVuKhcn.IdTinhTrangNhiemVu);
                return View(tbNhiemVuKhcn);
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request HTTP 400
                return BadRequest();
            }

        }

        //=================================================== XÓA ===================================================================================
        // GET: NhiemVuKhcn/Delete/5
        // Xóa một hồ sơ KHCN ra khỏi danh sách 
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) //Tìm kiếm Id của hồ sơ cần xóa 
                {
                    //Trả về NotFound nếu không tìm thấy Id của hồ sơ cần xóa 
                    return NotFound();
                }
                //Trả về các giá trị của Selectlist khi đã tìm thấy bản ghi qua Id 
                var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns
                    .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                    .Include(t => t.IdCoQuanChuQuanNavigation)
                    .Include(t => t.IdLinhVucNghienCuuNavigation)
                    .Include(t => t.IdNguonKinhPhiNavigation)
                    .Include(t => t.IdPhanLoaiNhiemVuNavigation)
                    .Include(t => t.IdTinhTrangNhiemVuNavigation)
                    .FirstOrDefaultAsync(m => m.IdNhiemVuKhcn == id);
                if (tbNhiemVuKhcn == null)
                {
                    return NotFound();
                }

                return View(tbNhiemVuKhcn);
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request HTTP 400
                return BadRequest();
            }

        }

        // POST: NhiemVuKhcn/Delete/5
        [HttpPost, ActionName("Delete")] //ActionName dùng để định dạng tên action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) //Xác nhận lại hồ sơ muốn xóa 
        {
            try
            {
                var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns.FindAsync(id);
                if (tbNhiemVuKhcn != null)
                {
                    _context.TbNhiemVuKhcns.Remove(tbNhiemVuKhcn);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception bat_loi)
            {
                // trả về HTTP Bad request HTTP 400
                return BadRequest();
            }

        }

        //Kiểm tra lỗi id khi nhập có trùng lặp trong khi tạo mới hay cập nhật hay không
        //Kiểm tra xem có tồn tại id hay không nếu có return true ngược lại return false
        private bool TbNhiemVuKhcnExists(int id)
        {
            return _context.TbNhiemVuKhcns.Any(e => e.IdNhiemVuKhcn == id);
        }
    }
}
