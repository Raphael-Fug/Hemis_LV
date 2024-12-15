using C500Hemis.API;
using C500Hemis.Models;
using C500Hemis.Models.DM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.API;
using C500Hemis.Models.DM;
using Spire.Xls;
using System.Data;
using Newtonsoft.Json;

namespace C500Hemis.Controllers.NH
{
    public class HocVienController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public HocVienController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbHocVien>> TbHocViens()
        {
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmHuyen> DmHuyens = await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen");
            List<DmLoaiKhuyetTat> DmLoaiKhuyetTats = await ApiServices_.GetAll<DmLoaiKhuyetTat>("/api/dm/LoaiKhuyetTat");
            List<TbNguoi> TbNguois = await ApiServices_.GetAll<TbNguoi>("/api/Nguoi");
            List<DmTinh> DmTinhs = await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh");
            List<DmXa> DmXas = await ApiServices_.GetAll<DmXa>("/api/dm/Xa");
            TbHocViens.ForEach(item =>
            {
                item.IdHuyenNavigation = DmHuyens.FirstOrDefault(x => x.IdHuyen == item.IdHuyen);
                item.IdLoaiKhuyetTatNavigation = DmLoaiKhuyetTats.FirstOrDefault(x => x.IdLoaiKhuyetTat == item.IdLoaiKhuyetTat);
                item.IdNguoiNavigation = TbNguois.FirstOrDefault(x => x.IdNguoi == item.IdNguoi);
                item.IdTinhNavigation = DmTinhs.FirstOrDefault(x => x.IdTinh == item.IdTinh);
                item.IdXaNavigation = DmXas.FirstOrDefault(x => x.IdXa == item.IdXa);
            });
            return TbHocViens;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbHocVien> getall = await TbHocViens();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
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
                var tbHocViens = await TbHocViens();
                var tbHocVien = tbHocViens.FirstOrDefault(m => m.IdHocVien == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbHocVien == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbHocVien);
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
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen");
                ViewData["IdLoaiKhuyetTat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKhuyetTat>("/api/dm/LoaiKhuyetTat"), "IdLoaiKhuyetTat", "LoaiKhuyetTat");
                ViewData["IdNguoi"] = new SelectList(await ApiServices_.GetAll<TbNguoi>("/api/Nguoi"), "IdNguoi", "name");
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh");
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa");
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
        public async Task<IActionResult> Create([Bind("IdHocVien,MaHocVien,IdNguoi,Email,Sdt,SoSoBaoHiem,IdLoaiKhuyetTat,IdTinh,IdHuyen,IdXa,NoiSinh,QueQuan")] TbHocVien tbHocVien)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbHocVienExists(tbHocVien.IdHocVien)) ModelState.AddModelError("IdHocVien", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbHocVien>("/api/nh/HocVien", tbHocVien);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
                ViewData["IdLoaiKhuyetTat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKhuyetTat>("/api/dm/LoaiKhuyetTat"), "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
                ViewData["IdNguoi"] = new SelectList(await ApiServices_.GetAll<TbNguoi>("/api/Nguoi"), "IdNguoi", "name", tbHocVien.IdNguoi);
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh", tbHocVien.IdTinh);
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa", tbHocVien.IdXa);
                return View(tbHocVien);
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

                var tbHocVien = await ApiServices_.GetId<TbHocVien>("/api/nh/HocVien", id ?? 0);
                if (tbHocVien == null)
                {
                    return NotFound();
                }
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
                ViewData["IdLoaiKhuyetTat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKhuyetTat>("/api/dm/LoaiKhuyetTat"), "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
                ViewData["IdNguoi"] = new SelectList(await ApiServices_.GetAll<TbNguoi>("/api/Nguoi"), "IdNguoi", "name", tbHocVien.IdNguoi);
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh", tbHocVien.IdTinh);
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa", tbHocVien.IdXa);
                return View(tbHocVien);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdHocVien,MaHocVien,IdNguoi,Email,Sdt,SoSoBaoHiem,IdLoaiKhuyetTat,IdTinh,IdHuyen,IdXa,NoiSinh,QueQuan")] TbHocVien tbHocVien)
        {
            try
            {
                if (id != tbHocVien.IdHocVien)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbHocVien>("/api/nh/HocVien", id, tbHocVien);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbHocVienExists(tbHocVien.IdHocVien) == false)
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
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
                ViewData["IdLoaiKhuyetTat"] = new SelectList(await ApiServices_.GetAll<DmLoaiKhuyetTat>("/api/dm/LoaiKhuyetTat"), "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
                ViewData["IdNguoi"] = new SelectList(await ApiServices_.GetAll<TbNguoi>("/api/Nguoi"), "IdNguoi", "name", tbHocVien.IdNguoi);
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh", tbHocVien.IdTinh);
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa", tbHocVien.IdXa);
                return View(tbHocVien);
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
                var tbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
                var tbHocVien = tbHocViens.FirstOrDefault(m => m.IdHocVien == id);
                if (tbHocVien == null)
                {
                    return NotFound();
                }

                return View(tbHocVien);
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
                await ApiServices_.Delete<TbHocVien>("/api/nh/HocVien", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbHocVien> getall = new List<TbHocVien>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbHocViens();
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
                        var hv = new TbHocVien()
                        {
                            IdHocVien = int.Parse(row["ID học viên"].ToString()),
                            MaHocVien = row["Mã học viên"].ToString(),
                            IdNguoi = int.Parse(row["ID người"].ToString()),
                            Email = row["Email"].ToString(),
                            Sdt = row["Số điện thoại"].ToString(),
                            SoSoBaoHiem = row["Số sổ bảo hiểm"].ToString(),
                            IdLoaiKhuyetTat = int.Parse(row["ID loại khuyết tật"].ToString()),
                            IdTinh = int.Parse(row["ID tỉnh"].ToString()),
                            IdHuyen = int.Parse(row["ID Huyện"].ToString()),
                            IdXa = int.Parse(row["ID xã"].ToString()),
                            NoiSinh = row["Nơi sinh"].ToString(),
                            QueQuan = row["Quê quán"].ToString()
                        };
                        await Create(hv);
                    }
                }
                getall = await TbHocViens();
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbHocViens();
                ViewBag.Message = "File is Invalid";
                return View("Index", getall);
            }
        }

        private async Task<bool> TbHocVienExists(int id)
        {
            var tbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            return tbHocViens.Any(e => e.IdHocVien == id);
        }

        public async Task<IActionResult> Chart()
        {
            try
            {
                List<TbHocVien> getall = await TbHocViens();
                // Lấy data cho biểu đồ khuyết tật
                var disabilityCounts = getall.GroupBy(hv => hv.IdLoaiKhuyetTatNavigation == null
                                        ? "Không" // Label for null cases
                                        : hv.IdLoaiKhuyetTatNavigation.LoaiKhuyetTat)
                                            .Select(g => new
                                            {
                                                LoaiKhuyetTat = g.Key,
                                                Count = g.Count()
                                            }).ToList();
                ViewData["DisabilityCounts"] = disabilityCounts;
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
