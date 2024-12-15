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
    public class ThongTinViPhamController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public ThongTinViPhamController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbThongTinViPham>> TbThongTinViPhams()
        {
            List<TbThongTinViPham> TbThongTinViPhams = await ApiServices_.GetAll<TbThongTinViPham>("/api/nh/ThongTinViPham");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmLoaiViPham> DmLoaiViPhams = await ApiServices_.GetAll<DmLoaiViPham>("/api/dm/LoaiViPham");
            TbThongTinViPhams.ForEach(item =>
            {
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.IdLoaiViPhamNavigation = DmLoaiViPhams.FirstOrDefault(x => x.IdLoaiViPham == item.IdLoaiViPham);
            });
            return TbThongTinViPhams;
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
                List<TbThongTinViPham> getall = await TbThongTinViPhams();
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
                var tbThongTinViPhams = await TbThongTinViPhams();
                var tbThongTinViPham = tbThongTinViPhams.FirstOrDefault(m => m.IdThongTinViPham == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbThongTinViPham == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbThongTinViPham);
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
                ViewData["IdLoaiViPham"] = new SelectList(await ApiServices_.GetAll<DmLoaiViPham>("/api/dm/LoaiViPham"), "IdLoaiViPham", "LoaiViPham");
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
        public async Task<IActionResult> Create([Bind("IdThongTinViPham,IdHocVien,ThoiGianViPham,NoiDungViPham,HinhThucXuLy,IdLoaiViPham")] TbThongTinViPham tbThongTinViPham)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbThongTinViPhamExists(tbThongTinViPham.IdThongTinViPham)) ModelState.AddModelError("IdThongTinViPham", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbThongTinViPham>("/api/nh/ThongTinViPham", tbThongTinViPham);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinViPham.IdHocVien);
                ViewData["IdLoaiViPham"] = new SelectList(await ApiServices_.GetAll<DmLoaiViPham>("/api/dm/LoaiViPham"), "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinViPham);
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

                var tbThongTinViPham = await ApiServices_.GetId<TbThongTinViPham>("/api/nh/ThongTinViPham", id ?? 0);
                if (tbThongTinViPham == null)
                {
                    return NotFound();
                }
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinViPham.IdHocVien);
                ViewData["IdLoaiViPham"] = new SelectList(await ApiServices_.GetAll<DmLoaiViPham>("/api/dm/LoaiViPham"), "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinViPham);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinViPham,IdHocVien,ThoiGianViPham,NoiDungViPham,HinhThucXuLy,IdLoaiViPham")] TbThongTinViPham tbThongTinViPham)
        {
            try
            {
                if (id != tbThongTinViPham.IdThongTinViPham)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbThongTinViPham>("/api/nh/ThongTinViPham", id, tbThongTinViPham);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbThongTinViPhamExists(tbThongTinViPham.IdThongTinViPham) == false)
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
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbThongTinViPham.IdHocVien);
                ViewData["IdLoaiViPham"] = new SelectList(await ApiServices_.GetAll<DmLoaiViPham>("/api/dm/LoaiViPham"), "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbThongTinViPham);
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
                var tbThongTinViPhams = await ApiServices_.GetAll<TbThongTinViPham>("/api/nh/ThongTinViPham");
                var tbThongTinViPham = tbThongTinViPhams.FirstOrDefault(m => m.IdThongTinViPham == id);
                if (tbThongTinViPham == null)
                {
                    return NotFound();
                }

                return View(tbThongTinViPham);
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
                await ApiServices_.Delete<TbThongTinViPham>("/api/nh/ThongTinViPham", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbThongTinViPhamExists(int id)
        {
            var tbThongTinViPhams = await ApiServices_.GetAll<TbThongTinViPham>("/api/nh/ThongTinViPham");
            return tbThongTinViPhams.Any(e => e.IdThongTinViPham == id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbThongTinViPham> getall = new List<TbThongTinViPham>();
            Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbThongTinViPhams();
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
                        var vipham = new TbThongTinViPham()
                        {
                            IdThongTinViPham = int.Parse(row["Id thông tin vi phạm"].ToString()),
                            IdHocVien = int.Parse(row["Id học viên"].ToString()),
                            ThoiGianViPham = DateOnly.Parse(row["Thời gian vi phạm"].ToString()),
                            NoiDungViPham = row["Nội dung vi phạm"].ToString(),
                            HinhThucXuLy = row["Hình thức xử lí"].ToString(),
                            IdLoaiViPham = int.Parse(row["Id loại vi phạm"].ToString())
                        };
                        await Create(vipham);
                    }
                }
                getall = await TbThongTinViPhams();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbThongTinViPhams();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "File is Invalid";
                return View("Index", getall);
            }
        }

        public async Task<IActionResult> Chart()
        {
            List<TbThongTinViPham> getall = await TbThongTinViPhams();
            // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index

            var loaiViPham = getall.GroupBy(k => k.IdLoaiViPham == null ? "Không" : k.IdLoaiViPhamNavigation.LoaiViPham).Select(g => new
            {
                loaiViPham = g.Key,
                Count = g.Count()
            }).ToList();
            ViewData["LoaiViPham"] = loaiViPham;
            return View(getall);
        }
    }
}
