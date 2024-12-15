using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VCoSoGiaoDuc
{
    public string? MaDonVi { get; set; }

    public string? TenDonVi { get; set; }

    public string? TenTiengAnh { get; set; }

    public string? HinhThucThanhLap { get; set; }

    public string? LoaiHinhTruong { get; set; }

    public string? SoQuyetDinhChuyenDoiLoaiHinh { get; set; }

    public DateOnly? NgayKyQuyetDinhChuyenDoiLoaiHinh { get; set; }

    public string? TenDaiHocTrucThuoc { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? DiaChiWebsite { get; set; }

    public string? CoQuanChuQuan { get; set; }

    public string? SoQuyetDinhThanhLap { get; set; }

    public DateOnly? NgayKyQuyetDinhThanhLap { get; set; }

    public string? DiaChi { get; set; }

    public string? TenTinh { get; set; }

    public string? TenHuyen { get; set; }

    public string? TenXa { get; set; }

    public string? HoatDongKhongLoiNhuan { get; set; }

    public string? SoQuyetDinhCapPhepHoatDong { get; set; }

    public DateOnly? NgayDuocCapPhepHoatDong { get; set; }

    public string? LoaiHinhCoSoDaoTao { get; set; }

    public int? SoGiaoVienGdtc { get; set; }

    public string? PhanLoaiCoSo { get; set; }

    public string? TuChuGiaoDucQpan { get; set; }

    public string? SoQuyetDinhGiaoTuChu { get; set; }

    public int? DaoTaoSvgdqpan1nam { get; set; }

    public string? SoQuyetDinhBanHanhQuyCheTaiChinh { get; set; }

    public DateOnly? NgayKyQuyetDinhBanHanhQuyCheTaiChinh { get; set; }
}
