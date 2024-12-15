using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace C500Hemis.Controllers.TS
{
    public class TbDuLieuTrungTuyensController : Controller
    {
        private readonly HemisContext _context;

        public TbDuLieuTrungTuyensController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbDuLieuTrungTuyens
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbDuLieuTrungTuyens.Include(t => t.IdDoiTuongDauVaoNavigation).Include(t => t.IdDoiTuongUuTienNavigation).Include(t => t.IdHinhThucTuyenSinhNavigation).Include(t => t.IdKhuVucNavigation);
                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi tải danh sách dữ liệu trúng tuyển: " + ex.Message);
                return View();
            }
        }

        // GET: TbDuLieuTrungTuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens
                    .Include(t => t.IdDoiTuongDauVaoNavigation)
                    .Include(t => t.IdDoiTuongUuTienNavigation)
                    .Include(t => t.IdHinhThucTuyenSinhNavigation)
                    .Include(t => t.IdKhuVucNavigation)
                    .FirstOrDefaultAsync(m => m.IdDuLieuTrungTuyen == id);

                if (tbDuLieuTrungTuyen == null)
                {
                    return NotFound();
                }

                return View(tbDuLieuTrungTuyen);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi tải chi tiết dữ liệu trúng tuyển: " + ex.Message);
                return BadRequest();
            }
        }

        // GET: TbDuLieuTrungTuyens/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "DoiTuongDauVao");
                ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "DoiTuongUuTien");
                ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "HinhThucTuyenSinh");
                ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "KhuVuc");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi tải form tạo mới: " + ex.Message);
                return BadRequest();
            }
        }

        // POST: TbDuLieuTrungTuyens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDuLieuTrungTuyen,Cccd,HoVaTen,MaTuyenSinh,KhoaDaoTaoTrungTuyen,IdDoiTuongDauVao,IdDoiTuongUuTien,IdHinhThucTuyenSinh,IdKhuVuc,TruongThpt,ToHopMonTrungTuyen,DiemMon1,DiemMon2,DiemMon3,DiemUuTien,TongDiemXetTuyen,SoQuyetDinhTrungTuyen,NgayBanHanhQuyetDinhTrungTuyen,ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc,NganhDaTotNghiepTrinhDoDaiHoc,ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi,NganhDaTotNghiepTrinhDoThacSi")] TbDuLieuTrungTuyen tbDuLieuTrungTuyen)
        {
            try
            {
                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.Cccd))
                {
                    ModelState.AddModelError("Cccd", "Số CCCD/ Hộ chiếu là bắt buộc.");
                }
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.HoVaTen))
                {
                    ModelState.AddModelError("HoVaTen", "Họ và tên là bắt buộc.");
                }
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.MaTuyenSinh))
                {
                    ModelState.AddModelError("MaTuyenSinh", "Mã tuyển sinh là bắt buộc.");
                }
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.KhoaDaoTaoTrungTuyen))
                {
                    ModelState.AddModelError("KhoaDaoTaoTrungTuyen", "Mã chương trình đào tạo là bắt buộc.");
                }

                if (ModelState.IsValid)
                {
                    tbDuLieuTrungTuyen.TongDiemXetTuyen = tbDuLieuTrungTuyen.DiemMon1 + tbDuLieuTrungTuyen.DiemMon2 + tbDuLieuTrungTuyen.DiemMon3 + tbDuLieuTrungTuyen.DiemUuTien;
                    _context.Add(tbDuLieuTrungTuyen);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "DoiTuongDauVao", tbDuLieuTrungTuyen.IdDoiTuongDauVao);
                ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "DoiTuongUuTien", tbDuLieuTrungTuyen.IdDoiTuongUuTien);
                ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "HinhThucTuyenSinh", tbDuLieuTrungTuyen.IdHinhThucTuyenSinh);
                ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "KhuVuc", tbDuLieuTrungTuyen.IdKhuVuc);
                return View(tbDuLieuTrungTuyen);
            }
            catch (Exception ex)
            {
                var errorMessage = "Lỗi khi tạo dữ liệu trúng tuyển: ";
                if (ex.InnerException != null)
                {
                    string innerMessage = ex.InnerException.Message;

                    if (innerMessage.Contains("PRIMARY KEY constraint"))
                    {
                        errorMessage += "Vi phạm ràng buộc khóa chính. ID dữ liệu trúng tuyển đã tồn tại. Vui lòng nhập ID khác.";
                    }
                    else if (innerMessage.Contains("UNIQUE constraint failed"))
                    {
                        errorMessage += "Dữ liệu đã tồn tại. Vui lòng kiểm tra lại.";
                    }
                    else if (innerMessage.Contains("Cannot insert NULL"))
                    {
                        errorMessage += "Một trường dữ liệu bắt buộc đang bị để trống. Vui lòng kiểm tra lại.";
                    }
                    else if (innerMessage.Contains("FOREIGN KEY constraint failed"))
                    {
                        errorMessage += "Không thể tạo dữ liệu do lỗi ràng buộc khóa ngoại. Vui lòng kiểm tra lại các trường liên kết.";
                    }
                    else
                    {
                        errorMessage += innerMessage;
                    }
                }
                else
                {
                    errorMessage += ex.Message;
                }

                ModelState.AddModelError("", errorMessage);
                return View(tbDuLieuTrungTuyen);
            }
        }

        // GET: TbDuLieuTrungTuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens.FindAsync(id);
                if (tbDuLieuTrungTuyen == null)
                {
                    return NotFound();
                }
                ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "DoiTuongDauVao", tbDuLieuTrungTuyen.IdDoiTuongDauVao);
                ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "DoiTuongUuTien", tbDuLieuTrungTuyen.IdDoiTuongUuTien);
                ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "HinhThucTuyenSinh", tbDuLieuTrungTuyen.IdHinhThucTuyenSinh);
                ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "KhuVuc", tbDuLieuTrungTuyen.IdKhuVuc);
                return View(tbDuLieuTrungTuyen);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi tải form chỉnh sửa: " + ex.Message);
                return BadRequest();
            }
        }

        // POST: TbDuLieuTrungTuyens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDuLieuTrungTuyen,Cccd,HoVaTen,MaTuyenSinh,KhoaDaoTaoTrungTuyen,IdDoiTuongDauVao,IdDoiTuongUuTien,IdHinhThucTuyenSinh,IdKhuVuc,TruongThpt,ToHopMonTrungTuyen,DiemMon1,DiemMon2,DiemMon3,DiemUuTien,TongDiemXetTuyen,SoQuyetDinhTrungTuyen,NgayBanHanhQuyetDinhTrungTuyen,ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc,NganhDaTotNghiepTrinhDoDaiHoc,ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi,NganhDaTotNghiepTrinhDoThacSi")] TbDuLieuTrungTuyen tbDuLieuTrungTuyen)
        {
            try
            {
                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.Cccd))
                {
                    ModelState.AddModelError("Cccd", "Số CCCD/ Hộ chiếu là bắt buộc.");
                }
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.HoVaTen))
                {
                    ModelState.AddModelError("HoVaTen", "Họ và tên là bắt buộc.");
                }
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.MaTuyenSinh))
                {
                    ModelState.AddModelError("MaTuyenSinh", "Mã tuyển sinh là bắt buộc.");
                }
                if (string.IsNullOrWhiteSpace(tbDuLieuTrungTuyen.KhoaDaoTaoTrungTuyen))
                {
                    ModelState.AddModelError("KhoaDaoTaoTrungTuyen", "Mã chương trình đào tạo là bắt buộc.");
                }

                if (id != tbDuLieuTrungTuyen.IdDuLieuTrungTuyen)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    tbDuLieuTrungTuyen.TongDiemXetTuyen = tbDuLieuTrungTuyen.DiemMon1 + tbDuLieuTrungTuyen.DiemMon2 + tbDuLieuTrungTuyen.DiemMon3 + tbDuLieuTrungTuyen.DiemUuTien;
                    _context.Update(tbDuLieuTrungTuyen);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "DoiTuongDauVao", tbDuLieuTrungTuyen.IdDoiTuongDauVao);
                ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "DoiTuongUuTien", tbDuLieuTrungTuyen.IdDoiTuongUuTien);
                ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "HinhThucTuyenSinh", tbDuLieuTrungTuyen.IdHinhThucTuyenSinh);
                ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "KhuVuc", tbDuLieuTrungTuyen.IdKhuVuc);
                return View(tbDuLieuTrungTuyen);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi chỉnh sửa dữ liệu trúng tuyển: " + ex.Message);
                return View(tbDuLieuTrungTuyen);
            }
        }
    
        // GET: TbDuLieuTrungTuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens
                    .Include(t => t.IdDoiTuongDauVaoNavigation)
                    .Include(t => t.IdDoiTuongUuTienNavigation)
                    .Include(t => t.IdHinhThucTuyenSinhNavigation)
                    .Include(t => t.IdKhuVucNavigation)
                    .FirstOrDefaultAsync(m => m.IdDuLieuTrungTuyen == id);
                if (tbDuLieuTrungTuyen == null)
                {
                    return NotFound();
                }

                return View(tbDuLieuTrungTuyen);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi tải thông tin xóa dữ liệu trúng tuyển: " + ex.Message);
                return BadRequest();
            }
        }

        // POST: TbDuLieuTrungTuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens.FindAsync(id);
                if (tbDuLieuTrungTuyen == null)
                {
                    return NotFound();
                }

                _context.TbDuLieuTrungTuyens.Remove(tbDuLieuTrungTuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi xóa dữ liệu trúng tuyển: " + ex.Message);
                return BadRequest();
            }
        }

        private bool TbDuLieuTrungTuyenExists(int id)
        {
            return _context.TbDuLieuTrungTuyens.Any(e => e.IdDuLieuTrungTuyen == id);
        }

    }
}
