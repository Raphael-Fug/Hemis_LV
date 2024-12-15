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
    public class NguoiHocVayTinDungController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public NguoiHocVayTinDungController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbNguoiHocVayTinDung>> TbNguoiHocVayTinDungs()
        {
            List<TbNguoiHocVayTinDung> tbNguoiHocVayTinDungs = await ApiServices_.GetAll<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmTuyChon> DmTuyChons = await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon");
            tbNguoiHocVayTinDungs.ForEach(item =>
            {
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.TinhTrangVayNavigation = DmTuyChons.FirstOrDefault(x => x.IdTuyChon == item.TinhTrangVay);
            });
            return tbNguoiHocVayTinDungs;
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
                List<TbNguoiHocVayTinDung> getall = await TbNguoiHocVayTinDungs();
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
                var tbNguoiHocVayTinDungs = await TbNguoiHocVayTinDungs();
                var tbNguoiHocVayTinDung = tbNguoiHocVayTinDungs.FirstOrDefault(m => m.IdNguoiHocVayTinDung == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbNguoiHocVayTinDung == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbNguoiHocVayTinDung);
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
                ViewData["IdTuyChon"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon");
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
        public async Task<IActionResult> Create([Bind("IdNguoiHocVayTinDung,IdHocVien,SoTienDuocVay,TenToChucTinDung,NgayVay,DiaChi,ThoiHanVay,TinhTrangVay")] TbNguoiHocVayTinDung tbNguoiHocVayTinDung)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbNguoiHocVayTinDungExists(tbNguoiHocVayTinDung.IdNguoiHocVayTinDung)) ModelState.AddModelError("IdNguoiHocVayTinDung", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung", tbNguoiHocVayTinDung);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbNguoiHocVayTinDung.IdHocVien);
                ViewData["IdTuyChon"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbNguoiHocVayTinDung.TinhTrangVay);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbNguoiHocVayTinDung);
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

                var tbNguoiHocVayTinDung = await ApiServices_.GetId<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung", id ?? 0);
                if (tbNguoiHocVayTinDung == null)
                {
                    return NotFound();
                }
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbNguoiHocVayTinDung.IdHocVien);
                ViewData["IdTuyChon"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbNguoiHocVayTinDung.TinhTrangVay);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbNguoiHocVayTinDung);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoiHocVayTinDung,IdHocVien,SoTienDuocVay,TenToChucTinDung,NgayVay,DiaChi,ThoiHanVay,TinhTrangVay")] TbNguoiHocVayTinDung tbNguoiHocVayTinDung)
        {
            try
            {
                if (id != tbNguoiHocVayTinDung.IdNguoiHocVayTinDung)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung", id, tbNguoiHocVayTinDung);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbNguoiHocVayTinDungExists(tbNguoiHocVayTinDung.IdNguoiHocVayTinDung) == false)
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
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbNguoiHocVayTinDung.IdHocVien);
                ViewData["IdTuyChon"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbNguoiHocVayTinDung.TinhTrangVay);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbNguoiHocVayTinDung);
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
                var tbNguoiHocVayTinDungs = await ApiServices_.GetAll<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung");
                var tbNguoiHocVayTinDung = tbNguoiHocVayTinDungs.FirstOrDefault(m => m.IdNguoiHocVayTinDung == id);
                if (tbNguoiHocVayTinDung == null)
                {
                    return NotFound();
                }

                return View(tbNguoiHocVayTinDung);
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
                await ApiServices_.Delete<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbNguoiHocVayTinDungExists(int id)
        {
            var tbNguoiHocVayTinDungs = await ApiServices_.GetAll<TbNguoiHocVayTinDung>("/api/nh/NguoiHocVayTinDung");
            return tbNguoiHocVayTinDungs.Any(e => e.IdNguoiHocVayTinDung == id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbNguoiHocVayTinDung> getall = new List<TbNguoiHocVayTinDung>();
            Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                if (file == null || file.Length == 0)
                {
                    getall = await TbNguoiHocVayTinDungs();
                    idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                    ViewData["idNguoiToName"] = idNguoiToName;
                    ViewData["Error"] = "File";
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
                        var nhvtd = new TbNguoiHocVayTinDung()
                        {
                            IdNguoiHocVayTinDung = int.Parse(row["ID người học vay tín dụng"].ToString()),
                            IdHocVien = int.Parse(row["ID học viên"].ToString()),
                            SoTienDuocVay = int.Parse(row["Số tiền được vay"].ToString()),
                            TenToChucTinDung = row["Tên tổ chức tín dụng"].ToString(),
                            NgayVay = DateOnly.Parse(row["Ngày vay"].ToString()),
                            DiaChi = row["Địa chỉ"].ToString(),
                            ThoiHanVay = int.Parse(row["Thời hạn vay (tháng)"].ToString()),
                            TinhTrangVay = int.Parse(row["Tình trạng vay"].ToString())
                        };
                        await Create(nhvtd);
                    }
                }
                getall = await TbNguoiHocVayTinDungs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbNguoiHocVayTinDungs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewData["Error"] = "File";
                ViewBag.Message = "File is Invalid";
                return View("Index", getall);

            }
        }

        public async Task<IActionResult> Chart()
        {
            try
            {
                List<TbNguoiHocVayTinDung> getall = await TbNguoiHocVayTinDungs();
                // Lấy data cho biểu đồ khuyết tật
                var ttvay = getall.GroupBy(g => g.TinhTrangVay == null ? "Không" : g.TinhTrangVayNavigation.TuyChon).Select(s => new
                {
                    ttvay = s.Key,
                    Count = s.Count()
                }).ToList();


                ViewData["ttvay"] = ttvay;

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
