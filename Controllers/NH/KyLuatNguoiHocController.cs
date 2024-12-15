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
    public class KyLuatNguoiHocController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public KyLuatNguoiHocController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbKyLuatNguoiHoc>> TbKyLuatNguoiHocs()
        {
            List<TbKyLuatNguoiHoc> TbKyLuatNguoiHocs = await ApiServices_.GetAll<TbKyLuatNguoiHoc>("/api/nh/KyLuatNguoiHoc");
            List<DmCapKhenThuong> DmCapKhenThuongs = await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmLoaiKyLuat> DmLoaiKyLuats = await ApiServices_.GetAll<DmLoaiKyLuat>("/api/dm/LoaiKyLuat");
            TbKyLuatNguoiHocs.ForEach(item =>
            {
                item.IdCapQuyetDinhNavigation = DmCapKhenThuongs.FirstOrDefault(x => x.IdCapKhenThuong == item.IdCapQuyetDinh);
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.IdLoaiKyLuatNavigation = DmLoaiKyLuats.FirstOrDefault(x => x.IdLoaiKyLuat == item.IdLoaiKyLuat);
            });
            return TbKyLuatNguoiHocs;
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
                List<TbKyLuatNguoiHoc> getall = await TbKyLuatNguoiHocs();
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
                var tbKyLuatNguoiHocs = await TbKyLuatNguoiHocs();
                var tbKyLuatNguoiHoc = tbKyLuatNguoiHocs.FirstOrDefault(m => m.IdKyLuatNguoiHoc == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbKyLuatNguoiHoc == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbKyLuatNguoiHoc);
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
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong");
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email");
                ViewData["IdLoaiKyLuat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKyLuat>("/api/dm/LoaiKyLuat"), "IdLoaiKyLuat", "LoaiKyLuat");
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
        public async Task<IActionResult> Create([Bind("IdKyLuatNguoiHoc,IdHocVien,IdLoaiKyLuat,LyDo,IdCapQuyetDinh,SoQuyetDinh,NgayQuyetDinh,NamBiKyLuat")] TbKyLuatNguoiHoc tbKyLuatNguoiHoc)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbKyLuatNguoiHocExists(tbKyLuatNguoiHoc.IdKyLuatNguoiHoc)) ModelState.AddModelError("IdKyLuatNguoiHoc", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbKyLuatNguoiHoc>("/api/nh/KyLuatNguoiHoc", tbKyLuatNguoiHoc);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong", tbKyLuatNguoiHoc.IdCapQuyetDinh);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbKyLuatNguoiHoc.IdHocVien);
                ViewData["IdLoaiKyLuat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKyLuat>("/api/dm/LoaiKyLuat"), "IdLoaiKyLuat", "LoaiKyLuat", tbKyLuatNguoiHoc.IdLoaiKyLuat);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbKyLuatNguoiHoc);
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

                var tbKyLuatNguoiHoc = await ApiServices_.GetId<TbKyLuatNguoiHoc>("/api/nh/KyLuatNguoiHoc", id ?? 0);
                if (tbKyLuatNguoiHoc == null)
                {
                    return NotFound();
                }
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong", tbKyLuatNguoiHoc.IdCapQuyetDinh);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbKyLuatNguoiHoc.IdHocVien);
                ViewData["IdLoaiKyLuat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKyLuat>("/api/dm/LoaiKyLuat"), "IdLoaiKyLuat", "LoaiKyLuat", tbKyLuatNguoiHoc.IdLoaiKyLuat);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbKyLuatNguoiHoc);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdKyLuatNguoiHoc,IdHocVien,IdLoaiKyLuat,LyDo,IdCapQuyetDinh,SoQuyetDinh,NgayQuyetDinh,NamBiKyLuat")] TbKyLuatNguoiHoc tbKyLuatNguoiHoc)
        {
            try
            {
                if (id != tbKyLuatNguoiHoc.IdKyLuatNguoiHoc)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbHocVien>("/api/nh/KyLuatNguoiHoc", id, tbKyLuatNguoiHoc);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbKyLuatNguoiHocExists(tbKyLuatNguoiHoc.IdKyLuatNguoiHoc) == false)
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
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong", tbKyLuatNguoiHoc.IdCapQuyetDinh);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbKyLuatNguoiHoc.IdHocVien);
                ViewData["IdLoaiKyLuat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKyLuat>("/api/dm/LoaiKyLuat"), "IdLoaiKyLuat", "LoaiKyLuat", tbKyLuatNguoiHoc.IdLoaiKyLuat);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbKyLuatNguoiHoc);
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
                var tbKyLuatNguoiHocs = await ApiServices_.GetAll<TbKyLuatNguoiHoc>("/api/nh/KyLuatNguoiHoc");
                var tbKyLuatNguoiHoc = tbKyLuatNguoiHocs.FirstOrDefault(m => m.IdKyLuatNguoiHoc == id);
                if (tbKyLuatNguoiHoc == null)
                {
                    return NotFound();
                }

                return View(tbKyLuatNguoiHoc);
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
                await ApiServices_.Delete<TbKyLuatNguoiHoc>("/api/nh/KyLuatNguoiHoc", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbKyLuatNguoiHocExists(int id)
        {
            var tbKyLuatNguoiHocs = await ApiServices_.GetAll<TbKyLuatNguoiHoc>("/api/nh/KyLuatNguoiHoc");
            return tbKyLuatNguoiHocs.Any(e => e.IdKyLuatNguoiHoc == id);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbKyLuatNguoiHoc> getall = new List<TbKyLuatNguoiHoc>();
            Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbKyLuatNguoiHocs();
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
                        var kyluat = new TbKyLuatNguoiHoc()
                        {
                            IdKyLuatNguoiHoc = int.Parse(row["ID kỷ luật người học"].ToString()),
                            IdHocVien = int.Parse(row["ID học viên"].ToString()),
                            IdLoaiKyLuat = int.Parse(row["ID loại kỷ luật"].ToString()),
                            LyDo = row["Lý do"].ToString(),
                            IdCapQuyetDinh = int.Parse(row["ID cấp quyết định"].ToString()),
                            SoQuyetDinh = row["Số quyết định"].ToString(),
                            NgayQuyetDinh = DateOnly.Parse(row["Ngày quyết định"].ToString()),
                            NamBiKyLuat = row["Năm bị kỷ luật"].ToString()
                        };
                        await Create(kyluat);
                    }
                }
                getall = await TbKyLuatNguoiHocs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbKyLuatNguoiHocs();
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
                List<TbKyLuatNguoiHoc> getall = await TbKyLuatNguoiHocs();
                // Lấy data cho biểu đồ khuyết tật
                var capQD = getall.GroupBy(g => g.IdCapQuyetDinh == null ? "Không" : g.IdCapQuyetDinhNavigation.CapKhenThuong).Select(s => new
                {
                    capQD = s.Key,
                    Count = s.Count()
                }).ToList();

                var loaiKyLuat = getall.GroupBy(g => g.IdLoaiKyLuat == null ? "Không" : g.IdLoaiKyLuatNavigation.LoaiKyLuat).Select(s => new
                {
                    loaiKyLuat = s.Key,
                    Count = s.Count()
                }).ToList();
                ViewData["CapQD"] = capQD;
                ViewData["LoaiKyLuat"] = loaiKyLuat;

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
