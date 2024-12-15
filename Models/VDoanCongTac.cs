using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VDoanCongTac
{
    public string? MaDoanCongTac { get; set; }

    public string? PhanLoaiDoanRaDoanVao { get; set; }

    public string? TenDoanCongTac { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public string? TenNuoc { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianketThuc { get; set; }

    public string? MucDichCongTac { get; set; }

    public string? KetQuaCongTac { get; set; }
}
