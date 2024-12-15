using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C500Hemis.Controllers.CSGD
{
    public class CSGDController : Controller
    {
        private readonly HemisContext _context;

        public CSGDController(HemisContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> vCoCauToChuc()
        {
            var hemisContext = _context.VKhoaHocs;
            return View(await hemisContext.ToListAsync());
        }


        public IActionResult vCoSoGiaoDuc()
        {
            return View();
        }

        public IActionResult vDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD()
        {
            return View();
        }


        public IActionResult vDauMoiLienHe()
        {
            return View();
        }


        public IActionResult vDonViLienKetDaoTaoGiaoDuc()
        {
            return View();
        }

        public IActionResult vKhoaHoc()
        {
            return View();
        }

        public IActionResult vLichSuDoiTenTruong()
        {
            return View();
        }

        public IActionResult vToChucKiemDinh()
        { 
            return View();
        }

        public IActionResult vVanBanTuChu()
        {
            return View();
        }
    }
}
