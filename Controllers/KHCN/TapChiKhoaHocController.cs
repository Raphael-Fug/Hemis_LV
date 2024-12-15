using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace C500Hemis.Controllers.KHCN
{
    //B8D55 AT13 Ca Kỳ Hòa

    public class TapChiKhoaHocController : Controller
    {
        private readonly HemisContext _context;

        public TapChiKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: TapChiKhoaHoc
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbTapChiKhoaHocs.Include(t => t.IdLinhVucXuatBanNavigation).Include(t => t.IdXepLoaiTapChiNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: TapChiKhoaHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try {
                if (id == null)
                {
                    return NotFound();
                }

                var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs
                    .Include(t => t.IdLinhVucXuatBanNavigation)
                    .Include(t => t.IdXepLoaiTapChiNavigation)
                    .FirstOrDefaultAsync(m => m.IdTapChiKhoaHoc == id);
                if (tbTapChiKhoaHoc == null)
                {
                    return NotFound();
                }

                return View(tbTapChiKhoaHoc);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: TapChiKhoaHoc/Create
        public IActionResult Create()
        {
            try {
                ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu");
                ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "TapChiTrongNuoc");
                return View();
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }    
        }

        // POST: TapChiKhoaHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTapChiKhoaHoc,MaTapChi,TenTapChiTiengViet,TenTapChiTiengAnh,MaChuanIssn,IdLinhVucXuatBan,IdXepLoaiTapChi,SoBaiBao1Nam")] TbTapChiKhoaHoc tbTapChiKhoaHoc)
        {
            //Bắt lỗi
            try {
                //Kiểm tra xem ID nhập vào có bị trùng với ID trước không
                if (TbTapChiKhoaHocExists(tbTapChiKhoaHoc.IdTapChiKhoaHoc)) ModelState.AddModelError("IdTapChiKhoaHoc", "ID vừa nhập đã tồn tại");
                if (ModelState.IsValid)
                {
                    _context.Add(tbTapChiKhoaHoc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbTapChiKhoaHoc.IdLinhVucXuatBan);
                ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "IdTapChiTrongNuoc", tbTapChiKhoaHoc.IdXepLoaiTapChi);
                return View(tbTapChiKhoaHoc);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: TapChiKhoaHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Bắt lỗi
            try {
                if (id == null)
                {
                    return NotFound();
                }

                var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs.FindAsync(id);
                if (tbTapChiKhoaHoc == null)
                {
                    return NotFound();
                }
                ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbTapChiKhoaHoc.IdLinhVucXuatBan);
                ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "TapChiTrongNuoc", tbTapChiKhoaHoc.IdXepLoaiTapChi);
                return View(tbTapChiKhoaHoc);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // POST: TapChiKhoaHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTapChiKhoaHoc,MaTapChi,TenTapChiTiengViet,TenTapChiTiengAnh,MaChuanIssn,IdLinhVucXuatBan,IdXepLoaiTapChi,SoBaiBao1Nam")] TbTapChiKhoaHoc tbTapChiKhoaHoc)
        {
            try {
                if (id != tbTapChiKhoaHoc.IdTapChiKhoaHoc)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbTapChiKhoaHoc);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbTapChiKhoaHocExists(tbTapChiKhoaHoc.IdTapChiKhoaHoc))
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
                ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbTapChiKhoaHoc.IdLinhVucXuatBan);
                ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "IdTapChiTrongNuoc", tbTapChiKhoaHoc.IdXepLoaiTapChi);
                return View(tbTapChiKhoaHoc);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // GET: TapChiKhoaHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try {
                if (id == null)
                {
                    return NotFound();
                }

                var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs
                    .Include(t => t.IdLinhVucXuatBanNavigation)
                    .Include(t => t.IdXepLoaiTapChiNavigation)
                    .FirstOrDefaultAsync(m => m.IdTapChiKhoaHoc == id);
                if (tbTapChiKhoaHoc == null)
                {
                    return NotFound();
                }

                return View(tbTapChiKhoaHoc);
            }
            catch (Exception ex)
            {
                export_message(ex.Message + "\n" + (ex.InnerException == null ? "" : ex.InnerException.ToString()));
                return BadRequest();
            }
        }

        // POST: TapChiKhoaHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs.FindAsync(id);
                if (tbTapChiKhoaHoc != null)
                {
                    _context.TbTapChiKhoaHocs.Remove(tbTapChiKhoaHoc);
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

        private bool TbTapChiKhoaHocExists(int id)
        {
            return _context.TbTapChiKhoaHocs.Any(e => e.IdTapChiKhoaHoc == id);
        }
        //In lỗi ra file
        private void export_message(string Message)
        {
            //Thêm tên để setup cho dễ
            string ten_folder_view = "TapChiKhoaHoc";
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
