using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.Models.DM;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http.HttpResults;

namespace C500Hemis.Controllers.CSVC
{
    public class DatDaiController : Controller
    {/// <summary>
     /// khởi tạo một controller cho phép truy cập và thao tác dữ liệu trong bảng TbDatDai
     /// </summary>
        private readonly HemisContext _context;

        public DatDaiController(HemisContext context)
        {
            _context = context;
        }

        // GET: DatDai
        //Truy vấn tất cả dữ liệu từ bảng TbDatDais và đưa vào view
        //lấy dữ liệu từ cơ sở dữ liệu (bao gồm cả các thông tin liên quan) và trả về một view với danh sách dữ liệu đó.
        //Nếu có lỗi xảy ra trong quá trình lấy dữ liệu, nó sẽ trả về mã trạng thái HTTP 400.
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbDatDais.Include(t => t.IdHinhThucSoHuuNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: DatDai/Details/
        //Kiểm tra nếu id là null, nếu có, trả về NotFound.
        //Tìm một bản ghi cụ thể trong bảng TbDatDais dựa trên id và trả về view chi tiết nếu tìm thấy.
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDatDai = await _context.TbDatDais
                    .Include(t => t.IdHinhThucSoHuuNavigation)
                    .FirstOrDefaultAsync(m => m.IdDatDai == id);
                if (tbDatDai == null)
                {
                    return NotFound();
                }

                return View(tbDatDai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: DatDai/Create
        //Tạo view để nhập thông tin cho một bản ghi mới, bao gồm danh sách chọn lựa cho trường IdHinhThucSoHuu.
        public IActionResult Create()
        {
            try
            {
                ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu");

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        //Xử lý dữ liệu được gửi từ form. Nếu IdDatDai đã tồn tại, thêm lỗi vào ModelState.
        //Nếu ModelState hợp lệ, thêm bản ghi vào cơ sở dữ liệu và chuyển hướng về trang danh sách.
        // POST: DatDai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDatDai,MaGiayChungNhanQuyenSoHuu,DienTichDat,IdHinhThucSoHuu,TenDonViSoHuu,MinhChungQuyenSoHuuDatDai,MucDichSuDungDat,NamBatDauSuDungDat,ThoiGianSuDungDat,DienTichDatDaSuDung")] TbDatDai tbDatDai)
        {
            try
            {
                //Nếu trùng id thfi sẽ bắt nhập thong báo lại
                if (TbDatDaiExists(tbDatDai.IdDatDai)) ModelState.AddModelError("IdDatdai", "Đã tồn tại Id này!");
                if (ModelState.IsValid)
                {
                    _context.Add(tbDatDai);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                foreach (var item in ModelState.Values) foreach (var error in item.Errors) Console.WriteLine(error.ErrorMessage);
                ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu", tbDatDai.IdHinhThucSoHuu);
                return View(tbDatDai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: DatDai/Edit/5
        //Kiểm tra nếu id là null. Nếu có, trả về NotFound.
        //Lấy bản ghi cần sửa và trả về view chỉnh sửa.
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDatDai = await _context.TbDatDais.FindAsync(id);
                if (tbDatDai == null)
                {
                    return NotFound();
                }
                ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu", tbDatDai.IdHinhThucSoHuu);
                return View(tbDatDai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //Kiểm tra nếu id và tbDatDai.IdDatDai không khớp, trả về NotFound.
        //Nếu ModelState hợp lệ, cập nhật bản ghi và lưu thay đổi.
        // POST: DatDai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDatDai,MaGiayChungNhanQuyenSoHuu,DienTichDat,IdHinhThucSoHuu,TenDonViSoHuu,MinhChungQuyenSoHuuDatDai,MucDichSuDungDat,NamBatDauSuDungDat,ThoiGianSuDungDat,DienTichDatDaSuDung")] TbDatDai tbDatDai)
        {
            try
            {
                if (id != tbDatDai.IdDatDai)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbDatDai);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbDatDaiExists(tbDatDai.IdDatDai))
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
                ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu", tbDatDai.IdHinhThucSoHuu);
                return View(tbDatDai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //iểm tra nếu id là null và tìm bản ghi để xóa
        // GET: DatDai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDatDai = await _context.TbDatDais
                    .Include(t => t.IdHinhThucSoHuuNavigation)
                    .FirstOrDefaultAsync(m => m.IdDatDai == id);
                if (tbDatDai == null)
                {
                    return NotFound();
                }

                return View(tbDatDai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //Xác nhận việc xóa một bản ghi. Nếu bản ghi tồn tại, xóa và lưu thay đổi.
        // POST: DatDai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbDatDai = await _context.TbDatDais.FindAsync(id);
                if (tbDatDai != null)
                {
                    _context.TbDatDais.Remove(tbDatDai);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //Kiểm tra xem một bản ghi có tồn tại trong cơ sở dữ liệu hay không, để ngăn chặn việc tạo hoặc chỉnh sửa bản ghi trùng lặp.
        private bool TbDatDaiExists(int id)
        {
            return _context.TbDatDais.Any(e => e.IdDatDai == id);
        }
    }
}
