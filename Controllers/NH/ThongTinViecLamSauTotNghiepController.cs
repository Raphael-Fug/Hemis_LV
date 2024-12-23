﻿using System;
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
namespace C500Hemis.Controllers.NH
{
    public class ThongTinViecLamSauTotNghiepController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public ThongTinViecLamSauTotNghiepController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbThongTinViecLamSauTotNghiep>> TbThongTinViecLamSauTotNghieps()
        {
            List<TbThongTinViecLamSauTotNghiep> TbThongTinViecLamSauTotNghieps = await ApiServices_.GetAll<TbThongTinViecLamSauTotNghiep>("/api/nh/ThongTinViecLamSauTotNghiep");
            List<DmHinhThucTuyenDung> DmHinhThucTuyenDungs = await ApiServices_.GetAll<DmHinhThucTuyenDung>("/api/dm/HinhThucTuyenDung");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmViTriViecLam> DmViTriViecLams = await ApiServices_.GetAll<DmViTriViecLam>("/api/dm/ViTriViecLam");
            TbThongTinViecLamSauTotNghieps.ForEach(item => {
                item.IdHinhThucTuyenDungNavigation = DmHinhThucTuyenDungs.FirstOrDefault(x => x.IdHinhThucTuyenDung == item.IdHinhThucTuyenDung);
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.IdViTriViecLamNavigation = DmViTriViecLams.FirstOrDefault(x => x.IdViTriViecLam == item.IdViTriViecLam);
            });
            return TbThongTinViecLamSauTotNghieps;
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
                List<TbThongTinViecLamSauTotNghiep> getall = await TbThongTinViecLamSauTotNghieps();
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
                var tbThongTinViecLamSauTotNghieps = await TbThongTinViecLamSauTotNghieps();
                var tbThongTinViecLamSauTotNghiep = tbThongTinViecLamSauTotNghieps.FirstOrDefault(m => m.IdThongTinViecLamSauTotNghiep == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbThongTinViecLamSauTotNghiep == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbThongTinViecLamSauTotNghiep);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // Hiển thị view Create để tạo một bản ghi CTĐT mới
        // Truyền data từ các table khác hiển thị tại view Create (khóa ngoài)
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["IdHinhThucTuyenDung"] = new SelectList(await ApiServices_.GetAll<DmHinhThucTuyenDung>("/api/dm/HinhThucTuyenDung"), "IdHinhThucTuyenDung", "HinhThucTuyenDung");
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email");
                ViewData["IdViTriViecLam"] = new SelectList(await ApiServices_.GetAll<DmViTriViecLam>("/api/dm/ViTriViecLam"), "IdViTriViecLam", "ViTriViecLam");
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
        public async Task<IActionResult> Create([Bind("IdThongTinViecLamSauTotNghiep,IdHocVien,TenDonViCapBang,DonViTuyenDung,IdHinhThucTuyenDung,ThoiGianTuyenDung,IdViTriViecLam,MucLuongKhoiDiem")] TbThongTinViecLamSauTotNghiep tbThongTinViecLamSauTotNghiep)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbThongTinViecLamSauTotNghiepExists(tbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep)) ModelState.AddModelError("IdThongTinViecLamSauTotNghiep", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbThongTinViecLamSauTotNghiep>("/api/nh/ThongTinViecLamSauTotNghiep", tbThongTinViecLamSauTotNghiep);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdHinhThucTuyenDung"] = new SelectList(await ApiServices_.GetAll<DmHinhThucTuyenDung>("/api/dm/HinhThucTuyenDung"), "IdHinhThucTuyenDung", "HinhThucTuyenDung", tbThongTinViecLamSauTotNghiep.IdHinhThucTuyenDung);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinViecLamSauTotNghiep.IdHocVien);
                ViewData["IdViTriViecLam"] = new SelectList(await ApiServices_.GetAll<DmViTriViecLam>("/api/dm/ViTriViecLam"), "IdViTriViecLam", "ViTriViecLam", tbThongTinViecLamSauTotNghiep.IdViTriViecLam);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinViecLamSauTotNghiep);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

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

                var tbThongTinViecLamSauTotNghiep = await ApiServices_.GetId<TbThongTinViecLamSauTotNghiep>("/api/nh/ThongTinViecLamSauTotNghiep", id ?? 0);
                if (tbThongTinViecLamSauTotNghiep == null)
                {
                    return NotFound();
                }
                ViewData["IdHinhThucTuyenDung"] = new SelectList(await ApiServices_.GetAll<DmHinhThucTuyenDung>("/api/dm/HinhThucTuyenDung"), "IdHinhThucTuyenDung", "HinhThucTuyenDung", tbThongTinViecLamSauTotNghiep.IdHinhThucTuyenDung);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinViecLamSauTotNghiep.IdHocVien);
                ViewData["IdViTriViecLam"] = new SelectList(await ApiServices_.GetAll<DmViTriViecLam>("/api/dm/ViTriViecLam"), "IdViTriViecLam", "ViTriViecLam", tbThongTinViecLamSauTotNghiep.IdViTriViecLam);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinViecLamSauTotNghiep);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Lưu data mới (ghi đè) vào các trường Data đã có thuộc IdChuongTrinhDaoTao cần chỉnh sửa
        // Nó chỉ cập nhật khi ModelState hợp lệ
        // Nếu không hợp lệ sẽ báo lỗi, vì vậy cần có bắt lỗi.

        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinViecLamSauTotNghiep,IdHocVien,TenDonViCapBang,DonViTuyenDung,IdHinhThucTuyenDung,ThoiGianTuyenDung,IdViTriViecLam,MucLuongKhoiDiem")] TbThongTinViecLamSauTotNghiep tbThongTinViecLamSauTotNghiep)
        {
            try
            {
                if (id != tbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbThongTinViecLamSauTotNghiep>("/api/nh/ThongTinViecLamSauTotNghiep", id, tbThongTinViecLamSauTotNghiep);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbThongTinViecLamSauTotNghiepExists(tbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep) == false)
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
                ViewData["IdHinhThucTuyenDung"] = new SelectList(await ApiServices_.GetAll<DmHinhThucTuyenDung>("/api/dm/HinhThucTuyenDung"), "IdHinhThucTuyenDung", "HinhThucTuyenDung", tbThongTinViecLamSauTotNghiep.IdHinhThucTuyenDung);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinViecLamSauTotNghiep.IdHocVien);
                ViewData["IdViTriViecLam"] = new SelectList(await ApiServices_.GetAll<DmViTriViecLam>("/api/dm/ViTriViecLam"), "IdViTriViecLam", "ViTriViecLam", tbThongTinViecLamSauTotNghiep.IdViTriViecLam);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinViecLamSauTotNghiep);
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
                var tbThongTinViecLamSauTotNghieps = await TbThongTinViecLamSauTotNghieps();
                var tbThongTinViecLamSauTotNghiep = tbThongTinViecLamSauTotNghieps.FirstOrDefault(m => m.IdThongTinViecLamSauTotNghiep == id);
                if (tbThongTinViecLamSauTotNghiep == null)
                {
                    return NotFound();
                }

                return View(tbThongTinViecLamSauTotNghiep);
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
                await ApiServices_.Delete<TbThongTinViecLamSauTotNghiep>("/api/nh/ThongTinViecLamSauTotNghiep", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbThongTinViecLamSauTotNghiepExists(int id)
        {
            var tbThongTinViecLamSauTotNghieps = await ApiServices_.GetAll<TbThongTinViecLamSauTotNghiep>("/api/nh/ThongTinViecLamSauTotNghiep");
            return tbThongTinViecLamSauTotNghieps.Any(e => e.IdThongTinViecLamSauTotNghiep == id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
                List<TbThongTinViecLamSauTotNghiep> getall = new List<TbThongTinViecLamSauTotNghiep>();
                Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbThongTinViecLamSauTotNghieps();
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
                        var vieclam = new TbThongTinViecLamSauTotNghiep()
                        {
                            IdThongTinViecLamSauTotNghiep = int.Parse(row["ID Việc Làm Sau Tốt Nghiệp"].ToString()),
                            IdHocVien = int.Parse(row["ID Học Viên"].ToString()),
                            TenDonViCapBang = row["Tên Đơn Vị Cấp Bằng"].ToString(),
                            DonViTuyenDung = row["Đơn Vị Tuyển Dụng"].ToString(),
                            IdHinhThucTuyenDung = int.Parse(row["ID Hình Thức Tuyển Dụng"].ToString()),
                            ThoiGianTuyenDung = DateOnly.Parse(row["Thời Gian Tuyển Dụng"].ToString()),
                            IdViTriViecLam = int.Parse(row["Id Vị Trí Việc Làm"].ToString()),
                            MucLuongKhoiDiem = int.Parse(row["Mức Lương Khởi Điểm"].ToString())
                        };
                        await Create(vieclam);
                    }
                }
                getall = await TbThongTinViecLamSauTotNghieps();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbThongTinViecLamSauTotNghieps();
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
                List<TbThongTinViecLamSauTotNghiep> getall = await TbThongTinViecLamSauTotNghieps();
                // Lấy data cho biểu đồ khuyết tật
                var htTD = getall.GroupBy(g => g.IdHinhThucTuyenDung == null ? "Không" : g.IdHinhThucTuyenDungNavigation.HinhThucTuyenDung).Select(s => new
                {
                    htTD = s.Key,
                    Count = s.Count()
                }).ToList();

                var vtriVL = getall.GroupBy(g => g.IdViTriViecLam == null ? "Không" : g.IdViTriViecLamNavigation.ViTriViecLam).Select(s => new
                {
                    vtriVL = s.Key,
                    Count = s.Count()
                }).ToList();
                ViewData["htTD"] = htTD;
                ViewData["vtriVL"] = vtriVL;

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        public async Task<IActionResult> OtherChart()
        {
            try
            {
                List<TbThongTinViecLamSauTotNghiep> getall = await TbThongTinViecLamSauTotNghieps();
                // Lấy data cho biểu đồ khuyết tật
                var htTD = getall.GroupBy(g => g.IdHinhThucTuyenDung == null ? "Không" : g.IdHinhThucTuyenDungNavigation.HinhThucTuyenDung).Select(s => new
                {
                    htTD = s.Key,
                    Count = s.Count()
                }).ToList();

                var vtriVL = getall.GroupBy(g => g.IdViTriViecLam == null ? "Không" : g.IdViTriViecLamNavigation.ViTriViecLam).Select(s => new
                {
                    vtriVL = s.Key,
                    Count = s.Count()
                }).ToList();
                ViewData["htTD"] = htTD;
                ViewData["vtriVL"] = vtriVL;

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
