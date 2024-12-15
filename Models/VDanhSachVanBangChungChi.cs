using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VDanhSachVanBangChungChi
{
    public string? SoCccd { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? TenVanBang { get; set; }

    public string? ChuongTrinhDaoTao { get; set; }

    public string? TenDonViBangCap { get; set; }

    public DateOnly? NgayCap { get; set; }

    public string? NamTotNghiep { get; set; }

    public string? LoaiTotNghiep { get; set; }

    public string? SoQuyetDinhCongNhanTotNghiep { get; set; }

    public DateOnly? NgayQuyetDinhCongNhanTotNghiep { get; set; }

    public string? SoHieuVanBang { get; set; }

    public string? SoVaoSoGocCapVanBang { get; set; }

    public string? SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan { get; set; }

    public DateOnly? NgayBaoVe { get; set; }
}
