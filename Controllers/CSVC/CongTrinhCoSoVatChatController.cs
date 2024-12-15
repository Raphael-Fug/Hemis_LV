using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSVC
{
    public class CongTrinhCoSoVatChatController : Controller
    {
        private readonly HemisContext _context;

        public CongTrinhCoSoVatChatController(HemisContext context)
        {
            _context = context;
        }

        // GET: CongTrinhCoSoVatChat
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbCongTrinhCoSoVatChats.Include(t => t.CongTrinhCsvctrongNhaNavigation).Include(t => t.IdHinhThucSoHuuNavigation).Include(t => t.IdLoaiCongTrinhNavigation).Include(t => t.IdMucDichSuDungNavigation).Include(t => t.IdTinhTrangCsvcNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: CongTrinhCoSoVatChat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCongTrinhCoSoVatChat = await _context.TbCongTrinhCoSoVatChats
                .Include(t => t.CongTrinhCsvctrongNhaNavigation)
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdLoaiCongTrinhNavigation)
                .Include(t => t.IdMucDichSuDungNavigation)
                .Include(t => t.IdTinhTrangCsvcNavigation)
                .FirstOrDefaultAsync(m => m.IdCongTrinhCoSoVatChat == id);
            if (tbCongTrinhCoSoVatChat == null)
            {
                return NotFound();
            }

            return View(tbCongTrinhCoSoVatChat);
        }

        // GET: CongTrinhCoSoVatChat/Create
        public IActionResult Create()
        {
            ViewData["CongTrinhCsvctrongNha"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "TuyChon");
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu");
            ViewData["IdLoaiCongTrinh"] = new SelectList(_context.DmLoaiCongTrinhCoSoVatChats, "IdLoaiCongTrinhCoSoVatChat", "LoaiCongTrinhCoSoVatChat");
            ViewData["IdMucDichSuDung"] = new SelectList(_context.DmMucDichSuDungCsvcs, "IdMucDichSuDungCsvc", "MucDichSuDungCsvc");
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "TinhTrangCoSoVatChat");
            return View();
        }

        // POST: CongTrinhCoSoVatChat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCongTrinhCoSoVatChat,MaCongTrinh,TenCongTrinh,IdLoaiCongTrinh,IdMucDichSuDung,DoiTuongSuDung,DienTichSanXayDung,VonBanDau,VonDauTu,IdTinhTrangCsvc,IdHinhThucSoHuu,CongTrinhCsvctrongNha,SoPhongOcongVu,SoChoOchoCanBoGiangDay,NamDuaVaoSuDung")] TbCongTrinhCoSoVatChat tbCongTrinhCoSoVatChat)
        {
            //Kiểm tra ID trùng lập
            if (TbCongTrinhCoSoVatChatExists(tbCongTrinhCoSoVatChat.IdCongTrinhCoSoVatChat)) ModelState.AddModelError("IdCongTrinhCoSoVatChat", "Đã tồn tại ID này, vui lòng nhâp lại ID khác");
            if (ModelState.IsValid)
            {
                _context.Add(tbCongTrinhCoSoVatChat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CongTrinhCsvctrongNha"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCongTrinhCoSoVatChat.CongTrinhCsvctrongNha);
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbCongTrinhCoSoVatChat.IdHinhThucSoHuu);
            ViewData["IdLoaiCongTrinh"] = new SelectList(_context.DmLoaiCongTrinhCoSoVatChats, "IdLoaiCongTrinhCoSoVatChat", "IdLoaiCongTrinhCoSoVatChat", tbCongTrinhCoSoVatChat.IdLoaiCongTrinh);
            ViewData["IdMucDichSuDung"] = new SelectList(_context.DmMucDichSuDungCsvcs, "IdMucDichSuDungCsvc", "IdMucDichSuDungCsvc", tbCongTrinhCoSoVatChat.IdMucDichSuDung);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbCongTrinhCoSoVatChat.IdTinhTrangCsvc);
            return View(tbCongTrinhCoSoVatChat);
        }

        // GET: CongTrinhCoSoVatChat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCongTrinhCoSoVatChat = await _context.TbCongTrinhCoSoVatChats.FindAsync(id);
            if (tbCongTrinhCoSoVatChat == null)
            {
                return NotFound();
            }
            ViewData["CongTrinhCsvctrongNha"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "TuyChon", tbCongTrinhCoSoVatChat.CongTrinhCsvctrongNha);
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "HinhThucSoHuu", tbCongTrinhCoSoVatChat.IdHinhThucSoHuu);
            ViewData["IdLoaiCongTrinh"] = new SelectList(_context.DmLoaiCongTrinhCoSoVatChats, "IdLoaiCongTrinhCoSoVatChat", "LoaiCongTrinhCoSoVatChat", tbCongTrinhCoSoVatChat.IdLoaiCongTrinh);
            ViewData["IdMucDichSuDung"] = new SelectList(_context.DmMucDichSuDungCsvcs, "IdMucDichSuDungCsvc", "MucDichSuDungCsvc", tbCongTrinhCoSoVatChat.IdMucDichSuDung);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "TinhTrangCoSoVatChat", tbCongTrinhCoSoVatChat.IdTinhTrangCsvc);
            return View(tbCongTrinhCoSoVatChat);
        }

        // POST: CongTrinhCoSoVatChat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCongTrinhCoSoVatChat,MaCongTrinh,TenCongTrinh,IdLoaiCongTrinh,IdMucDichSuDung,DoiTuongSuDung,DienTichSanXayDung,VonBanDau,VonDauTu,IdTinhTrangCsvc,IdHinhThucSoHuu,CongTrinhCsvctrongNha,SoPhongOcongVu,SoChoOchoCanBoGiangDay,NamDuaVaoSuDung")] TbCongTrinhCoSoVatChat tbCongTrinhCoSoVatChat)
        {
            if (id != tbCongTrinhCoSoVatChat.IdCongTrinhCoSoVatChat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCongTrinhCoSoVatChat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCongTrinhCoSoVatChatExists(tbCongTrinhCoSoVatChat.IdCongTrinhCoSoVatChat))
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
            ViewData["CongTrinhCsvctrongNha"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "IdTuyChon", tbCongTrinhCoSoVatChat.CongTrinhCsvctrongNha);
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbCongTrinhCoSoVatChat.IdHinhThucSoHuu);
            ViewData["IdLoaiCongTrinh"] = new SelectList(_context.DmLoaiCongTrinhCoSoVatChats, "IdLoaiCongTrinhCoSoVatChat", "IdLoaiCongTrinhCoSoVatChat", tbCongTrinhCoSoVatChat.IdLoaiCongTrinh);
            ViewData["IdMucDichSuDung"] = new SelectList(_context.DmMucDichSuDungCsvcs, "IdMucDichSuDungCsvc", "IdMucDichSuDungCsvc", tbCongTrinhCoSoVatChat.IdMucDichSuDung);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbCongTrinhCoSoVatChat.IdTinhTrangCsvc);
            return View(tbCongTrinhCoSoVatChat);
        }

        // GET: CongTrinhCoSoVatChat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCongTrinhCoSoVatChat = await _context.TbCongTrinhCoSoVatChats
                .Include(t => t.CongTrinhCsvctrongNhaNavigation)
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdLoaiCongTrinhNavigation)
                .Include(t => t.IdMucDichSuDungNavigation)
                .Include(t => t.IdTinhTrangCsvcNavigation)
                .FirstOrDefaultAsync(m => m.IdCongTrinhCoSoVatChat == id);
            if (tbCongTrinhCoSoVatChat == null)
            {
                return NotFound();
            }

            return View(tbCongTrinhCoSoVatChat);
        }

        // POST: CongTrinhCoSoVatChat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCongTrinhCoSoVatChat = await _context.TbCongTrinhCoSoVatChats.FindAsync(id);
            if (tbCongTrinhCoSoVatChat != null)
            {
                _context.TbCongTrinhCoSoVatChats.Remove(tbCongTrinhCoSoVatChat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCongTrinhCoSoVatChatExists(int id)
        {
            return _context.TbCongTrinhCoSoVatChats.Any(e => e.IdCongTrinhCoSoVatChat == id);
        }
    }
}
