using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinHocTapSinhVien
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public string? MaHocVien { get; set; }

    public string? DoiTuongDauVao { get; set; }

    public string? SoQuyetDinhTrungTuyen { get; set; }

    public DateOnly? NgayKyQuyetDinhTrungTuyen { get; set; }

    public string? SinhVienNam { get; set; }

    public string? KetQuaTuyenSinh { get; set; }

    public string? ChuongTrinhDaoTao { get; set; }

    public string? LoaiHinhDaoTao { get; set; }

    public DateOnly? DaoTaoTuNam { get; set; }

    public DateOnly? DaoTaoDenNam { get; set; }

    public string? Khoa { get; set; }

    public string? Lop { get; set; }

    public string? BangTotNghiepLienThong { get; set; }

    public string? DangOnoiTru { get; set; }

    public DateOnly? NgayNhapHoc { get; set; }

    public string? TrangThaiHoc { get; set; }

    public DateOnly? NgayChuyenTrangThai { get; set; }

    public string? SoQuyetDinhThoiHoc { get; set; }

    public DateOnly? ThoiGianTotNghiep { get; set; }

    public string? LoaiTotNghiep { get; set; }

    public string? SoQuyetDinhTotNghiep { get; set; }

    public DateOnly? NgayQuyetDinhCongNhanTotNghiep { get; set; }
}
