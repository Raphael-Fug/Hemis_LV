using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinHocBong
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public string? TenHocBong { get; set; }

    public string? DonViTaiTro { get; set; }

    public DateOnly? ThoiGianTraoTangHocBong { get; set; }

    public string? LoaiHocBong { get; set; }

    public int? GiaTriHocBong { get; set; }
}
