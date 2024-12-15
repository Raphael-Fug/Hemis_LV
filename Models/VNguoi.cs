using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VNguoi
{
    public int IdNguoi { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public int? IdQuocTich { get; set; }

    public string? TenNuoc { get; set; }

    public string? SoCccd { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public int? IdDanToc { get; set; }

    public string? DanToc { get; set; }

    public int? IdTonGiao { get; set; }

    public string? TonGiao { get; set; }

    public DateOnly? NgayVaoDang { get; set; }

    public DateOnly? NgayVaoDangChinhThuc { get; set; }

    public DateOnly? NgayNhapNgu { get; set; }

    public DateOnly? NgayXuatNgu { get; set; }

    public int? IdThuongBinhHang { get; set; }

    public string? HangThuongBinh { get; set; }

    public int? IdGiaDinhChinhSach { get; set; }

    public string? HoGiaDinhChinhSach { get; set; }

    public int? IdChucDanhKhoaHoc { get; set; }

    public string? ChucDanhKhoaHoc { get; set; }

    public int? IdTrinhDoDaoTao { get; set; }

    public string? TrinhDoDaoTao { get; set; }

    public int? IdChuyenMonDaoTao { get; set; }

    public string? NganhDaoTao { get; set; }

    public int? IdNgoaiNgu { get; set; }

    public string? NgoaiNgu { get; set; }

    public int? IdKhungNangLucNgoaiNguc { get; set; }

    public string? TenKhungNangLucNgoaiNgu { get; set; }

    public int? IdTrinhDoLyLuanChinhTri { get; set; }

    public string? TenTrinhDoLyLuanChinhTri { get; set; }

    public int? IdTrinhDoQuanLyNhaNuoc { get; set; }

    public string? TrinhDoQuanLyNhaNuoc { get; set; }

    public int? IdTrinhDoTinHoc { get; set; }

    public string? TrinhDoTinHoc { get; set; }

    public string? Expr1 { get; set; }
}
