using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VHocVien
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? SoCccd { get; set; }

    public string? SoSoBaoHiem { get; set; }

    public string? TenNuoc { get; set; }

    public string? DanToc { get; set; }

    public string? TonGiao { get; set; }

    public string? LoaiKhuyetTat { get; set; }

    public string? TenTinh { get; set; }

    public string? TenHuyen { get; set; }

    public string? TenXa { get; set; }

    public string? NoiSinh { get; set; }

    public string? QueQuan { get; set; }

    public DateOnly? NgayVaoDoan { get; set; }

    public DateOnly? NgayVaoDang { get; set; }

    public DateOnly? NgayVaoDangChinhThuc { get; set; }
}
