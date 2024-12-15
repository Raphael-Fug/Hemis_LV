using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using System.Text;

namespace C500Hemis.Controllers.KHCN
{
    //B8D55 AT13 Ca Kỳ Hòa
    public class DoiTuongThamGiumController : Controller
    {
        private readonly HemisContext _context;

        public DoiTuongThamGiumController(HemisContext context)
        {
            _context = context;
        }

        // GET: DoiTuongThamGium
        // Thu thập các dữ liệu cần thiết của table TbDoiTuongThamGium để trả về hiển thị trên trang index
        public async Task<IActionResult> Index()
        {
            //Bắt lỗi
            try {   
                var hemisContext = _context.TbDoiTuongThamGia.Include(t => t.IdLoaiThamGiaNavigation).Include(t => t.IdNguoiNavigation).Include(t => t.IdPhanLoaiNavigation).Include(t => t.IdVaiTroNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
           
        }

        // GET: DoiTuongThamGium/Details/5
        // Thu thập thông tin chi tiết của người với Id cụ thể để trả về hiện thị ở Details

        public async Task<IActionResult> Details(int? id)
        {
            //Bắt lỗi
            try
            {
                // Kiểm tra nếu id truyền vào là null, trả về NotFound (404) nếu không có ID
                if (id == null)
                {
                    return NotFound();
                }

                var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia
                    .Include(t => t.IdLoaiThamGiaNavigation)
                    .Include(t => t.IdNguoiNavigation)
                    .Include(t => t.IdPhanLoaiNavigation)
                    .Include(t => t.IdVaiTroNavigation)
                    .FirstOrDefaultAsync(m => m.IdDoiTuongThamGia == id);
                if (tbDoiTuongThamGium == null)
                {
                    return NotFound();
                }

                return View(tbDoiTuongThamGium);

            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
          }

        // GET: DoiTuongThamGium/Create
        public IActionResult Create()
        {
            //Bắt lỗi
            try
            {
                ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "LoaiThamGia");
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name");
                ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "PhanLoaiDoiNguNguoiHoc");
                ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "VaiTroThamGia");
                return View();
            } catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
            
        }

        // POST: DoiTuongThamGium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoiTuongThamGia,IdLoaiThamGia,MaLoaiThamGia,IdNguoi,IdVaiTro,IdPhanLoai")] TbDoiTuongThamGium tbDoiTuongThamGium)
        { 
            //Bắt lỗi
            try
            {
                //Kiểm tra xem đã tồn tại IdDoiTuongThamGia chưa nếu tồn tại thì thêm ModelError cho IdDoiTuongThamGia
                if (TbDoiTuongThamGiumExists(tbDoiTuongThamGium.IdDoiTuongThamGia)) ModelState.AddModelError("IdDoiTuongThamGia", "ID vừa nhập đã tồn tại, vui lòng nhập lại ID khác");
                if (ModelState.IsValid)
                {
                    _context.Add(tbDoiTuongThamGium);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "IdLoaiThamGia", tbDoiTuongThamGium.IdLoaiThamGia);
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbDoiTuongThamGium.IdNguoi);
                ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "IdPhanLoaiDoiNguNguoiHoc", tbDoiTuongThamGium.IdPhanLoai);
                ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbDoiTuongThamGium.IdVaiTro);
                return View(tbDoiTuongThamGium);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }

        }

        // GET: DoiTuongThamGium/Edit/5
        //Chỉnh sửa thông tin
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia.Include(e => e.IdNguoiNavigation).FirstOrDefaultAsync(e => e.IdDoiTuongThamGia == id);
                if (tbDoiTuongThamGium == null)
                {
                    return NotFound();
                }

                ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "LoaiThamGia", tbDoiTuongThamGium.IdLoaiThamGia);
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbDoiTuongThamGium.IdNguoi);
                ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "PhanLoaiDoiNguNguoiHoc", tbDoiTuongThamGium.IdPhanLoai);
                ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "VaiTroThamGia", tbDoiTuongThamGium.IdVaiTro);
                return View(tbDoiTuongThamGium);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
            
        }

        // POST: DoiTuongThamGium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoiTuongThamGia,IdLoaiThamGia,MaLoaiThamGia,IdNguoi,IdVaiTro,IdPhanLoai")] TbDoiTuongThamGium tbDoiTuongThamGium)
        {
            try {
                if (id != tbDoiTuongThamGium.IdDoiTuongThamGia)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbDoiTuongThamGium);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbDoiTuongThamGiumExists(tbDoiTuongThamGium.IdDoiTuongThamGia))
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
                ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "IdLoaiThamGia", tbDoiTuongThamGium.IdLoaiThamGia);
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbDoiTuongThamGium.IdNguoi);
                ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "IdPhanLoaiDoiNguNguoiHoc", tbDoiTuongThamGium.IdPhanLoai);
                ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbDoiTuongThamGium.IdVaiTro);
                return View(tbDoiTuongThamGium);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
            
        }

        // GET: DoiTuongThamGium/Delete/5
        //Xóa một người ra khỏi database
        public async Task<IActionResult> Delete(int? id)
        {
            try {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia
                    .Include(t => t.IdLoaiThamGiaNavigation)
                    .Include(t => t.IdNguoiNavigation)
                    .Include(t => t.IdPhanLoaiNavigation)
                    .Include(t => t.IdVaiTroNavigation)
                    .FirstOrDefaultAsync(m => m.IdDoiTuongThamGia == id);
                if (tbDoiTuongThamGium == null)
                {
                    return NotFound();
                }

                return View(tbDoiTuongThamGium);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
           
        }

        // POST: DoiTuongThamGium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia.FindAsync(id);
                if (tbDoiTuongThamGium != null)
                {
                    _context.TbDoiTuongThamGia.Remove(tbDoiTuongThamGium);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
            
        }

        private bool TbDoiTuongThamGiumExists(int id)
        {
            return _context.TbDoiTuongThamGia.Any(e => e.IdDoiTuongThamGia == id);
        }
        //In lỗi ra file
        private void export_message(string Message)
        {
            //Thêm tên để setup cho dễ
            string ten_folder_view = "DoiTuongThamGium";
            // In lỗi vào file
            //Tạo UTF-8 encoding để encode ký tự về UTF-8
            UTF8Encoding unicode = new UTF8Encoding();
            //Tên của file để in lỗi
            string filename = Path.Combine(Environment.CurrentDirectory, $"Views/{ten_folder_view}/error.txt");
            //Tạo dãy byte để in vào filestream
            byte[] bytes = unicode.GetBytes(Message);
            //Mở file
            using (FileStream file = new FileStream(filename, FileMode.OpenOrCreate))
            {
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