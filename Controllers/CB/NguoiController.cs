using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.Models.DM;
using System.Text;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Data.SqlClient;

namespace C500Hemis.Controllers.CB
{
    public class NguoiController : Controller
    {
        private readonly HemisContext _context;

        //Nhận HemisContext truyền từ service
        public NguoiController(HemisContext context)
        {
            _context = context;
        }

        //GET: /Nguoi | /Nguoi/Index
        // Thu thập các dữ liệu cần thiết của table TbNguoi để trả về hiển thị trên trang index
        public async Task<IActionResult> Index()
        {
            //Bắt lổi
            try
            {
                List<TbNguoi> content = await
                    _context.TbNguois
                    .Include(t => t.IdChucDanhKhoaHocNavigation)
                    .Include(t => t.IdChuyenMonDaoTaoNavigation)
                    .Include(t => t.IdTonGiaoNavigation)
                    .Include(t => t.IdDanTocNavigation)
                    .Include(t => t.IdGiaDinhChinhSachNavigation)
                    .Include(t => t.IdGioiTinhNavigation)
                    .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                    .Include(t => t.IdNgoaiNguNavigation)
                    .Include(t => t.IdQuocTichNavigation)
                    .Include(t => t.IdThuongBinhHangNavigation)
                    .Include(t => t.IdTrinhDoDaoTaoNavigation)
                    .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                    .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                    .Include(t => t.IdTrinhDoTinHocNavigation)
                    .ToListAsync();
                return View(content);
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        //GET: /Nguoi/Details
        // Thu thập thông tin chi tiết của người với Id cụ thể để trả về hiện thị ở Details
        public async Task<IActionResult> Details(int? id)
        {
            //Bắt lổi
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                //Tìm người cần trả về
                //Include là tìm các model cần thiết cho model TbNguoi
                //theo relationship được cài đặt trong HemisContext.cs qua FOREIGN KEY Constraint trong database 
                var tbNguoi = await _context.TbNguois
                    .Include(t => t.IdChucDanhKhoaHocNavigation)
                    .Include(t => t.IdChuyenMonDaoTaoNavigation)
                    .Include(t => t.IdTonGiaoNavigation)
                    .Include(t => t.IdDanTocNavigation)
                    .Include(t => t.IdGiaDinhChinhSachNavigation)
                    .Include(t => t.IdGioiTinhNavigation)
                    .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                    .Include(t => t.IdNgoaiNguNavigation)
                    .Include(t => t.IdQuocTichNavigation)
                    .Include(t => t.IdThuongBinhHangNavigation)
                    .Include(t => t.IdTrinhDoDaoTaoNavigation)
                    .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                    .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                    .Include(t => t.IdTrinhDoTinHocNavigation)
                    .FirstOrDefaultAsync(m => m.IdNguoi == id);
                if (tbNguoi == null)
                {
                    return NotFound();
                }
                //Nếu tồn tại trả về View Details
                return View(tbNguoi);
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: Nguoi/Create
        public IActionResult Create()
        {
            //Bắt lổi
            try
            {
                make_select_list();
                return View();
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        //POST: /Nguoi/Create
        [HttpPost]//Để action Khớp với POST HTTP 
        [ValidateAntiForgeryToken]//Ngăn chặn Cross-Site Request Forgery qua Token verification (Đối chiếu với token được gửi bởi client mà trước đó được inject ở Form qua TagHelper) 
        public async Task<IActionResult> Create([Bind("IdNguoi,Ho,Ten,IdQuocTich,SoCccd,NgayCapCccd,NoiCapCccd,NgaySinh,IdGioiTinh,IdDanToc,IdTonGiao,NgayVaoDoan,NgayVaoDang,NgayVaoDangChinhThuc,NgayNhapNgu,NgayXuatNgu,IdThuongBinhHang,IdGiaDinhChinhSach,IdChucDanhKhoaHoc,IdTrinhDoDaoTao,IdChuyenMonDaoTao,IdNgoaiNgu,IdKhungNangLucNgoaiNguc,IdTrinhDoLyLuanChinhTri,IdTrinhDoQuanLyNhaNuoc,IdTrinhDoTinHoc")] TbNguoi tbNguoi)
        {
            try
            {
                //Kiểm tra xem đã tồn tại IdNguoi chưa nếu tồn tại thêm ModelError cho IdNguoi\
                check_null(tbNguoi);
                if (TbNguoiExists(tbNguoi.IdNguoi)) ModelState.AddModelError("IdNguoi", "Đã tồn tại!");
                if (ModelState.IsValid)
                {
                    //Không trùng thì INSERT vào TABLE qua method ADD của HemisContext (EF)
                    _context.Add(tbNguoi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                make_select_list(tbNguoi);
                return View(tbNguoi);
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: Nguoi/Edit/5
        //Chỉnh sửa thông tin 
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                //Tìm model người khớp với Id được cung cấp
                var tbNguoi = await _context.TbNguois.FindAsync(id);
                if (tbNguoi == null)
                {
                    return NotFound();
                }
                //Nếu tìm thấy, khởi tạo các giá trị các giá trị cần thiết và trả về view
                make_select_list(tbNguoi);
                return View(tbNguoi);
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // POST: Nguoi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoi,Ho,Ten,IdQuocTich,SoCccd,NgayCapCccd,NoiCapCccd,NgaySinh,IdGioiTinh,IdDanToc,IdTonGiao,NgayVaoDoan,NgayVaoDang,NgayVaoDangChinhThuc,NgayNhapNgu,NgayXuatNgu,IdThuongBinhHang,IdGiaDinhChinhSach,IdChucDanhKhoaHoc,IdTrinhDoDaoTao,IdChuyenMonDaoTao,IdNgoaiNgu,IdKhungNangLucNgoaiNguc,IdTrinhDoLyLuanChinhTri,IdTrinhDoQuanLyNhaNuoc,IdTrinhDoTinHoc")] TbNguoi tbNguoi)
        {
            try
            {
                if (id != tbNguoi.IdNguoi)
                {
                    return NotFound();
                }
                check_null(tbNguoi);
                if (ModelState.IsValid)
                {
                    //Kiểm tra quá trình update
                    try
                    {
                        _context.Update(tbNguoi);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {//Nếu QUERY thực thi ở Database không thay đổi giá trị nào thì trả về DbUpdateConcurrencyException
                     //Lỗi xảy ra chủ yếu do table cần thực thi UPDATE ở database đã bị thay đổi sau khi QUERY được gửi đi
                     //và trước khi QUERY UPDATE được thực hiện
                     //Khi gửi QUERY bên cạnh điều kiện ID EF sẽ thêm điều kiện Version để so sánh version khi gửi và khi thực thi 
                        if (!TbNguoiExists(tbNguoi.IdNguoi))//Nếu đã bị xóa thì trả về STATUS 404
                        {
                            return NotFound();
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                make_select_list(tbNguoi);
                return View(tbNguoi);
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: Nguoi/Delete/5
        //Xóa một người khỏi database
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbNguoi = await _context.TbNguois
                    .Include(t => t.IdChucDanhKhoaHocNavigation)
                    .Include(t => t.IdChuyenMonDaoTaoNavigation)
                    .Include(t => t.IdTonGiaoNavigation)
                    .Include(t => t.IdDanTocNavigation)
                    .Include(t => t.IdGiaDinhChinhSachNavigation)
                    .Include(t => t.IdGioiTinhNavigation)
                    .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                    .Include(t => t.IdNgoaiNguNavigation)
                    .Include(t => t.IdQuocTichNavigation)
                    .Include(t => t.IdThuongBinhHangNavigation)
                    .Include(t => t.IdTrinhDoDaoTaoNavigation)
                    .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                    .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                    .Include(t => t.IdTrinhDoTinHocNavigation)
                    .FirstOrDefaultAsync(m => m.IdNguoi == id);
                if (tbNguoi == null)
                {
                    return NotFound();
                }

                return View(tbNguoi);
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // POST: Nguoi/Delete/5
        [HttpPost, ActionName("Delete")]//ActionName dùng để định dạng tên action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) //Xác nhận xóa
        {
            try
            {
                var tbNguoi = await _context.TbNguois.FindAsync(id);
                if (tbNguoi != null)
                {
                    _context.TbNguois.Remove(tbNguoi);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "":ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        //Kiểm tra xem có tồn tại id hay không nếu có return true ngược lại return false
        private bool TbNguoiExists(int id)
        {
            return _context.TbNguois.Any(e => e.IdNguoi == id);
        }

        //Kiểm tra giá trị

        private void check_null(TbNguoi tbNguoi)
        {
            if (tbNguoi.Ho == null) ModelState.AddModelError("Ho", "Vui lòng nhập họ!");
            if (tbNguoi.Ten == null) ModelState.AddModelError("Ten", "Vui lòng nhập tên!");
            if (tbNguoi.IdQuocTich == null) ModelState.AddModelError("IdQuocTich", "Không được bỏ trống!");
            if (tbNguoi.IdDanToc == null) ModelState.AddModelError("IdDanToc", "Không được bỏ trống!");
            if (tbNguoi.IdChucDanhKhoaHoc == null) ModelState.AddModelError("IdChucDanhKhoaHoc", "Không được bỏ trống!");
            if (tbNguoi.IdChuyenMonDaoTao == null) ModelState.AddModelError("IdChuyenMonDaoTao", "Không được bỏ trống!");
            if (tbNguoi.IdTonGiao == null) ModelState.AddModelError("IdTonGiao", "Không được bỏ trống!");
            if (tbNguoi.IdGioiTinh == null) ModelState.AddModelError("IdGioiTinh", "Không được bỏ trống!");
            if (tbNguoi.IdKhungNangLucNgoaiNguc == null) ModelState.AddModelError("IdKhungNangLucNgoaiNguc", "Không được bỏ trống!");
            if (tbNguoi.IdNgoaiNgu == null) ModelState.AddModelError("IdNgoaiNgu", "Không được bỏ trống!");
            if (tbNguoi.IdTrinhDoDaoTao == null) ModelState.AddModelError("IdTrinhDoDaoTao", "Không được bỏ trống!");
            if (tbNguoi.IdTrinhDoLyLuanChinhTri == null) ModelState.AddModelError("IdTrinhDoLyLuanChinhTri", "Không được bỏ trống!");
            if (tbNguoi.IdTrinhDoQuanLyNhaNuoc == null) ModelState.AddModelError("IdTrinhDoQuanLyNhaNuoc", "Không được bỏ trống!");
            if (tbNguoi.IdTrinhDoTinHoc == null) ModelState.AddModelError("IdTrinhDoTinHoc", "Không được bỏ trống!");
            if (tbNguoi.IdThuongBinhHang == null) ModelState.AddModelError("IdThuongBinhHang", "Không được bỏ trống!");
            if (tbNguoi.IdGiaDinhChinhSach == null) ModelState.AddModelError("IdGiaDinhChinhSach", "Không được bỏ trống!");
        }

        //Tạo các select_list
        private void make_select_list(TbNguoi? tbNguoi = null) {
            //Nếu là null tức là chỉ cần in ra select_list không cần định nghĩa giá trị đã chọn
            if (tbNguoi == null) {
                //SelectList phục vụ cho việc nhập dữ liệu cho các ForeignKey
                //Mô hình selectlist(List<model>, ValueField, TextField)
                //ValueField, TextField đều là tên attribute của model
                //ValueField là tên attribute cần client nhập để lấy dữ liệu
                //TextField là tên attribute muốn hiển thị cho client
                //Vd model DmChucDanhKhoaHoc thì ValueField là IdChucDanhKhoaHoc tương đương DmChucDanhKhoaHoc.IdChucDanhKhoaHoc
                ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc");
                ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "NganhDaoTao");
                ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "TonGiao");
                ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "DanToc");
                ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "HoGiaDinhChinhSach");
                ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "GioiTinh");
                ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu");
                ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu");
                ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc");
                ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "HangThuongBinh");
                ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "TrinhDoDaoTao");
                ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "TenTrinhDoLyLuanChinhTri");
                ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "TrinhDoQuanLyNhaNuoc");
                ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "TrinhDoTinHoc");
            } else {
                //Mô hình giải thích ở phía trên chỉ khác biệt ở chổ có thêm phần value của selectlist mà đang được chọn
                ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
                ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "NganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
                ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "TonGiao", tbNguoi.IdDanToc);
                ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "DanToc", tbNguoi.IdDanToc);
                ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "HoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
                ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "GioiTinh", tbNguoi.IdGioiTinh);
                ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
                ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNguoi.IdNgoaiNgu);
                ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbNguoi.IdQuocTich);
                ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "HangThuongBinh", tbNguoi.IdThuongBinhHang);
                ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "TrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
                ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "TenTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
                ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "TrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
                ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "TrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
            }
        }
        //In lỗi ra file
        private void export_message(string Message) {
            //Thêm tên để setup cho dễ
            string ten_folder_view = "Nguoi";
            // In lỗi vào file
            //Tạo UTF-8 encoding để encode ký tự về UTF-8
            UTF8Encoding unicode = new UTF8Encoding();
            //Tên của file để in lỗi
            string filename = Path.Combine(Environment.CurrentDirectory, $"Views/{ten_folder_view}/error.txt"); 
            //Tạo dãy byte để in vào filestream
            byte[] bytes = unicode.GetBytes(Message);
            //Mở file
            using(FileStream file = new FileStream(filename, FileMode.OpenOrCreate)) {
                //Xóa nội dung của file
                file.SetLength(0);
                //In lỗi vào file
                file.Write(bytes, 0, bytes.Length);
                //Đóng file
                file.Close();
            }
        }
    }
}
