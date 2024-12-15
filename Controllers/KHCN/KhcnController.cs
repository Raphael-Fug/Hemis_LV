using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C500Hemis.Controllers.KHCN
{
    public class KhcnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly HemisContext _context;

        public KhcnController(HemisContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> vDeAnDuAnChuongTrinh()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vDoanCongTac()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vGVDuocCuDiDaoTao()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vHoiThaoHoiNghi()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vLuuHocSinhSinhVienNN()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vThanhPhanThamGiaDoanCongTac()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vThoaThuanHopTacQuocTe()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vThongTinHopTac()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

        public async Task<IActionResult> vToChucHopTacQuocTe()
        {
            var hemisContext = _context.TbBaiBaoKhdaCongBos.Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTapChiQuocTeNavigation).Include(t => t.IdTapChiTrongNuocNavigation).Include(t => t.IdXepHangQNavigation);
            return View(await hemisContext.ToListAsync());
        }

    }
}
