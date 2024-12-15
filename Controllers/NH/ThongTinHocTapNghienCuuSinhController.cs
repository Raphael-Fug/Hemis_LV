using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.API;
using C500Hemis.Models.DM;
using Spire.Xls;
using System.Data;
namespace C500Hemis.Controllers.CTDT
{
    public class ThongTinHocTapNghienCuuSinhController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public ThongTinHocTapNghienCuuSinhController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbThongTinHocTapNghienCuuSinh>> TbThongTinHocTapNghienCuuSinhs()
        {
            List<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs = await ApiServices_.GetAll<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh");
            List<DmChuongTrinhDaoTao> DmChuongTrinhDaoTaos = await ApiServices_.GetAll<DmChuongTrinhDaoTao>("/api/dm/ChuongTrinhDaoTao");
            List<DmDoiTuongDauVao> DmDoiTuongDauVaos = await ApiServices_.GetAll<DmDoiTuongDauVao>("/api/dm/DoiTuongDauVao");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmLoaiHinhDaoTao> DmLoaiHinhDaoTaos = await ApiServices_.GetAll<DmLoaiHinhDaoTao>("/api/dm/LoaiHinhDaoTao");
            List<DmLoaiTotNghiep> DmLoaiTotNghieps = await ApiServices_.GetAll<DmLoaiTotNghiep>("/api/dm/LoaiTotNghiep");
            List<TbCanBo> TbCanBos = await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo");
            List<DmSinhVienNam> DmSinhVienNams = await ApiServices_.GetAll<DmSinhVienNam>("/api/dm/SinhVienNam");
            List<DmTrangThaiHoc> DmTrangThaiHocs = await ApiServices_.GetAll<DmTrangThaiHoc>("/api/dm/TrangThaiHoc");
            TbThongTinHocTapNghienCuuSinhs.ForEach(item =>
            {
                item.IdChuongTrinhDaoTaoNavigation = DmChuongTrinhDaoTaos.FirstOrDefault(x => x.IdChuongTrinhDaoTao == item.IdChuongTrinhDaoTao);
                item.IdDoiTuongDauVaoNavigation = DmDoiTuongDauVaos.FirstOrDefault(x => x.IdDoiTuongDauVao == item.IdDoiTuongDauVao);
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.IdLoaiHinhDaoTaoNavigation = DmLoaiHinhDaoTaos.FirstOrDefault(x => x.IdLoaiHinhDaoTao == item.IdLoaiHinhDaoTao);
                item.IdLoaiTotNghiepNavigation = DmLoaiTotNghieps.FirstOrDefault(x => x.IdLoaiTotNghiep == item.IdLoaiTotNghiep);
                item.IdNguoiHuongDanChinhNavigation = TbCanBos.FirstOrDefault(x => x.IdCanBo == item.IdNguoiHuongDanChinh);
                item.IdNguoiHuongDanPhuNavigation = TbCanBos.FirstOrDefault(x => x.IdCanBo == item.IdNguoiHuongDanPhu);
                item.IdSinhVienNamNavigation = DmSinhVienNams.FirstOrDefault(x => x.IdSinhVienNam == item.IdSinhVienNam);
                item.IdTrangThaiHocNavigation = DmTrangThaiHocs.FirstOrDefault(x => x.IdTrangThaiHoc == item.IdTrangThaiHoc);
            });
            return TbThongTinHocTapNghienCuuSinhs;
        }
        private async Task<List<TbNguoi>> TbNguois()
        {
            List<TbNguoi> tbNguois = await ApiServices_.GetAll<TbNguoi>("/api/Nguoi");
            return tbNguois;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbThongTinHocTapNghienCuuSinh> getall = await TbThongTinHocTapNghienCuuSinhs();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(getall);
                // Bắt lỗi các trường hợp ngoại lệ
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // Lấy chi tiết 1 bản ghi dựa theo ID tương ứng đã truyền vào (IdChuongTrinhDaoTao)
        // Hiển thị bản ghi đó ở view Details
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm các dữ liệu theo Id tương ứng đã truyền vào view Details
                var tbThongTinHocTapNghienCuuSinhs = await TbThongTinHocTapNghienCuuSinhs();
                var tbThongTinHocTapNghienCuuSinh = tbThongTinHocTapNghienCuuSinhs.FirstOrDefault(m => m.IdThongTinHocTapNghienCuuSinh == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbThongTinHocTapNghienCuuSinh == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbThongTinHocTapNghienCuuSinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: ChuongTrinhDaoTao/Create
        // Hiển thị view Create để tạo một bản ghi CTĐT mới
        // Truyền data từ các table khác hiển thị tại view Create (khóa ngoài)
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmChuongTrinhDaoTao>("/api/dm/ChuongTrinhDaoTao"), "IdChuongTrinhDaoTao", "ChuongTrinhDaoTao");
                ViewData["IdDoiTuongDauVao"] = new SelectList(await ApiServices_.GetAll<DmDoiTuongDauVao>("/api/dm/DoiTuongDauVao"), "IdDoiTuongDauVao", "DoiTuongDauVao");
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email");
                ViewData["IdLoaiHinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhDaoTao>("/api/dm/LoaiHinhDaoTao"), "IdLoaiHinhDaoTao", "LoaiHinhDaoTao");
                ViewData["IdLoaiTotNghiep"] = new SelectList(await ApiServices_.GetAll<DmLoaiTotNghiep>("/api/dm/LoaiTotNghiep"), "IdLoaiTotNghiep", "LoaiTotNghiep");
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "IdCanBo");
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "IdCanBo");
                ViewData["IdSinhVienNam"] = new SelectList(await ApiServices_.GetAll<DmSinhVienNam>("/api/dm/SinhVienNam"), "IdSinhVienNam", "SinhVienNam");
                ViewData["IdTrangThaiHoc"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiHoc>("/api/dm/TrangThaiHoc"), "IdTrangThaiHoc", "TrangThaiHoc");
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Thêm một CTĐT mới vào Database nếu IdChuongTrinhDaoTao truyền vào không trùng với Id đã có trong Database
        // Trong trường hợp nhập trùng IdChuongTrinhDaoTao sẽ bắt lỗi
        // Bắt lỗi ngoại lệ sao cho người nhập BẮT BUỘC phải nhập khác IdChuongTrinhDaoTao đã có
        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Create([Bind("IdThongTinHocTapNghienCuuSinh,IdHocVien,IdDoiTuongDauVao,IdSinhVienNam,IdChuongTrinhDaoTao,IdLoaiHinhDaoTao,DaoTaoTuNam,DaoTaoDenNam,NgayNhapHoc,IdTrangThaiHoc,NgayChuyenTrangThai,SoQuyetDinhThoiHoc,TenLuanVan,NgayBaoVeCapTruong,NgayBaoVeCapCoSo,QuyChuanNguoiHuongDan,IdNguoiHuongDanChinh,IdNguoiHuongDanPhu,SoQuyetDinhCongNhan,NgayQuyetDinhCongNhan,IdLoaiTotNghiep,SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo,NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo,SoQuyetDinhThanhLapHoiDongBaoVeCapTruong,NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong")] TbThongTinHocTapNghienCuuSinh tbThongTinHocTapNghienCuuSinh)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbThongTinHocTapNghienCuuSinhExists(tbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh)) ModelState.AddModelError("IdThongTinHocTapNghienCuuSinh", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh", tbThongTinHocTapNghienCuuSinh);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmChuongTrinhDaoTao>("/api/dm/ChuongTrinhDaoTao"), "IdChuongTrinhDaoTao", "ChuongTrinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdChuongTrinhDaoTao);
                ViewData["IdDoiTuongDauVao"] = new SelectList(await ApiServices_.GetAll<DmDoiTuongDauVao>("/api/dm/DoiTuongDauVao"), "IdDoiTuongDauVao", "DoiTuongDauVao", tbThongTinHocTapNghienCuuSinh.IdDoiTuongDauVao);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinHocTapNghienCuuSinh.IdHocVien);
                ViewData["IdLoaiHinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhDaoTao>("/api/dm/LoaiHinhDaoTao"), "IdLoaiHinhDaoTao", "LoaiHinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdLoaiHinhDaoTao);
                ViewData["IdLoaiTotNghiep"] = new SelectList(await ApiServices_.GetAll<DmLoaiTotNghiep>("/api/dm/LoaiTotNghiep"), "IdLoaiTotNghiep", "LoaiTotNghiep", tbThongTinHocTapNghienCuuSinh.IdLoaiTotNghiep);
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "MaCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanChinh);
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "MaCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanPhu);
                ViewData["IdSinhVienNam"] = new SelectList(await ApiServices_.GetAll<DmSinhVienNam>("/api/dm/SinhVienNam"), "IdSinhVienNam", "SinhVienNam", tbThongTinHocTapNghienCuuSinh.IdSinhVienNam);
                ViewData["IdTrangThaiHoc"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiHoc>("/api/dm/TrangThaiHoc"), "IdTrangThaiHoc", "TrangThaiHoc", tbThongTinHocTapNghienCuuSinh.IdTrangThaiHoc);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinHocTapNghienCuuSinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: ChuongTrinhDaoTao/Edit
        // Lấy data từ Database với Id đã có, sau đó hiển thị ở view Edit
        // Nếu không tìm thấy Id tương ứng sẽ báo lỗi NotFound
        // Phương thức này gần giống Create, nhưng nó nhập dữ liệu vào Id đã có trong database
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbThongTinHocTapNghienCuuSinh = await ApiServices_.GetId<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh", id ?? 0);
                if (tbThongTinHocTapNghienCuuSinh == null)
                {
                    return NotFound();
                }
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmChuongTrinhDaoTao>("/api/dm/ChuongTrinhDaoTao"), "IdChuongTrinhDaoTao", "ChuongTrinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdChuongTrinhDaoTao);
                ViewData["IdDoiTuongDauVao"] = new SelectList(await ApiServices_.GetAll<DmDoiTuongDauVao>("/api/dm/DoiTuongDauVao"), "IdDoiTuongDauVao", "DoiTuongDauVao", tbThongTinHocTapNghienCuuSinh.IdDoiTuongDauVao);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinHocTapNghienCuuSinh.IdHocVien);
                ViewData["IdLoaiHinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhDaoTao>("/api/dm/LoaiHinhDaoTao"), "IdLoaiHinhDaoTao", "LoaiHinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdLoaiHinhDaoTao);
                ViewData["IdLoaiTotNghiep"] = new SelectList(await ApiServices_.GetAll<DmLoaiTotNghiep>("/api/dm/LoaiTotNghiep"), "IdLoaiTotNghiep", "LoaiTotNghiep", tbThongTinHocTapNghienCuuSinh.IdLoaiTotNghiep);
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "MaCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanChinh);
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "MaCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanPhu);
                ViewData["IdSinhVienNam"] = new SelectList(await ApiServices_.GetAll<DmSinhVienNam>("/api/dm/SinhVienNam"), "IdSinhVienNam", "SinhVienNam", tbThongTinHocTapNghienCuuSinh.IdSinhVienNam);
                ViewData["IdTrangThaiHoc"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiHoc>("/api/dm/TrangThaiHoc"), "IdTrangThaiHoc", "TrangThaiHoc", tbThongTinHocTapNghienCuuSinh.IdTrangThaiHoc);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinHocTapNghienCuuSinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Lưu data mới (ghi đè) vào các trường Data đã có thuộc IdChuongTrinhDaoTao cần chỉnh sửa
        // Nó chỉ cập nhật khi ModelState hợp lệ
        // Nếu không hợp lệ sẽ báo lỗi, vì vậy cần có bắt lỗi.

        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinHocTapNghienCuuSinh,IdHocVien,IdDoiTuongDauVao,IdSinhVienNam,IdChuongTrinhDaoTao,IdLoaiHinhDaoTao,DaoTaoTuNam,DaoTaoDenNam,NgayNhapHoc,IdTrangThaiHoc,NgayChuyenTrangThai,SoQuyetDinhThoiHoc,TenLuanVan,NgayBaoVeCapTruong,NgayBaoVeCapCoSo,QuyChuanNguoiHuongDan,IdNguoiHuongDanChinh,IdNguoiHuongDanPhu,SoQuyetDinhCongNhan,NgayQuyetDinhCongNhan,IdLoaiTotNghiep,SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo,NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo,SoQuyetDinhThanhLapHoiDongBaoVeCapTruong,NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong")] TbThongTinHocTapNghienCuuSinh tbThongTinHocTapNghienCuuSinh)
        {
            try
            {
                if (id != tbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh", id, tbThongTinHocTapNghienCuuSinh);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbThongTinHocTapNghienCuuSinhExists(tbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh) == false)
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
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmChuongTrinhDaoTao>("/api/dm/ChuongTrinhDaoTao"), "IdChuongTrinhDaoTao", "ChuongTrinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdChuongTrinhDaoTao);
                ViewData["IdDoiTuongDauVao"] = new SelectList(await ApiServices_.GetAll<DmDoiTuongDauVao>("/api/dm/DoiTuongDauVao"), "IdDoiTuongDauVao", "DoiTuongDauVao", tbThongTinHocTapNghienCuuSinh.IdDoiTuongDauVao);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinHocTapNghienCuuSinh.IdHocVien);
                ViewData["IdLoaiHinhDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhDaoTao>("/api/dm/LoaiHinhDaoTao"), "IdLoaiHinhDaoTao", "LoaiHinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdLoaiHinhDaoTao);
                ViewData["IdLoaiTotNghiep"] = new SelectList(await ApiServices_.GetAll<DmLoaiTotNghiep>("/api/dm/LoaiTotNghiep"), "IdLoaiTotNghiep", "LoaiTotNghiep", tbThongTinHocTapNghienCuuSinh.IdLoaiTotNghiep);
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "MaCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanChinh);
                ViewData["IdCanBo"] = new SelectList(await ApiServices_.GetAll<TbCanBo>("/api/cb/CanBo"), "IdCanBo", "MaCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanPhu);
                ViewData["IdSinhVienNam"] = new SelectList(await ApiServices_.GetAll<DmSinhVienNam>("/api/dm/SinhVienNam"), "IdSinhVienNam", "SinhVienNam", tbThongTinHocTapNghienCuuSinh.IdSinhVienNam);
                ViewData["IdTrangThaiHoc"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiHoc>("/api/dm/TrangThaiHoc"), "IdTrangThaiHoc", "TrangThaiHoc", tbThongTinHocTapNghienCuuSinh.IdTrangThaiHoc);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinHocTapNghienCuuSinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: ChuongTrinhDaoTao/Delete
        // Xóa một CTĐT khỏi Database
        // Lấy data CTĐT từ Database, hiển thị Data tại view Delete
        // Hàm này để hiển thị thông tin cho người dùng trước khi xóa
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var tbThongTinHocTapNghienCuuSinhs = await ApiServices_.GetAll<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh");
                var tbThongTinHocTapNghienCuuSinh = tbThongTinHocTapNghienCuuSinhs.FirstOrDefault(m => m.IdThongTinHocTapNghienCuuSinh == id);
                if (tbThongTinHocTapNghienCuuSinh == null)
                {
                    return NotFound();
                }

                return View(tbThongTinHocTapNghienCuuSinh);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Delete
        // Xóa CTĐT khỏi Database sau khi nhấn xác nhận 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Lệnh xác nhận xóa hẳn một CTĐT
        {
            try
            {
                await ApiServices_.Delete<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbThongTinHocTapNghienCuuSinhExists(int id)
        {
            var tbThongTinHocTapNghienCuuSinhs = await ApiServices_.GetAll<TbThongTinHocTapNghienCuuSinh>("/api/nh/ThongTinHocTapNghienCuuSinh");
            return tbThongTinHocTapNghienCuuSinhs.Any(e => e.IdThongTinHocTapNghienCuuSinh == id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbThongTinHocTapNghienCuuSinh> getall = new List<TbThongTinHocTapNghienCuuSinh>();
            Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbThongTinHocTapNghienCuuSinhs();
                    idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                    ViewData["idNguoiToName"] = idNguoiToName;
                    ViewBag.Message = "File is Invalid";
                    return View("Index", getall);
                }
                using (var stream = new MemoryStream())
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                    stream.Position = 0;
                    var workbook = new Workbook();
                    workbook.LoadFromStream(stream);
                    var worksheet = workbook.Worksheets[0];
                    DataTable dataTable = worksheet.ExportDataTable();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        var ncs = new TbThongTinHocTapNghienCuuSinh()
                        {
                            IdThongTinHocTapNghienCuuSinh = int.Parse(row["ID thông tin học tập nghiên cứu sinh"].ToString()),
                            IdHocVien = int.Parse(row["ID học viên"].ToString()),
                            IdDoiTuongDauVao = int.Parse(row["ID đối tượng đầu vào"].ToString()),
                            IdSinhVienNam = int.Parse(row["ID sinh viên năm"].ToString()),
                            IdChuongTrinhDaoTao = int.Parse(row["ID chương trình đào tạo"].ToString()),
                            IdLoaiHinhDaoTao = int.Parse(row["ID loại hình đào tạo"].ToString()),
                            DaoTaoTuNam = DateOnly.Parse(row["Đào tạo từ năm"].ToString()),
                            DaoTaoDenNam = DateOnly.Parse(row["Đào tạo đến năm"].ToString()),
                            NgayNhapHoc = DateOnly.Parse(row["Ngày nhập học"].ToString()),
                            IdTrangThaiHoc = int.Parse(row["ID trạng thái học"].ToString()),
                            NgayChuyenTrangThai = DateOnly.Parse(row["Ngày chuyển trạng thái"].ToString()),
                            SoQuyetDinhThoiHoc = row["Số quyết định thôi học"].ToString(),
                            TenLuanVan = row["Tên luận văn"].ToString(),
                            NgayBaoVeCapTruong = DateOnly.Parse(row["Ngày bảo vệ cấp trường"].ToString()),
                            NgayBaoVeCapCoSo = DateOnly.Parse(row["Ngày bảo vệ cấp cơ sở"].ToString()),
                            QuyChuanNguoiHuongDan = row["Quy chuẩn người hướng dẫn"].ToString(),
                            IdNguoiHuongDanChinh = int.Parse(row["ID người hướng dẫn chính"].ToString()),
                            IdNguoiHuongDanPhu = int.Parse(row["ID người hướng dẫn phụ"].ToString()),
                            SoQuyetDinhCongNhan = row["Số quyết định công nhận"].ToString(),
                            NgayQuyetDinhCongNhan = DateOnly.Parse(row["Ngày quyết định công nhận"].ToString()),
                            IdLoaiTotNghiep = int.Parse(row["ID loại tốt nghiệp"].ToString()),
                            SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo = row["Số quyết định thành lập hội đồng bảo vệ cấp cơ sở"].ToString(),
                            NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo = DateOnly.Parse(row["Ngày quyết định thành lập hội đồng bảo vệ cấp cơ sở"].ToString()),
                            SoQuyetDinhThanhLapHoiDongBaoVeCapTruong = row["Số quyết định thành lập hội đồng bảo vệ cấp trường"].ToString(),
                            NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong = DateOnly.Parse(row["Ngày quyết định thành lập hội đồng bảo vệ cấp trường"].ToString())
                        };
                        await Create(ncs);
                    }
                }
                getall = await TbThongTinHocTapNghienCuuSinhs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbThongTinHocTapNghienCuuSinhs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "File is Invalid";
                return View("Index", getall);
            }
        }

        public async Task<IActionResult> Chart()
        {
            try
            {
                List<TbThongTinHocTapNghienCuuSinh> getall = await TbThongTinHocTapNghienCuuSinhs();
                // Lấy data cho biểu đồ
                var ctrDaotao = getall.GroupBy(hv => hv.IdChuongTrinhDaoTao == null
                                        ? "Không" // Label for null cases
                                        : hv.IdChuongTrinhDaoTaoNavigation.ChuongTrinhDaoTao)
                                            .Select(g => new
                                            {
                                                ctrDaoTao = g.Key,
                                                Count = g.Count()
                                            }).ToList();

                var loaiDaotao = getall.GroupBy(hv => hv.IdLoaiHinhDaoTao == null
                                        ? "Không" // Label for null cases
                                        : hv.IdLoaiHinhDaoTaoNavigation.LoaiHinhDaoTao)
                                            .Select(g => new
                                            {
                                                loaiDaoTao = g.Key,
                                                Count = g.Count()
                                            }).ToList();

                var ttDaotao = getall.GroupBy(hv => hv.IdTrangThaiHoc == null
                                        ? "Không" // Label for null cases
                                        : hv.IdTrangThaiHocNavigation.TrangThaiHoc)
                                            .Select(g => new
                                            {
                                                ttDaoTao = g.Key,
                                                Count = g.Count()
                                            }).ToList();

                ViewData["ctrDaotao"] = ctrDaotao;
                ViewData["loaiDaotao"] = loaiDaotao;

                ViewData["ttDaotao"] = ttDaotao;

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
