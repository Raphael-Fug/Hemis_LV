using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinHocTapNghienCuuSinh
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public string? MaHocVien { get; set; }

    public string? DoiTuongDauVao { get; set; }

    public string? SinhVienNam { get; set; }

    public string? ChuongTrinhDaoTao { get; set; }

    public string? LoaiHinhDaoTao { get; set; }

    public DateOnly? DaoTaoTuNam { get; set; }

    public DateOnly? DaoTaoDenNam { get; set; }

    public DateOnly? NgayNhapHoc { get; set; }

    public string? TrangThaiHoc { get; set; }

    public DateOnly? NgayChuyenTrangThai { get; set; }

    public string? SoQuyetDinhThoiHoc { get; set; }

    public string? TenLuanVan { get; set; }

    public DateOnly? NgayBaoVeCapTruong { get; set; }

    public DateOnly? NgayBaoVeCapCoSo { get; set; }

    public string? QuyChuanNguoiHuongDan { get; set; }

    public string? MaCanBo { get; set; }

    public string? Expr1 { get; set; }

    public string? SoQuyetDinhCongNhan { get; set; }

    public DateOnly? NgayQuyetDinhCongNhan { get; set; }

    public string? LoaiTotNghiep { get; set; }

    public string? SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo { get; set; }

    public DateOnly? NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo { get; set; }

    public string? SoQuyetDinhThanhLapHoiDongBaoVeCapTruong { get; set; }

    public DateOnly? NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong { get; set; }
}
