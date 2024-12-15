using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VNguoiHocVayTinDung
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public int? SoTienDuocVay { get; set; }

    public string? TenToChucTinDung { get; set; }

    public DateOnly? NgayVay { get; set; }

    public string? DiaChi { get; set; }

    public int? ThoiHanVay { get; set; }

    public string? TinhTrangVay { get; set; }
}
