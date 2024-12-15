using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VNhomNghienCuuManh
{
    public string? MaNhomNghienCuuManh { get; set; }

    public string? TenNhomNghienCuuManh { get; set; }

    public string? SoQuyetDinhThanhLap { get; set; }

    public string? ToChucBanHanhQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public string? CacNhiemVuNckh { get; set; }

    public string? TomTatKetQuaDatDuoc { get; set; }
}
