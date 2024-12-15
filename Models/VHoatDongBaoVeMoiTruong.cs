using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VHoatDongBaoVeMoiTruong
{
    public string? MaNhiemVu { get; set; }

    public string? TenNhiemVuBvmt { get; set; }

    public string? PhanCapNhiemVu { get; set; }

    public string? CoQuanChuQuan { get; set; }

    public string? CoQuanChuTri { get; set; }

    public string? LoaiNhiemVuBaoVeMoiTruong { get; set; }

    public int? TongKinhPhiCuaNhiemVu { get; set; }

    public string? NguonKinhPhi { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? DanhGiaKetQuaNhiemVu { get; set; }

    public string? SanPhamChinhCuaNhiemVu { get; set; }

    public string? DonViThucHienLuuTruSanPham { get; set; }

    public string? TinhTrangNhiemVu { get; set; }
}
