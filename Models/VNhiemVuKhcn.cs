using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VNhiemVuKhcn
{
    public string? MaNhiemVu { get; set; }

    public string? TenNhiemVu { get; set; }

    public string? PhanCapNhiemVu { get; set; }

    public string? CoQuanChuQuan { get; set; }

    public string? CoQuanChuTri { get; set; }

    public string? NguoiChuTri { get; set; }

    public string? LoaiNhiemVu { get; set; }

    public string? ThuocNhiemVu { get; set; }

    public string? LinhVucNghienCuu { get; set; }

    public string? TongKinhPhiCuaNhiemVu { get; set; }

    public string? NguonKinhPhi { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? DanhGiaKetQuaNhiemVu { get; set; }

    public string? SanPhamChinhCuaNhiemVu { get; set; }

    public string? TinhTrangNhiemVu { get; set; }
}
