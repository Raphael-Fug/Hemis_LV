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
    public class DanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public DanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // GET: DanhHieuThiDua
        // Lấy danh sách từ database, trả về view Index.

        private async Task<List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs()
        {
            List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs = await ApiServices_.GetAll<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc");
            List<DmCapKhenThuong> DmCapKhenThuongs = await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong");
            List<DmThiDuaGiaiThuongKhenThuong> DmThiDuaGiaiThuongKhenThuongs = await ApiServices_.GetAll<DmThiDuaGiaiThuongKhenThuong>("/api/dm/ThiDuaGiaiThuongKhenThuong");
            List<TbHocVien> TbHocViens = await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien");
            List<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong> DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs = await ApiServices_.GetAll<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>("/api/dm/LoaiDanhHieuThiDuaGiaiThuongKhenThuong");
            List<DmPhuongThucKhenThuong> DmPhuongThucKhenThuongs = await ApiServices_.GetAll<DmPhuongThucKhenThuong>("/api/dm/PhuongThucKhenThuong");
            TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.ForEach(item =>
            {
                item.IdCapKhenThuongNavigation = DmCapKhenThuongs.FirstOrDefault(x => x.IdCapKhenThuong == item.IdCapKhenThuong);
                item.IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation = DmThiDuaGiaiThuongKhenThuongs.FirstOrDefault(x => x.IdThiDuaGiaiThuongKhenThuong == item.IdDanhHieuThiDuaGiaiThuongKhenThuong);
                item.IdHocVienNavigation = TbHocViens.FirstOrDefault(x => x.IdHocVien == item.IdHocVien);
                item.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation = DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs.FirstOrDefault(x => x.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong == item.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
                item.IdPhuongThucKhenThuongNavigation = DmPhuongThucKhenThuongs.FirstOrDefault(x => x.IdPhuongThucKhenThuong == item.IdPhuongThucKhenThuong);
            });
            return TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs;
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
                List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> getall = await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
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
                var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs = await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs();
                var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FirstOrDefault(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: DanhHieuThiDua/Create
        // Hiển thị view Create để tạo một bản ghi CTĐT mới
        // Truyền data từ các table khác hiển thị tại view Create (khóa ngoài)
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong");
                ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmThiDuaGiaiThuongKhenThuong>("/api/dm/ThiDuaGiaiThuongKhenThuong"), "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong");
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email");
                ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>("/api/dm/LoaiDanhHieuThiDuaGiaiThuongKhenThuong"), "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong");
                ViewData["IdPhuongThucKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmPhuongThucKhenThuong>("/api/dm/PhuongThucKhenThuong"), "IdPhuongThucKhenThuong", "PhuongThucKhenThuong");
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
        public async Task<IActionResult> Create([Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc,IdHocVien,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdDanhHieuThiDuaGiaiThuongKhenThuong,SoQuyetDinhKhenThuong,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
        {
            try
            {
                // Nếu trùng IDDanhHieuThiDua sẽ báo lỗi
                if (await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)) ModelState.AddModelError("IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdCapKhenThuong);
                ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmThiDuaGiaiThuongKhenThuong>("/api/dm/ThiDuaGiaiThuongKhenThuong"), "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuong);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdHocVien);
                ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>("/api/dm/LoaiDanhHieuThiDuaGiaiThuongKhenThuong"), "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
                ViewData["IdPhuongThucKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmPhuongThucKhenThuong>("/api/dm/PhuongThucKhenThuong"), "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdPhuongThucKhenThuong);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: DanhHieuThiDua/Edit
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

                var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await ApiServices_.GetId<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", id ?? 0);
                if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
                {
                    return NotFound();
                }
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdCapKhenThuong);
                ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmThiDuaGiaiThuongKhenThuong>("/api/dm/ThiDuaGiaiThuongKhenThuong"), "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuong);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdHocVien);
                ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>("/api/dm/LoaiDanhHieuThiDuaGiaiThuongKhenThuong"), "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
                ViewData["IdPhuongThucKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmPhuongThucKhenThuong>("/api/dm/PhuongThucKhenThuong"), "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdPhuongThucKhenThuong);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: DanhHieuThiDua/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Lưu data mới (ghi đè) vào các trường Data đã có thuộc IdChuongTrinhDaoTao cần chỉnh sửa
        // Nó chỉ cập nhật khi ModelState hợp lệ
        // Nếu không hợp lệ sẽ báo lỗi, vì vậy cần có bắt lỗi.

        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc,IdHocVien,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdDanhHieuThiDuaGiaiThuongKhenThuong,SoQuyetDinhKhenThuong,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
        {
            try
            {
                if (id != tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", id, tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc) == false)
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
                ViewData["IdCapKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmCapKhenThuong>("/api/dm/CapKhenThuong"), "IdCapKhenThuong", "CapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdCapKhenThuong);
                ViewData["IdThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmThiDuaGiaiThuongKhenThuong>("/api/dm/ThiDuaGiaiThuongKhenThuong"), "IdThiDuaGiaiThuongKhenThuong", "ThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuong);
                ViewData["IdHocVien"] = new SelectList(await ApiServices_.GetAll<TbHocVien>("/api/nh/HocVien"), "IdHocVien", "Email", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdHocVien);
                ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>("/api/dm/LoaiDanhHieuThiDuaGiaiThuongKhenThuong"), "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "LoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
                ViewData["IdPhuongThucKhenThuong"] = new SelectList(await ApiServices_.GetAll<DmPhuongThucKhenThuong>("/api/dm/PhuongThucKhenThuong"), "IdPhuongThucKhenThuong", "PhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdPhuongThucKhenThuong);
                //Bổ xung liên kết api ngoài
                Dictionary<int, string> idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: DanhHieuThiDua/Delete
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
                var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs = await ApiServices_.GetAll<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc");
                var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FirstOrDefault(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
                if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
                {
                    return NotFound();
                }
                return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: DanhHieuThiDua/Delete
        // Xóa CTĐT khỏi Database sau khi nhấn xác nhận 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Lệnh xác nhận xóa hẳn một CTĐT
        {
            try
            {
                await ApiServices_.Delete<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(int id)
        {
            var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs = await ApiServices_.GetAll<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>("/api/nh/DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc");
            return tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
        }
        public async Task<IActionResult> Chart()
        {
            List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> getall = await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs();
            // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index

            var capKhenThuong = getall.GroupBy(k => k.IdCapKhenThuong == null ? "Không" : k.IdCapKhenThuongNavigation.CapKhenThuong).Select(g => new
            {
                capKhenThuong = g.Key,
                Count = g.Count()
            }).ToList();

            var ptKhenThuong = getall.GroupBy(k => k.IdPhuongThucKhenThuong == null ? "Không" : k.IdPhuongThucKhenThuongNavigation.PhuongThucKhenThuong).Select(g => new
            {
                ptKhenThuong = g.Key,
                Count = g.Count()
            }).ToList();

            var loaiDanhHieu = getall.GroupBy(k => k.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong == null ? "Không" : k.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation.LoaiDanhHieuThiDuaGiaiThuongKhenThuong).Select(g => new
            {
                loaiDanhHieu = g.Key,
                Count = g.Count()
            }).ToList();
            ViewData["CapKhenThuong"] = capKhenThuong;
            ViewData["PhuongThucKhenThuong"] = ptKhenThuong;
            ViewData["LoaiDanhHieu"] = loaiDanhHieu;
            return View(getall);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> getall = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>();
            Dictionary<int, string> idNguoiToName = new Dictionary<int, string>();
            try
            {
                ViewData["Error"] = "File";
                if (file == null || file.Length == 0)
                {
                    getall = await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs();
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
                        var khenthuong = new TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc()
                        {
                            IdHocVien = int.Parse(row["ID học viên"].ToString()),
                            IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = int.Parse(row["Danh hiệu thi đua giải thưởng khen thưởng người học"].ToString()),
                            IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong = int.Parse(row["Loại danh hiệu thi đua giải thưởng khen thưởng"].ToString()),
                            IdDanhHieuThiDuaGiaiThuongKhenThuong = int.Parse(row["Danh hiệu thi đua giải thưởng khen thưởng"].ToString()),
                            SoQuyetDinhKhenThuong = row["Số quyết định khen thưởng"].ToString(),
                            IdPhuongThucKhenThuong = int.Parse(row["Phương thức khen thưởng"].ToString()),
                            NamKhenThuong = row["Năm khen thưởng"].ToString(),
                            IdCapKhenThuong = int.Parse(row["Cấp khen thưởng"].ToString())
                        };
                        await Create(khenthuong);
                    }
                }
                getall = await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "Import Successfully";
                return View("Index", getall);
            }
            catch (Exception ex)
            {
                getall = await TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs();
                idNguoiToName = (await TbNguois()).ToDictionary(x => x.IdNguoi, x => x.Ho + " " + x.Ten);
                ViewData["idNguoiToName"] = idNguoiToName;
                ViewBag.Message = "File is Invalid";
                return View("Index", getall);
            }
        }
    }
}
