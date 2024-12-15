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
namespace C500Hemis.Controllers.NH
{
    public class ThongTinHocBongController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public ThongTinHocBongController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbThongTinHocBong>> TbThongTinHocBongs()
        {
            List<TbThongTinHocBong> TbThongTinHocBongs = await ApiServices_.GetAll<TbThongTinHocBong>("/api/nh/ThongTinHocBong");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmLoaiHocBong> DmLoaiHocBongs = await ApiServices_.GetAll<DmLoaiHocBong>("/api/dm/LoaiHocBong");
            TbThongTinHocBongs.ForEach(item =>
            {
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.IdLoaiHocBongNavigation = DmLoaiHocBongs.FirstOrDefault(x => x.IdLoaiHocBong == item.IdLoaiHocBong);
            });
            return TbThongTinHocBongs;
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
                List<TbThongTinHocBong> getall = await TbThongTinHocBongs();
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
                var tbThongTinHocBongs = await TbThongTinHocBongs();
                var tbThongTinHocBong = tbThongTinHocBongs.FirstOrDefault(m => m.IdThongTinHocBong == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbThongTinHocBong == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbThongTinHocBong);
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
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email");
                ViewData["IdLoaiHocBong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHocBong>("/api/dm/LoaiHocBong"), "IdLoaiHocBong", "LoaiHocBong");
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
        public async Task<IActionResult> Create([Bind("IdThongTinHocBong,IdHocVien,TenHocBong,DonViTaiTro,ThoiGianTraoTangHocBong,IdLoaiHocBong,GiaTriHocBong")] TbThongTinHocBong tbThongTinHocBong)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbThongTinHocBongExists(tbThongTinHocBong.IdThongTinHocBong)) ModelState.AddModelError("IdThongTinHocBong", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbThongTinHocBong>("/api/nh/ThongTinHocBong", tbThongTinHocBong);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinHocBong.IdHocVien);
                ViewData["IdLoaiHocBong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHocBong>("/api/dm/LoaiHocBong"), "IdLoaiHocBong", "LoaiHocBong", tbThongTinHocBong.IdLoaiHocBong);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinHocBong);
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

                var tbThongTinHocBong = await ApiServices_.GetId<TbThongTinHocBong>("/api/nh/ThongTinHocBong", id ?? 0);
                if (tbThongTinHocBong == null)
                {
                    return NotFound();
                }
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinHocBong.IdHocVien);
                ViewData["IdLoaiHocBong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHocBong>("/api/dm/LoaiHocBong"), "IdLoaiHocBong", "LoaiHocBong", tbThongTinHocBong.IdLoaiHocBong);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinHocBong);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinHocBong,IdHocVien,TenHocBong,DonViTaiTro,ThoiGianTraoTangHocBong,IdLoaiHocBong,GiaTriHocBong")] TbThongTinHocBong tbThongTinHocBong)
        {
            try
            {
                if (id != tbThongTinHocBong.IdThongTinHocBong)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbThongTinHocBong>("/api/nh/ThongTinHocBong", id, tbThongTinHocBong);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbThongTinHocBongExists(tbThongTinHocBong.IdThongTinHocBong) == false)
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
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinHocBong.IdHocVien);
                ViewData["IdLoaiHocBong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHocBong>("/api/dm/LoaiHocBong"), "IdLoaiHocBong", "LoaiHocBong", tbThongTinHocBong.IdLoaiHocBong);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinHocBong);
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
                var tbThongTinHocBongs = await ApiServices_.GetAll<TbThongTinHocBong>("/api/nh/ThongTinHocBong");
                var tbThongTinHocBong = tbThongTinHocBongs.FirstOrDefault(m => m.IdThongTinHocBong == id);
                if (tbThongTinHocBong == null)
                {
                    return NotFound();
                }

                return View(tbThongTinHocBong);
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
                await ApiServices_.Delete<TbThongTinHocBong>("/api/nh/ThongTinHocBong", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbThongTinHocBongExists(int id)
        {
            var tbThongTinHocBongs = await ApiServices_.GetAll<TbThongTinHocBong>("/api/nh/ThongTinHocBong");
            return tbThongTinHocBongs.Any(e => e.IdThongTinHocBong == id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbThongTinHocBong> getall = new List<TbThongTinHocBong>();
            Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbThongTinHocBongs();
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
                        var hocbong = new TbThongTinHocBong()
                        {
                            IdThongTinHocBong = int.Parse(row["ID thông tin học bổng"].ToString()),
                            IdHocVien = int.Parse(row["ID học viên"].ToString()),
                            TenHocBong = row["Tên học bổng"].ToString(),
                            DonViTaiTro = row["Đơn vị tài trợ"].ToString(),
                            ThoiGianTraoTangHocBong = DateOnly.Parse(row["Thời gian trao tặng học bổng"].ToString()),
                            IdLoaiHocBong = int.Parse(row["ID loại học bổng"].ToString()),
                            GiaTriHocBong = int.Parse(row["Giá trị học bổng"].ToString())
                        };
                        await Create(hocbong);
                    }
                }
                getall = await TbThongTinHocBongs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbThongTinHocBongs();
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
                List<TbThongTinHocBong> getall = await TbThongTinHocBongs();
                // Lấy data cho biểu đồ khuyết tật
                var loaiHocBong = getall.GroupBy(g => g.IdThongTinHocBong == null ? "Không" : g.IdLoaiHocBongNavigation.LoaiHocBong).Select(s => new
                {
                    tenHocBong = s.Key,
                    Count = s.Count()
                }).ToList();
                ViewData["LoaiHocBong"] = loaiHocBong;
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
